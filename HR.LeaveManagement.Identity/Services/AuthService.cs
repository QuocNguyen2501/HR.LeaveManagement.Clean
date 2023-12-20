using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Models.Identity;
using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HR.LeaveManagement.Identity.Services
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly JwTSettings _jwtSettings;
		public AuthService(UserManager<ApplicationUser> userManager,
			IOptions<JwTSettings> jwtSettings,
			SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_jwtSettings = jwtSettings.Value;
		}

		public async Task<AuthResponse> Login(AuthRequest request)
		{
			// step 1: Find user by email by using UserManager
			var user = await _userManager.FindByEmailAsync(request.Email);
			if (user == null)
			{
				throw new NotFoundException($"User with {request.Email} not found", request.Email);
			}
			// step 2: Check user match with the password or not
			var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
			if (!result.Succeeded)
			{
				throw new BadRequestException($"Credentials for '{request.Email}' aren't valid.");
			}
			// step 3: Generate jwt token from the user
			JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
			return new AuthResponse
			{
				Email = request.Email,
				UserName = user.UserName,
				Id = user.Id,
				Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
			};
		}


		public Task<RegistrationResponse> Register(RegistrationRequest request)
		{
			throw new NotImplementedException();
		}

		private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
		{
			var userClaims = await _userManager.GetClaimsAsync(user);
			var roles = await _userManager.GetRolesAsync(user);

			var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim("uid", user.Id),
			}
			.Union(userClaims)
			.Union(roleClaims);

			var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
			var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

			var jwtSecurityToken = new JwtSecurityToken(
					issuer: _jwtSettings.Issuer,
					audience: _jwtSettings.Audience,
					claims: claims,
					expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
					signingCredentials: signingCredentials
				);
			return jwtSecurityToken;
		}
	}
}

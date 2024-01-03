FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source
COPY ["HR.LeaveManagement.BlazorUI.csproj", "."]
RUN dotnet restore "HR.LeaveManagement.BlazorUI.csproj"
COPY . .
WORKDIR "/source/."
RUN dotnet build "HR.LeaveManagement.BlazorUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HR.LeaveManagement.BlazorUI.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf
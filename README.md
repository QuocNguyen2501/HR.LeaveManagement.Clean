# HR.LeaveManagement.Clean
This is a project that I use to learn in this course: https://www.udemy.com/course/aspnet-core-solid-and-clean-architecture-net-5-and-up

# From section 1 to 4
From the section 1 to 4 from the course, I have learned:
- Setup Application Core **(important)**
    - Domain and Application Projects
- Added MediatR and Automapper (Actually, I have known how to use Automapper from when I worked with .Net Framework 4.5)
    - CQRS - Requests and Handlers
        - Use MediatR to support CQRS pattern **(important)**
        - For every action, need 2 files:
            - File 1:  implement IRequest (from MediatR) - It is called Request.
            - File 2: implement IRequestHandler (from MediatR) - It is called Handler. This place is used to handle business logic.
    - Object Mapping
- Finally, Fluent Validation (Optional - My Viewpoint) - it's used to validate input models which are used in handlers before converting them to data object and update to database.


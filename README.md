# HR.LeaveManagement.Clean
This is a project that I use to review my knowledge in this course: https://www.udemy.com/course/aspnet-core-solid-and-clean-architecture-net-5-and-up

# From section 1 to 4 (03 Dec, 2023)
From the section 1 to 4 from the course, I have learned:
- Setup Application Core **(important)**
    - **Domain and Application Projects**
- Added MediatR and Automapper (Actually, I have known how to use Automapper from when I worked with .Net Framework 4.5)
    - CQRS - Requests and Handlers
        - Use MediatR to support CQRS pattern **(important)**
        - For every action, need 2 files:
            - File 1:  implement IRequest (from MediatR) - It is called Request.
            - File 2: implement IRequestHandler (from MediatR) - It is called Handler. This place is used to handle business logic.
    - Object Mapping
- Finally, Fluent Validation (Optional - My Viewpoint), it's used to validate input models which are used in handlers before converting them to data object and update to database.

# Section 5 (04 Dec, 2023)
For this session, I had revised some basic knowledge like: 
- Setup **the Persistence Project** which is responsible for accessing to Database (from this project, can setup to use more than 2 databases [read database - nosql and write database - sql], this story will be implemented in the future)
    - Revised the ways to setup a SQL database using EF (Code First)
        - Data Annotations
        - Fluent API
- Generic Repository pattern
    - Learned how to extend specific repositories, it helps Generic Repository become flexible.
- Setup **the Infrastructure project** which is resposible for doing third-party libraries like Email, Logger and external API service.
    - For Logger, revised some basic knowledge about Log Levels:
        - **Information** : standard log level used when something has happened as expected.
        - **Debug** : a very informational log level that is more than we might need for everyday use in development.
        - **Warning** : indicates that something has happened that isn't an error but not normal.
        - **Error** : is an error, this type of log entry is usually created when an exception is encountered. 
    - Known what is Options pattern, and how to implement it in an ASP.NET project 

# Section 6 (05 Dec - 07 Dec, 2023)
- Completed all features (LeaveType, LeaveAllocation, LeaveRequest) in HR.LeaveManagement.Api (without testing by Swagger). My feeling about this architecture, there are so many steps to implement a feature, it may be a difficulty for new developers. However,when we separate our code to smallest parts, then it is very short and easy for understanding and testing.
- Revised how to make an Exception Global Handler by a middleware the powerful feature in .Net.


# Section 7 to 9 (07 Dec - 22 Dec, 2023)
- Finished some based unit-test and integration test as in this course.
- Finished adding Identity to project.
- Finished some basic UI in Blazor.

# Section 10 (Skipped)


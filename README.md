# Users-Identification
User identification with basic authentication and authorization with JWT

## Using
- .Net 5  
- Web API  
- Microsoft.AspNetCore.Authorization  
- Microsoft.AspNetCore.Authentication.JwtBearer  


### How to use

> - Run API as Kestrel  
> - dotnet run  
> - Application open port 5000  
> - Use Postman to see informations of API   

### Informations
> - **Simulation of Repository**  


### Methods
> - **login**  
> HttpPost: Send Json with username and password  
> Result: Json with user without password and with token

> - **anonymous**  
> HttpGet  
> Result Message Anonymous 

> - **authenticated**  
> HttpGet: Send Header Authorization with Bearer Token
> Result: Message with name username

> - **employee**  
> HttpGet: Send Header Authorization with Bearer Token 
> Result: Message with name employee

> - **manager**  
> HttpGet: Send Header Authorization with Bearer Token (Role only Manager)
> Result: Message with name manager



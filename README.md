# Simple REST API

## Endpoints
# Create user
POST
https://localhost:4000/api/users
JSON body:
```
{
    "email":"valid@email.format",
    "password": "atLeast8CharactersWithOneDigit",
    "displayname": "randomString"
}
```
# List users
GET
https://localhost:4000/api/users/
JSON body:
```
{
    "Email":"5@1", // Retrieve only users with matching (.Contains()) emails This may also be empty (not null).
    "PageSize":"10", // How many results will be returned
    "Page":"0" // Which page of the results
}
```

# Update user
PUT
https://localhost:4000/api/users/{id}
JSON body:
```
{
    "DisplayName":"nameUpdate",
    "Password":"passWordUpdate"
}
```

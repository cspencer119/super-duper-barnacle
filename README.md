# SPONGEBOB API README

SpongebobAPI is an api that allows you to create, look up, update, and delete
various characters, places, and items within the world of bikini bottom.

## Features
- Full crud of Characters, Items, and Places
- Able to assign items to inventories and attribute those inventories to a specific character
- Able to have a character have a collection of places that they would hang out in
- Contains seeded content of some known characters, items, and places in bikini bottom on the api
- Able to use swagger to access the API

## Seeding instructions
To obtain the seed content for the api:
1. Within visual studio open up tools
2. Go to NuGet Package Manager
```sh
Package Manager Console
```
3. Within the default project in the Package Manager Console at the top switch to:
```sh
Spongebob.Data
```
4. Type in: 
```sh
Update-Database
```

## How to use
1. First access the api either by Swagger or by Postman
```sh
https://localhost:Your#Here/swagger
```
2. Next make an account with an email and password (the password must have at least 6 characters, a capital letter, a number, and a special character)
```sh
https://localhost:Your#Here/api/Account/Register
```
3. Obtain a bearer token to have access to Posting, Deleting, and Updating various parts of the api
- Within the api you can look up and update the contents within seed list but not delete any of them
- With the account you made you can do a full crud of the api for contents you made but not other accounts created
- With other accounts content you can only look up and update the their contents they made but not delete any of them

## Account
- Post change password
```sh
https://localhost:Your#Here/Account/ChangePassword
```
- Post register
```sh
https://localhost:Your#Here/Account/Register
```

## Place
- Get All
```sh
https://localhost:Your#Here/api/Place
```
- Get by ID
```sh
https://localhost:Your#Here/api/Place/{id}
```
- Post
```sh
https://localhost:Your#Here/api/Place
```
- Put
```sh
https://localhost:Your#Here/api/Place
```
- Delete by ID
```sh
https://localhost:Your#Here/api/Place/{id}
```

## Character
- Get All
```sh
https://localhost:Your#Here/api/Character
```
- Get by ID
```sh
https://localhost:Your#Here/api/Character/{id}
```
- Post
```sh
https://localhost:Your#Here/api/Character
```
- Put
```sh
https://localhost:Your#Here/api/Character
```
- Delete by ID
```sh
https://localhost:Your#Here/api/Character/{id}
```

## Inventory
- Get All
```sh
https://localhost:Your#Here/api/Inventory
```
- Get by ID
```sh
https://localhost:Your#Here/api/Inventory/{id}
```
- Post
```sh
https://localhost:Your#Here/api/Inventory
```
- Put
```sh
https://localhost:Your#Here/api/Inventory
```
- Delete by ID
```sh
https://localhost:Your#Here/api/Inventory/{id}
```

## Item
- Get All
```sh
https://localhost:Your#Here/api/Item
```
- Get by ID
```sh
https://localhost:Your#Here/api/Item/{id}
```
- Post
```sh
https://localhost:Your#Here/api/Item
```
- Put
```sh
https://localhost:Your#Here/api/Item
```
- Delete by ID
```sh
https://localhost:Your#Here/api/Item/{id}
```

## Hangouts
- Get All
```sh
https://localhost:Your#Here/api/Hangouts
```
- Get by ID
```sh
https://localhost:Your#Here/api/Hangouts/{id}
```
- Post
```sh
https://localhost:Your#Here/api/Hangouts
```
- Put
```sh
https://localhost:Your#Here/api/Hangouts
```
- Delete by ID
```sh
https://localhost:Your#Here/api/Hangouts/{id}
```

## SpongebobAPI Authors
- Hayden Linville
- Cyrus Spencer
- Ethan Starling

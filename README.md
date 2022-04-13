# SPONGEBOB API README

SpongebobAPI is an api that allows you to create, look up, update, and delete
various characters, places, and items within the world of bikini bottom.

## Features
- Full crud of Characters, Items, and Places
- Able to assign items to inventories and attribute those inventories to a specific character
- Able to have a character have a collection of places that they would hang out in
- Contains some seeded content of some known characters, items, and places in bikini bottom on the api
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
1. First make an account with an email and password (the password must have at least 6 characters, a capital letter, a number, and a special character)
```sh
https://localhost:Your#Here/api/Account/Register
```
3. Obtain a bearer token to have access to Posting, Deleting, and updating various parts of the api
```sh
https://localhost:Your#Here/token
```
- Within the api you can look up and update the contents within seed list but not delete any of them
- With the account you made you can do a full crud of the api for contents you made but not other accounts created
- With other accounts content you can only look up and update the their contents they made but not delete any of them

## SpongebobAPI Authors
- Hayden Linville
- Cyrus Spencer
- Ethan Starling

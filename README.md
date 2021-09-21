# .NET-Core

## Description

The aim of this project is to develop a set of APIs that support the operations of Southern Hemisphere Institute of Technology.
An SQLite database is used to host the information about the staff and the products sold at the institute's shop.

## Endpoints

1. GET THE LOGO OF THE INSTITUTE (https:localhost:8080/api/GetLogo). This returns the logo of the institute as an image file.
2. GET THE VERSION OF THE WEB API (https:localhost:8080/api/GetVersion). This returns a string “V1” which represents the version of the APIs.
3. GET THE INFORMATION OF ALL STAFF (https:localhost:8080/api/GetAllStaff). This returns the information of all the staff.
4. GET THE PHOTO OF A STAFF (https:localhost:8080/api/GetStaffPhoto/{id}). This returns the photo of the staff with a given ID.
5. GET THE VCARD OF A STAFF (https:localhost:8080/api/GetCard/{id}). This returns the vCard of the staff with a given ID.
6. LIST ITEMS/ITEM SOLD IN THE INSTITUE’S SHOP (https:localhost:8080/api/GetItems/{name}). This returns the information of the products/product sold in the institute’s shop. It also allows for partial searching.
7. GET THE PHOTO OF AN ITEM (https:localhost:8080/api/GetItemPhoto/{name}). This returns the photo of an item with a given ID.
8. WRITE COMMENT (https:localhost:8080/api/WriteComment). This allows the user to write comments, with the data being stored in the database.
9. GET COMMENTS (https:localhost:8080/api/GetComments). This allows the user to retrieve the last 5 comments made by users.

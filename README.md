# The Book Haven - A Bookstore Chain Inventory App

For an assignment at IT-Högskolan, while learning to use Entity Framework Core.

I've created a database for the mock-up bookstore chain "The Book Haven" with some data for demonstration. For this I've developed an application using WPF where the user can choose from the existing bookstores and see the inventory for each store and book in the store. 
The user can select a book and add, as well as remove, (or buy, and sell) from the choosen bookstore.  

## Guide to test the solution:
1. Clone the github-repository in to VS or your preferred IDE
2. Make sure to have installed these EF Core packages for the solution:
   - Microsoft.EntityFrameworkCore.SqlServer
   - Microsoft.EntityFrameworkCore.Tools
3. Get the file “TheBookHaven.bak” and restore it into SSMS. 

The connection string has localhost pointed to as a server, so now you should be able to run the solution. 

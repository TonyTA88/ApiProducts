# ApiProducts

* Visual Studio 2019 or Visual Code
* .NET Core SDK 2.2 
* DataBase used SqlServerExpress

* For Authentication used jwt token.

-Postman files included in the postman folder:

  Use the create or login endpoint to generate a token then you can add, remove, delete, buy, search, get products order by likes or name.
  
  The public endpoint where everyone can get the list of products and use the search feature is the ProductsPagination the Pagination tab in postman.

-You can find database script in the Databasedump folder.

-To change the connection string go to the appsettings.json and modify the DefaultConnection property

 ## Requirements/Postman
The API should allow:
* Adding/Removing products and set their stock quantity.           //Add a new product, Remove product, Delete product in postman
* Modify the price of the products.                                //Update product in postman
* Save a log of the price updates for a product.                   //Table in database ProductLog
* Buy a product                                                    //Saels in postman
* Buying a product should reduce its stock.
* Keep a log of all the purchases (who bought it, how many, when). //Table in database ProductLog
* Liking a product                                                 //Liking a product in postman
* Obtain a list of all the available products.                     //Pagination in postman
* The list should be sortable by name (default), and by popularity (likes) //Pagination in postman
* The list should have pagination functionality                    //Pagination in postman
* Search through the products by name.                             //Pagination in postman

## Security requirements/Postman
* Add login functionality //Create and Login in postman

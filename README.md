# PCI-ApplicationPizzaCabinInc.
Tec stack: Asp.net core, LiteDB.
Lite DB : https://www.litedb.org/docs/getting-started/ , https://www.litedb.org/docs/dbref/
Run LiteDB.Studio.exe , to see the Tables in your database (select MyData.db )
 

Implementation and Logic :
1.	To get the data from the REST service (json output) that the WFM service exposes and store it into a database. 
2.	Transforms it into a query able database for other systems to access
Create an API with following controller.
 WebApiClient :
 [HttpGet]
 GetPizzacabinicIncResult() : calls GetPizzacabinicIncJsonResult(from PizzaCabinInc.BusinessLogic) to get schedule data from external Rest service PizzacabinicInc
[HttpPost]
PostPizzacabinicIncJsonDataInDB : Inserts the schedule data into LiteDB “MyData.db”

3.	The Test project needs more time to implement.

4.	I have added Swagger to give the API:
Access url : https://localhost:44301/swagger/index.html
 


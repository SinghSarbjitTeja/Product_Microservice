# Product_Microservice

Technologies Used:

React/Javascript(es6+) - FrontEnd
C#/.NetCore Web APi/Restful/Microservice/DI/Repository/ Swagger - Backend
Sql- Database
EF Code First - ORM 

Instructions:

1. Download or clone from Github

2 Make Product Microservice persistence layer as startup project for generating database purpose only (Right click> set as startup)

3. Change connection string in appsettiing.json of Client App (CodeChallengeApp)- to local to generate database

	"ConnectionStrings": {
    "ProductDB": "Server=[YourLocal];Database=ChemistDatabase;Trusted_Connection=True;"
  }

4. Open View>OtherWindows>ConsolePackage manager and Enter
	add-migration "createDB"
	update-database

5. Open in VS and run Product Microservice persistence layer(Right click project Debug>start new instance) 

6. Type "http://localhost:52077/swagger/index.html" in browser to see all the documentation --- and testing purposes (swagger documentation will only work if persistence layer is running)

8. Run Client app (CodeChallengeApp) through IIS Express or Right click project Debug>start new instance 

(if incase this project does not run please open cmd - cd clientApp folder of project and enter - npm install (you must have npm installed in your server in order to do so)

9. Client App will make requests to API

(Optional)-Docker :

(I have only created image of client app and pushed it on Docker hub - This is not whole projet just client side)

1.Link to docker image 
"https://cloud.docker.com/repository/docker/sarbjitteja/codechallenge.web"
2.Run compose file attached to email in docker using 
docker compose run


Postman EndPoint:
[Your Local]/api/product -GET
[Your Local]/api/product/{id} -Get 
[Your Local]/api/product/  - Post [Body-{"Name":"Sa","Url":"www@nam.com","Code":2}]
[Your Local]/api/product/  -Put({"Id":1,"Name":"Sa","Url":"www@nam.com","Code":2}])
[Your Local]/api/product/{id}  -Delete



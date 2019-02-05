# FlowMonitoringInspections
An MVC project to track inspections at different sites throught the system

DESIGN
*when a manhole and a telog is set together, that makes a SITE
*a SITE can have a list of equipment, consisting of flow meters, and sensors.

TODO
* Add Connection String to WebConfig File (done)
* Change the data model from site to other models of the data. (done)
* fix siteview model for manhole edits. (done)
* Add Views for Showing Site Attributes. (done)
* Add Create View Page for each entity
* Add Edit Page for each entity
... * Edit Page for Site entity (done)
* Run the Project and Test Functionality
* Introduct EF Migrations
* need to make error view (done)

QUESTIONS:
* How can you show multiple models into one view?
```You can create a viewModel that collects is two view. You'll need to declare strongly typed views.```
* What is a strongly typed view?
* What does the connection string look like? What are it's attributes?
* Why should you check if the model state is valid?
...* Its for making sure, before you add it to the db, the you have added the correct value for that feild and if it passed all of the validation that you defined.
...* further reading: https://www.exceptionnotfound.net/asp-net-mvc-demystified-modelstate/

THINGS I LEARNED (AGAIN):
* DbSet == table in db
* when clicking the "submit" button on a form MVC will call an HTTP post method back same url. For example, when you click edit you go to SiteModel/Edit/id ... with an HTTP GET. Then you you click submit you go back to the same url but with an HTTP Post


#ADDING initializer using entity framework.
*https://docs.microsoft.com/en-us/ef/ef6/fundamentals/configuring/config-file
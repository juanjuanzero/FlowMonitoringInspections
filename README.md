# Flow Monitoring Inspections
An MVC project to track inspections at different sites throught the system

# DESIGN
* when a manhole and a telog is set together, that makes a SITE
* a SITE can have a list of equipment, consisting of flow meters, and sensors.
* Edits to site equipment should alreayd 

# TO DO
* ~~Add Connection String to WebConfig File (done)~~
* ~~Change the data model from site to other models of the data. (done)~~
* ~~fix siteview model for manhole edits. (done)~~
* ~~Add Views for Showing Site Attributes. (done)~~
* ~~Add Create View Page for each entity (done)~~
* ~~Bug, when there are no equipment on the site, the view should not be called up. (done)~~
* ~~Add Edit Page for each entity (Flow Meter, Telog, Sensor, Manhole) (done)~~
* ~~When creating/add a new equipment for the site, route the view that is returned back to the site equipment view.~~
*~~Going from Manhole to the other equipment~~
* Create delete method for site
* ~~Edit Page for Site entity (done)~~
* Introduce EF Migrations
* need to make error view (done)

# QUESTIONS:
* How can you show multiple models into one view?
```You can create a viewModel that collects is two view. You'll need to declare strongly typed views.```
* What is a strongly typed view?
* What does the connection string look like? What are it's attributes?
* Why should you check if the model state is valid? ```because you don't want to save to the db if the data going into the model is invalid. Its for making sure, before you add it to the db, the you have added the correct value for that feild and if it passed all of the validation that you defined.```
* Further reading: https://www.exceptionnotfound.net/asp-net-mvc-demystified-modelstate/
* ELI5 over-posting: Its when you have an attribute in your model that you dont want to be set by a view, like ID or a secret attribute. Ways to handle this include using the BindAttribute with Include, Using a ViewModel or specifying the attribute assignments in the db.

# THINGS I LEARNED (AGAIN):
* DbSet == table in db
* when clicking the "submit" button on a form MVC will call an HTTP post method back same url. For example, when you click edit you go to SiteModel/Edit/id ... with an HTTP GET. Then you you click submit you go back to the same url but with an HTTP Post


# ADDING initializer using entity framework.
* https://docs.microsoft.com/en-us/ef/ef6/fundamentals/configuring/config-file
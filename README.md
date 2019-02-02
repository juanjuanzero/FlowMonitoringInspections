# FlowMonitoringInspections
An MVC project to track inspections at different sites throught the system

DESIGN
*when a manhole and a telog is set together, that makes a SITE
*a SITE can have a list of equipment, consisting of flow meters, and sensors.

TODO
*Add Connection String to WebConfig File (done)
*Change the data model from site to other models of the data. (done)
*fix siteview model for manhole edits. (done)
*Add Views for Showing Site Attributes. (done)
*Run the Project and Test Functionality
*Introduct EF Migrations

QUESTIONS:
*How can you show multiple models into one view?
```You can create a viewModel that collects is two view. You'll need to declare strongly typed views.```
*What is a strongly typed view?
*What does the connection string look like? What are it's attributes?

THINGS I LEARNED (AGAIN):
*DbSet == table in db

#ADDING initializer using entity framework.
*https://docs.microsoft.com/en-us/ef/ef6/fundamentals/configuring/config-file
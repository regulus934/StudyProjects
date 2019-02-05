# StudyProjects
----------------------About me------------------------------<br>
Hello my namies Valeriy, this is my project for Rubl Bum<br>
----------------------About the project---------------------<br>
The project consists of a table of requests for tools and a monthly report. You can create a monthly report using a special form.<br>
First, create a query for the required tools, and then create a report.<br>
----------------------Migrations----------------------------<br>
Install-Package EntityFramework -IncludePrerelease<br>
Enable-Migrations -ContextTypeName InventoryContext -MigrationsDirectory Migrations\RublBum<br>
add-migration -ConfigurationTypeName WebApplication1.Migrations.RublBum.Configuration "InitialCreate"<br>
update-database -ConfigurationTypeName WebApplication1.Migrations.RublBum.Configuration <br>



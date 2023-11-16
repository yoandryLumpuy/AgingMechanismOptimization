
//For inserting a new migration type in Manager Console:

Add-Migration -Name MigrationName -Project Infrastructure -StartupProject Infrastructure.Startup.Project


//For Update database type in Manager Console the following:

Update-Database -Project Infrastructure -StartupProject Infrastructure.Startup.Project


//For Removing a Migration type in Manager Console the following:

Remove-Migration -Project Infrastructure -StartupProject Infrastructure.Startup.Project
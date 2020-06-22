NBA Data Extraction Application:

This is a console based application that extracts NBA data from websites and creates a repository 
of the NBA Stats, player roster, team standings and the state of the latest depth chart.

The aim of the project is to create an archive of historical data as the season progresses. 
The application can be run at the end of the day and the data will be stored in the tables 
based on the date the game is played.

The objective is to provide a dynamic data repository for analysis and forecasting of game 
results and players performance.

The application can be expanded to include an interface to display the data in charts and graphs.

The project is built in tiers that include a Data Access layer, Business Layer, Model, Utility, 
and a Web Scraper. The web scraper is built using the HtmlAgilityPack. 

Please make sure to create the database using the script defined in the 'Sql Scripts folder'
and change the Connection String in the App.Config file before running the app.

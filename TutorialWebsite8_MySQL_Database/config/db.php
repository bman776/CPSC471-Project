<?php
	
	//Establish Connection
	$serverName = "localhost:3308";	//<--communication endpoint for database on local server is @ port 3308 so we include this in the servername
	$userName = "root"; //<--mySQL has a defualt user called 'root'
	$password = ""; //<--'root' user does not require password to access databases on local server so we leave this as an empty string
	$databaseName = "phpblog"; //<--Recall this is the name of the database that we created on local server (listens for requests @ port 3308)
	
	//Check the config.php file in config folder: the constants defined there are the same values as the variables above, the variables here are just for tutorial purposes
	//require('config.php'); <--apparently I dont need this line for... some reason I guess becuase it is in the same working directory as config.php?
	
	$conn = mysqli_connect(DB_HOST,DB_USER,DB_PASS,DB_NAME);

	//Check connection
	if (mysqli_connect_errno()) {
		echo "Connection Failed".mysqli_connect_errno()."<br/>\n";
	}
?>
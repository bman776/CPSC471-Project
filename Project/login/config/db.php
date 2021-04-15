<?php
	//Establish connection
	$host = "localhost:3308";
	$user = "root";
	$pwd = "";
	$db = "cpsc471_project_db";
	
	//Connect to DataBase
	$conn = mysqli_connect($host, $user, $pwd, $db);
	
	//Check connection
	if (mysqli_connect_errno()) {
		echo "Connection Failed".mysqli_connect_errno()."<br/>\n";
	}

?>
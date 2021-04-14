<?php
	//Establish connection
	$host = "localhost:3308";
	$user = "root";
	$pwd = "";
	$db = "cpsc_471_project_db";
	
	$conn = mysqli_connect($host, $user, $pwd, $db);
	
	//Check connection
	if (mysqli_connect_errno()) {
		echo "Connection Failed".mysqli_connect_errno()."<br/>\n";
	}

?>
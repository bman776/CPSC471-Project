<?php
	require('config/config.php');
	require('config/db.php');
	
	//Check for delete
	if (isset($_POST['delete'])) {
		//Get form data
		$delete_id = mysqli_real_escape_string($conn, $_POST['delete_id']);
	
		$query = "DELETE FROM posts WHERE ID = ".$delete_id.";";
		
		if (mysqli_query($conn, $query)) {
			header('Location: '.ROOT_URL.'');
		} else {
			echo 'Error: '.mysqli_error($conn);
		}
	}
	
	//get ID from URL
	$id = mysqli_real_escape_string($conn,$_GET['id']);
	
	//Create Query 
	$query = 'SELECT * FROM posts WHERE ID = '.$id;
	
	//Get Results of Query from database via connection
	$result = mysqli_query($conn,$query);
	
	//Fetch Data from Results 
	$post = mysqli_fetch_assoc($result);	//<--This is what we'll be working with
	
	//Free Result
	mysqli_free_result($result);
	
	//Close Connection
	mysqli_close($conn);
?>

<?php include('inc/header.php'); ?>
		<div clas="container">
			<a href="<?php echo ROOT_URL; ?>" class="btn btn-default">Back</a>
			<h1><?php echo $post['Title'] ?></h1>
				<small>Created on <?php echo $post['created_at']; ?> by 
				<?php echo $post['Author']; ?> </small>
				<p><?php echo $post['Body']; ?></p>
				<hr>
				
					<form class="pull-right" method="POST" action="<?php $_SERVER['PHP_SELF']; ?>">
						<input type="hidden" name="delete_id" value="<?php echo $post['ID']; ?>">
						<input type="submit" name="delete" value="Delete" class="btn btn-danger">
					</form>
					<a href="<?php echo ROOT_URL; ?>editpost.php?id=<?php echo $post['ID']; ?>"
						class="btn btn-default">Edit</a>
		</div>
<?php include('inc/footer.php'); ?>
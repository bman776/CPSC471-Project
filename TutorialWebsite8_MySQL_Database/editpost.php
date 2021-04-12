<?php
	require('config/config.php');
	require('config/db.php');
	
	//Check for submit
	if (isset($_POST['submit'])) {
		//Get form data
		$update_id = mysqli_real_escape_string($conn, $_POST['update_id']);
		$title = mysqli_real_escape_string($conn, $_POST['title']);
		$body = mysqli_real_escape_string($conn, $_POST['body']);
		$author = mysqli_real_escape_string($conn, $_POST['author']);
		
		$query = "UPDATE posts SET 
					Title = '$title',
					Author = '$author',
					Body = '$body' WHERE ID = {$update_id}";
					
		
		if (mysqli_query($conn, $query)) {
			header('Location: '.ROOT_URL.'');
		} else {
			echo 'Error: '.mysqli_error($conn);
		}
	}
	
	//get ID
	$id = mysqli_real_escape_string($conn,$_GET['id']);
	
	//Create Query 
	$query = 'SELECT * FROM posts WHERE ID = '.$id;
	
	//Get Results of Query from database via connection
	$result = mysqli_query($conn,$query);
	
	//Fetch Data from Results 
	$post = mysqli_fetch_assoc($result);

	//Free Result
	mysqli_free_result($result);
	
	//Close Connection
	mysqli_close($conn);
?>

<?php include('inc/header.php'); ?>
		<div clas="container">
			<h1>Add Posts</h1>
			<form method="POST" action="<?php $_SERVER['PHP_SELF']; ?>">
				<div class="form-group">
					<label>Title</label>
					<input type="text" name="title" class="form-control"
						value="<?php echo $post['Title']; ?>">
				</div>
				<div class="form-group">
					<label>Author</label>
					<input type="text" name="author" class="form-control"
						value="<?php echo $post['Author']; ?>">
				</div>
				<div class="form-group">
					<label>Body</label>
					<textarea name="body" class="form-control"><?php echo $post['Body']; ?></textarea>
				</div>
				<input type="hidden" name="update_id" value="<?php echo $post['ID']; ?>">
				<input type="submit" name="submit" value="Submit" class="btn btn-primary">
			</form>
		</div>
<?php include('inc/footer.php'); ?>
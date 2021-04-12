<?php
	require('config/config.php');
	require('config/db.php');
	
	//Create Query 
	$query = 'SELECT * FROM posts ORDER BY created_at DESC';
	
	//Get Results of Query from database via connection
	$result = mysqli_query($conn,$query);
	
	//Fetch Data from Results 
	$posts = mysqli_fetch_all($result,MYSQLI_ASSOC);
	//var_Dump($posts);
	
	//Free Result
	mysqli_free_result($result);
	
	//Close Connection
	mysqli_close($conn);
?>

<?php include('inc/header.php'); ?>
		<div clas="container">
			<h1>Posts</h1>
			<?php foreach($posts as $post) : ?>
				<div class="well">
					<h3><?php echo $post['Title'] ?></h3>
					<small>Created on <?php echo $post['created_at']; ?> by 
					<?php echo $post['Author']; ?> </small>
					<p><?php echo $post['Body']; ?></p>
					<a class="btn btn-default" href="<?php echo ROOT_URL; ?>post.php?id=<?php echo $post['ID']; ?>">Read More</a>
				</div>
			<?php endforeach; ?>
		</div>
<?php include('inc/footer.php'); ?>
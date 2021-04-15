<?php
	require('../config/config.php');
	require('../config/db.php');

	//get session
	session_start();

	$name = $_SESSION['name'];
?>

<?php include('inc/clientHeader.php'); ?>
	<div class="container">
		<h1>Welcome <?php echo $name; ?></h1>
	</div>
<?php include('../inc/footer.php'); ?>
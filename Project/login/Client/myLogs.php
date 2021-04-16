<?php
	require('../config/config.php');
	require('../config/db.php');

    $dir_name = dirname($_SERVER['PHP_SELF']); 
?>

<?php include('inc/clientHeader.php'); ?>
	<div class="container">
		<h1>My Logs</h1>
        <legend>Please select the type of log you wish to view.</legend>
        <ul class="list-group">
        <li class="list-group-item">
            <a href="<?php echo $dir_name . "/workoutLogs.php";?>" class="btn btn-primary">Workout Log</a>
        </li>
        <li class="list-group-item">
            <a href="<?php echo $dir_name . "/cardioLogs.php";?>" class="btn btn-primary">Cardio Log</a>
        </li>
        <li class="list-group-item">
            <a href="<?php echo $dir_name . "/foodLogs.php";?>" class="btn btn-primary">Food Log</a>
        </li>
        <li class="list-group-item">
            <a href="<?php echo $dir_name . "/sleepLogs.php";?>" class="btn btn-primary">Sleep Log</a>
        </li>
        </ul>
	</div>
<?php include('../inc/footer.php'); ?>
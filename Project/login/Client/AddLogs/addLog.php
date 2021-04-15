<?php
	require('../../config/config.php');
	require('../../config/db.php');
?>

<?php include('inc/clientHeader.php'); ?>
	<div class="container">
		<h1>Add New Log</h1>
        <legend>Please select the type of log you wish to add.</legend>
        <ul class="list-group">
        <li class="list-group-item">
            <a href="<?php echo $dir_name . "/" . "addExerciseSet.php";?>" class="btn btn-primary">Exercise Set</a>
        </li>
        <li class="list-group-item">
            <a href="<?php echo $dir_name . "/" . "addCardio.php";?>" class="btn btn-primary">Cardio Log</a>
        </li>
        <li class="list-group-item">
            <a href="<?php echo $dir_name . "/" . "addFood.php";?>" class="btn btn-primary">Food Log</a>
        </li>
        <li class="list-group-item">
            <a href="<?php echo $dir_name . "/" . "addSleep.php";?>" class="btn btn-primary">Sleep Log</a>
        </li>
        </ul>
	</div>
<?php include('../../inc/footer.php'); ?>
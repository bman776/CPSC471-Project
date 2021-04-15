<?php
	require('../config/config.php');
	require('../config/db.php');

    //get session
	session_start();
	$name = $_SESSION['name'];
	$id = $_SESSION['id'];

    //get user workoutLog selection
    $log_name = $_GET['log_name'];
    $log_date = $_GET['log_date'];
    $log_time = $_GET['log_time'];

    //query DB (retrieve workout logs)
    $query = "SELECT * FROM exercise_set WHERE clientID = '$id' AND workoutLog_date = '$log_date' AND workoutLog_time = '$log_time'";
    $result = mysqli_query($conn, $query);

    //evaluate result
    if (!$result) {
        echo "Query Error: " . mysqli_error($conn);
    } else {
        $result_row_count = mysqli_num_rows($result);
        if ($result_row_count <= 0) {
            echo "You currently have no workoutlogs";
        } else {
            //fetch data
            $exercise_set = mysqli_fetch_all($result, MYSQLI_ASSOC);

            //free result
            mysqli_free_result($result);

            //close connection
            mysqli_close($conn);
        }
    }
?>

<?php include('../inc/clientHeader.php'); ?>
	<div class="container">
		<h1><?php echo $log_name?></h1>
        <?php foreach($exercise_set as $set) : ?>
            <div>
                <h3><?php echo $set['type']; ?></h3>
                <h4>set#: <?php echo $set['set_number']; ?></h4>
                <h4>reps: <?php echo $set['reps']; ?></h4>
                <h4>weight: <?php echo $set['weight']; ?></h4>
            </div>
        <?php endforeach; ?>
        
	</div>
<?php include('../../inc/footer.php'); ?>
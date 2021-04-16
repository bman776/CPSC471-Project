<?php
	require('../config/config.php');
	require('../config/db.php');
    $dir_name = dirname($_SERVER['PHP_SELF']); 

    //get session
	session_start();
	$name = $_SESSION['name'];
	$id = $_SESSION['id'];

    //query DB (retrieve workout logs)
    $query = "SELECT * FROM workout_log WHERE clientID = '$id'";
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
            $workout_log = mysqli_fetch_all($result, MYSQLI_ASSOC);

            //free result
            mysqli_free_result($result);

            //close connection
            mysqli_close($conn);
        }
    }
?>

<?php include('inc/clientHeader.php'); ?>
	<div class="container">
		<h1>My Workout Logs</h1>
        <?php foreach($workout_log as $log) : ?>
            <div>
                <h3><?php echo $log['log_name']; ?></h3>
                <h4>date: <?php echo $log['log_date']; ?></h4>
                <h4>start time: <?php echo $log['start_time']; ?></h4>
                <h4>end time: <?php echo $log['end_time']; ?></h4>
                <h4>calories burned: <?php echo $log['calories_burned']; ?></h4>

                <?php 
                    $log_date = $log['log_date'];
                    $log_time = $log['start_time'];
                    $log_name = $log['log_name'];
                ?>
                <a href="<?php echo $dir_name . "/workoutLogSets.php?log_name=$log_name&log_date=$log_date&log_time=$log_time";?>">view</a>
            
            </div>
        <?php endforeach; ?>
	</div>
<?php include('../inc/footer.php'); ?>
<?php
	require('../config/config.php');
	require('../config/db.php');
    $dir_name = dirname($_SERVER['PHP_SELF']); 

    //get session
	session_start();
	$name = $_SESSION['name'];
	$id = $_SESSION['id'];

    //query DB (retrieve workout logs)
    $query = "SELECT * FROM food_log WHERE clientID = '$id'";
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
            $food_log = mysqli_fetch_all($result, MYSQLI_ASSOC);

            //free result
            mysqli_free_result($result);

            //close connection
            mysqli_close($conn);
        }
    }
?>

<?php include('inc/clientHeader.php'); ?>
	<div class="container">
		<h1>My Food Logs</h1>
        <?php foreach($food_log as $log) : ?>
            <div>
                <h3><?php echo $log['meal_desc']; ?></h3>
                <h4>protein: <?php echo $log['protein']; ?></h4>
                <h4>carbohydrates: <?php echo $log['carbohydrates']; ?></h4>
                <h4>fat: <?php echo $log['fat']; ?></h4>
                <h4>calories: <?php echo $log['calories']; ?></h4>

                <small>consumed on: <?php echo $log['log_date']; ?> @ <?php echo $log['log_time']; ?> </small>
              
            </div>
        <?php endforeach; ?>
	</div>
<?php include('../inc/footer.php'); ?>
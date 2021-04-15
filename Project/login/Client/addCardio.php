<?php
	require('../config/config.php');
	require('../config/db.php');
?>

<?php $dir_name = dirname($_SERVER['PHP_SELF']); ?>
<?php include('inc/clientHeader.php'); ?>
	<div class="container">
		<h1>Add Cardio Log</h1>
        <legend>Please enter your log details.</legend>
        <form class="form-horizontal">
            <fieldset>
                <div class="form-group">
                    <label for="inputType" class="col-lg-2 control-label">Exercise Type</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="inputType">
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputCalories" class="col-lg-2 control-label">Calories Burned</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="inputCalories">
                    </div>
                </div>
                <div class="form-group">
                    <label for="startTime" class="col-lg-2 control-label">Start time</label>
                    <div class="col-lg-10">
                        <input type ="text" class="form-control" id="startTime" name="time" placeholder="<?php echo date("h:i:s A")?>"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="endTime" class="col-lg-2 control-label">End time</label>
                    <div class="col-lg-10">
                        <input type ="text" class="form-control" id="endTtime" name="time" placeholder="<?php echo date("h:i:s A")?>"/>
                    </div>
                </div>
            </fieldset>
        </form>
	</div>
<?php include('../../inc/footer.php'); ?>
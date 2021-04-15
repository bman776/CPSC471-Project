<?php
	require('../config/config.php');
	require('../config/db.php');
?>

<?php $dir_name = dirname($_SERVER['PHP_SELF']); ?>
<?php include('inc/clientHeader.php'); ?>
	<div class="container">
		<h1>Add Exercise Set</h1>
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
                    <label for="inputSetNumber" class="col-lg-2 control-label">Set Number</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="inputSetNumber">
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputReps" class="col-lg-2 control-label">Repetitions</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="inputReps">
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputWeight" class="col-lg-2 control-label">Weight (lbs)</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="inputWeight">
                    </div>
                </div>
            </fieldset>
        </form>
	</div>
<?php include('../../inc/footer.php'); ?>
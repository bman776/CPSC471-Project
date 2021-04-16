<?php
	require('../config/config.php');
	require('../config/db.php');
?>

<?php $dir_name = dirname($_SERVER['PHP_SELF']); ?>
<?php include('inc/instructorHeader.php'); ?>
	<div class="container">
		<h1>Add Fitness Program</h1>
        <legend>Please enter your program details.</legend>
        <form class="form-horizontal">
            <fieldset>
                <div class="form-group">
                    <label for="name" class="col-lg-2 control-label">Program Name</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="name">
                    </div>
                </div>
                <div class="form-group">
                    <label for="description" class="col-lg-2 control-label">Description</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="description">
                    </div>
                </div>
                <div class="form-group">
                    <label for="routine" class="col-lg-2 control-label">Routine</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="routine">
                    </div>
                </div>
                <div class="form-group">
                    <label for="trainingType" class="col-lg-2 control-label">Training Type</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="trainingType">
                    </div>
                </div>
                <div class="form-group">
                    <label for="exerciseModality" class="col-lg-2 control-label">Exercise Modality</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="exerciseModality">
                    </div>
                </div>
                <div class="form-group">
                    <label for="videoLink" class="col-lg-2 control-label">Video link</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="videoLink">
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <button type="submit" class="btn btn-primary">Submit</button>
                    </div>
                </div>
            </fieldset>
        </form>
	</div>
<?php include('../inc/footer.php'); ?>
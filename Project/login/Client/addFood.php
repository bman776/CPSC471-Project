<?php
	require('../config/config.php');
	require('../config/db.php');
?>

<?php $dir_name = dirname($_SERVER['PHP_SELF']); ?>
<?php include('inc/clientHeader.php'); ?>
	<div class="container">
		<h1>Add Food Log</h1>
        <legend>Please enter your log details.</legend>
        <form class="form-horizontal">
            <fieldset>                
                <div class="form-group">
                    <label for="mealDescription" class="col-lg-2 control-label">Meal Description</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="mealDescription">
                    </div>
                </div>
                <div class="form-group">
                    <label for="calories" class="col-lg-2 control-label">Calories</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="calories">
                    </div>
                </div>
                <div class="form-group">
                    <label for="protein" class="col-lg-2 control-label">Protein (g)</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="protein">
                    </div>
                </div>
                <div class="form-group">
                    <label for="carbs" class="col-lg-2 control-label">Carbs (g)</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="carbs">
                    </div>
                </div>
                <div class="form-group">
                    <label for="fat" class="col-lg-2 control-label">Fat (g)</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="fat">
                    </div>
                </div>
                <div class="form-group">
                    <label for="mealTime" class="col-lg-2 control-label">Meal time</label>
                    <div class="col-lg-10">
                        <input type ="text" class="form-control" id="mealTime" name="time" placeholder="<?php echo date("h:i:s A")?>"/>
                    </div>
                </div>
            </fieldset>
        </form>
	</div>
<?php include('../../inc/footer.php'); ?>
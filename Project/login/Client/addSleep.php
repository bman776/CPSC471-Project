<?php
	require('../config/config.php');
	require('../config/db.php');
?>

<?php $dir_name = dirname($_SERVER['PHP_SELF']); ?>
<?php include('inc/clientHeader.php'); ?>
	<div class="container">
		<h1>Add Sleep Log</h1>
        <legend>Please enter your log details.</legend>
        <form class="form-horizontal">
            <fieldset>                
                <div class="form-group">
                    <label for="bedTime" class="col-lg-2 control-label">Bed Time</label>
                    <div class="col-lg-10">
                        <input type ="text" class="form-control" id="bedTime" name="time" placeholder="<?php echo date("h:i:s A")?>"/>
                    </div>
                </div>
                <div class="form-group">
                    <label for="duration" class="col-lg-2 control-label">Sleep duration</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="duration">
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
<?php include('../../inc/footer.php'); ?>
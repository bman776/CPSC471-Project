<?php
	require('../config/config.php');
	require('../config/db.php');
?>

<?php $dir_name = dirname($_SERVER['PHP_SELF']); ?>
<?php include('inc/dieticianHeader.php'); ?>
	<div class="container">
		<h1>Add Page</h1>
        <legend>Please enter your page details.</legend>
        <form class="form-horizontal">
            <fieldset>
                <div class="form-group">
                    <label for="topic" class="col-lg-2 control-label">Topic</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="topic">
                    </div>
                </div>
                <div class="form-group">
                    <label for="content" class="col-lg-2 control-label">Content</label>
                    <div class="col-lg-10"><grammarly-extension data-grammarly-shadow-root="true" class="cGcvT" style="position: absolute; top: 0px; left: 0px; pointer-events: none;"></grammarly-extension>
                        <textarea class="form-control" rows="10" id="content" spellcheck="false"></textarea>
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
<?php
	require('config/config.php');
	require('config/db.php');
	
	if (isset($_POST['username'])) {
		echo $_POST['username'];
	}
	
	if (isset($_POST['password'])) {
		echo $_POST['password'];
	}
?>

<?php include('inc/loginHeader.php'); ?>
	<div class="container">
		<h1>Login</h1>
		<form class="form-horizontal" method="post" action="index.php">
			<fieldset>
			
				<div class="form-group">
					<label for="inputUsername" class="col-lg-2 control-label">Username</label>
					<div class="col-lg-10">
						<input type="text" class="form-control" id="inputUsername" name="username" placeholder="username">
					</div>
				</div>
				
				<div class="form-group">
					<label for="inputPassword" class="col-lg-2 control-label">Password</label>
					<div class="col-lg-10">
						<input type="password" class="form-control" id="inputPassword" name="password" placeholder="Password">
					</div>
				</div>
				
				<div class="form-group">
					<div class="col-lg-l0 col-lg-offset-2">
					<button type="reset" class="btn btn-default">Cancel</button>
					<button type="submit" class="btn btn-primary">Submit</button>
				</div>
			</fieldset>
		</form>
	</div>
<?php include('inc/footer.php'); ?>


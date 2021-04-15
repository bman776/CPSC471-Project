<?php
	require('config/config.php');
	require('config/db.php');

	if ( isset($_POST['username']) and isset($_POST['password']) ) {

		//http://localhost/Project/Login/Instructor/
		//$loc = INST_ROOT_URL;
		//header("Location:$loc");
		$usrnm = $_POST['username'];
		$psswd = $_POST['password'];

		$query = "SELECT u.username, u.password FROM user AS u WHERE u.username = '$usrnm' AND u.password = '$psswd'";
		$query2 = "SELECT * FROM user";

		$result = mysqli_query($conn, $query);
		
		if (!$result) {
			echo "Query Error: " . mysqli_error($conn);
		} else {
			$result_row_count = mysqli_num_rows($result);
			if ($result_row_count > 0) {
				echo "You are in the System!";
				$loc = CLIENT_ROOT_URL;
				header("Location:$loc");
			} else {
				echo "Invalid Username or Password";
			}
		}
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
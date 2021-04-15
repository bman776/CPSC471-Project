<?php
	require('config/config.php');
	require('config/db.php');

	if ( isset($_POST['submit']) ) {

		if ( isset($_POST['username']) and isset($_POST['password']) ) {

			//query user login credentials
			$usrnm = $_POST['username'];
			$psswd = $_POST['password'];
			$query = "SELECT u.userID, u.name FROM user AS u WHERE u.username = '$usrnm' AND u.password = '$psswd'";
			$result = mysqli_query($conn, $query);

			//evaluate result
			if (!$result) {
				echo "Query Error: " . mysqli_error($conn);
			} else {
				$result_row_count = mysqli_num_rows($result);
				if ($result_row_count > 0) {
					//user credentials valid, begin login

					$result_row = mysqli_fetch_row($result);
					$id = $result_row[0]; // the id attribute of the user
					$name = $result_row[1]; // the name attribute of user

					//Start Session
					session_start();
					$_SESSION['name'] = $name;

					//Redirect to client profile page (for now)
					$loc = CLIENT_ROOT_URL;
					header("Location:$loc");

				} else {
					echo "Invalid Username or Password";
				}
			}
		} else {
			echo "Please enter a username and password";
		}
	} 
?>

<?php include('inc/loginHeader.php'); ?>
	<div class="container">
		<h1>Login</h1>
		<form class="form-horizontal" method="post" action="<?php echo $_SERVER['PHP_SELF']; ?>">
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
					<button type="submit" name="submit" class="btn btn-primary">Submit</button>
				</div>
			</fieldset>
		</form>
	</div>
<?php include('inc/footer.php'); ?>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
<?php $dir_name = dirname($_SERVER['PHP_SELF']); ?>
 <nav class="navbar navbar-default">
     <div class="container">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" href="#">My Fitness</a>
        </div>
        <div id="navbar" class="collapse navbar-collapse">
			<ul class="nav navbar-nav">
				<li><a href="<?php echo ROOT_URL; ?>">Home</a></li>
				<li><a href="<?php echo ROOT_URL; ?>">Account</a></li>
				<li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Pages <span class="caret"></span></a>
                <ul class="dropdown-menu" role="menu">
                    <li><a href="<?php echo $dir_name;?>">View Pages</a></li>
                    <li><a href="<?php echo $dir_name . "/" . "addPage.php";?>">Add New Page</a></li>
                </ul>
        </li>
				<li><a href="<?php echo ROOT_URL; ?>">My Fitness Programs</a></li>
				<li><a href="<?php echo $dir_name . "/" . "addProgram.php";?>">Add New Program</a></li>
			</ul>
		</div><!--/.nav-collapse -->
     </div>
</nav>

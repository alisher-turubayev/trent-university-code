<html>

	<head>
		<!-- This is how you comment in HTML, typically you need some information here I will leave that to your COIS 3420 instructor to teach you -->
	</head>

	<body>
		<center>
			<H1> Welcome To This Fancy Form</H1> <br>

			<!-- This is where the form starts -->
			<!-- the action = index.php, this is only the case because the PHP script is in the same file as this one -->
			<form action="index.php" method="post">
				Firstname: <input type="text" name="firstname">	<br> <br>
				Lastname: <input type="text" name="lastname">	<br> <br>
				Age: <input type="number" name="age" min="13" max="100" id="age"> <br> <br>
				<input type="submit">
			</form>
		</center>
	</body>
</html>

<?php
//Step 0: Load HTML elements as PHP variables:
$firstName = @$_POST['firstname'];
$lastName = @$_POST['lastname'];
$age = @$_POST['age'];

//Step 1: Connect (refer to the slides and the lab handout):
$con = mysqli_connect("localhost", "root", "", "ThirdLab");

//Step 2: Check if we connected successfully (refer to the slides):
if (mysqli_connect_errno($con)) {
	echo "Failed to connect to the database: " . mysqli_connect_error() . "<br>";
}
else {
	echo "Connection successful<br>";
}

//Step 3: Execute a query while checking if it executed correctly (refer to the slides):
$query = "INSERT INTO formtable(firstname, lastname, age) VALUES ('$firstName', '$lastName', '$age')";

if (mysqli_query($con, $query)) {
	echo "Successfully added 1 entry to table formtable<br>";
}
else {
	echo "Error adding data<br>";
}

//Step 4: Close connection (refer to the slides):
mysqli_close($con);

?>

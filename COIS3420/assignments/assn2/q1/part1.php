<!--
COIS 3420 - Web Application Development

Assignment 2 - Question 1 Part A
Prepared by Alisher Turubayev, 0630908
-->

<?php
// Start with this code
$names="Harry Potter, ron Weasley, Hermione Granger, lavender brown, Pavarti patil, NEVILLE Longbottom, Seamus FiNNegan, Dean Thomas";
// Split the string into array based on comma delimiters
$arrayNames = explode(', ', $names);
// Append to the end of the newly created array
array_push($arrayNames, 'draco Malfoy');
// Sort the array using a case-insensitive sort
natcasesort($arrayNames);
// Use a loop to make only first letter of first and last name capital
// 	note: to change the items in the foreach loop without creating a wheel, used this trick (see point 2):
//	https://alexwebdevelop.com/foreach-loops/
foreach($arrayNames as $key => $fullname) {
	$arrayNames[$key] = ucwords(strtolower($fullname));
}
?>
<!DOCTYPE html>
<html lang="en">
	<head>
		<title>Assignment 2 - Question 1 by Alisher Turubayev</title>
		<!-- Viewport optimization -->
		<meta name="viewport" content="width=device-width, initial-scale=1.0">
		<link rel="stylesheet" href="part1.css">
	</head>
	
	<body>
		<div>
			<h1>Class roster for Hogwarts Alumni</h1>
			<h2>2020-2021 Academic Year</h2>
			<ul>
				<?php
				// Output all names into an unordered list and apply the coloring based on following rule:
				// 		if the name contains "h", the class is rav
				//		if the name does not, the class is griff
				// Please refer to styles.css for more information on exact colors. 
				foreach($arrayNames as $fullname) {
					if (stripos($fullname, "h") === false) {
						echo "<li class=\"rav\">$fullname</li>";
					}
					else {
						echo "<li class=\"griff\">$fullname</li>";
					}
				} 
				?>
			</ul>
		</div>	
	</body>
</html>
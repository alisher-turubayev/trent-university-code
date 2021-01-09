<!--
COIS 3420 - Web Application Development

Assignment 2 - Question 2
Prepared by Alisher Turubayev, 0630908
-->
<?php
// Include library for database connection
include "includes/library.php";

// Start session
session_start();
// Check if the fields are set: if not, redirect back to index.php    
if (!isset($_SESSION['username']) 
    || !isset($_SESSION['current_question']) 
    || !isset($_SESSION['score'])) {
        header("Location: index.php");
        exit();
}
   
// Store in local variables     
$username = $_SESSION['username'];
$score = $_SESSION['score'];

// Connect to database and push new data in
$pdo = connectDB();

$query = "INSERT INTO `a2_scores` VALUES (0, ?, ?)";
$stmt = $pdo->prepare($query);
$stmt->execute([$username, $score]);

// Remove the data from the session storage and end the session
unset($_SESSION['username']);
unset($_SESSION['current_question']);
unset($_SESSION['score']);
session_destroy();
?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <title>Leaderboard for Tech Quiz - Compete with others!</title>
        <!-- Viewport optimization -->
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" href="q2.css">
    </head>
    <body>
        <div>
            <h1>Current best players</h1>
            <ol>
                <?php
                // Connect to database and take all users
                $pdo = connectDB();
                $scores = $pdo->query("SELECT * FROM `a2_scores` ORDER BY score DESC");
                
                foreach ($scores as $row) {
                    echo "<li>" . $row['username'] . " with a score of " . $row['score'] . "</li>";
                }
                ?>
            </ol>
            <p>Here is the cheatcode: <a href="cheatsheet.php">psst</a></p>
        </div>
    </body>
</html>
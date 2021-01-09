<!--
COIS 3420 - Web Application Development

Assignment 2 - Question 2
Prepared by Alisher Turubayev, 0630908
-->
<?php
// Include library for database connectivity
include "includes/library.php";
// Set this so to avoid non-assigned variable error
$GLOBALS['form_output'] = null;
// Question number: a global variable (change to reflect how many questions are in a database)
$GLOBALS['total_questions'] = 5;

// Start session
session_start();

// Check if the session has data; if not, that means the user did not follow the correct path
if (!isset($_SESSION['username']) 
    || !isset($_SESSION['current_question']) 
    || !isset($_SESSION['score'])) {
        header("Location: index.php");
        exit();
}

// If the input came in - process it
if (isset($_POST) && count($_POST) > 0) {
    process_input();
}

// Otherwise, call function to fetch the question
$GLOBALS['form_output'] = fetch_question();

/*
function process_input() 

Purpose: processes input and saves the result in the session/database

Returns: nothing; if database has errors the entire page crashes with an error message
*/
function process_input () {
    if (!isset($_POST['answer'])) {
        echo "<p class=\"error\">Form was incorrectly submitted</p>";
        return;
    }
    
    // Get the id of a chosen answer
    $chosen_id = $_POST['answer'];
    
    // Try to retrieve its' entry from the database
    $pdo = connectDB();

    $query = "SELECT * FROM `a2_ans` WHERE id = ?";
    $stmt1 = $pdo->prepare($query);
    $stmt1->execute([$chosen_id]);
    
    $answer_entry = $stmt1->fetchAll();
    
    // If the answer entry array does not contain exactly 1 entry, something went terribly wrong
    if (count($answer_entry) !== 1) {
        die("Database error - contact the system administrator");
    }
    
    // Take the answer's information
    // Did not find a better way to make it look pretty :)
    foreach ($answer_entry as $row) {
        // Store the data in local variables
        $is_correct = intval($row['correct']);
        $choice_count = intval($row['choicecount']);
    }
    
    // Increase the choice count by 1
    $choice_count += 1;
    
    // If the answer is correct, increase the variable in the session storage
    if ($is_correct == 1) {
        $_SESSION['score'] += 1;
    }
    
    // Continue by updating the database
    $query = "UPDATE `a2_ans` SET choicecount = ? WHERE id = ?";
    $stmt2 = $pdo->prepare($query);
    $stmt2->execute([$choice_count, $chosen_id]);
    
    // Increase the current_question count in the session storage
    $_SESSION['current_question'] += 1;
    
    // If the current_question is bigger than the total number of questions in the quiz, go to results 
    // (see constant value at the top of this code)
    if ($_SESSION['current_question'] > $GLOBALS['total_questions']) {
        header("Location: results.php");
        exit();
    }
    else {
        // Clear the post array to avoid problems of constant submission
        $_POST = array();
        // 'Reload' the page
        header("Location: quiz.php");
        exit();
    }
}

/*
function fetch_question()

Purpose: fetches current question and returns an output array with HTML elements

Output: array with HTML elements; if database has errors the entire page crashes with an error message
*/
function fetch_question() {
    // Connect to the database
    $pdo = connectDB();

    // Get the question from the database 
    $query = "SELECT * FROM `a2_quest` WHERE id = ?";
    $stmt1 = $pdo->prepare($query);
    $stmt1->execute([$_SESSION['current_question']]);

    $quest = $stmt1->fetchAll();

    // If the query result does not have exactly 1 question, something went wrong
    if (count($quest) !== 1) {
        die("Database error - contact the system administrator");
    }
    
    // Take the question body and its' id from the query result
    // Did not find a better way to make it look pretty :)
    foreach ($quest as $row) {
        // Store the result in local variables
        $quest_id = intval($row['id']);
        $quest_body = $row['question'];
    }
    
    // Get the answers from the database
    $query = "SELECT * FROM `a2_ans` WHERE `fk_questid` = ?";
    $stmt2 = $pdo->prepare($query);
    $stmt2->execute([$quest_id]);
    
    $ans = $stmt2->fetchAll();
    
    // Create an output array which will contain HTML elements
    $output = array();
    
    // Add the question to the array
    array_push($output, "<p class=\"question\">" . $quest_body . "</p>");
    
    // Push the answers line by line
    foreach($ans as $line) {
        array_push($output, "<label for=\"" . $line['id'] . "\">");
        array_push($output, "<input type=\"radio\" name=\"answer\" value=\"" . $line['id'] .  "\" id =\"" . $line['id'] . "\" required/>");
        array_push($output, $line['answer'] . "</label>");
    }
    // Push the submit button
    array_push($output, "<input type=\"submit\" value=\"Submit\"/>");
    
    // Return the array
    return $output;
}
?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <!-- Automatically put the current question number into a title of a webpage -->
        <title><?="Question " . $_SESSION['current_question'] . " of Tech Trivia"?></title>
        <!-- Viewport optimization -->
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" href="q2.css">    
    </head>
    
    <body>
        <div>
            <!-- Automatically put the current question number into the header -->
            <h1><?="Question " . $_SESSION['current_question']?></h1>
            <form action="" method="post">
                <?php 
                foreach($GLOBALS['form_output'] as $line) {
                    echo $line;
                }
                ?>
            </form>
        </div>
    </body>
</html>
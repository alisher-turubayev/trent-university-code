<!--
COIS 3420 - Web Application Development

Assignment 2 - Question 2
Prepared by Alisher Turubayev, 0630908
-->
<?php
// Set error_msg to empty string in global scope to avoid error on first visit
$GLOBALS['error_msg'] = "";

/* 
function evaluate_input()

Purpose: if the form was submitted, process and store username in session, and continue to a next page:
        - checks for username correctness beforehand (no spaces, input sanitized);
        - any error to be outputted into $error_msg (it will be displayed in p.error element).
        
Output: none; $error_msg value is changed if any errors were found in the input
*/
function evaluate_input() {
    // If the input does not contain username, create an error message and finish function
    if (!isset($_POST['username'])) {
        $GLOBALS['error_msg'] = "No username provided";
        return;
    }
    
    // Use FILTER_SANITIZE_EMAIL to remove any code or spaces in the input
    $username = filter_input(INPUT_POST, 'username', FILTER_SANITIZE_EMAIL);
    // Solution taken here: https://stackoverflow.com/questions/4383878/php-username-validation
    // Correct username only contains English letters and numbers and confirms to size requirements
    if (!preg_match('/^[a-zA-Z0-9]{15,}$/', $username) && strlen($username) < 5) {
        $GLOBALS['error_msg'] = "Username contains illegal characters (only letters/numbers allowed), or is not of correct size";
        return;
    }
    
    // Start session and forward to next page
    session_start();
    $_SESSION['username'] = $username;
    $_SESSION['current_question'] = 1;
    $_SESSION['score'] = 0;
    
    header("Location: quiz.php");
}

// Only when the form was submitted, process it; otherwise, do nothing
if (isset($_POST) && count($_POST) > 0) {
    evaluate_input();
}

?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <title>Take a tech pop-quiz now! - Alisher Turubayev</title>
        <!-- Viewport optimization -->
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" href="q2.css">
    </head>
    <body>
        <div>
            <h1>Take a Tech Quiz Now!</h1>
            <p>Input a username to get started: 5 to 15 characters with numbers and letters only</p>
            <form action="index.php" method="post">
                <label for="username">Username:
                    <input type="text" name="username" required/>
                </label>
                <input type="submit" value="Submit"/>
            </form>
            
            <!-- If there is any error message, put it here. Otherwise, the element is not visible -->
            <p><?=$GLOBALS['error_msg']?></p>
            <h6>Questions taken from <a href="https://www.opinionstage.com/blog/trivia-questions/">Opinion Stage</h6>
        </div>
    </body>
</html>
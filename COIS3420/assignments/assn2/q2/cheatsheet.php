<!--
COIS 3420 - Web Application Development

Assignment 2 - Question 2
Prepared by Alisher Turubayev, 0630908
-->
<!DOCTYPE html>
<html lang="en">
    <head>
        <title>Super-secret Tech Quiz Cheatsheet</title>
        <!-- Viewport optimization -->
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" href="q2.css">
    </head>
    <body>
        <div class="cheatsheet">
            <h1>Cheatsheet for Tech Quiz - don't tell anyone!</h1>
            <?php
            // Include library for database connection
            include "includes/library.php";

            // Connect to database and fetch all questions
            $pdo = connectDB();
            $questions = $pdo->query("SELECT * FROM `a2_quest`");
            
            // Output them into a neat HTML (each question has a div, and an unordered list of answers)
            // Correct answers are dark green and have (correct) next to them for semantics
            foreach($questions as $quest) {
                echo "<div class=\"question_holder\">";
                echo "<p>" . $quest['question'] . "</p>";
                echo "<ul>";
                
                // Get answers from the query (otherwise it does not work, I tried using PDO::FETCH_INTO but couldn't figure out an error)
                $answers = $pdo->query("SELECT * FROM `a2_ans`");

                foreach($answers as $ans) {
                    // If the answers are not for a current question, continue
                    if ($ans['fk_questid'] != $quest['id']) {
                        continue;
                    }
                    else if ($ans['correct'] === 1) {
                        echo "<li class=\"correct\">" . $ans['answer'] . " (correct) " . $ans['choicecount'] . " times</li>";
                    }
                    else {
                        echo "<li>" . $ans['answer'] . " " . $ans['choicecount'] . " times</li>";
                    }
                }
                
                echo "</ul>";
                echo "</div>";
            }
            ?>
            <a href="index.php">Back to start!</a>
        </div>
    </body>
</html>
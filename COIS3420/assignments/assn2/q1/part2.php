<!--
COIS 3420 - Web Application Development

Assignment 2 - Question 1 Part B
Prepared by Alisher Turubayev, 0630908
-->
<?php
// If the form was not submitted, set the global var to false so that the rest of php does not execute
if (!isset($_GET) || count($_GET) <= 0) {
    $is_submitted = false;
}
else {
    $is_submitted = true;
}

// This function only gets called when the form was submitted; see above comment
/*
get_table function

Purpose: to generate a multiplication table based on the sanitized user bounds. Also sets a message into a 
$caption to describe the created table (sets $error to a an error message if the user input is not valid).

Returns: array; null if errors are found in user input
*/
function get_table() {
    // Note: this function puts an error 
    
    // Row values validation: check if a number and in bounds (1 to 9)
    // Lower row bound
    if (!isset($_GET['row_low'])) {
        $GLOBALS['error'] = "Input has missing values";
        return;
    }
    $row_low = intval(filter_input(INPUT_GET, 'row_low', FILTER_SANITIZE_NUMBER_INT));
    if ($row_low <= 0 || $row_low >= 10) {
        $GLOBALS['error'] = "Input has negative integers or is out of bounds";
        return;
    }
    // Upper row bound
    if (!isset($_GET['row_high'])) {
        $GLOBALS['error'] = "Input has missing values";
        return;
    }
    $row_high = intval(filter_input(INPUT_GET, 'row_high', FILTER_SANITIZE_NUMBER_INT));
    if ($row_high <= 0 || $row_high >= 10) {
        $GLOBALS['error'] = "Input has negative integers or is out of bounds";
        return;;
    }
    
    // Column values validation: check if a number and in bounds (1 to 9)
    // Lower column bound
    if (!isset($_GET['col_low'])) {
        $GLOBALS['error'] = "Input has missing values";
        return;
    }
    $col_low = intval(filter_input(INPUT_GET, 'col_low', FILTER_SANITIZE_NUMBER_INT));
    if ($col_low <= 0 || $col_low >= 10) {
        $GLOBALS['error'] = "Input has negative integers or is out of bounds";
        return;
    }
    // Upper column bound
    if (!isset($_GET['col_high'])) {
        $GLOBALS['error'] = "Input has missing values";
        return;
    }
    $col_high = intval(filter_input(INPUT_GET, 'col_high', FILTER_SANITIZE_NUMBER_INT));
    if ($col_high <= 0 || $col_high >= 10) {
        $GLOBALS['error'] = "Input has negative integers or is out of bounds";
        return;   
    }
    
    // Check whether the boundaries are corrent (lower bounds are smaller than higher bounds)
    if ($row_low > $row_high || $col_low > $col_high) {
        $GLOBALS['error'] = "The boundaries are incorrect (lower bound is larger than higher bound)";
        return;
    }
    
    // Put a caption explaining the table contents
    $GLOBALS['caption'] = "Table is generated: " . $row_low . " to " . $row_high
                            . " &times; " . $col_low . " to " . $col_high;
    
    // Construct a table and store in array $output
    // Instantiate array
    $output = array();
    
    // Push the first line of bolded column numbers into array
    array_push($output, "<tr> <th>&nbsp;&nbsp;&nbsp;</th>");
    for ($col = $col_low; $col <= $col_high; $col++) {
        array_push($output, "<th>&nbsp;" . $col . "&nbsp;</th>");
    }
    array_push($output, "</tr>");
    
    // Push the rest of data line by line
    for ($row = $row_low; $row <= $row_high; $row++) {
        // Push the value bolded for best formatting
        array_push($output, "<tr> <th>" . $row . "</th>");
        for ($col = $col_low; $col <= $col_high; $col++) {
            // Calculate value for the cell (multiply current column by row number)
            $val = $row * $col;
            array_push($output, "<td>" . $val . "</td>");
        }
        array_push($output, "</tr>");
    }
    
    return $output;
}
?>
<!DOCTYPE html> 
<html lang="en">
    <head>
        <title>Assignment 2 Question 1 by Alisher Turubayev</title>
        <!-- Viewport optimization -->
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" href="part2.css">
    </head>

    <body>
        <div>
            <h1>Learn multiplication table today!</h1>
            <form action="part2.php" method="get">
                <label for="row_low">Lower left boundary 
                    <input type="number" name="row_low" min="1" max="9" required/>
                </label>
                <label for="row_high">Higher left boundary 
                    <input type="number" name="row_high" min="1" max="9" required/>
                </label>
                <label for="col_low">Lower top boundary 
                    <input type="number" name="col_low" min="1" max="9" required/>
                </label>
                <label for="col_high">Higher top boundary
                    <input type="number" name="col_high" min="1" max="9" required/>
                </label>
                <input type="submit" value="Submit"/>
            </form>
        </div>
        <div class="table">
            <table>
                <?php
                // Only call this function if the global var was set to true 
                if ($GLOBALS['is_submitted'] !== false) {
                    // Save output of function 
                    $output = get_table();
                    // Put a caption out (it might contain error message)
                    // If output of function is null, there was an error in input
                    if (!is_null($output)) {
                        echo '<caption>' . $GLOBALS['caption'] . '</caption>';
                        foreach($output as $line)
                        echo $line;
                    }
                    else {
                        echo '<p class="error">' . $GLOBALS['error'] . '</p>';
                    }
                }
                else {
                    echo '<p>Bookmark the page with the table of your choice for easy later access!</p>';
                }
                ?>
            </table>
        </div>
    </body>
</html>
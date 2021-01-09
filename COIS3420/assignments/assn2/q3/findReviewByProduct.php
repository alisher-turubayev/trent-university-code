<?php
/*
COIS 3420 - Web Application Development

Assignment 2 - Question 3
Prepared by Alisher Turubayev, 0630908
*/
// Access and content description headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");

// Before continuing with the database connection, sanitize input and check whether it is correct
if (!isset($_GET['product_id'])) {
    http_response_code(400);
    echo json_encode(
        array("message" => "Empty input - provide key 'product_id'.")
    );
    exit();
}

// Need intval to avoid '+' sign in the sanitized input
$provided_id = intval(filter_input(INPUT_GET, 'product_id', FILTER_SANITIZE_NUMBER_INT));
// If the number is negative - no need to connect to the database
if ($provided_id <= 0) {
    http_response_code(400);
    echo json_encode(
        array("message" => "Input not a number or a negative one.")
    );
    exit();
}

// Include both Product and Review classes
include_once './objects/review.php';
include_once './objects/product.php';
// Use this for database connection
include './includes/library.php';

// Initiate the product object - pass the database connection to it
// Note that later the same database connection is used for second query for the product
$db = connectDB();
$review = new Review($db);

// Call readAll function to get a prepared statement 
$stmt = $review->findByProductID($provided_id);
$count = $stmt->rowCount();

// If there is data in the table, return it with the code 200
if($count > 0) {
    // Create products array that will contain the result
    $reviews = array();

    // Create a new product - this is needed for output formatting (product name and price are only repeated once)
    $product = new Product($db);
    // Find the product by id
    $stmt_prod = $product->findByID($provided_id);
    // No need to check whether the rows are empty - if the previous query 
    // returned something, we know that product exists (product_id is foreign key)
    $row = $stmt_prod->fetch();
    extract($row);
    $reviews['name'] = $name;
    $reviews['price'] = $price;
    
    // Fetch entries one by one and put into an array (there might be multiple reviews for one product)
    while ($row = $stmt->fetch()) {
        // Put all array items into variables ($row['id'] becomes $id)
        extract($row);
        
        // Create an entry into an array and push it
        $item = array(
            "review" => $review,
            "score" => $score
        );
        
        array_push($reviews, $item);
    }
    
    // Set the code to 200 and encode return data
    http_response_code(200);
    echo json_encode($reviews);
}

// Else, return a code 404
else {
    http_response_code(404);
    echo json_encode(
        array("message" => "No entries with a given id found.")
    );
}
?>
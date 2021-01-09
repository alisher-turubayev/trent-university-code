<?php
/*
COIS 3420 - Web Application Development

Assignment 2 - Question 3
Prepared by Alisher Turubayev, 0630908
*/
// Access and content description headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");

// Include Product class
include_once './objects/product.php';
// Use this for database connection
include './includes/library.php';

// Initiate the product object - database connection is inside this already
$product = new Product(connectDB());

// Call readAll function to get a prepared statement 
$stmt = $product->readAll();
$count = $stmt->rowCount();

// If there is data in the table, return it with the code 200
if($count > 0) {
    // Create products array that will contain the result
    $products = array();
    
    // Fetch entries one by one and put into an array
    while ($row = $stmt->fetch()) {
        // Put all array items into variables ($row['id'] becomes $id)
        extract($row);
        
        // Create an entry into an array and push it
        $item = array(
            "id" => $id, 
            "name" => $name,
            "price" => $price
        );
        
        array_push($products, $item);
    }
    
    // Set the code to 200 and encode return data
    http_response_code(200);
    echo json_encode($products);
}

// Else, return a code 404
else {
    http_response_code(404);
    echo json_encode(
        array("message" => "No entries found.")
    );
}
?>
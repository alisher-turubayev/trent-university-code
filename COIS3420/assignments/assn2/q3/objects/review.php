<?php
/*
COIS 3420 - Web Application Development

Assignment 2 - Question 3
Prepared by Alisher Turubayev, 0630908
*/

class Review {
    // Database connection
    private $pdo;
    
    // Constructor - creates a database connection
    public function __construct($db) {
        $this->pdo = $db;
    }
    
    /*
    function readAll
    
    Purpose:    Returns a statement with all entries from "reviews" table
    
    Arguments: none
    Returns: SQL statement
    */
    public function readAll() {
        // Sort all results by product_id in ascending order so to group any reviews for one product
        $stmt = $this->pdo->query("SELECT reviews.id, reviews.product_id, products.name, products.price, reviews.review, reviews.score FROM products RIGHT JOIN reviews ON products.id = reviews.product_id ORDER BY product_id ASC");
        return $stmt;
    }
    
    /*
    function findByProductID
    
    Purpose:    Returns a statement with all entries from "reviews" table where product_id matches a given variable
                Note that the function sanitizes the argument
    
    Arguments: int - the product_id to find the reviews by
    Returns: SQL statement
    */
    public function findByProductID($provided_id) {
        // Need intval to avoid '+' sign in the sanitized input
        $provided_id = intval(filter_var($provided_id, FILTER_SANITIZE_NUMBER_INT));
        
        $stmt = $this->pdo->prepare("SELECT reviews.id, reviews.product_id, products.name, products.price, reviews.review, reviews.score FROM products RIGHT JOIN reviews ON products.id = reviews.product_id WHERE product_id = ?");
        $stmt->execute([$provided_id]);
        return $stmt;
    }
}
?>
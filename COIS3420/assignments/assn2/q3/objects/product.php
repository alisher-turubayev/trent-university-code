<?php
/*
COIS 3420 - Web Application Development

Assignment 2 - Question 3
Prepared by Alisher Turubayev, 0630908
*/

class Product {
    // Database connection
    private $pdo;
    
    // Constructor - creates a database connection
    public function __construct($db) {
        $this->pdo = $db;
    }
    
    /*
    function readAll
    
    Purpose: returns a statement with all entries from "products" table
    
    Arguments: none
    Returns: SQL statement
    */
    public function readAll() {
        $stmt = $this->pdo->query("SELECT * FROM products");
        return $stmt;
    }
    
    /*
    function findByID
    
    Purpose:    Returns a statement with an entry (or none if ID is not found) from table where 
                id matches a given variable.
                Note that the function sanitizes the argument
    
    Arguments: int - the product_id to find the product by
    Returns: SQL statement
    */
    public function findByID($provided_id) {
        // Need intval to avoid '+' sign in the sanitized input
        $provided_id = intval(filter_var($provided_id, FILTER_SANITIZE_NUMBER_INT));
        
        $stmt = $this->pdo->prepare("SELECT name, price FROM products WHERE id = ?");
        $stmt->execute([$provided_id]);
        return $stmt;
    }
}
?>
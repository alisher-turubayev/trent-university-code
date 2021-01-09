<?php
/* require or include the library */
require './includes/library.php';

/* ------ <from-the-last-lab> ------- */
/* Redirect if $_POST has nothing in it */
if (!isset($_POST) || count($_POST) <= 0) {
  header("Location: voting.php");
}

/* $errors starts as an empty array */
$errors = [];

/* Get everything from $_POST */
$name = $_POST['name'] ?? NULL;
$email = $_POST['email'] ?? NULL;
$perspective = $_POST['perspective'] ?? NULL;
$choice = $_POST['choice'] ?? NULL;
$agree = $_POST['agree'] ?? NULL;

/* Error Validation (from last lab) */
if (!isset($name) || strlen($name) === 0) array_push($errors, "Please enter a name.");
if (strpos($name, ' ') === FALSE) array_push($errors, "Please use your first and last name.");
if (!filter_var($email, FILTER_VALIDATE_EMAIL)) array_push($errors, "Please enter a valid email address.");
if (!isset($perspective)) array_push($errors, "Please select your persepctive.");
if ($choice < 0) array_push($errors, "Please select an option.");
if (!isset($agree)) array_push($errors, "Please agree to the terms and conditions.");
/* ------ </from-the-last-lab> ------- */

/* If no errors, do database work */
if (count($errors) === 0) {
  /* Connect to DB */
  $pdo = connectDB();
  
  /* Check for email duplicate before submitting the vote */
  $query = "SELECT candy_choice FROM `cois3420_allvotes` WHERE email = ?";
  $stmt = $pdo->prepare($query);
  $stmt->execute([$email]);
  
  $results = $stmt->fetchAll();
  
  /* Continue processing if the email is not duplicate */
  if (sizeof($results) !== 0) {
    array_push($errors, "You have already voted.");    
  }
  else {
    /* Add the vote to `allvotes` */
    $query = "INSERT INTO `cois3420_allvotes` (name, email, perspective, candy_choice) VALUES (?, ?, ?, ?)";
    $stmt_1 = $pdo->prepare($query);
    $stmt_1->execute([$name, $email, $perspective, $choice]);

    /* Increase the vote-count in `candies` */
    $query = "UPDATE `cois3420_candies` SET votecount = votecount + 1 WHERE id = ?";
    $stmt_2 = $pdo->prepare($query);
    $stmt_2->execute([$choice]);

    /* Redirect to thankyou.php */
    header("Location: thankyou.php");
  }
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
  <?php
  $PAGE_TITLE = "Something went wrong";
  include "./includes/metadata.php";
  ?>
</head>
<body>
  <?php include "./includes/header.php"; ?>
  <main>
    <h1>Errors</h1>
    <ul id="errors">
      <?php foreach ($errors as $error): ?>
        <li><?= $error ?></li>
      <?php endforeach; ?>
    </ul>
  </main>
  <?php include "./includes/footer.php"; ?>
</body>

</html>

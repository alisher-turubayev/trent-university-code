<?php
/* Redirect if $_POST has nothing in it */
if (!isset($_POST) || count($_POST) <= 0) {
  header("Location: voting.php");
}

/* $errors starts as an empty array */
$errors = [];

/* Error Validation */
if (!isset($_POST['name']) || strlen($_POST['name']) == 0)
  array_push($errors, "Please enter a name.");

// if (...)
//  Push "Please use your first and last name." to $errors
if (strpos($_POST['name'], ' ') === false)
  array_push($errors, "Please enter both first and last name.");

// if (...)
//  Push to $errors
$email = filter_var($_POST['email'], FILTER_SANITIZE_EMAIL);
if (filter_var($email, FILTER_VALIDATE_EMAIL) === false)
  array_push($errors, "Please input a valid email address.");

// and so on...
if (!isset($_POST['perspective']))
  array_push($errors, "Please choose a perspective for your vote.");

if ($_POST['choice'] === '-1') 
  array_push($errors, "Please make a choice for the product you want to see.");
  
if (!isset($_POST['agree']))
  array_push($errors, "Please agree to the Terms & Conditions of the voting.");
  
if (count($errors) == 0) {
  header("Location: results.php");
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
  <?php
  $PAGE_TITLE = "Vote errors - Willy Wonka Factory";
  include("includes/metadata.php");
  ?>
</head>
<body>
  <?php include("includes/header.php"); ?>
  <main>
    <h1>Errors</h1>
    <ul id="errors">
      <?php foreach ($errors as $error): ?>
        <li><?= $error ?></li>
      <?php endforeach; ?>
    </ul>
  </main>
  <?php include("includes/footer.php"); ?>
  <!-- Fix for Chrome bug, leave this. https://stackoverflow.com/a/42969608 -->
  <script> </script>
</body>

</html>

<?php

$email = $_GET['email'] ?? NULL;
if (!$email || !filter_var($email, FILTER_VALIDATE_EMAIL)) {
  echo 'error';
  return;
}

require './includes/library.php';
$pdo = connectDB();

$statement = $pdo->prepare("SELECT * FROM `cois3420_allvotes` WHERE email = ?");
$statement->execute([$email]);

if ($statement->fetch()) echo 'true';
else echo 'false';
?>
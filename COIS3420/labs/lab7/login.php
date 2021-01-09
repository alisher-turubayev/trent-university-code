<?php
  $usererror = false;
  
  require './includes/library.php';
  /* Get everything from $_POST */
  $user = $_POST['username'] ?? NULL;
  $pass = $_POST['password'] ?? NULL;
  #put form processing here  
  
  if (isset($_POST) && count($_POST) > 0) {
    $pdo = connectDB();
    $query = "SELECT * FROM cois3420_users WHERE username = ?";
    $stmt = $pdo->prepare($query);
    $stmt->execute([$user]);
  
    $results = $stmt->fetch();
  
    if (!password_verify($pass, $results['password'])) {
      $usererror = true;
    }
    else {
      session_start();
      $_SESSION['id'] = $results['id'];
      $_SESSION['username'] = $results['username'];
      header("Location: results.php");
      exit();
    }
  }
?>
<!DOCTYPE html>
<html lang="en">
<head>
  <?php
  $PAGE_TITLE = "Login";
  include './includes/metadata.php';
  ?>
</head>
<body>
  <?php include './includes/header.php'; ?>

       <main>
         <h1>Super Secret Voting Results</h1>
   
        <form id="login" method="post" action="<?php echo $_SERVER['PHP_SELF'] ?>">
            <div>
              <label for="username">Username:</label> 
              <!--notice the echo of username to allow for a sticky form on error-->
              <input type="text" id="username" name="username" size="25" value="<?php echo $user?>"/>
            </div>
            <div>
              <label for="password">Password:</label> 
              <input type="password" id="password" name="password" size="25" />
            </div>
            <div>
               <!--notice variable which triggers output of error message if sticky processing fails-->
           <?php if ($usererror){?><span class="error">Your username or password was invalid</span> <?php }?>
            </div>
            <div>
                <label for="remember">Remember:</label>
              <input type="checkbox" name="remember" value="remember" />
            </div>

          <button id="submit" name="submit" class="centered">Login</button>
       
    </form>


      </main><!--Content-->
     <?php include './includes/footer.php'; ?>
</body>
</html>

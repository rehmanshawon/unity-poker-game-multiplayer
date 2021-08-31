<?php
$con = mysqli_connect('www.kopotron.com', 'kopotron_admin','threecard369','kopotron_threecard');
if (mysqli_connect_errno())
{
	echo "1: Connection failed";
	exit();
}

$playername = $_POST["PlayerName"];
//$email = $_POST["Email"];

/*
$playername = "shawonshawon";
$email = "info@rehmanshawon.com";
$password = "999999999999";
$phone = "01736979369";
$country = "Bangladesh";
$sponsor = "IqbalHossain";
$club = "Club A";
$currency = "Rupi";
*/
$namecheck = "select Playername, Hash, Email from Player_Profile where Playername = '" . $playername . "';";
$check = mysqli_query($con, $namecheck) or die("2: Name check query failed");
if(mysqli_num_rows($check)!=1)
{
	echo "5: User does not exist";
	exit();
}
$existinginfo = mysqli_fetch_assoc($check);

$hash = $existinginfo["Hash"];
$to = $existinginfo["Email"];
$plain = openssl_decrypt($hash, "AES-128-ECB", "HelloBangladesh");
$subject = "Forgot Password";
$message = "<h1>Below is your password.</h1>";
$message .= "<b>Your Password is: ".$plain." </b>";
$message .= "<br>Delete this message as soon as you retrieve the password";
  
$header = "From:info@kopotron.com \r\n";
$header .= "MIME-Version: 1.0\r\n";
$header .= "Content-type: text/html\r\n";
         
$retval = mail ($to,$subject,$message,$header);
         
if( $retval == true ) {
   echo "0";
  }else {
  echo "Password could not be sent your provide email. Maybe your email is not correct...";
  exit();
 }
?>
<?php
$con = mysqli_connect('www.kopotron.com', 'kopotron_admin','threecard369','kopotron_threecard');
if (mysqli_connect_errno())
{
	echo "1: Connection failed";
	exit();
}

$playername = $_POST["PlayerName"];
$password = $_POST["Password"];

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
$namecheck = "select Playername, Hash from Player_Profile where Playername = '" . $playername . "';";
$check = mysqli_query($con, $namecheck) or die("2: Name check query failed");
if(mysqli_num_rows($check)!=1)
{
	echo "5: User does not exist";
	exit();
}
$existinginfo = mysqli_fetch_assoc($check);
//$salt = $existinginfo["Salt"];
$hash = $existinginfo["Hash"];
$plain = openssl_decrypt($hash, "AES-128-ECB", "HelloBangladesh");
//$loginhash = crypt($password,$salt);
if ($password != $plain)
{
	echo "6: incorrect password";
	exit();
}

echo("0");
?>
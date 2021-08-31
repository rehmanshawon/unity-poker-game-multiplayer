<?php
$con = mysqli_connect('www.kopotron.com', 'kopotron_admin','threecard369','kopotron_threecard');
if (mysqli_connect_errno())
{
	echo "1: Connection failed";
	exit();
}

$playername = $_POST["PlayerName"];
$email = $_POST["Email"];
$password = $_POST["Password"];
$phone = $_POST["Phone"];
$country = $_POST["Country"];
$sponsor = $_POST["Sponsor"];
$club = $_POST["Club"];
$currency = $_POST["Currency"];
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
$namecheck = "select Playername from Player_Profile where Playername = '" . $playername . "';";
$check = mysqli_query($con, $namecheck) or die("2: Name check query failed");
if(mysqli_num_rows($check)>0)
{
	echo "3: name already exists";
	exit();
}
//$salt = "\$5\$rounds=5000\$" . "steamedhams" . $playername . "\$";
//$hash = crypt($password,$salt);
$hash = openssl_encrypt($password, "AES-128-ECB", "HelloBangladesh");
$insertplayerquery = "insert into Player_Profile (Playername, Hash, Email, Phone, Sponsorname, Clubname, country, Currency) values ('" . $playername . "', '" . $hash . "', '" . $email . "', '" . $phone . "', '" . $sponsor . "', '" . $club . "', '" . $country . "', '" . $currency . "');";
mysqli_query($con,$insertplayerquery) or die("4: Insert player query failed");
echo("0");
?>
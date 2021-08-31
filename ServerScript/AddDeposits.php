<?php
header('Access-Control-Allow-Origin: *');
header('Content-Type: application/json');
header('Access-Control-Allow-Methods: POST');
header('Access-Control-Allow-Headers: Access-Control-Allow-Headers, Content-Type, Access-Control-Allow-Methods, Authorization, X-Requested-With');

include_once '../../config/Database.php';
include_once '../../models/DepositHistory.php';

//Instantiate DB & connect
$database = new Database();
$db = $database->connect();

//Instantiate DepositHistory object
$deposits = new DepositHistory($db);

//Get the raw posted data
$record = json_decode(file_get_contents("php://input"));

$deposits->PlayerName = $record->PlayerName;
$deposits->Payment = $record->Payment;
$deposits->Coins = $record->Coins;
$deposits->Method = $record->Method;
$deposits->ToNo = $record->ToNo;
$deposits->FromNo = $record->FromNo;

if($deposits->MakePlayerDeposits()){
	echo json_encode(array('message' => 'post created' ));
}
else
{
	echo json_encode(array('message' => 'post not created' ));
}

?>
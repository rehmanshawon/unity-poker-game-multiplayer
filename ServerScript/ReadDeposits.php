<?php
header('Access-Control-Allow-Origin: *');
header('Content-Type: application/json');

include_once '../../config/Database.php';
include_once '../../models/DepositHistory.php';

//Instantiate DB & connect
$database = new Database();
$db = $database->connect();

//Instantiate DepositHistory object
$deposits = new DepositHistory($db);

//Get Player Name
$deposits->PlayerName = isset($_GET['PlayerName']) ? $_GET['PlayerName'] : die();
//Read the data
$result = $deposits->ReadPlayerDeposits();
//Get row count
$num = $result->rowCount();
//Check if any data
if($num > 0)
{
	//Deposit Array
	$deposit_arr = array();
	$deposit_arr["records"] = array();

	// retrieve our table contents
    // fetch() is faster than fetchAll()
    while ($row = $result->fetch(PDO::FETCH_ASSOC)){
        // extract row
        // this will make $row['name'] to
        // just $name only
        extract($row);
  
        $deposit_record=array(
            "DepositId" => $DepositId,
            "PlayerName" => $PlayerName,            
            "Date" => $Date,
            "Payment" => $Payment,
            "Coins" => $Coins,
            "Method" => $Method,
            "ToNo" => $ToNo,
            "FromNo" => $FromNo,
            "Status" => $Status
        );
  
        array_push($deposit_arr["records"], $deposit_record);
    }
    // set response code - 200 OK
    http_response_code(200);
    // show products data in json format
    echo json_encode($deposit_arr);
}
else
{
	// No Records
	echo json_encode(array('message' => 'No Posts Found'));
}

?>
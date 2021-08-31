<?php
/**
 * 
 */
class DepositHistory
{
	//DB stuff
	private $conn;
	private $table='DepositHistory';

	//Table Data
	public $DepositId;
	public $PlayerName;
	public $Date;
	public $Payment;
	public $Coins;
	public $Method;
	public $ToNo;
	public $FromNo;
	public $Status;

	//Constructor with DB
	public function __contruct($db)
	{
		$this->conn = $db;

	}

	//Get Data
	public function ReadPlayerDeposits(){
		//Create Query
		$query = 'SELECT * FROM ' . $this->table . ' WHERE PlayerName = ?';
		//Prepare Statement
		$stmt = $this->conn->prepare($query);
		$stmt->bindParam(1,$this->PlayerName);

		//Execute Query
		$stmt->execute();
		return $stmt;

	}

	public function MakePlayerDeposits(){
		//Create Query
		$query = 'INSERT INTO ' . $this->table . 'SET PlayerName = :PlayerName, Payment = : Payment, Coins =: Coins, Method = : Method, ToNo = : ToNo, FromNo = : FromNo';
		//Prepare Statement
		$stmt = $this->conn->prepare($query);
		//Clear Data


		//Bind Data
		$stmt ->bindParam(':PlayerName', $this->PlayerName);
		$stmt ->bindParam(':Payment', $this->Payment);
		$stmt ->bindParam(':Coins', $this->Coins);
		$stmt ->bindParam(':Method', $this->Method);
		$stmt ->bindParam(':ToNo', $this->ToNo);
		$stmt ->bindParam(':FromNo', $this->FromNo);

		//Execute Query
		if($this->execute()){
			return true;
		}

		print("Error: %s.\n", $stmt->error);
		return false;

	}
	
}

?>
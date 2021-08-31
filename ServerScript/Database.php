<?php
class Database{
	private $host = 'www.kopotron.com';
	private $db_name = 'kopotron_threecard';
	private $username = 'kopotron_admin';
	private $password = 'threecard369';
	private $conn;

	public function connect(){
		$this->conn = null;

		try{
			$this->conn = new PDO('mysql:host=' . $this->host . ';dbname=' . $this->db_name, $this->username, $this->password);
			this->conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

		} catch(PDOException $e)
		{
			echo 'Connection Error: ' . e->getMessage();
		}
		return this->conn;

	}

}
?>
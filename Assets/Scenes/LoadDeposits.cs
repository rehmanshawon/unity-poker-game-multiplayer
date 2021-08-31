using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;


public class LoadDeposits : MonoBehaviour
{
    public Text txtDate;
    public Text txtPayment;
    public Text txtCoins;
    public Text txtFromNo;
    public Text txtStatus;
    public Text txtMethod;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowDepositHistory());
    }

    IEnumerator ShowDepositHistory()
    {
        
        string DepositApiURL = "https://kopotron.com/php_rest_threecards/api/deposithistory/ReadDeposits.php?PlayerName="+DBManager.username;
        UnityWebRequest DepositTableRequest = UnityWebRequest.Get(DepositApiURL);
        yield return DepositTableRequest.SendWebRequest();
        if(DepositTableRequest.isNetworkError || DepositTableRequest.isHttpError)
        {
            Debug.LogError(DepositTableRequest.error);
            yield break;
        }
        
       
        JSONNode DepositTable = JSON.Parse(DepositTableRequest.downloadHandler.text);
        JSONNode DepositRecords = DepositTable["records"];
        int recordNo = DepositRecords.Count;
        txtDate.text = "";
        txtPayment.text = "";
        txtCoins.text = "";
        txtMethod.text = "";
        txtFromNo.text = "";
        txtStatus.text = "";
        for (int i = 0; i < recordNo; i++)
        {
            //iRecords.text =
            txtDate.text += DepositRecords[i]["Date"]+"\n";
            txtPayment.text += DepositRecords[i]["Payment"] + "\n";
            txtCoins.text += DepositRecords[i]["Coins"] + "\n";
            txtMethod.text += DepositRecords[i]["Method"] + "\n";
            txtFromNo.text += DepositRecords[i]["FromNo"] + "\n";
            txtStatus.text += DepositRecords[i]["Status"] + "\n";
            //Debug.Log(DepositRecords[i]["Payment"]);
        }
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}



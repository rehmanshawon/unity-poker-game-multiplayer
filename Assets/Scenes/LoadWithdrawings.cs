using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;


public class LoadWithdrawings : MonoBehaviour
{
    public Text txtDate;
    public Text txtAmount;
    public Text txtFromNo;
    public Text txtStatus;
    public Text txtMethod;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowWithdrawHistory());
    }

    IEnumerator ShowWithdrawHistory()
    {
        
        string DepositApiURL = "https://kopotron.com/php_rest_threecards/api/deposithistory/ReadWithdrawings.php?PlayerName="+DBManager.username;
        UnityWebRequest WithdrawTableRequest = UnityWebRequest.Get(DepositApiURL);
        yield return WithdrawTableRequest.SendWebRequest();
        if(WithdrawTableRequest.isNetworkError || WithdrawTableRequest.isHttpError)
        {
            Debug.LogError(WithdrawTableRequest.error);
            yield break;
        }
        
       
        JSONNode WithdrawTable = JSON.Parse(WithdrawTableRequest.downloadHandler.text);
        JSONNode WithdrawRecords = WithdrawTable["records"];
        int recordNo = WithdrawRecords.Count;
        txtDate.text = "";
        txtAmount.text = "";
        txtMethod.text = "";
        txtFromNo.text = "";
        txtStatus.text = "";
        for (int i = 0; i < recordNo; i++)
        {
            //iRecords.text =
            txtDate.text += WithdrawRecords[i]["Date"]+"\n";
            txtAmount.text += WithdrawRecords[i]["Amount"] + "\n";
            txtMethod.text += WithdrawRecords[i]["Method"] + "\n";
            txtFromNo.text += WithdrawRecords[i]["FromNo"] + "\n";
            txtStatus.text += WithdrawRecords[i]["Status"] + "\n";
            //Debug.Log(DepositRecords[i]["Payment"]);
        }
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}



using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WithdrawMoney : MonoBehaviour
{
    public List<string> Methods = new List<string>() {"Withdraw Method","Method01", "Method02", "Method03", "Method04", "Method05" }; 

    readonly string postURL = "https://www.kopotron.com/AddWithdrawings.php";
    public InputField Amount;
    public InputField ToNo;
    public InputField FromNo;
    public Dropdown Method;
    public Button SubmitButton;
    public GameObject pnlOK;
    public Text DialogMsg;
    public void CallWithdraw()
    {
        //if(PlayerName.text.Length<6)
        //{
        //    pnlOK.SetActive(true);
        //    SubmitButton.interactable = false;
        //   return false;
        //}
        StartCoroutine(Withdraw());
        //return true;
    }
    

    
    
    

    public void HideDialog()
    {
        pnlOK.SetActive(false);
    }
    // Start is called before the first frame update

    IEnumerator Withdraw()
    {


        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        //WWWForm form = new WWWForm();
        formData.Add(new MultipartFormDataSection("PlayerName", DBManager.username));
        formData.Add(new MultipartFormDataSection("Amount", Amount.text));
        formData.Add(new MultipartFormDataSection("Method", Methods[Method.value]));
        formData.Add(new MultipartFormDataSection("ToNo", ToNo.text));
        formData.Add(new MultipartFormDataSection("FromNo", ToNo.text));
        UnityWebRequest www = UnityWebRequest.Post(postURL, formData);

        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
            DialogMsg.text = www.error;
            pnlOK.SetActive(true);
            //SubmitButton.interactable = false;
            //www.responseCode.
        }
        else
        {

            if (www.downloadHandler.text != "0")
            {
                DialogMsg.text = www.downloadHandler.text;
                pnlOK.SetActive(true);
                //SubmitButton.interactable = false;
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(10);
            }

        }


    }

    public void VerifyInputs()
    {
        if(!String.IsNullOrWhiteSpace(Amount.text) && !String.IsNullOrWhiteSpace(ToNo.text) && !String.IsNullOrWhiteSpace(FromNo.text))
        {
            double userval2;
            SubmitButton.interactable = double.TryParse(Amount.text, out userval2);
            SubmitButton.interactable = (Methods[Method.value] != "Payment Method");
        }

    }

    


}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RetrievePassword : MonoBehaviour
{
    // Start is called before the first frame update
    public Button SubmitButton;
    public GameObject pnlOK;
    public Text DialogMsg;
    //public InputField Email;
    readonly string postURL = "https://www.kopotron.com/GetPassword.php";
    public void CallRetrievePassword()
    {
        StartCoroutine(GetPassword());
    }

    IEnumerator GetPassword()
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("PlayerName", DBManager.t_username));
        //formData.Add(new MultipartFormDataSection("Email", Email.text));
        UnityWebRequest www = UnityWebRequest.Post(postURL, formData);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
            DialogMsg.text = www.error;
            pnlOK.SetActive(true);

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
                //DBManager.username = PlayerName.text;
                UnityEngine.SceneManagement.SceneManager.LoadScene(2);
            }

        }

    }


}

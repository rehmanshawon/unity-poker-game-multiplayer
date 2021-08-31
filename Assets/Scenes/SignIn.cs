using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
//using UnityEngine.
//using Newtonsoft.Json;
//using Newtonsoft.Json.Serialization;
//using System.Text.j;
//using System.Text.Json.Serialization;
[System.Serializable]
public class Result
{
    public string user_id { get; set; }
    public string user_amount { get; set; }
    public string image_url { get; set; }
    public string user_name { get; set; }
    public int session_id { get; set; }
    public string classic_pot_amount { get; set; }
    public string classic_bet_amount { get; set; }
    public string muflis_pot_amount { get; set; }
    public string muflis_bet_amount { get; set; }
    public string joker_pot_amount { get; set; }
    public string joker_bet_amount { get; set; }
    public string user_image { get; set; }
}

public class LogResponse
{
    public string status { get; set; }
    public Result result { get; set; }
    public static LogResponse GetLogInfoFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<LogResponse>(jsonString);
    }
}

public class SignIn : MonoBehaviour
{
    // Start is called before the first frame update
    readonly string postURL = "kopotron.com/Signin.php";
    public InputField PlayerName;    
    public InputField Password;
    public Button SubmitButton;
    public GameObject pnlOK;
    public Text DialogMsg;


    public void CallSignIn()
    {
        StartCoroutine(Signin());
    }
    public void NameOK(string name)
    {
        if (name.Length < 6)
        {
            DialogMsg.text = "Not a valid name! Minimum 6 letters!";
            pnlOK.SetActive(true);
            SubmitButton.interactable = false;
            //return false;
        }
    }
    public void PswdOK(string pswd)
    {
        if (pswd.Length < 6)
        {
            DialogMsg.text = "Password must have minimum 6 digits";
            pnlOK.SetActive(true);
            SubmitButton.interactable = false;

        }
    }
    public void HideDialog()
    {
        pnlOK.SetActive(false);
    }
    public void GoToRetrievePassword()
    {
        DBManager.t_username = PlayerName.text;
        UnityEngine.SceneManagement.SceneManager.LoadScene(6);
    }
    IEnumerator Signin()
    {
        /*
        //string postURL = "https://mygamebuzz.net/live/gapi.php/watchman/find/333P4TT1";
        //string postURL = "https://mygamebuzz.net/live/gapi.php/watchman/find/333P4TT1";
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        //formData.Add(new MultipartFormDataSection)
        //formData.Add(new MultipartFormDataSection("api_key", "333P4TT1"));
        formData.Add(new MultipartFormDataSection("action", "user_login"));
        formData.Add(new MultipartFormDataSection("username", PlayerName.text.ToLower()));
        formData.Add(new MultipartFormDataSection("password", Password.text));
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
            
            LogResponse myLogInfo = LogResponse.GetLogInfoFromJSON(www.downloadHandler.text);
            if(myLogInfo.status=="1")
            {
                DBManager.username = PlayerName.text;
                DBManager.userpic = myLogInfo.result.user_image;
                UnityEngine.SceneManagement.SceneManager.LoadScene(3);
            }
            else
            {
                DialogMsg.text = www.downloadHandler.text;
                pnlOK.SetActive(true);
            }

        }
        */
       
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();        
        formData.Add(new MultipartFormDataSection("PlayerName", PlayerName.text.ToLower()));        
        formData.Add(new MultipartFormDataSection("Password", Password.text));        
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
            if (www.downloadHandler.text.Length > 10)
            {
                DialogMsg.text = www.downloadHandler.text;
                pnlOK.SetActive(true);                
            }
            else
            {
                DBManager.username = PlayerName.text;
                DBManager.userpic = www.downloadHandler.text;
                UnityEngine.SceneManagement.SceneManager.LoadScene(3);
            }
            
        }

        
    }

    public void VerifyInputs()
    {
        
            SubmitButton.interactable = (PlayerName.text.Length >= 6 && Password.text.Length >= 6);
        

    }

}

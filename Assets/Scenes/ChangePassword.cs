using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class ChangePassword : MonoBehaviour
{
    readonly string postURL = "kopotron.com/ChangePassword.php";
    public InputField inNew;
    public InputField inConfirm;
    public Button btnSubmit;
    public Button btnBack;
    public Button btnExit;
    public GameObject pnlOK;
    public Text DialogMsg;

    public void OnOK()
    {
        pnlOK.SetActive(false);
    }
    public void GoToProfile()
    {
        SceneManager.LoadScene(7);
    }
    public void OnExit()
    {
        Application.Quit();
    }
    public void CallChangePassword()
    {
        if(inNew.text!=inConfirm.text)
        {
            DialogMsg.text = "Passwords don't match! Try again!";
            pnlOK.SetActive(true);
            return;
        }
        else
        {
            StartCoroutine(ChangePassord());
        }
    }
    IEnumerator ChangePassord()
    {

        
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        //WWWForm form = new WWWForm();
        formData.Add(new MultipartFormDataSection("PlayerName", DBManager.username));
        
        formData.Add(new MultipartFormDataSection("Password", inConfirm.text));
        

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

            Debug.Log("Received: " + www.downloadHandler.text);
            if (www.downloadHandler.text != "0")
            {
                DialogMsg.text = www.downloadHandler.text;
                pnlOK.SetActive(true);
                //SubmitButton.interactable = false;
            }
            else
            {
                DialogMsg.text = "Password Changed Succesfully!";
                pnlOK.SetActive(true);
                //UnityEngine.SceneManagement.SceneManager.LoadScene(3);
            }

        }


    }

}

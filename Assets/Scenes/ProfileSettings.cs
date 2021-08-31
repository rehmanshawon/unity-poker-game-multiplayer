using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ProfileSettings : MonoBehaviour
{
    readonly string postURL = "kopotron.com/LoadPic.php";
    public GameObject imgScrollPics;
    public GameObject pnlOK;
    public Text DialogMsg;
    // Start is called before the first frame update
   

    // Update is called once per frame
    
    public void OnProfilePic()
    {
        imgScrollPics.SetActive(true);
    }
    public void OnBtnOK()
    {
        if(DBManager.userpic!="")
        {
            StartCoroutine(UpdatePic());           
        }
        imgScrollPics.SetActive(false);
    }
    public void OnPicSelect(Button btnPicName)
    {
        string strTmp = btnPicName.name;
        string[] tmpAr = strTmp.Split('_');
        DBManager.userpic = tmpAr[1];        
        
    }
    public void HideDialog()
    {
        pnlOK.SetActive(false);
    }
    IEnumerator UpdatePic()
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("PlayerName", DBManager.username));
        formData.Add(new MultipartFormDataSection("Picture", DBManager.userpic));
        UnityWebRequest loadPic = UnityWebRequest.Post(postURL, formData);

        yield return loadPic.SendWebRequest();
        if (loadPic.isNetworkError || loadPic.isHttpError)
        {
            Debug.LogError(loadPic.error);
            DialogMsg.text = loadPic.error;
            pnlOK.SetActive(true);
            //SubmitButton.interactable = false;
            //www.responseCode.
        }
        else
        {

            Debug.Log("Received: " + loadPic.downloadHandler.text);
            if (loadPic.downloadHandler.text != "0")
            {
                DialogMsg.text = loadPic.downloadHandler.text;
                pnlOK.SetActive(true);
                //SubmitButton.interactable = false;
            }
            else
            {
                // DBManager.username = PlayerName.text;
                //UnityEngine.SceneManagement.SceneManager.LoadScene(3);
                DialogMsg.text = "Profile Picture Updated!";
                pnlOK.SetActive(true);
            }

        }
    }
}

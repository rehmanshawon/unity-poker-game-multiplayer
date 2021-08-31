using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneNavigator: MonoBehaviour
{
    // Start is called before the first frame update
    public void GoToChangePassword()
    {
        SceneManager.LoadScene(13);
    }
   public void GoToSignup()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToSignIN()
    {
        SceneManager.LoadScene(2);
    }
    public void GoToMain()
    {
        SceneManager.LoadScene(0);
    }
    public void SignIn()
    {
        SceneManager.LoadScene(3);
    }
    public void SignUP()
    {
        GoToSignIN();
    }
    public void SelectRoom()
    {
        SceneManager.LoadScene(3);
    }

    public void GoToProfile()
    {
        SceneManager.LoadScene(7);
    }

    public void GoToDeposit()
    {
        SceneManager.LoadScene(8);
    }

    public void GoToWithdraw()
    {
        SceneManager.LoadScene(10);
    }

    public void DepositHistory()
    {
        SceneManager.LoadScene(9);
    }
    public void WithdrawHistory()
    {
        SceneManager.LoadScene(11);
    }
    public void GoToClassic()
    {
        SceneManager.LoadScene(4);
    }
    public void GoToPrivate()
    {
        SceneManager.LoadScene(5);
    }
    public void GoToProfileSettings()
    {
        SceneManager.LoadScene(12);
    }
    
}

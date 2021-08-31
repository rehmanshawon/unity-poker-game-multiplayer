using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Text PlayerDisplay;
    private void Start()
    {
        if(DBManager.LoggedIn)
        {
            PlayerDisplay.text = DBManager.username;
        }
    }

    // Update is called once per frame
    
}

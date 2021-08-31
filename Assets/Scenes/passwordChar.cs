using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class passwordChar : MonoBehaviour    
{
    public InputField password;
    // Start is called before the first frame update
    void Start()
    {
    password.contentType = InputField.ContentType.Password;
}

    // Update is called once per frame
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MethodList : MonoBehaviour
{
    public List<string> Methods = new List<string>() { "Payment Method", "Method01", "Method02", "Method03", "Method04", "Method05" };
    
    public Dropdown ddMethod;

    
    // Start is called before the first frame update
    void Start()
    {
        PopulateMethodList();
    }
    void PopulateMethodList()
    {
        ddMethod.AddOptions(Methods);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}




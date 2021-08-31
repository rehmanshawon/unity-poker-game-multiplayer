using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyList : MonoBehaviour
{
    List<string> Currencies = new List<string>() {"Your Currency", "Bangladesh Taka - BDT","India Rupees - INR",
"United Kingdom Pounds - GBP","United States Dollars - USD"};
    public Text selectedCurrency;
    public Dropdown ddCurrency;
    public void Currency_Changed(int index)
    {
        selectedCurrency.text = Currencies[index];
    }
    void Start()
    {
        PopulateCurrencyList();
    }
    void PopulateCurrencyList()
    {
        ddCurrency.AddOptions(Currencies);
    }

    // Update is called once per frame

}

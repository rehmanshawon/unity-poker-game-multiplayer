using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SignUP : MonoBehaviour
{
  public  List<string> Countries = new List<string>() {"Your Country","Afghanistan","Albania","Algeria","American Samoa","Andorra","Angola","Anguilla","Antarctica","Antigua and Barbuda","Argentina","Armenia",
"Aruba","Australia","Austria","Azerbaijan","Bahamas","Bahrain","Bangladesh","Barbados","Belarus","Belgium","Belize","Benin","Bermuda","Bhutan","Bolivia","Bosnia and Herzegovina","Botswana","Bouvet Island",
"Brazil","British Indian Ocean Territory","Brunei Darussalam","Bulgaria","Burkina Faso","Burundi","Cambodia","Cameroon","Canada","Cape Verde","Cayman Islands","Central African Republic","Chad","Chile",
"China","Christmas Island","Cocos (Keeling) Islands","Colombia","Comoros","Congo","Congo", "Cook Islands","Costa Rica","Cote D'ivoire","Croatia","Cuba","Cyprus","Czech Republic","Denmark","Djibouti","Dominica",
"Dominican Republic","Ecuador","Egypt","El Salvador","Equatorial Guinea","Eritrea","Estonia","Ethiopia","Falkland Islands (Malvinas)","Faroe Islands","Fiji","Finland","France","French Guiana","French Polynesia",
"French Southern Territories","Gabon","Gambia","Georgia","Germany","Ghana","Gibraltar","Greece","Greenland","Grenada","Guadeloupe","Guam","Guatemala","Guinea","Guinea-bissau","Guyana","Haiti","Heard Island and Mcdonald Islands",
"Holy See (Vatican City State)","Honduras","Hong Kong","Hungary","Iceland","India","Indonesia","Iran, Islamic Republic of","Iraq","Ireland","Israel","Italy","Jamaica","Japan","Jordan","Kazakhstan","Kenya",
"Kiribati","Korea, Democratic People's Republic of","Korea, Republic of","Kuwait","Kyrgyzstan","Lao People's Democratic Republic","Latvia","Lebanon","Lesotho","Liberia","Libyan Arab Jamahiriya","Liechtenstein",
"Lithuania","Luxembourg","Macao","Macedonia, The Former Yugoslav Republic of","Madagascar","Malawi","Malaysia","Maldives","Mali","Malta","Marshall Islands","Martinique","Mauritania","Mauritius","Mayotte",
"Mexico","Micronesia, Federated States of","Moldova, Republic of","Monaco","Mongolia","Montserrat","Morocco","Mozambique","Myanmar","Namibia","Nauru","Nepal","Netherlands","Netherlands Antilles","New Caledonia",
"New Zealand","Nicaragua","Niger","Nigeria","Niue","Norfolk Island","Northern Mariana Islands","Norway","Oman","Pakistan","Palau","Palestinian Territory, Occupied","Panama","Papua New Guinea","Paraguay",
"Peru","Philippines","Pitcairn","Poland","Portugal","Puerto Rico","Qatar","Reunion","Romania","Russian Federation","Rwanda","Saint Helena","Saint Kitts and Nevis","Saint Lucia","Saint Pierre and Miquelon",
"Saint Vincent and The Grenadines","Samoa","San Marino","Sao Tome and Principe","Saudi Arabia","Senegal","Serbia and Montenegro","Seychelles","Sierra Leone","Singapore","Slovakia","Slovenia","Solomon Islands",
"Somalia","South Africa","South Georgia and The South Sandwich Islands","Spain","Sri Lanka","Sudan","Suriname","Svalbard and Jan Mayen","Swaziland","Sweden","Switzerland","Syrian Arab Republic","Taiwan, Province of China",
"Tajikistan","Tanzania, United Republic of","Thailand","Timor-leste","Togo","Tokelau","Tonga","Trinidad and Tobago","Tunisia","Turkey","Turkmenistan","Turks and Caicos Islands","Tuvalu","Uganda","Ukraine",
"United Arab Emirates","United Kingdom","United States","United States Minor Outlying Islands","Uruguay","Uzbekistan","Vanuatu","Venezuela","Viet Nam","Virgin Islands, British","Virgin Islands, U.S.","Wallis and Futuna",
"Western Sahara","Yemen","Zambia","Zimbabwe"};

    public List<string> Currencies = new List<string>() {"Your Currency", "Bangladesh Taka - BDT","India Rupees - INR",
"United Kingdom Pounds - GBP","United States Dollars - USD"};

    public List<string> Clubs = new List<string>() { "Your Club", "Club A", "Club B", "Club C" };

    readonly string postURL = "kopotron.com/Signup.php";
    public InputField PlayerName;
    public InputField Email;
    public InputField Password;
    public InputField passwordCon;
    public InputField Phone;
    public Dropdown Country;
    public InputField Sponsor;
    public Dropdown Club;
    public Dropdown Currency;
    public Toggle Agree;
    public Button SubmitButton;
    public GameObject pnlOK;
    public Text DialogMsg;
    public void CallSignup()
    {
        //if(PlayerName.text.Length<6)
        //{
        //    pnlOK.SetActive(true);
        //    SubmitButton.interactable = false;
         //   return false;
        //}
        StartCoroutine(SignUp());
        //return true;
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

    public void EmailOK(string email)
    {
        if(!IsValidEmail(email))
        {
            DialogMsg.text = "Not a valid email format! Make sure address format is okay.";
            pnlOK.SetActive(true);
            SubmitButton.interactable = false;
        }
    }

    public void PswdOK(string pswd)
    {
        if(pswd.Length<6)
        {
            DialogMsg.text = "Password must have minimum 6 digits";
            pnlOK.SetActive(true);
            SubmitButton.interactable = false;

        }
    }
    public void PswdMatch(string pswd)
    {
        if(pswd!=Password.text)
        {
            DialogMsg.text = "Passwords dont match!";
            pnlOK.SetActive(true);
            SubmitButton.interactable = false;
        }
    }

    public void HideDialog()
    {
        pnlOK.SetActive(false);
    }
    // Start is called before the first frame update
    
    IEnumerator SignUp()
    {


        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        //WWWForm form = new WWWForm();
        formData.Add(new MultipartFormDataSection("PlayerName", PlayerName.text.ToLower()));
        formData.Add(new MultipartFormDataSection("Email", Email.text));
        formData.Add(new MultipartFormDataSection("Password", Password.text));
        if(Phone.text.Length>0)
        {
            formData.Add(new MultipartFormDataSection("Phone", Phone.text));
        }
        else
        {
            formData.Add(new MultipartFormDataSection("Phone", "No Number"));
        }
        if(Country.value==0)
        {
            formData.Add(new MultipartFormDataSection("Country", "India"));
        }
        else
        {
            formData.Add(new MultipartFormDataSection("Country",Countries[Country.value]));
        }
        if(Sponsor.text.Length>0)
        {
            formData.Add(new MultipartFormDataSection("Sponsor", Sponsor.text));
        }
        else
        {
            formData.Add(new MultipartFormDataSection("Sponsor", "Admin"));
        }
        if (Club.value == 0)
        {
            formData.Add(new MultipartFormDataSection("Club", "Admin"));
        }
        else
        {
            formData.Add(new MultipartFormDataSection("Club", Clubs[Club.value]));
        }
        if(Currency.value==0)
        {
            formData.Add(new MultipartFormDataSection("Currency", "Rupee"));
        }
        else
        {
            formData.Add(new MultipartFormDataSection("Currency", Currencies[Currency.value]));
        }
        
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
            if(www.downloadHandler.text!= "0")
            {
                DialogMsg.text = www.downloadHandler.text;
                pnlOK.SetActive(true);
                //SubmitButton.interactable = false;
            }
            else
            {
                DBManager.username = PlayerName.text;
                UnityEngine.SceneManagement.SceneManager.LoadScene(3);
            }
            
        }

        
    }

    public void VerifyInputs()
    {
        if (Agree.isOn && Password.text==passwordCon.text && IsValidEmail(Email.text))
        {
            SubmitButton.interactable = (PlayerName.text.Length >= 6 && Password.text.Length>=6 && Email.text.Length>=10);
        }
        
    }

    public bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            // Normalize the domain
            email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200));

            // Examines the domain part of the email and normalizes it.
            string DomainMapper(Match match)
            {
                // Use IdnMapping class to convert Unicode domain names.
                var idn = new IdnMapping();

                // Pull out and process domain name (throws ArgumentException on invalid)
                var domainName = idn.GetAscii(match.Groups[2].Value);

                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException e)
        {
            return false;
        }
        catch (ArgumentException e)
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(email,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
    

}

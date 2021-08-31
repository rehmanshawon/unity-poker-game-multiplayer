using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClubList : MonoBehaviour
{
    List<string> Clubs = new List<string>() {"Your Club","Club A","Club B","Club C"};
    public Text selectedClub;
    public Dropdown ddClub;
    public void Club_Changed(int index)
    {
        selectedClub.text = Clubs[index];
    }

    // Start is called before the first frame update
    void Start()
    {
        PopulateClubList();
    }

    void PopulateClubList()
    {
        ddClub.AddOptions(Clubs);
    }
    // Update is called once per frame

}

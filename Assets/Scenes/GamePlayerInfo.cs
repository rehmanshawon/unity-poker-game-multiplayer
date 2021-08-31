using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GamePlayerInfo 
{
    // Start is called before the first frame update
    public int GameId;
    public int RoomId;
    public string PlayerName;
    public int Card1;
    public int Card2;
    public int Card3;
    public int CardValue;
    
    

    public static GamePlayerInfo CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<GamePlayerInfo>(jsonString);
    }
}

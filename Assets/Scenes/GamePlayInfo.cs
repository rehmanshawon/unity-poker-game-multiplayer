using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GamePlayInfo
{
    public int PlayId;
    public int RoomId;
    public string LastPlayer;
    public int ChaalCoin;
    public int PotCoin;
    public string PlayType;

    public static GamePlayInfo CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<GamePlayInfo>(jsonString);
    }

}
    


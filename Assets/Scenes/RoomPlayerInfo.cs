using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomPlayerInfo
{
    public int RoomId;
    public int PlayerCount;
    public int GameOn;
    public string Seat1;
    public string Seat2;
    public string Seat3;
    public string Seat4;
    public string Seat5;
    public string Seat1Icon;
    public string Seat2Icon;
    public string Seat3Icon;
    public string Seat4Icon;
    public string Seat5Icon;
    public string DealSerial1;
    public string DealSerial2;
    public string DealSerial3;
    public string DealSerial4;
    public string DealSerial5;
    public string ActivePlayer;
    //public int DealDone;

    public static RoomPlayerInfo GetRoomInfoFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<RoomPlayerInfo>(jsonString);
    }

}

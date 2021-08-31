//using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Globalization;
using System.Linq;
//using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
//using Newtonsoft.Json;
//using HybridWebSocket;
//using System.Text;
using UnityEngine.SceneManagement;
using SocketIO;
//using System;
//using UnityEditorInternal;
[System.Serializable]


public class playerInfo
{
    public string socketId;
    public string playerName;
    public string playerPic;
    public string roomName;
    public string seatNo;
    public string playingStatus;
}
public class StartGameData
{
    public string numPlayers;
}
public class BlindInfo
{
    public string playerName;
    public string amount;
    public string board;
    public string next;
}
public class BreakInfo
{
    
    public string board;
}
public class PlayerCards
{
    public string player_1;
    public string cards1;
    public string player_2;
    public string cards2;
    public string player_3;
    public string cards3;
    public string player_4;
    public string cards4;
    public string player_5;
    public string cards5;
}
public class PlayingPlayerCards
{
    public string playerName;
    public string playerCard;
    public string playingStatus;
}
public class PackData
{
    public string playerName;
    public string nextPlayer;
}
public class WinnerData
{
    public string playerName;
    public string winBy;
}
public class ShowData
{
    public string playerName;
    public string targetPlayer;
    public string boardMoney;
    public string winnerPlayer;
    public string winRank;
}
public class SideShower
{
    public string playerName;
    public string targetPlayer;
    public string playerCards;
}
public class SideShowReject
{
    public string playerName;
}
public class SideShowReturn
{
    public string targetPlayer;
    public string playerCards;
    public string returningPlayer;
}
public class NextPlayer
{
    public string nextPlayer;
}
public class SeenPlayer
{
    public string playerName;
}

public class ChatData
{
    public string playerName;
    public string chatText;
}

public class TipsData
{
    public string playerName;
}
    
public class JoinClassicRoom : MonoBehaviour
{
    private SocketIOComponent socket;
    bool socketConnected = false;
    static UnityWebRequestAsyncOperation request;
    //bool newcomer;
    //string newcomerName, newcomerImage, newcomerSeat;
    //string strAllCards = "";
    //string strAllPlayers = "";
    //int gPlayerCount = 1;
    //int gBreaker = 0;
    //bool GotCards = false;
    //bool wait = false;
    string sideshow = "";
    string ssPlayer = "";
    string ssCards = "";
    public GameObject pnlAnnounce;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    public GameObject Player5;
    public GameObject pSeat1;
    public GameObject pSeat2;
    public GameObject pSeat3;
    public GameObject pSeat4;
    public GameObject pSeat5;

    public GameObject P1PotCoin;
    public GameObject P2PotCoin;
    public GameObject P3PotCoin;
    public GameObject P4PotCoin;
    public GameObject P5PotCoin;
    private Animator P1Coin, P2Coin, P3Coin, P4Coin, P5Coin;
    public GameObject Clock1, Clock2, Clock3, Clock4, Clock5;
    public GameObject P1Clock;
    public GameObject P2Clock;
    public GameObject P3Clock;
    public GameObject P4Clock;
    public GameObject P5Clock;
    private Animator pClock1, pClock2, pClock3, pClock4, pClock5;

    public GameObject P1WinFX, P2WinFX, P3WinFX, P4WinFX, P5WinFX;
    private Animator pWin1, pWin2, pWin3, pWin4, pWin5;

    public GameObject GamePlayPanel;
    private Animator playPanel;
    public Button btnPlus,btnMinus;
    public GameObject btnSee;
    public Button btnBlind;
    public Button btnPack, btnShow;
    public Text txtBlind;
    public Text txtShow;
    public Text txtSee;
    //private bool Seen = false;
    private int BlindLimit = 0;

    public GameObject ShowCardsP2;
    public GameObject ShowCardsP3;
    public GameObject ShowCardsP4;
    public GameObject ShowCardsP5;

    public Button btnLobby;

    // Message Panel
    public GameObject pnlMessage;
    public GameObject pnlText1,pnlText2,pnlText3,pnlText4,pnlText5;
    public Text pText1,pText2,pText3,pText4,pText5;
    //player picture
    public Image imgP1, imgP2, imgP3, imgP4, imgP5;
    public Image P1C1;
    public Image P1C2;
    public Image P1C3;
    public Image P2C1;
    public Image P2C2;
    public Image P2C3;
    public Image P3C1;
    public Image P3C2;
    public Image P3C3;
    public Image P4C1;
    public Image P4C2;
    public Image P4C3;
    public Image P5C1;
    public Image P5C2;
    public Image P5C3;
    //private Animator ap1c1, ap1c2, ap1c3, ap2c1, ap2c2, ap2c3, ap3c1, ap3c2, ap3c3, ap4c1, ap4c2, ap4c3, ap5c1, ap5c2, ap5c3;
    //public Text nP1C1;
    //public Text nP1C2;
    //public Text nP1C3;
    //public Text nP2C1;
    //public Text nP2C2;
    //public Text nP2C3;
    //public Text nP3C1;
    //public Text nP3C2;
    //public Text nP3C3;
    //public Text nP4C1;
    //public Text nP4C2;
    //public Text nP4C3;
    //public Text nP5C1;
    //public Text nP5C2;
    //public Text nP5C3;
    private Sprite sP1C1;
    private Sprite sP1C2;
    private Sprite sP1C3;
    private Sprite sP2C1;
    private Sprite sP2C2;
    private Sprite sP2C3;
    private Sprite sP3C1;
    private Sprite sP3C2;
    private Sprite sP3C3;
    private Sprite sP4C1;
    private Sprite sP4C2;
    private Sprite sP4C3;
    private Sprite sP5C1;
    private Sprite sP5C2;
    private Sprite sP5C3;
    public Image iP2C1;
    public Image iP2C2;
    public Image iP2C3;
    public Image iP3C1;
    public Image iP3C2;
    public Image iP3C3;
    public Image iP4C1;
    public Image iP4C2;
    public Image iP4C3;
    public Image iP5C1;
    public Image iP5C2;
    public Image iP5C3;

    public Text Seat1;
    public Text Seat2;
    public Text Seat3;
    public Text Seat4;
    public Text Seat5;
    public Text ps1, ps2, ps3, ps4, ps5,ss1,ss2,ss3,ss4,ss5,rn1,rn2,rn3,rn4,rn5;
    public Text txtAmount;
    //private const int amountLimit = 256;
    public Text txtPotCoin;
    public Text txtThrowCoin;

    public Text txtThrowCoin2;
    public Text txtThrowCoin3;
    public Text txtThrowCoin4;
    public Text txtThrowCoin5;

    public GameObject ShowChaal2, ShowChaal3, ShowChaal4, ShowChaal5;
    private Animator chaal2, chaal3, chaal4, chaal5;
    public Text txtChaal2, txtChaal3, txtChaal4, txtChaal5;

    public Text txtMyCoin;

    public Text txtPacked1, txtPacked2, txtPacked3, txtPacked4, txtPacked5;
    public Text txtLastCoin2, txtLastCoin3, txtLastCoin4, txtLastCoin5;

    private string[] cList1= new string[] { "0", "0", "0" };
    private string[] cList2 = new string[] { "0", "0", "0" };
    private string[] cList3 = new string[] { "0", "0", "0" };
    private string[] cList4 = new string[] { "0", "0", "0" };
    private string[] cList5 = new string[] { "0", "0", "0" };
    public GameObject pnlOK;
    public GameObject pnlSide;
    public Text txtSide;
    public Text DialogMsg;
    public Text DialogMsg2;
    public Text RoomId;
    //private string mySeat = "";
    //private bool IamDealer = false;
    //private float update;
    private bool destroy;
    //private bool DealDone=false;
    //private bool DealMessageSent = false;
    //private string[] DealSerialCopy = new string[] { "0", "0", "0", "0","0" };
    // private int serial=1;
    readonly string JoinRoomURL = "kopotron.com/CreateJoinRoom.php";
    readonly string LeaveRoomURL = "kopotron.com/LeaveRoom.php";
    //readonly string SaveDealStateURL = "kopotron.com/SaveDealState.php";
    readonly string SaveCardURL = "kopotron.com/SaveCards.php";
    //readonly string SaveActivePlayerURL = "kopotron.com/SaveActivePlayer.php";
    //readonly string SaveCurrentChaalURL = "kopotron.com/SaveGamePlay.php";
    GameManager MyGame = new GameManager();
    //RoomPlayerInfo myRoomInfo = new RoomPlayerInfo();
    public RoomSeats myRoom = new RoomSeats();
    //private bool mePlayed = false;
    //private bool InitPotMoney = false;

    //WebSocket ws;
    string json;
    //string retJson;
    bool newMessage = false;
    PlayerText Mine=new PlayerText();
    //PlayerText OtherPlayer = new PlayerText();
    //private int RoomPlayerCount=0;
    private string tmpCards1 = "", tmpCards2 = "", tmpCards3 = "", tmpCards4 = "", tmpCards5 = "";
    public Text txtAnnounce;
    //private bool PotFinished=false;
    //private bool DealFinished = false;
    //private bool CardFinished = false;
    
   // private bool p1Card1 = false, p2Card1 = false, p3Card1 = false, p4Card1 = false, p5Card1 = false;
   // private bool p1Card2 = false, p2Card2 = false, p3Card2 = false, p4Card2 = false, p5Card2 = false;
   // private bool p1Card3 = false, p2Card3 = false, p3Card3 = false, p4Card3 = false, p5Card3 = false;
    //string[] tmpG = new string[] { "0", "0" };
    //string[] myCards = new string[] { "0", "0", "0" };
    private bool BackToLobby=false;
    // all card positions
    //Vector3 p1c1
    // ---------- All Audios---------------
    public AudioSource GameSoundFx;
    public AudioClip ClockStart;
    public AudioClip BlindSound, CardDealSound, BootMoneySound,NewPlayerSound,PackSound,ShowSound,SideShowSound,WinningSound;

  // private int SendingCards=0;
   // private bool p1Finished,p2Finished,p3Finished,p4Finished,p5Finished;
    private bool FlashMessage = false;
   // private int nPlayers = 0;

    playerInfo myInfo = new playerInfo();
    void Start()
    {
        destroy = false;
        

        pClock1 = P1Clock.GetComponent<Animator>();
        pClock2 = P2Clock.GetComponent<Animator>();
        pClock3 = P3Clock.GetComponent<Animator>();
        pClock4 = P4Clock.GetComponent<Animator>();
        pClock5 = P5Clock.GetComponent<Animator>();
        pWin1 = P1WinFX.GetComponent<Animator>();
        pWin2 = P2WinFX.GetComponent<Animator>();
        pWin3 = P3WinFX.GetComponent<Animator>();
        pWin4 = P4WinFX.GetComponent<Animator>();
        pWin5 = P5WinFX.GetComponent<Animator>();
        playPanel = GamePlayPanel.GetComponent<Animator>();
        P1Coin = P1PotCoin.GetComponent<Animator>();
        P2Coin = P2PotCoin.GetComponent<Animator>();
        P3Coin = P3PotCoin.GetComponent<Animator>();
        P4Coin = P4PotCoin.GetComponent<Animator>();
        P5Coin = P5PotCoin.GetComponent<Animator>();
        /*
        ap1c1 = P1C1.GetComponent<Animator>();
        ap1c2 = P1C2.GetComponent<Animator>();
        ap1c3 = P1C3.GetComponent<Animator>();
        ap2c1 = P2C1.GetComponent<Animator>();
        ap2c2 = P2C2.GetComponent<Animator>();
        ap2c3 = P2C3.GetComponent<Animator>();
        ap3c1 = P3C1.GetComponent<Animator>();
        ap3c2 = P3C2.GetComponent<Animator>();
        ap3c3 = P3C3.GetComponent<Animator>();
        ap4c1 = P4C1.GetComponent<Animator>();
        ap4c2 = P4C2.GetComponent<Animator>();
        ap4c3 = P4C3.GetComponent<Animator>();
        ap5c1 = P5C1.GetComponent<Animator>();
        ap5c2 = P5C2.GetComponent<Animator>();
        ap5c3 = P5C3.GetComponent<Animator>();
        */
        chaal2 = ShowChaal2.GetComponent<Animator>();
        chaal3 = ShowChaal3.GetComponent<Animator>();
        chaal4 = ShowChaal4.GetComponent<Animator>();
        chaal5 = ShowChaal5.GetComponent<Animator>();
        Seat1.text = "EMPTY";
        Seat2.text = "EMPTY";
        Seat3.text = "EMPTY";
        Seat4.text = "EMPTY";
        Seat5.text = "EMPTY";
        ps1.text = "n";
        ps2.text = "n";
        ps3.text = "n";
        ps4.text = "n";
        ps5.text = "n";
        ss1.text = "n";
        ss2.text = "n";
        ss3.text = "n";
        ss4.text = "n";
        ss5.text = "n";
        rn1.text = "n";
        rn2.text = "n";
        rn3.text = "n";
        rn4.text = "n";
        rn5.text = "n";
        txtPacked1.text = "Watching";
        // new socket io code
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();

        socket.On("open", TestOpen);
        socket.On("room", CheckRoom);
        socket.On("error", TestError);
        socket.On("close", TestClose);
        socket.On("NewPlayer", AddNewPlayer);
        socket.On("OldPlayer", AddOldPlayer);
        socket.On("Quit", DeletePlayer);
        socket.On("next", NextPlayerClock);
        socket.On("wait", WaitForDealToFinish);
        socket.On("Start", StartNewGame);
        socket.On("cards", OnGetCards);
        socket.On("playing", OnGetPlayingPlayerCards);
        socket.On("blind", _OnBlind);        
        socket.On("chaal", _OnChaal);
        socket.On("break", OnReachMaxLimit);
        socket.On("seen", _OnSeen);
        socket.On("tips", _OnTips);
        socket.On("pack", _OnPack);
        socket.On("show", _OnShow);
        socket.On("sideshow", _OnSideShow);
        socket.On("youpack", OnSideShowReturn);
        socket.On("reject", OnSideShowReject);
        socket.On("chat", _OnChat);
        socket.On("winner", _OnWinner);        
        StartCoroutine("JoinRoomClassic");
        //StartCoroutine(JoinClassic());
        //StartCoroutine(PullMessage());

    }

    public void OnGetCards(SocketIOEvent e)
    {
        cList1 = new string[] { "0", "0", "0" };
        cList2 = new string[] { "0", "0", "0" };
        cList3 = new string[] { "0", "0", "0" };
        cList4 = new string[] { "0", "0", "0" };
        cList5 = new string[] { "0", "0", "0" };
        PlayerCards AllCards = new PlayerCards();
        AllCards = JsonUtility.FromJson<PlayerCards>(e.data.ToString());
        Debug.Log(AllCards.player_1+"|"+ AllCards.player_2 + "|" + AllCards.player_3 + "|" + AllCards.player_4 + "|" + AllCards.player_5);
        Debug.Log(AllCards.cards1 + "|" + AllCards.cards2 + "|" + AllCards.cards3 + "|" + AllCards.cards4 + "|" + AllCards.cards5);
        if (Seat1.text == AllCards.player_1)
        {
            cList1 = AllCards.cards1.Split(',');
            MyGame.FirstPlayerCardWeight = SavePlayerCardValue(int.Parse(cList1[0]), int.Parse(cList1[1]), int.Parse(cList1[2]));
        }
        else if (Seat1.text== AllCards.player_2)
        {
            cList1 = AllCards.cards2.Split(',');
            MyGame.FirstPlayerCardWeight = SavePlayerCardValue(int.Parse(cList1[0]), int.Parse(cList1[1]), int.Parse(cList1[2]));
        }
        else if (Seat1.text == AllCards.player_3)
        {
            cList1 = AllCards.cards3.Split(',');
            MyGame.FirstPlayerCardWeight = SavePlayerCardValue(int.Parse(cList1[0]), int.Parse(cList1[1]), int.Parse(cList1[2]));

        }
        else if (Seat1.text == AllCards.player_4)
        {
            cList1 = AllCards.cards4.Split(',');
            MyGame.FirstPlayerCardWeight = SavePlayerCardValue(int.Parse(cList1[0]), int.Parse(cList1[1]), int.Parse(cList1[2]));
        }
        else if (Seat1.text == AllCards.player_5)
        {
            cList1 = AllCards.cards5.Split(',');
            MyGame.FirstPlayerCardWeight = SavePlayerCardValue(int.Parse(cList1[0]), int.Parse(cList1[1]), int.Parse(cList1[2]));
        }

        if(Seat2.text!="EMPTY")
        {
            if (Seat2.text == AllCards.player_1)
            {
                cList2 = AllCards.cards1.Split(',');
                MyGame.SecondPlayerCardWeight = SavePlayerCardValue(int.Parse(cList2[0]), int.Parse(cList2[1]), int.Parse(cList2[2]));
            }
            else if (Seat2.text == AllCards.player_2)
            {
                cList2 = AllCards.cards2.Split(',');
                MyGame.SecondPlayerCardWeight = SavePlayerCardValue(int.Parse(cList2[0]), int.Parse(cList2[1]), int.Parse(cList2[2]));
            }
            else if (Seat2.text == AllCards.player_3)
            {
                cList2 = AllCards.cards3.Split(',');
                MyGame.SecondPlayerCardWeight = SavePlayerCardValue(int.Parse(cList2[0]), int.Parse(cList2[1]), int.Parse(cList2[2]));

            }
            else if (Seat2.text == AllCards.player_4)
            {
                cList2 = AllCards.cards4.Split(',');
                MyGame.SecondPlayerCardWeight = SavePlayerCardValue(int.Parse(cList2[0]), int.Parse(cList2[1]), int.Parse(cList2[2]));
            }
            else if (Seat2.text == AllCards.player_5)
            {
                cList2 = AllCards.cards5.Split(',');
                MyGame.SecondPlayerCardWeight = SavePlayerCardValue(int.Parse(cList2[0]), int.Parse(cList2[1]), int.Parse(cList2[2]));
            }
        }
        if (Seat3.text != "EMPTY")
        {
            if (Seat3.text == AllCards.player_1)
            {
                cList3 = AllCards.cards1.Split(',');
                MyGame.ThirdPlayerCardWeight = SavePlayerCardValue(int.Parse(cList3[0]), int.Parse(cList3[1]), int.Parse(cList3[2]));
            }
            else if (Seat3.text == AllCards.player_2)
            {
                cList3 = AllCards.cards2.Split(',');
                MyGame.ThirdPlayerCardWeight = SavePlayerCardValue(int.Parse(cList3[0]), int.Parse(cList3[1]), int.Parse(cList3[2]));
            }
            else if (Seat3.text == AllCards.player_3)
            {
                cList3 = AllCards.cards3.Split(',');
                MyGame.ThirdPlayerCardWeight = SavePlayerCardValue(int.Parse(cList3[0]), int.Parse(cList3[1]), int.Parse(cList3[2]));

            }
            else if (Seat3.text == AllCards.player_4)
            {
                cList3 = AllCards.cards4.Split(',');
                MyGame.ThirdPlayerCardWeight = SavePlayerCardValue(int.Parse(cList3[0]), int.Parse(cList3[1]), int.Parse(cList3[2]));
            }
            else if (Seat3.text == AllCards.player_5)
            {
                cList3 = AllCards.cards5.Split(',');
                MyGame.ThirdPlayerCardWeight = SavePlayerCardValue(int.Parse(cList3[0]), int.Parse(cList3[1]), int.Parse(cList3[2]));
            }
        }
        if (Seat4.text != "EMPTY")
        {
            if (Seat4.text == AllCards.player_1)
            {
                cList4 = AllCards.cards1.Split(',');
                MyGame.FourthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList4[0]), int.Parse(cList4[1]), int.Parse(cList4[2]));
            }
            else if (Seat4.text == AllCards.player_2)
            {
                cList4 = AllCards.cards2.Split(',');
                MyGame.FourthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList4[0]), int.Parse(cList4[1]), int.Parse(cList4[2]));
            }
            else if (Seat4.text == AllCards.player_3)
            {
                cList4 = AllCards.cards3.Split(',');
                MyGame.FourthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList4[0]), int.Parse(cList4[1]), int.Parse(cList4[2]));

            }
            else if (Seat4.text == AllCards.player_4)
            {
                cList4 = AllCards.cards4.Split(',');
                MyGame.FourthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList4[0]), int.Parse(cList4[1]), int.Parse(cList4[2]));
            }
            else if (Seat4.text == AllCards.player_5)
            {
                cList4 = AllCards.cards5.Split(',');
                MyGame.FourthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList4[0]), int.Parse(cList4[1]), int.Parse(cList4[2]));
            }
        }
        if (Seat5.text != "EMPTY")
        {
            if (Seat5.text == AllCards.player_1)
            {
                cList5 = AllCards.cards1.Split(',');
                MyGame.FifthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList5[0]), int.Parse(cList5[1]), int.Parse(cList5[2]));
            }
            else if (Seat5.text == AllCards.player_2)
            {
                cList5 = AllCards.cards2.Split(',');
                MyGame.FifthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList5[0]), int.Parse(cList5[1]), int.Parse(cList5[2]));
            }
            else if (Seat5.text == AllCards.player_3)
            {
                cList5 = AllCards.cards3.Split(',');
                MyGame.FifthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList5[0]), int.Parse(cList5[1]), int.Parse(cList5[2]));

            }
            else if (Seat5.text == AllCards.player_4)
            {
                cList5 = AllCards.cards4.Split(',');
                MyGame.FifthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList5[0]), int.Parse(cList5[1]), int.Parse(cList5[2]));
            }
            else if (Seat5.text == AllCards.player_5)
            {
                cList5 = AllCards.cards5.Split(',');
                MyGame.FifthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList5[0]), int.Parse(cList5[1]), int.Parse(cList5[2]));
            }
        }
    }
    public void WaitForDealToFinish(SocketIOEvent e)
    {
        txtAnnounce.text = "Card dealing is going on. Please wait!";
    }
    public void OnGetPlayingPlayerCards(SocketIOEvent e)
    {
        PlayingPlayerCards playingPlayer = new PlayingPlayerCards();
        playingPlayer = JsonUtility.FromJson<PlayingPlayerCards>(e.data.ToString());
        if(playingPlayer.playingStatus=="Playing")
        {
            if(Seat2.text==playingPlayer.playerName)
            {
                txtPacked2.text = playingPlayer.playingStatus;
                cList2 = playingPlayer.playerCard.Split(',');
            }
            else if (Seat3.text == playingPlayer.playerName)
            {
                txtPacked3.text = playingPlayer.playingStatus;
                cList3 = playingPlayer.playerCard.Split(',');
            }
            else if (Seat4.text == playingPlayer.playerName)
            {
                txtPacked4.text = playingPlayer.playingStatus;
                cList4 = playingPlayer.playerCard.Split(',');
            }
            if (Seat5.text == playingPlayer.playerName)
            {
                txtPacked5.text = playingPlayer.playingStatus;
                cList5 = playingPlayer.playerCard.Split(',');
            }
        }
        else
        {
            if (Seat2.text == playingPlayer.playerName)
            {
                txtPacked2.text = playingPlayer.playingStatus;
                
            }
            else if (Seat3.text == playingPlayer.playerName)
            {
                txtPacked3.text = playingPlayer.playingStatus;
                
            }
            else if (Seat4.text == playingPlayer.playerName)
            {
                txtPacked4.text = playingPlayer.playingStatus;
                
            }
            if (Seat5.text == playingPlayer.playerName)
            {
                txtPacked5.text = playingPlayer.playingStatus;
                
            }
        }
    }
    public void _OnBlind(SocketIOEvent e)
    {
        GameSoundFx.PlayOneShot(BlindSound);
        BlindInfo blindPlayer = new BlindInfo();
        blindPlayer = JsonUtility.FromJson<BlindInfo>(e.data.ToString());
        //Anouce the Action
        txtAnnounce.text = blindPlayer.playerName + " has played a BLIND";
        
        //--if (OtherPlayer.OC == OpCodes.Chaal)
        //--    txtAnnounce.text = OtherPlayer.PN + " has played a CHAAL";
        pnlAnnounce.SetActive(true);
        // If I'm a watcher, I should enable potcoin
        txtPotCoin.enabled = true;
        // Find the player's seat and show the coin throw animation and other info
        if (Seat2.text == blindPlayer.playerName)
        {
            txtThrowCoin2.text = blindPlayer.amount;
            txtLastCoin2.text = blindPlayer.amount;
            //P2Coin.Play("ThrowCoin");
            P2PotCoin.SetActive(false);
            P2PotCoin.SetActive(true);
            P2Coin.Play("PotCoinP2");
            txtChaal2.text = "BLIND";
            //chaal2.Play("HideChaal");
            chaal2.Play("ShowChaal");
            // Stop that player's clock
            pClock2.Play("Start");
            Clock2.SetActive(false);
        }
        else if (Seat3.text == blindPlayer.playerName)
        {
            txtThrowCoin3.text = blindPlayer.amount;
            txtLastCoin3.text = blindPlayer.amount;
            //P3Coin.Play("ThrowCoin");
            P3PotCoin.SetActive(false);
            P3PotCoin.SetActive(true);
            P3Coin.Play("PotCoinP3");
            txtChaal3.text =  "BLIND";
            //chaal3.Play("HideChaal");
            chaal3.Play("ShowChaal");
            // Stop that player's clock
            pClock3.Play("Start");
            Clock3.SetActive(false);
        }
        else if (Seat4.text == blindPlayer.playerName)
        {
            txtThrowCoin4.text = blindPlayer.amount;
            txtLastCoin4.text = blindPlayer.amount;
            //P4Coin.Play("ThrowCoin");
            P4PotCoin.SetActive(false);
            P4PotCoin.SetActive(true);
            P4Coin.Play("PotCoinP4");
            txtChaal4.text =  "BLIND";
            //chaal4.Play("HideChaal");
            chaal4.Play("ShowChaal");
            // Stop that player's clock
            pClock4.Play("Start");
            Clock4.SetActive(false);
        }
        else if (Seat5.text == blindPlayer.playerName)
        {
            txtThrowCoin5.text = blindPlayer.amount;
            txtLastCoin5.text = blindPlayer.amount;
            //P5Coin.Play("ThrowCoin");
            P5PotCoin.SetActive(false);
            P5PotCoin.SetActive(true);
            P5Coin.Play("PotCoinP5");
            txtChaal5.text = "BLIND";
            //chaal5.Play("HideChaal");
            chaal5.Play("ShowChaal");
            // Stop that player's clock
            pClock5.Play("Start");
            Clock5.SetActive(false);
        }
        // Add coin to the pot coin amount
        // Total pot coin is in the board money
        txtPotCoin.text = blindPlayer.board;

        // Start Next Player's Clock
        if (blindPlayer.next == Seat2.text)
        {
            //pClock2.Play("Start");
            Clock2.SetActive(true);
            pClock2.Play("Clock2");
        }
        else if (blindPlayer.next == Seat3.text)
        {
            //pClock3.Play("Start");
            Clock3.SetActive(true);
            pClock3.Play("Clock3");
        }
        else if (blindPlayer.next == Seat4.text)
        {
            //pClock4.Play("Start");
            Clock4.SetActive(true);
            pClock4.Play("Clock4");
        }
        else if (blindPlayer.next == Seat5.text)
        {
            //pClock5.Play("Start");
            Clock5.SetActive(true);
            pClock5.Play("Clock5");
        }
        else if (blindPlayer.next == Seat1.text)
        {

            //GameSoundFx.PlayOneShot(ClockStart);
            btnMinus.interactable = false;
            btnPlus.interactable = true;
            btnPack.interactable = true;
            if (txtBlind.text == "BLIND")
            {
                //string tmpAmount = txtLastCoin5.text != "" ? txtLastCoin5.text : txtLastCoin4.text != "" ? txtLastCoin4.text : txtLastCoin3.text != "" ? txtLastCoin3.text : txtLastCoin2.text;
                txtAmount.text = blindPlayer.amount;
            }
            if (txtBlind.text == "CHAAL")
            {
                //string tmpAmount = txtLastCoin5.text != "" ? txtLastCoin5.text : txtLastCoin4.text != "" ? txtLastCoin4.text : txtLastCoin3.text != "" ? txtLastCoin3.text : txtLastCoin2.text;
                txtAmount.text = (int.Parse(blindPlayer.amount) * 2).ToString();
            }
            /*
            if (OtherPlayer.OC == OpCodes.Chaal && txtBlind.text == "CHAAL")
            {
                //string tmpAmount = txtLastCoin5.text != "" ? txtLastCoin5.text : txtLastCoin4.text != "" ? txtLastCoin4.text : txtLastCoin3.text != "" ? txtLastCoin3.text : txtLastCoin2.text;
                txtAmount.text = OtherPlayer.OP;
            }
            
            if (OtherPlayer.OC == OpCodes.Chaal && txtBlind.text == "BLIND")
            {
                //string tmpAmount = txtLastCoin5.text != "" ? txtLastCoin5.text : txtLastCoin4.text != "" ? txtLastCoin4.text : txtLastCoin3.text != "" ? txtLastCoin3.text : txtLastCoin2.text;
                txtAmount.text = (int.Parse(OtherPlayer.OP) / 2).ToString();
            }
            */
            if (int.Parse(txtMyCoin.text) < 16)
            {
                DialogMsg.text = "You don't have the minimum balance of 16 coins. Please buy more coins.";
                DialogMsg2.text = "";
                BackToLobby = true;
                pnlOK.SetActive(true);
                //--newMessage = false;
                return;
            }
            if (int.Parse(txtAmount.text) > int.Parse(txtMyCoin.text))
            {
                GameSoundFx.PlayOneShot(PackSound);
                DialogMsg.text = "You don't have enough balance. You are packed.";
                DialogMsg2.text = "";
                pnlOK.SetActive(true);
                OnPack();
                //txtPacked1.text = "Packed";                                                  
                //--newMessage = false;
                return;
            }
            int playerCount = 1;
            if (txtPacked2.text == "Playing")
                playerCount++;
            if (txtPacked3.text == "Playing")
                playerCount++;
            if (txtPacked4.text == "Playing")
                playerCount++;
            if (txtPacked5.text == "Playing")
                playerCount++;
            if (playerCount == 2)
            {
                txtShow.text = "SHOW";
                btnShow.interactable = true;
            }
            if (playerCount > 2 && txtBlind.text == "CHAAL")
            {
                txtShow.text = "SIDE SHOW";
                if (txtPacked5.text == "Playing")
                {
                    if (txtChaal5.text == "CHAAL")
                    {
                        btnShow.interactable = true;
                        sideshow = Seat5.text;
                    }
                    else
                    {
                        btnShow.interactable = false;

                    }
                }
                else if (txtPacked4.text == "Playing")
                {
                    if (txtChaal4.text == "CHAAL")
                    {

                        btnShow.interactable = true;
                        sideshow = Seat4.text;
                    }
                    else
                    {
                        btnShow.interactable = false;
                    }
                }
                else if (txtPacked3.text == "Playing")
                {
                    if (txtChaal3.text == "CHAAL")
                    {

                        btnShow.interactable = true;
                        sideshow = Seat3.text;
                    }
                    else
                    {
                        btnShow.interactable = false;
                    }
                }

            }

            // Unhide the PlayPanel
            playPanel.SetBool("Show", true);
            GameSoundFx.PlayOneShot(ClockStart);
            //pClock1.Play("Start");
            Clock1.SetActive(true);
            pClock1.Play("Clock1");
        }
        //Mine.OC = "Blind";
        //Mine.OP = "Updated";
        //json = JsonUtility.ToJson(Mine);
        // Send json string to socket
        //ws.Send(Encoding.UTF8.GetBytes(json));

        // set to recieve new message again
        //--newMessage = false;
        //return;
    }
    public void OnReachMaxLimit(SocketIOEvent e)
    {
        GameSoundFx.PlayOneShot(BlindSound);
        BreakInfo breakData = new BreakInfo();
        breakData = JsonUtility.FromJson<BreakInfo>(e.data.ToString());
        //hide the seen button
        btnSee.SetActive(false);
        // Pot money has reached the limit
        txtAnnounce.text = "Pot money has reached the limit. So here is the winner . . .";
        txtPotCoin.text = breakData.board;
        //JSONObject data = new JSONObject();        
        //socket.Emit("break", data);
        //--Mine.BM = txtPotCoin.text;
        //--Mine.OP = txtAmount.text;
        // Show the cards if already not seen
        if (txtPacked1.text == "Playing")
        {
            // hide the panel
            playPanel.SetBool("Show", false);
            // Stop the clock
            pClock1.Play("Start");
            Clock1.SetActive(false);
            txtPacked1.text = "Watching";
            if (txtSee.text == "SEE")
            {
                txtSee.text = "SEEN";
                sP1C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList1[0]);
                P1C1.GetComponent<Image>().sprite = sP1C1;
                sP1C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList1[1]);
                P1C2.GetComponent<Image>().sprite = sP1C2;
                sP1C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList1[2]);
                P1C3.GetComponent<Image>().sprite = sP1C3;

            }

        }
        if (txtPacked2.text == "Playing")
        {
            // Stop the clock
            pClock2.Play("Start");
            Clock2.SetActive(false);
            txtPacked2.text = "Watching";           

            sP2C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[0]);
            iP2C1.GetComponent<Image>().sprite = sP2C1;
            sP2C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[1]);
            iP2C2.GetComponent<Image>().sprite = sP2C2;
            sP2C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[2]);
            iP2C3.GetComponent<Image>().sprite = sP2C3;
            ShowCardsP2.SetActive(true);
        }
        if (txtPacked3.text == "Playing")
        {
            // Stop the clock
            pClock3.Play("Start");
            Clock3.SetActive(false);
            txtPacked3.text = "Watching";            

            sP3C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[0]);
            iP3C1.GetComponent<Image>().sprite = sP3C1;
            sP3C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[1]);
            iP3C2.GetComponent<Image>().sprite = sP3C2;
            sP3C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[2]);
            iP3C3.GetComponent<Image>().sprite = sP3C3;
            ShowCardsP3.SetActive(true);            
        }
        if (txtPacked4.text == "Playing")
        {
            // Stop the clock
            pClock4.Play("Start");
            Clock4.SetActive(false);
            txtPacked4.text = "Watching";          

            sP4C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[0]);
            iP4C1.GetComponent<Image>().sprite = sP4C1;
            sP4C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[1]);
            iP4C2.GetComponent<Image>().sprite = sP4C2;
            sP4C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[2]);
            iP4C3.GetComponent<Image>().sprite = sP4C3;
            ShowCardsP4.SetActive(true);
        }
        if (txtPacked5.text == "Playing")
        {
            // Stop the clock
            pClock5.Play("Start");
            Clock5.SetActive(false);
            txtPacked5.text = "Watching";           

            sP5C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[0]);
            iP5C1.GetComponent<Image>().sprite = sP5C1;
            sP5C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[1]);
            iP5C2.GetComponent<Image>().sprite = sP5C2;
            sP5C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[2]);
            iP5C3.GetComponent<Image>().sprite = sP5C3;
            ShowCardsP5.SetActive(true);

            
        }

        long maxCard = Math.Max(Math.Max(Math.Max(Math.Max(MyGame.FirstPlayerCardWeight, MyGame.SecondPlayerCardWeight), MyGame.ThirdPlayerCardWeight), MyGame.FourthPlayerCardWeight), MyGame.FifthPlayerCardWeight);
        string CardDegree = (maxCard > 1000000 && maxCard < 2000000) ? "High Cards"
                                    : (maxCard > 2000000 && maxCard < 3000000) ? "Pair of Cards"
                                    : (maxCard > 3000000 && maxCard < 4000000) ? "One Color"
                                    : (maxCard > 4000000 && maxCard < 5000000) ? "Sequence"
                                    : (maxCard > 5000000 && maxCard < 6000000) ? "Colored Sequence"
                                    : (maxCard > 6000000 && maxCard < 7000000) ? "Tripple of a Card"
                                    : "Error";
        if (maxCard == MyGame.FirstPlayerCardWeight)
        {
            // me winner
            txtAnnounce.text = DBManager.username + " has won the match with a " + CardDegree;

            // Show Board coin animation to player
            txtThrowCoin.text = txtPotCoin.text;
            P1Coin.Play("PotCoinP1R");
            // I get all the board coins
            txtMyCoin.text = (int.Parse(txtMyCoin.text) + int.Parse(txtPotCoin.text)).ToString();
            // Show Board coin animation to player
            txtPotCoin.text = "0";
            // Play winning animation
            pWin1.Play("Play");           
            txtPacked1.text = "Watching"; 

        }
        if (maxCard == MyGame.SecondPlayerCardWeight)
        {
            // second player winner
            txtAnnounce.text = Seat2.text + " has won the match with a " + CardDegree;
            // Show Board coin animation to player
            txtThrowCoin2.text = txtPotCoin.text;
            P2Coin.Play("PotCoinP2R");
            // Show Board coin animation to player
            txtPotCoin.text = "0";
            // Play winning animation
            pWin2.Play("Play");            
            // Switch player status to watching
            txtPacked2.text = "Watching";           

        }
        if (maxCard == MyGame.ThirdPlayerCardWeight)
        {
            // second player winner
            txtAnnounce.text = Seat3.text + " has won the match with a " + CardDegree;
            // Show Board coin animation to player
            txtThrowCoin3.text = txtPotCoin.text;
            P3Coin.Play("PotCoinP3R");
            // Show Board coin animation to player
            txtPotCoin.text = "0";
            // Play winning animation
            pWin3.Play("Play");

            //--Mine.DN = Seat3.text;
            // Switch player status to watching
            txtPacked3.text = "Watching";
            
        }

        if (maxCard == MyGame.FourthPlayerCardWeight)
        {
            // second player winner
            txtAnnounce.text = Seat4.text + " has won the match with a " + CardDegree;
            // Show Board coin animation to player
            txtThrowCoin4.text = txtPotCoin.text;
            P4Coin.Play("PotCoinP4R");
            // Show Board coin animation to player
            txtPotCoin.text = "0";
            // Play winning animation
            pWin4.Play("Play");
            // I'm going to be the next dealer
            
            // Switch player status to watching
            txtPacked4.text = "Watching";            

        }
        if (maxCard == MyGame.FifthPlayerCardWeight)
        {
            // second player winner
            txtAnnounce.text = Seat5.text + " has won the match with a " + CardDegree;
            // Show Board coin animation to player
            txtThrowCoin5.text = txtPotCoin.text;
            P5Coin.Play("PotCoinP5R");
            // Show Board coin animation to player
            txtPotCoin.text = "0";
            // Play winning animation
            pWin5.Play("Play");
            // I'm going to be the next dealer
            
            // Switch player status to watching
            txtPacked5.text = "Watching";           
        }
    }
    public void _OnChaal(SocketIOEvent e)
    {
        GameSoundFx.PlayOneShot(BlindSound);
        BlindInfo blindPlayer = new BlindInfo();
        blindPlayer = JsonUtility.FromJson<BlindInfo>(e.data.ToString());
        //Anouce the Action
        txtAnnounce.text = blindPlayer.playerName + " has played a Chaal";

        //--if (OtherPlayer.OC == OpCodes.Chaal)
        //--    txtAnnounce.text = OtherPlayer.PN + " has played a CHAAL";
        pnlAnnounce.SetActive(true);
        // If I'm a watcher, I should enable potcoin
        txtPotCoin.enabled = true;
        // Find the player's seat and show the coin throw animation and other info
        if (Seat2.text == blindPlayer.playerName)
        {
            txtThrowCoin2.text = blindPlayer.amount;
            txtLastCoin2.text = blindPlayer.amount;
            //P2Coin.Play("ThrowCoin");
            P2PotCoin.SetActive(false);
            P2PotCoin.SetActive(true);
            P2Coin.Play("PotCoinP2");
            txtChaal2.text = "CHAAL";
            //chaal2.Play("HideChaal");
            chaal2.Play("ShowChaal");
            // Stop that player's clock
            pClock2.Play("Start");
            Clock2.SetActive(false);
        }
        else if (Seat3.text == blindPlayer.playerName)
        {
            txtThrowCoin3.text = blindPlayer.amount;
            txtLastCoin3.text = blindPlayer.amount;
            //P3Coin.Play("ThrowCoin");
            P3PotCoin.SetActive(false);
            P3PotCoin.SetActive(true);
            P3Coin.Play("PotCoinP3");
            txtChaal3.text = "CHAAL";
            //chaal3.Play("HideChaal");
            chaal3.Play("ShowChaal");
            // Stop that player's clock
            pClock3.Play("Start");
            Clock3.SetActive(false);
        }
        else if (Seat4.text == blindPlayer.playerName)
        {
            txtThrowCoin4.text = blindPlayer.amount;
            txtLastCoin4.text = blindPlayer.amount;
            //P4Coin.Play("ThrowCoin");
            P4PotCoin.SetActive(false);
            P4PotCoin.SetActive(true);
            P4Coin.Play("PotCoinP4");
            txtChaal4.text = "CHAAL";
            //chaal4.Play("HideChaal");
            chaal4.Play("ShowChaal");
            // Stop that player's clock
            pClock4.Play("Start");
            Clock4.SetActive(false);
        }
        else if (Seat5.text == blindPlayer.playerName)
        {
            txtThrowCoin5.text = blindPlayer.amount;
            txtLastCoin5.text = blindPlayer.amount;
            //P5Coin.Play("ThrowCoin");
            P5PotCoin.SetActive(false);
            P5PotCoin.SetActive(true);
            P5Coin.Play("PotCoinP5");
            txtChaal5.text = "CHAAL";
            //chaal5.Play("HideChaal");
            chaal5.Play("ShowChaal");
            // Stop that player's clock
            pClock5.Play("Start");
            Clock5.SetActive(false);
        }
        // Add coin to the pot coin amount
        // Total pot coin is in the board money
        txtPotCoin.text = blindPlayer.board;

        // Start Next Player's Clock
        if (blindPlayer.next == Seat2.text)
        {
            //pClock2.Play("Start");
            Clock2.SetActive(true);
            pClock2.Play("Clock2");
        }
        else if (blindPlayer.next == Seat3.text)
        {
            //pClock3.Play("Start");
            Clock3.SetActive(true);
            pClock3.Play("Clock3");
        }
        else if (blindPlayer.next == Seat4.text)
        {
            //pClock4.Play("Start");
            Clock4.SetActive(true);
            pClock4.Play("Clock4");
        }
        else if (blindPlayer.next == Seat5.text)
        {
            //pClock5.Play("Start");
            Clock5.SetActive(true);
            pClock5.Play("Clock5");
        }
        else if (blindPlayer.next == Seat1.text)
        {

            //GameSoundFx.PlayOneShot(ClockStart);
            btnMinus.interactable = false;
            btnPlus.interactable = true;
            btnPack.interactable = true;
            /*
            if (txtBlind.text == "BLIND")
            {
                //string tmpAmount = txtLastCoin5.text != "" ? txtLastCoin5.text : txtLastCoin4.text != "" ? txtLastCoin4.text : txtLastCoin3.text != "" ? txtLastCoin3.text : txtLastCoin2.text;
                txtAmount.text = blindPlayer.amount;
            }
            if (txtBlind.text == "CHAAL")
            {
                //string tmpAmount = txtLastCoin5.text != "" ? txtLastCoin5.text : txtLastCoin4.text != "" ? txtLastCoin4.text : txtLastCoin3.text != "" ? txtLastCoin3.text : txtLastCoin2.text;
                txtAmount.text = (int.Parse(blindPlayer.amount) * 2).ToString();
            }
            */
            if (txtBlind.text == "CHAAL")
            {
                //string tmpAmount = txtLastCoin5.text != "" ? txtLastCoin5.text : txtLastCoin4.text != "" ? txtLastCoin4.text : txtLastCoin3.text != "" ? txtLastCoin3.text : txtLastCoin2.text;
                txtAmount.text = blindPlayer.amount;
            }
            
            if (txtBlind.text == "BLIND")
            {
                //string tmpAmount = txtLastCoin5.text != "" ? txtLastCoin5.text : txtLastCoin4.text != "" ? txtLastCoin4.text : txtLastCoin3.text != "" ? txtLastCoin3.text : txtLastCoin2.text;
                txtAmount.text = (int.Parse(blindPlayer.amount) / 2).ToString();
            }
            
            if (int.Parse(txtMyCoin.text) < 16)
            {
                DialogMsg.text = "You don't have the minimum balance of 16 coins. Please buy more coins.";
                DialogMsg2.text = "";
                BackToLobby = true;
                pnlOK.SetActive(true);
                //--newMessage = false;
                return;
            }
            if (int.Parse(txtAmount.text) > int.Parse(txtMyCoin.text))
            {
                GameSoundFx.PlayOneShot(PackSound);
                DialogMsg.text = "You don't have enough balance. You are packed.";
                DialogMsg2.text = "";
                pnlOK.SetActive(true);
                OnPack();
                //txtPacked1.text = "Packed";                                                  
                //--newMessage = false;
                return;
            }
            int playerCount = 1;
            if (txtPacked2.text == "Playing")
                playerCount++;
            if (txtPacked3.text == "Playing")
                playerCount++;
            if (txtPacked4.text == "Playing")
                playerCount++;
            if (txtPacked5.text == "Playing")
                playerCount++;
            if (playerCount == 2)
            {
                txtShow.text = "SHOW";
                btnShow.interactable = true;
            }
            if (playerCount > 2 && txtBlind.text == "CHAAL")
            {
                txtShow.text = "SIDE SHOW";
                if (txtPacked5.text == "Playing")
                {
                    if (txtChaal5.text == "CHAAL")
                    {
                        btnShow.interactable = true;
                        sideshow = Seat5.text;
                    }
                    else
                    {
                        btnShow.interactable = false;

                    }
                }
                else if (txtPacked4.text == "Playing")
                {
                    if (txtChaal4.text == "CHAAL")
                    {

                        btnShow.interactable = true;
                        sideshow = Seat4.text;
                    }
                    else
                    {
                        btnShow.interactable = false;
                    }
                }
                else if (txtPacked3.text == "Playing")
                {
                    if (txtChaal3.text == "CHAAL")
                    {

                        btnShow.interactable = true;
                        sideshow = Seat3.text;
                    }
                    else
                    {
                        btnShow.interactable = false;
                    }
                }

            }

            // Unhide the PlayPanel
            playPanel.SetBool("Show", true);
            GameSoundFx.PlayOneShot(ClockStart);
            //pClock1.Play("Start");
            Clock1.SetActive(true);
            pClock1.Play("Clock1");
        }

    }
    public void _OnSeen(SocketIOEvent e)
    {
        SeenPlayer seenPlayer = new SeenPlayer();
        seenPlayer = JsonUtility.FromJson<SeenPlayer>(e.data.ToString());
        txtAnnounce.text = seenPlayer.playerName + " has seen their cards!";
        if(seenPlayer.playerName==Seat2.text)
        {
            txtChaal2.text = "CHAAL";
        }
        else if (seenPlayer.playerName == Seat3.text)
        {
            txtChaal3.text = "CHAAL";
        }
        else if (seenPlayer.playerName == Seat4.text)
        {
            txtChaal4.text = "CHAAL";
        }
        else if (seenPlayer.playerName == Seat5.text)
        {
            txtChaal5.text = "CHAAL";
        }
        int playerCount = 1;
        if (txtPacked2.text == "Playing")
            playerCount++;
        if (txtPacked3.text == "Playing")
            playerCount++;
        if (txtPacked4.text == "Playing")
            playerCount++;
        if (txtPacked5.text == "Playing")
            playerCount++;
        if (playerCount == 2)
        {
            txtShow.text = "SHOW";
            btnShow.interactable = true;
        }
        if (playerCount > 2 && txtBlind.text == "CHAAL")
        {
            txtShow.text = "SIDE SHOW";
            if (txtPacked5.text == "Playing")
            {
                if (txtChaal5.text == "CHAAL")
                {
                    btnShow.interactable = true;
                    sideshow = Seat5.text;
                }
                else
                {
                    btnShow.interactable = false;

                }
            }
            else if (txtPacked4.text == "Playing")
            {
                if (txtChaal4.text == "CHAAL")
                {

                    btnShow.interactable = true;
                    sideshow = Seat4.text;
                }
                else
                {
                    btnShow.interactable = false;
                }
            }
            else if (txtPacked3.text == "Playing")
            {
                if (txtChaal3.text == "CHAAL")
                {

                    btnShow.interactable = true;
                    sideshow = Seat3.text;
                }
                else
                {
                    btnShow.interactable = false;
                }
            }

        }

    }
    public void _OnTips(SocketIOEvent e)
    {
        TipsData tp = new TipsData();
        tp = JsonUtility.FromJson<TipsData>(e.data.ToString());
        txtAnnounce.text = tp.playerName + " has paid a tip money!";
        GameSoundFx.PlayOneShot(BlindSound);
        if (tp.playerName == Seat2.text)
        {
            txtThrowCoin2.text = "2";
            txtLastCoin2.text = txtThrowCoin2.text;
            //P2Coin.Play("ThrowCoin");
            P2PotCoin.SetActive(false);
            P2PotCoin.SetActive(true);
            P2Coin.Play("PotCoinP2");
            txtChaal2.text = "TIPS";
            //chaal2.Play("HideChaal");
            chaal2.Play("ShowChaal");
        }
        else if (tp.playerName == Seat3.text)
        {
            txtThrowCoin3.text = "2";
            txtLastCoin3.text = txtThrowCoin3.text;
            //P2Coin.Play("ThrowCoin");
            P3PotCoin.SetActive(false);
            P3PotCoin.SetActive(true);
            P3Coin.Play("PotCoinP3");
            txtChaal3.text = "TIPS";
            //chaal2.Play("HideChaal");
            chaal3.Play("ShowChaal");
        }
        else if (tp.playerName == Seat4.text)
        {
            txtThrowCoin4.text = "2";
            txtLastCoin4.text = txtThrowCoin4.text;
            //P2Coin.Play("ThrowCoin");
            P4PotCoin.SetActive(false);
            P4PotCoin.SetActive(true);
            P4Coin.Play("PotCoinP4");
            txtChaal4.text = "TIPS";
            //chaal2.Play("HideChaal");
            chaal4.Play("ShowChaal");
        }
        else if (tp.playerName == Seat5.text)
        {
            txtThrowCoin5.text = "2";
            txtLastCoin5.text = txtThrowCoin5.text;
            //P2Coin.Play("ThrowCoin");
            P5PotCoin.SetActive(false);
            P5PotCoin.SetActive(true);
            P5Coin.Play("PotCoinP5");
            txtChaal5.text = "TIPS";
            //chaal2.Play("HideChaal");
            chaal5.Play("ShowChaal");
        }

    }
    public void _OnPack(SocketIOEvent e)
    {
        PackData packedPlayer = new PackData();
        packedPlayer = JsonUtility.FromJson<PackData>(e.data.ToString());
        GameSoundFx.PlayOneShot(PackSound);
        //Anouce the Action
        txtAnnounce.text = packedPlayer.playerName + " has packed";
        if (Seat2.text == packedPlayer.playerName)
        {
            txtChaal2.text = "PACKED";
            //chaal2.Play("HideChaal");
            chaal2.Play("ShowChaal");
            // Stop that player's clock                        
            pClock2.Play("Start");
            Clock2.SetActive(false);
            txtPacked2.text = "Watching";
            // txtPacked2.enabled = true;
        }
        else if (Seat3.text == packedPlayer.playerName)
        {
            txtChaal3.text = "PACKED";
            //chaal3.Play("HideChaal");
            chaal3.Play("ShowChaal");
            // Stop that player's clock                        
            pClock3.Play("Start");
            Clock3.SetActive(false);
            txtPacked3.text = "Watching";
            //txtPacked3.enabled = true;
        }
        else if (Seat4.text == packedPlayer.playerName)
        {
            txtChaal4.text = "PACKED";
            // chaal4.Play("HideChaal");

            chaal4.Play("ShowChaal");
            // Stop that player's clock                        
            pClock4.Play("Start");
            Clock4.SetActive(false);
            txtPacked4.text = "Watching";
            //txtPacked4.enabled = true;
        }
        else if (Seat5.text == packedPlayer.playerName)
        {
            txtChaal5.text = "PACKED";
            //chaal5.Play("HideChaal");
            chaal5.Play("ShowChaal");
            // Stop that player's clock                        
            pClock5.Play("Start");
            Clock5.SetActive(false);
            txtPacked5.text = "Watching";
            //txtPacked5.enabled = true;
        }
        // Determine if I'm the only player now
        int playerCount = 1;
        if (txtPacked2.text == "Playing")
            playerCount++;
        if (txtPacked3.text == "Playing")
            playerCount++;
        if (txtPacked4.text == "Playing")
            playerCount++;
        if (txtPacked5.text == "Playing")
            playerCount++;
        if (playerCount == 1 && txtPacked1.text == "Playing")
        {
            JSONObject data = new JSONObject();
            //data.AddField("socket", myInfo.roomName);
            data.AddField("room", myInfo.roomName);
            data.AddField("name", Seat1.text);
            data.AddField("by", "Everyone Packing");
            socket.Emit("Winner", data);
            // I'm the only player. So I win the match
            // Stop the clock                        
            pClock1.Play("Start");
            Clock1.SetActive(false);
            // Hide panel
            playPanel.SetBool("Show", false);
            // hide the see button
            btnSee.SetActive(false);
            // Show Board coin animation to player
            txtThrowCoin.text = txtPotCoin.text;
            P1Coin.Play("PotCoinP1R");
            // I'm the winner. I get all the board coins
            txtMyCoin.text = (int.Parse(txtMyCoin.text) + int.Parse(txtPotCoin.text)).ToString();
            // Show Board coin animation to player
            txtPotCoin.text = "0";
            GameSoundFx.PlayOneShot(WinningSound);

            //StartCoroutine(PlayWinningSound());
            // Show Winner Animation on my player tab
            pWin1.Play("Play");
            // Disable the lobby button
            //--btnLobby.enabled = false;
            txtAnnounce.text = DBManager.username + " has won the match with everyone packing!";
            return;            
        }
        if(playerCount==2)
        {
            txtShow.text = "SHOW";
            btnShow.interactable = true;
        }
        if(playerCount>2)
        {
            txtShow.text = "SIDE SHOW";
        }
        // Start Next Player's Clock
        if (packedPlayer.nextPlayer == Seat1.text)
        {

            //pClock1.Play("Start");

            Clock1.SetActive(true);
            pClock1.Play("Clock1");
            GameSoundFx.PlayOneShot(ClockStart);
            playPanel.SetBool("Show", true);
        }
        else if (packedPlayer.nextPlayer == Seat2.text)
        {
            //pClock2.Play("Start");
            Clock2.SetActive(true);
            pClock2.Play("Clock2");
        }
        else if (packedPlayer.nextPlayer == Seat3.text)
        {
            //pClock3.Play("Start");
            Clock3.SetActive(true);
            pClock3.Play("Clock3");
        }
        else if (packedPlayer.nextPlayer == Seat4.text)
        {
            //pClock4.Play("Start");
            Clock4.SetActive(true);
            pClock4.Play("Clock4");
        }
        else if (packedPlayer.nextPlayer == Seat5.text)
        {
            //pClock5.Play("Start");
            Clock5.SetActive(true);
            pClock5.Play("Clock5");
        }
        
    }
    public void NextPlayerClock(SocketIOEvent e)
    {
        NextPlayer nextPlayer = new NextPlayer();
        nextPlayer = JsonUtility.FromJson<NextPlayer>(e.data.ToString());
        // Start Next Player's Clock
        if (nextPlayer.nextPlayer == Seat1.text)
        {

            //pClock1.Play("Start");

            Clock1.SetActive(true);
            pClock1.Play("Clock1");
            GameSoundFx.PlayOneShot(ClockStart);
            playPanel.SetBool("Show", true);
        }
        else if (nextPlayer.nextPlayer == Seat2.text)
        {
            //pClock2.Play("Start");
            Clock2.SetActive(true);
            pClock2.Play("Clock2");
        }
        else if (nextPlayer.nextPlayer == Seat3.text)
        {
            //pClock3.Play("Start");
            Clock3.SetActive(true);
            pClock3.Play("Clock3");
        }
        else if (nextPlayer.nextPlayer == Seat4.text)
        {
            //pClock4.Play("Start");
            Clock4.SetActive(true);
            pClock4.Play("Clock4");
        }
        else if (nextPlayer.nextPlayer == Seat5.text)
        {
            //pClock5.Play("Start");
            Clock5.SetActive(true);
            pClock5.Play("Clock5");
        }

    }
    public void _OnShow(SocketIOEvent e)
    {
        ShowData Shower = new ShowData();
        Shower = JsonUtility.FromJson<ShowData>(e.data.ToString());
        txtAnnounce.text = Shower.playerName + " played a Show";
        // Add coin to the pot coin amount
        txtPotCoin.text = Shower.boardMoney;
        if(Shower.playerName==Seat2.text)
        {
            // Stop the clock
            pClock2.Play("Start");
            Clock2.SetActive(false);
            sP2C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[0]);
            iP2C1.GetComponent<Image>().sprite = sP2C1;
            sP2C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[1]);
            iP2C2.GetComponent<Image>().sprite = sP2C2;
            sP2C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[2]);
            iP2C3.GetComponent<Image>().sprite = sP2C3;
            ShowCardsP2.SetActive(true);
        }
        else if (Shower.playerName == Seat3.text)
        {
            // Stop the clock
            pClock3.Play("Start");
            Clock3.SetActive(false);
            sP3C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[0]);
            iP3C1.GetComponent<Image>().sprite = sP3C1;
            sP3C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[1]);
            iP3C2.GetComponent<Image>().sprite = sP3C2;
            sP3C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[2]);
            iP3C3.GetComponent<Image>().sprite = sP3C3;
            ShowCardsP3.SetActive(true);            
        }
        else if (Shower.playerName == Seat4.text)
        {
            // Stop the clock
            pClock4.Play("Start");
            Clock4.SetActive(false);
            sP4C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[0]);
            iP4C1.GetComponent<Image>().sprite = sP4C1;
            sP4C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[1]);
            iP4C2.GetComponent<Image>().sprite = sP4C2;
            sP4C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[2]);
            iP4C3.GetComponent<Image>().sprite = sP4C3;
            ShowCardsP4.SetActive(true);            
        }
        else if (Shower.playerName == Seat5.text)
        {
            // Stop the clock
            pClock5.Play("Start");
            Clock5.SetActive(false);
            sP5C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[0]);
            iP5C1.GetComponent<Image>().sprite = sP5C1;
            sP5C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[1]);
            iP5C2.GetComponent<Image>().sprite = sP5C2;
            sP5C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[2]);
            iP5C3.GetComponent<Image>().sprite = sP5C3;
            ShowCardsP5.SetActive(true);            
        }

        if (Shower.targetPlayer == Seat1.text)
        {

            if (txtSee.text == "SEE")
            {
                txtSee.text = "SEEN";
                sP1C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList1[0]);
                P1C1.GetComponent<Image>().sprite = sP1C1;
                sP1C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList1[1]);
                P1C2.GetComponent<Image>().sprite = sP1C2;
                sP1C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList1[2]);
                P1C3.GetComponent<Image>().sprite = sP1C3;
            }
            btnSee.SetActive(false);
        }
        else if (Shower.targetPlayer == Seat2.text)
        {
            sP2C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[0]);
            iP2C1.GetComponent<Image>().sprite = sP2C1;
            sP2C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[1]);
            iP2C2.GetComponent<Image>().sprite = sP2C2;
            sP2C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[2]);
            iP2C3.GetComponent<Image>().sprite = sP2C3;
            ShowCardsP2.SetActive(true);
        }
        else if (Shower.targetPlayer == Seat3.text)
        {
            sP3C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[0]);
            iP3C1.GetComponent<Image>().sprite = sP3C1;
            sP3C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[1]);
            iP3C2.GetComponent<Image>().sprite = sP3C2;
            sP3C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[2]);
            iP3C3.GetComponent<Image>().sprite = sP3C3;
            ShowCardsP3.SetActive(true);            
        }
        else if (Shower.targetPlayer == Seat4.text)
        {
            sP4C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[0]);
            iP4C1.GetComponent<Image>().sprite = sP4C1;
            sP4C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[1]);
            iP4C2.GetComponent<Image>().sprite = sP4C2;
            sP4C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[2]);
            iP4C3.GetComponent<Image>().sprite = sP4C3;
            ShowCardsP4.SetActive(true);
           
        }
        else if (Shower.targetPlayer == Seat5.text)
        {
            sP5C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[0]);
            iP5C1.GetComponent<Image>().sprite = sP5C1;
            sP5C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[1]);
            iP5C2.GetComponent<Image>().sprite = sP5C2;
            sP5C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[2]);
            iP5C3.GetComponent<Image>().sprite = sP5C3;
            ShowCardsP5.SetActive(true);            
        }
        StartCoroutine(DelayedDeclareWinner(2.0f, Shower.winnerPlayer, Shower.winRank));        
    }
    public void _OnSideShow(SocketIOEvent e)
    {
        ssCards ="";
        ssPlayer = "";
        SideShower S_Shower = new SideShower();
        S_Shower = JsonUtility.FromJson<SideShower>(e.data.ToString());
        ssCards = S_Shower.playerCards;
        ssPlayer = S_Shower.playerName;
        if(S_Shower.targetPlayer!=Seat1.text)
        {
            txtAnnounce.text = S_Shower.playerName + " has offered " + S_Shower.targetPlayer + " a Side Showing!";
        }
        else
        {
            txtSide.text = "Accept Side Show Offer from " + S_Shower.playerName + "?";
            StartCoroutine(ShowSideShowOffer(5.0f));           
        }
    }
    IEnumerator ShowSideShowOffer(float seconds)
    {
        pnlSide.SetActive(true);
        yield return new WaitForSeconds(seconds);
        pnlSide.SetActive(false);
    }
    public void OnSideShowReturn(SocketIOEvent e)
    {
        SideShowReturn ssr = new SideShowReturn();
        ssr = JsonUtility.FromJson<SideShowReturn>(e.data.ToString());
        if(ssr.targetPlayer==Seat1.text)
        {
            if(ssr.returningPlayer==Seat5.text)
            {
                sP5C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[0]);
                iP5C1.GetComponent<Image>().sprite = sP5C1;
                sP5C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[1]);
                iP5C2.GetComponent<Image>().sprite = sP5C2;
                sP5C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[2]);
                iP5C3.GetComponent<Image>().sprite = sP5C3;
                ShowCardsP5.SetActive(true);
            }
            else if (ssr.returningPlayer == Seat5.text)
            {
                sP4C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[0]);
                iP4C1.GetComponent<Image>().sprite = sP4C1;
                sP4C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[1]);
                iP4C2.GetComponent<Image>().sprite = sP4C2;
                sP4C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[2]);
                iP4C3.GetComponent<Image>().sprite = sP4C3;
                ShowCardsP4.SetActive(true);
            }
            else if (ssr.returningPlayer == Seat3.text)
            {
                sP3C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[0]);
                iP3C1.GetComponent<Image>().sprite = sP3C1;
                sP3C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[1]);
                iP3C2.GetComponent<Image>().sprite = sP3C2;
                sP3C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[2]);
                iP3C3.GetComponent<Image>().sprite = sP3C3;
                ShowCardsP3.SetActive(true);
            }
            else if (ssr.returningPlayer == Seat2.text)
            {
                sP2C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[0]);
                iP2C1.GetComponent<Image>().sprite = sP2C1;
                sP2C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[1]);
                iP2C2.GetComponent<Image>().sprite = sP2C2;
                sP2C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[2]);
                iP2C3.GetComponent<Image>().sprite = sP2C3;
                ShowCardsP2.SetActive(true);
            }
            OnPack();
        }
        else
        {
            txtAnnounce.text = ssr.returningPlayer + " has accepted " + ssr.targetPlayer + "'s sideshow offer";
        }
    }
    public void OnSideShowReject(SocketIOEvent e)
    {
        //txtAnnounce.text=
        SideShowReject ssr = new SideShowReject();
        ssr = JsonUtility.FromJson<SideShowReject>(e.data.ToString());
        txtAnnounce.text = ssr.playerName + " has rejected the sideshow offer!";
    }
    public void _OnChat(SocketIOEvent e)
    {
        ChatData cd = new ChatData();
        cd = JsonUtility.FromJson<ChatData>(e.data.ToString());
        GameSoundFx.PlayOneShot(PackSound);
        if (Seat2.text == cd.playerName)
        {
            StartCoroutine(ShowMessage(pnlText2, pText2, cd.chatText, 3.0f));
        }
        else if (Seat3.text == cd.playerName)
        {
            StartCoroutine(ShowMessage(pnlText3, pText3, cd.chatText, 3.0f));
        }
        else if(Seat4.text == cd.playerName)
        {
            StartCoroutine(ShowMessage(pnlText4, pText4, cd.chatText, 3.0f));
        }
        else if (Seat5.text == cd.playerName)
        {
            StartCoroutine(ShowMessage(pnlText5, pText5, cd.chatText, 3.0f));
        }

    }
    public void _OnWinner(SocketIOEvent e)
    {
        WinnerData winningPlayer = new WinnerData();
        winningPlayer = JsonUtility.FromJson<WinnerData>(e.data.ToString());
              
        btnSee.SetActive(false);
        Clock1.SetActive(false);
        Clock2.SetActive(false);
        Clock3.SetActive(false);
        Clock4.SetActive(false);
        Clock5.SetActive(false);
        if (Seat2.text==winningPlayer.playerName)
        {
            GameSoundFx.PlayOneShot(WinningSound);
            pWin2.Play("Play");
            // Show Board coin animation to player
            txtThrowCoin2.text = txtPotCoin.text;
            P2Coin.Play("PotCoinP2R");
            //Empty Board coin
            txtPotCoin.text = "0";
        }
        else if(Seat3.text == winningPlayer.playerName)
        {
            GameSoundFx.PlayOneShot(WinningSound);
            pWin3.Play("Play");
            // Show Board coin animation to player
            txtThrowCoin3.text = txtPotCoin.text;
            P3Coin.Play("PotCoinP2R");
            //Empty Board coin
            txtPotCoin.text = "0";
        }
        else if (Seat4.text == winningPlayer.playerName)
        {
            GameSoundFx.PlayOneShot(WinningSound);
            pWin4.Play("Play");
            // Show Board coin animation to player
            txtThrowCoin4.text = txtPotCoin.text;
            P4Coin.Play("PotCoinP2R");
            //Empty Board coin
            txtPotCoin.text = "0";
        }
        else if (Seat5.text == winningPlayer.playerName)
        {
            GameSoundFx.PlayOneShot(WinningSound);
            pWin5.Play("Play");
            // Show Board coin animation to player
            txtThrowCoin5.text = txtPotCoin.text;
            P5Coin.Play("PotCoinP2R");
            //Empty Board coin
            txtPotCoin.text = "0";
        }        
        txtAnnounce.text = winningPlayer.playerName + " has won the match with "+winningPlayer.winBy+"!";
    }

    void Update()
    {
        /*
        
        
        if (wait)
        {
            //GameSoundFx.Stop();
            update += Time.deltaTime;
            if (update < 6.0f)
            {
                
                txtAnnounce.text = "New Game Starting. Wait . . ";
                pnlAnnounce.SetActive(true);
                return;                
            }
            else
            {
                wait = false;
                //nPlayers = 1;
                update = 0.0f;
                //ShowFlashMessage();
                //GameSoundFx.Stop();
                // reset pot coin animations
                // Reset Seen Cards
                sP1C1 = Resources.Load<Sprite>("Sprites/CardBack");
                P1C1.GetComponent<Image>().sprite = sP1C1;
                sP1C2 = Resources.Load<Sprite>("Sprites/CardBack");
                P1C2.GetComponent<Image>().sprite = sP1C2;
                sP1C3 = Resources.Load<Sprite>("Sprites/CardBack");
                P1C3.GetComponent<Image>().sprite = sP1C3;
                P1Coin.Play("ThrowCoin");
                P2Coin.Play("ThrowCoin");
                P3Coin.Play("ThrowCoin");
                P4Coin.Play("ThrowCoin");
                P5Coin.Play("ThrowCoin");
                //Reset Potfinished variable
                PotFinished = false;
                DealFinished = false;
                DealMessageSent = false;
                CardFinished = false;
                GameState.CardAnimateFinished = false;
                p1Card1 = false;
                p1Card2 = false;
                p1Card3 = false;
                p2Card1 = false;
                p2Card2 = false;
                p2Card3 = false;
                p3Card1 = false;
                p3Card2 = false;
                p3Card3 = false;
                p4Card1 = false;
                p4Card2 = false;
                p4Card3 = false;
                p5Card1 = false;
                p5Card2 = false;
                p5Card3 = false;

                btnLobby.enabled = false;

                Animator cAnim = P2C1.GetComponent<Animator>();
                cAnim.Play("DealerHand");
                
                 cAnim = P2C2.GetComponent<Animator>();
                cAnim.Play("DealerHand");
                 cAnim = P2C3.GetComponent<Animator>();
                cAnim.Play("DealerHand");

                 cAnim = P3C1.GetComponent<Animator>();
                cAnim.Play("DealerHand");
                 cAnim = P3C2.GetComponent<Animator>();
                cAnim.Play("DealerHand");
                 cAnim = P3C3.GetComponent<Animator>();
                cAnim.Play("DealerHand");

                cAnim = P4C1.GetComponent<Animator>();
                cAnim.Play("DealerHand");
                cAnim = P4C2.GetComponent<Animator>();
                cAnim.Play("DealerHand");
                cAnim = P4C3.GetComponent<Animator>();
                cAnim.Play("DealerHand");

                cAnim = P5C1.GetComponent<Animator>();
                cAnim.Play("DealerHand");
                cAnim = P5C2.GetComponent<Animator>();
                cAnim.Play("DealerHand");
                cAnim = P5C3.GetComponent<Animator>();
                cAnim.Play("DealerHand");

                cAnim = P1C1.GetComponent<Animator>();
                cAnim.Play("DealerHand");
                cAnim = P1C2.GetComponent<Animator>();
                cAnim.Play("DealerHand");
                cAnim = P1C3.GetComponent<Animator>();
                cAnim.Play("DealerHand");
                // Reset the cards
                tmpCards1 = "";
                tmpCards2 = "";
                tmpCards3 = "";
                tmpCards4 = "";
                tmpCards5 = "";
                cList1 = new string[] { "0", "0", "0" };
                cList2 = new string[] { "0", "0", "0" };
                cList3 = new string[] { "0", "0", "0" };
                cList4 = new string[] { "0", "0", "0" };
                cList5 = new string[] { "0", "0", "0" };
                MyGame.FirstPlayerCardWeight = 0;
                MyGame.SecondPlayerCardWeight = 0;
                MyGame.ThirdPlayerCardWeight = 0;
                MyGame.FourthPlayerCardWeight = 0;
                MyGame.FifthPlayerCardWeight = 0;
                // Reset the winner animation
                pWin1.Play("Stop");
                pWin2.Play("Stop");
                pWin3.Play("Stop");
                pWin4.Play("Stop");
                pWin5.Play("Stop");
                // Reset My status to watching
                txtPacked1.text = "Watching";
                if (nPlayers == 1)
                {
                    newMessage = false;
                    return;
                }
                    
               
                // Signal for the next game that I'm the dealer.
                Mine.PN = DBManager.username;
                //Mine.OC = "NEW";
                Mine.OC = OpCodes.New;
                //Mine.OP = "Game";
                Mine.OP = OpCodes.Game;
                Mine.DN = DBManager.username;
                json = JsonUtility.ToJson(Mine);
                //Send json string to socket
                 //--ws.Send(Encoding.UTF8.GetBytes(json));
                // set to recieve new message again
                 newMessage = false;                
                return;
            }
        }
        if(ClockSequencer.ClockChanged)
        {
            //Mine.OC = "ShowClock";
            Mine.OC = OpCodes.ShowClock;
            Mine.OP = ClockSequencer.PN;
            // Convert data to json string
            json = JsonUtility.ToJson(Mine);
            // Send json string to socket
            //--ws.Send(Encoding.UTF8.GetBytes(json));
            // set to recieve new message again
            newMessage = false;
            // set to animate new clock again
            ClockSequencer.ClockChanged = false;
            
            return;
        }
        //if (Mine.DN == DBManager.username && Mine.GameState == "On" && DealMessageSent && GameState.pot)
        if (Mine.DN == DBManager.username && DealMessageSent)
        {
            // Reset Cards rotation quatarnion
            /*
            P1C1.transform.Rotate(new Vector3(0, 0, -180));
            P1C2.transform.Rotate(new Vector3(0, 0, -180));
            P1C3.transform.Rotate(new Vector3(0, 0, -180));
            P2C1.transform.Rotate(new Vector3(0, 0, -180));
            P2C2.transform.Rotate(new Vector3(0, 0, -180));
            P2C3.transform.Rotate(new Vector3(0, 0, -180));
            P3C1.transform.Rotate(new Vector3(0, 0, -180));
            P3C2.transform.Rotate(new Vector3(0, 0, -180));
            P3C3.transform.Rotate(new Vector3(0, 0, -180));
            P4C1.transform.Rotate(new Vector3(0, 0, -180));
            P4C2.transform.Rotate(new Vector3(0, 0, -180));
            P4C3.transform.Rotate(new Vector3(0, 0, -180));
            P5C1.transform.Rotate(new Vector3(0, 0, -180));
            P5C2.transform.Rotate(new Vector3(0, 0, -180));
            P5C3.transform.Rotate(new Vector3(0, 0, -180));
            
            // Deal cards
            txtAnnounce.text = "Dealer is dealing cards";
            if (!p2Card1)
            {
                if (txtPacked2.text == "Playing")
                {
                    Animator cAnim = P2C1.GetComponent<Animator>();
                    cAnim.Play("P2C1Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p2Card1 = true;
            if (!GameState.CardAnimateFinished)
                return;

            if (!p3Card1)
            {
                if (txtPacked3.text == "Playing")
                {
                    Animator cAnim = P3C1.GetComponent<Animator>();
                    cAnim.Play("P3C1Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p3Card1 = true;
            if (!GameState.CardAnimateFinished)
                return;

            if (!p4Card1)
            {
                if (txtPacked4.text == "Playing")
                {
                    Animator cAnim = P4C1.GetComponent<Animator>();
                    cAnim.Play("P4C1Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p4Card1 = true;
            if (!GameState.CardAnimateFinished)
                return;

            if (!p5Card1)
            {
                if (txtPacked5.text == "Playing")
                {
                    Animator cAnim = P5C1.GetComponent<Animator>();
                    cAnim.Play("P5C1Animation");
                    GameState.CardAnimateFinished = false;

                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p5Card1 = true;
            if (!GameState.CardAnimateFinished)
                return;
            if (!p1Card1)
            {
                Animator cAnim = P1C1.GetComponent<Animator>();
                cAnim.Play("P1C1Animation");
                GameState.CardAnimateFinished = false;
            }
            p1Card1 = true;
            if (!GameState.CardAnimateFinished)
                return;

            if (!p2Card2)
            {
                if (txtPacked2.text == "Playing")
                {
                    Animator cAnim = P2C2.GetComponent<Animator>();
                    cAnim.Play("P2C2Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p2Card2 = true;
            if (!GameState.CardAnimateFinished)
                return;
            if (!p3Card2)
            {
                if (txtPacked3.text == "Playing")
                {
                    Animator cAnim = P3C2.GetComponent<Animator>();
                    cAnim.Play("P3C2Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p3Card2 = true;
            if (!GameState.CardAnimateFinished)
                return;
            if (!p4Card2)
            {
                if (txtPacked4.text == "Playing")
                {
                    Animator cAnim = P4C2.GetComponent<Animator>();
                    cAnim.Play("P4C2Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p4Card2 = true;
            if (!GameState.CardAnimateFinished)
                return;
            if (!p5Card2)
            {
                if (txtPacked5.text == "Playing")
                {
                    Animator cAnim = P5C2.GetComponent<Animator>();
                    cAnim.Play("P5C2Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p5Card2 = true;
            if (!GameState.CardAnimateFinished)
                return;
            if (!p1Card2)
            {

                Animator cAnim = P1C2.GetComponent<Animator>();
                cAnim.Play("P1C2Animation");
                GameState.CardAnimateFinished = false;
            }
            p1Card2 = true;
            if (!GameState.CardAnimateFinished)
                return;
            if (!p2Card3)
            {
                if (txtPacked2.text == "Playing")
                {
                    Animator cAnim = P2C3.GetComponent<Animator>();
                    cAnim.Play("P2C3Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p2Card3 = true;
            if (!GameState.CardAnimateFinished)
                return;
            if (!p3Card3)
            {
                if (txtPacked3.text == "Playing")
                {
                    Animator cAnim = P3C3.GetComponent<Animator>();
                    cAnim.Play("P3C3Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p3Card3 = true;
            if (!GameState.CardAnimateFinished)
                return;
            if (!p4Card3)
            {
                if (txtPacked4.text == "Playing")
                {
                    Animator cAnim = P4C3.GetComponent<Animator>();
                    cAnim.Play("P4C3Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p4Card3 = true;
            if (!GameState.CardAnimateFinished)
                return;
            if (!p5Card3)
            {
                if (txtPacked5.text == "Playing")
                {
                    Animator cAnim = P5C3.GetComponent<Animator>();
                    cAnim.Play("P5C3Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p5Card3 = true;
            if (!GameState.CardAnimateFinished)
                return;
            if (!p1Card3)
            {

                Animator cAnim = P1C3.GetComponent<Animator>();
                cAnim.Play("P1C3Animation");
                GameState.CardAnimateFinished = false;
            }
            p1Card3 = true;
            if (!GameState.CardAnimateFinished)
                return;
            newMessage = false;
            DealMessageSent = false;
            txtAnnounce.text = "Card Dealing Complete";            
            OtherPlayer.OP = "";
            OtherPlayer.OC = "";            
            return;
        }
        //if (Mine.GameState == "On" && DealMessageSent && GameState.pot)
        if (Mine.DN!=DBManager.username && DealMessageSent)
        {
            
            // Reset Cards Rotation quatarnions
            P1C1.transform.Rotate(new Vector3(0, 0, -180));
            P1C2.transform.Rotate(new Vector3(0, 0, -180));
            P1C3.transform.Rotate(new Vector3(0, 0, -180));
            P2C1.transform.Rotate(new Vector3(0, 0, -180));
            P2C2.transform.Rotate(new Vector3(0, 0, -180));
            P2C3.transform.Rotate(new Vector3(0, 0, -180));
            P3C1.transform.Rotate(new Vector3(0, 0, -180));
            P3C2.transform.Rotate(new Vector3(0, 0, -180));
            P3C3.transform.Rotate(new Vector3(0, 0, -180));
            P4C1.transform.Rotate(new Vector3(0, 0, -180));
            P4C2.transform.Rotate(new Vector3(0, 0, -180));
            P4C3.transform.Rotate(new Vector3(0, 0, -180));
            P5C1.transform.Rotate(new Vector3(0, 0, -180));
            P5C2.transform.Rotate(new Vector3(0, 0, -180));
            P5C3.transform.Rotate(new Vector3(0, 0, -180));
            
            txtAnnounce.text = "Dealer is dealing cards";
            Mine.DN = "";
            if (!p2Card1)
            {
                if (txtPacked2.text == "Playing")
                {
                    Animator cAnim = P2C1.GetComponent<Animator>();
                    cAnim.Play("P2C1Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p2Card1 = true;
            if (!GameState.CardAnimateFinished)
                return;

            if (!p3Card1)
            {
                if (txtPacked3.text == "Playing")
                {
                    Animator cAnim = P3C1.GetComponent<Animator>();
                    cAnim.Play("P3C1Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p3Card1 = true;
            if (!GameState.CardAnimateFinished)
                return;

            if (!p4Card1)
            {
                if (txtPacked4.text == "Playing")
                {
                    Animator cAnim = P4C1.GetComponent<Animator>();
                    cAnim.Play("P4C1Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p4Card1 = true;
            if (!GameState.CardAnimateFinished)
                return;

            if (!p5Card1)
            {
                if (txtPacked5.text == "Playing")
                {
                    Animator cAnim = P5C1.GetComponent<Animator>();
                    cAnim.Play("P5C1Animation");
                    GameState.CardAnimateFinished = false;

                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p5Card1 = true;
            if (!GameState.CardAnimateFinished)
                return;
            if (!p1Card1)
            {
                Animator cAnim = P1C1.GetComponent<Animator>();
                cAnim.Play("P1C1Animation");
                GameState.CardAnimateFinished = false;
            }
            p1Card1 = true;
            if (!GameState.CardAnimateFinished)
                return;

            if (!p2Card2)
            {
                if (txtPacked2.text == "Playing")
                {
                    Animator cAnim = P2C2.GetComponent<Animator>();
                    cAnim.Play("P2C2Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p2Card2 = true;
            if (!GameState.CardAnimateFinished)
                return;
            if (!p3Card2)
            {
                if (txtPacked3.text == "Playing")
                {
                    Animator cAnim = P3C2.GetComponent<Animator>();
                    cAnim.Play("P3C2Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p3Card2 = true;
            if (!GameState.CardAnimateFinished)
                return;
            if (!p4Card2)
            {
                if (txtPacked4.text == "Playing")
                {
                    Animator cAnim = P4C2.GetComponent<Animator>();
                    cAnim.Play("P4C2Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p4Card2 = true;
            if (!GameState.CardAnimateFinished)
                return;
            if (!p5Card2)
            {
                if (txtPacked5.text == "Playing")
                {
                    Animator cAnim = P5C2.GetComponent<Animator>();
                    cAnim.Play("P5C2Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p5Card2 = true;
            if (!GameState.CardAnimateFinished)
                return;
            if (!p1Card2)
            {

                Animator cAnim = P1C2.GetComponent<Animator>();
                cAnim.Play("P1C2Animation");
                GameState.CardAnimateFinished = false;
            }
            p1Card2 = true;
            if (!GameState.CardAnimateFinished)
                return;
            if (!p2Card3)
            {
                if (txtPacked2.text == "Playing")
                {
                    Animator cAnim = P2C3.GetComponent<Animator>();
                    cAnim.Play("P2C3Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p2Card3 = true;
            if (!GameState.CardAnimateFinished)
                return;
            if (!p3Card3)
            {
                if (txtPacked3.text == "Playing")
                {
                    Animator cAnim = P3C3.GetComponent<Animator>();
                    cAnim.Play("P3C3Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p3Card3 = true;
            if (!GameState.CardAnimateFinished)
                return;
            if (!p4Card3)
            {
                if (txtPacked4.text == "Playing")
                {
                    Animator cAnim = P4C3.GetComponent<Animator>();
                    cAnim.Play("P4C3Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p4Card3 = true;
            if (!GameState.CardAnimateFinished)
                return;
            if (!p5Card3)
            {
                if (txtPacked5.text == "Playing")
                {
                    Animator cAnim = P5C3.GetComponent<Animator>();
                    cAnim.Play("P5C3Animation");
                    GameState.CardAnimateFinished = false;
                }
                else
                {
                    GameState.CardAnimateFinished = true;
                }
            }
            p5Card3 = true;
            if (!GameState.CardAnimateFinished)
                return;
            if (!p1Card3)
            {

                Animator cAnim = P1C3.GetComponent<Animator>();
                cAnim.Play("P1C3Animation");
                GameState.CardAnimateFinished = false;
            }
            p1Card3 = true;
            if (!GameState.CardAnimateFinished)
                return;

            //Mine.OC = "CardDeal";
            Mine.OC = OpCodes.Deal;
            //Mine.OP = "Done";
            Mine.OP = OpCodes.DealDone;
            // Convert data to json string
            json = JsonUtility.ToJson(Mine);
            // Send json string to socket
            //--ws.Send(Encoding.UTF8.GetBytes(json));
            // set to recieve; new message again
            newMessage = false;
            DealMessageSent = false;
            txtAnnounce.text = "Card Dealing Complete";
            OtherPlayer.OP = "";
           
            OtherPlayer.OC = "";
            GameState.pot = false;
            return;
        }
        if (newMessage)
        {
            if(OtherPlayer.PN=="null")
            {
                txtAnnounce.text = "A player has joined the room.";
                newMessage = false;
                return;
            }

            if(OtherPlayer.PN!=DBManager.username && OtherPlayer.RI==RoomId.text)
            {   
                
                // Dealer Begins----------------------------------------------------------------------------------------------------------

                //if (OtherPlayer.OC=="START" && Mine.DN==DBManager.username && txtPacked1.text=="Watching")
                if (OtherPlayer.OC == OpCodes.Start && Mine.DN == DBManager.username && txtPacked1.text != "Playing")
                {
                    btnLobby.enabled = false;
                    //I'm the dealer. It's new game, I will deal the cards, conduct the game.                    

                    //reset all the globals
                    tmpCards1 = "";
                    tmpCards2 = "";
                    tmpCards3 = "";
                    tmpCards4 = "";
                    tmpCards5 = "";
                    cList1 = new string[] { "0", "0", "0" };
                    cList2 = new string[] { "0", "0", "0" };
                    cList3 = new string[] { "0", "0", "0" };
                    cList4 = new string[] { "0", "0", "0" };
                    cList5 = new string[] { "0", "0", "0" };
                    MyGame.FirstPlayerCardWeight = 0;
                    MyGame.SecondPlayerCardWeight = 0;
                    MyGame.ThirdPlayerCardWeight = 0;
                    MyGame.FourthPlayerCardWeight = 0;
                    MyGame.FifthPlayerCardWeight = 0;
                    sideshow = "";
                    txtPacked1.text = "Playing";
                // Reset Player counter
                gPlayerCount = 1;
                // As I'm the dealer, I'm the first player playing
                //gPlayerCount = 1;
                // Reset all the chaal amount to nothing
                txtLastCoin2.text = "";
                txtLastCoin3.text = "";
                txtLastCoin4.text = "";
                txtLastCoin5.text = "";
                // Reset my chaal amount to lowest
                txtAmount.text = "2";
                // Reset all player's pot amount to lowest
                txtThrowCoin.text = "2";
                txtThrowCoin2.text = "2";
                txtThrowCoin3.text = "2";
                txtThrowCoin4.text = "2";
                txtThrowCoin5.text = "2";
                    // reset BM to zero
                    txtPotCoin.text = "0";
                // Reset all the player's chaal
                txtChaal2.text = "";
                txtChaal3.text = "";
                txtChaal4.text = "";
                txtChaal5.text = "";

                // Reset see and blind button
                txtSee.text = "SEE";
                btnSee.SetActive(false);
                txtBlind.text = "BLIND";
                // Reset GamePanel
                btnBlind.interactable = true;
                btnMinus.interactable = false;
                btnPlus.interactable = true;
                btnPack.interactable = true;
                btnShow.interactable = false;
                BlindLimit = 0;

                // Hide all the show cards slots
                ShowCardsP2.SetActive(false);
                ShowCardsP3.SetActive(false);
                ShowCardsP4.SetActive(false);
                ShowCardsP5.SetActive(false);
                
                // Check if this other player is new player or existing one
                // He will be given an empty seat first if he is new
                if (OtherPlayer.PN!=Seat2.text && OtherPlayer.PN!=Seat3.text && OtherPlayer.PN!=Seat4.text && OtherPlayer.PN!=Seat5.text)
                {                       
                    //This player has just entered the room while the game is about to begin
                    // Arrange his seat first
                    int serialHis = int.Parse(OtherPlayer.SR);
                    int serialMine = int.Parse(Mine.SR);
                    if (serialHis > serialMine)
                    {
                        if (serialHis - serialMine == 1)
                        {
                            Seat2.text = OtherPlayer.PN;
                                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + OtherPlayer.PI);
                                imgP2.GetComponent<Image>().sprite = tmpPicute;
                            }
                        if (serialHis - serialMine == 2)
                        {
                            Seat3.text = OtherPlayer.PN;
                                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + OtherPlayer.PI);
                                imgP3.GetComponent<Image>().sprite = tmpPicute;
                            }
                        if (serialHis - serialMine == 3)
                        {
                            Seat4.text = OtherPlayer.PN;
                                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + OtherPlayer.PI);
                                imgP4.GetComponent<Image>().sprite = tmpPicute;
                            }
                        if (serialHis - serialMine == 4)
                        {
                            Seat5.text = OtherPlayer.PN;
                                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + OtherPlayer.PI);
                                imgP5.GetComponent<Image>().sprite = tmpPicute;
                            }
                    }
                    if (serialHis < serialMine)
                    {
                        if (serialMine - serialHis == 1)
                        {
                            Seat5.text = OtherPlayer.PN;
                                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + OtherPlayer.PI);
                                imgP5.GetComponent<Image>().sprite = tmpPicute;
                                GameState.seat5Playing = false;
                        }
                        if (serialMine - serialHis == 2)
                        {
                            Seat4.text = OtherPlayer.PN;
                                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + OtherPlayer.PI);
                                imgP4.GetComponent<Image>().sprite = tmpPicute;
                                GameState.seat4Playing = false;
                        }
                        if (serialMine - serialHis == 3)
                        {
                            Seat3.text = OtherPlayer.PN;
                                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + OtherPlayer.PI);
                                imgP3.GetComponent<Image>().sprite = tmpPicute;
                                GameState.seat3Playing = false;
                        }
                        if (serialMine - serialHis == 4)
                        {
                            Seat2.text = OtherPlayer.PN;
                                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + OtherPlayer.PI);
                                imgP2.GetComponent<Image>().sprite = tmpPicute;
                                GameState.seat2Playing = false;
                        }
                    }
                }
                // Now throw coins in the pot
                // NP has all the playing player list
                //Mine.NP =DBManager.username;
                if(Seat2.text!="EMPTY")
                {
                        GameSoundFx.PlayOneShot(BootMoneySound);
                        // Collect pot money                        
                        // P2Coin.Play("ThrowCoin");
                        P2Coin.Play("PotCoinP2");
                    txtPotCoin.text = (int.Parse(txtPotCoin.text) + int.Parse(txtThrowCoin2.text)).ToString();
                        // change player to playing
                        txtPacked2.text = "Playing";
                        
                        //Mine.NP = Mine.NP + "," + Seat2.text;
                        
                    }
                if (Seat3.text != "EMPTY")
                {
                        GameSoundFx.PlayOneShot(BootMoneySound);
                        // Collect pot money                        
                        //P3Coin.Play("ThrowCoin");
                        P3Coin.Play("PotCoinP3");
                    txtPotCoin.text = (int.Parse(txtPotCoin.text) + int.Parse(txtThrowCoin3.text)).ToString();
                        // change player to playing
                        txtPacked3.text = "Playing";
                        
                        //Mine.NP = Mine.NP + "," + Seat3.text ;
                    }
                if (Seat4.text != "EMPTY")
                {
                        GameSoundFx.PlayOneShot(BootMoneySound);
                        // Collect pot money                        
                        // P4Coin.Play("ThrowCoin");
                        P4Coin.Play("PotCoinP4");
                    txtPotCoin.text = (int.Parse(txtPotCoin.text) + int.Parse(txtThrowCoin4.text)).ToString();
                        // change player to playing
                        txtPacked4.text = "Playing";
                        
                        //Mine.NP = Mine.NP + "," + Seat4.text;
                    }
                if (Seat5.text != "EMPTY")
                {
                        GameSoundFx.PlayOneShot(BootMoneySound);
                        // Collect pot money                        
                        //P5Coin.Play("ThrowCoin");
                        P5Coin.Play("PotCoinP5");
                    txtPotCoin.text = (int.Parse(txtPotCoin.text) + int.Parse(txtThrowCoin5.text)).ToString();
                        // change player to playing
                        txtPacked5.text = "Playing";
                        //txtPacked5.enabled = true;
                        //Mine.NP = Mine.NP + "," + Seat5.text;
                    }
                    txtChaal2.text = "";
                    txtChaal3.text = "";
                    txtChaal4.text = "";
                    txtChaal5.text = "";
                    GameSoundFx.PlayOneShot(BootMoneySound);
                    //P1Coin.Play("ThrowCoin");
                    P1Coin.Play("PotCoinP1");
                txtPotCoin.text = (int.Parse(txtPotCoin.text) + int.Parse(txtThrowCoin.text)).ToString();
                    txtMyCoin.text = (int.Parse(txtMyCoin.text) - int.Parse(txtThrowCoin.text)).ToString();
                    Mine.BM = txtPotCoin.text;
               // Mine.GameState = "On";

                    //Mine.OC = "Pot";
                    Mine.OC = OpCodes.Pot;
                GameState.pot = true;
                txtAnnounce.text = "New Game Started!";
                Mine.OP = txtThrowCoin.text;
                    strAllPlayers = Mine.NP;
                
                // Convert data to json string
                json = JsonUtility.ToJson(Mine);
                // Send json string to socket
                //--ws.Send(Encoding.UTF8.GetBytes(json));
                // set to recieve; new message again
                newMessage = false;
                    Mine.NP = "";
                return;                    
            }

                //if (OtherPlayer.OC=="Pot" && OtherPlayer.OP==txtThrowCoin.text)
                if (OtherPlayer.OC == OpCodes.Pot && OtherPlayer.OP == txtThrowCoin.text)
                {
                    btnLobby.enabled = false;
                    //So the dealer started a new game. I should reset everything
                    // First Hide all the packed texts except mine
                    //txtPacked1.enabled = false;
                    //txtPacked2.enabled = false;
                    //txtPacked3.enabled = false;
                    //txtPacked4.enabled = false;
                    //txtPacked5.enabled = false;
                    // reset all the global variables
                    tmpCards1 = "";
                    tmpCards2 = "";
                    tmpCards3 = "";
                    tmpCards4 = "";
                    tmpCards5 = "";
                    cList1 = new string[] { "0", "0", "0" };
                    cList2 = new string[] { "0", "0", "0" };
                    cList3 = new string[] { "0", "0", "0" };
                    cList4 = new string[] { "0", "0", "0" };
                    cList5 = new string[] { "0", "0", "0" };
                    MyGame.FirstPlayerCardWeight = 0;
                    MyGame.SecondPlayerCardWeight = 0;
                    MyGame.ThirdPlayerCardWeight = 0;
                    MyGame.FourthPlayerCardWeight = 0;
                    MyGame.FifthPlayerCardWeight = 0;
                    sideshow = "";
                    // change mine to playing
                    txtPacked1.text = "Playing";
                    // change the rest player status according to given info
                    //string[] tpl = OtherPlayer.NP.Split(',');
                    /*
                    for(int i=0; i<tpl.Length;i++)
                    {
                        if (tpl[i] == Seat2.text)
                        {
                            txtPacked2.text = "Playing";
                            //txtPacked2.enabled = true;
                        }
                            
                        else if (tpl[i] == Seat3.text)
                        {
                            txtPacked3.text = "Playing";
                            //txtPacked3.enabled = true;
                        }
                            
                        else if (tpl[i] == Seat4.text)
                        {
                            txtPacked4.text = "Playing";
                            //txtPacked4.enabled = true;
                        }
                            
                        else if (tpl[i] == Seat5.text)
                        {
                            txtPacked5.text = "Playing";
                            //txtPacked5.enabled = true;
                        }
                            
                    }
                    
                    //if(Seat2.text!="EMPTY")
                    
                    // reset player counter
                    gPlayerCount = 1;
                    //gPlayerCount++;
                    // Reset all the chaal amount to nothing
                    txtLastCoin2.text = "";
                    txtLastCoin3.text = "";
                    txtLastCoin4.text = "";
                    txtLastCoin5.text = "";
                    // Reset my chaal amount to lowest
                    txtAmount.text = "2";
                    // Reset all player's pot amount to lowest
                    txtThrowCoin.text = "2";
                    txtThrowCoin2.text = "2";
                    txtThrowCoin3.text = "2";
                    txtThrowCoin4.text = "2";
                    txtThrowCoin5.text = "2";
                    // Reset board money to zero
                    txtPotCoin.text = "0";
                    // Reset all the player's chaal
                    txtChaal2.text = "";
                    txtChaal3.text = "";
                    txtChaal4.text = "";
                    txtChaal5.text = "";
                    // Reset see and blind button
                    txtSee.text = "SEE";
                    btnSee.SetActive(false);
                    txtBlind.text = "BLIND";
                    // Reset GamePanel
                    btnBlind.interactable = true;
                    btnMinus.interactable = false;
                    btnPlus.interactable = true;
                    btnPack.interactable = true;
                    btnShow.interactable = false;
                    BlindLimit = 0;
                    // Hide all the show cards slots
                    ShowCardsP2.SetActive(false);
                    ShowCardsP3.SetActive(false);
                    ShowCardsP4.SetActive(false);
                    ShowCardsP5.SetActive(false);
                    // Now throw coins in the pot
                    if (Seat2.text != "EMPTY")
                    {
                        GameSoundFx.PlayOneShot(BootMoneySound);
                        // Collect pot money                        
                        //P2Coin.Play("ThrowCoin");
                        P2Coin.Play("PotCoinP2");
                        txtPotCoin.text = (int.Parse(txtPotCoin.text) + int.Parse(txtThrowCoin2.text)).ToString();
                        txtPacked2.text = "Playing";
                        
                    }
                    if (Seat3.text != "EMPTY")
                    {
                        GameSoundFx.PlayOneShot(BootMoneySound);
                        // Collect pot money                        
                        //P3Coin.Play("ThrowCoin");
                        P3Coin.Play("PotCoinP3");
                        txtPotCoin.text = (int.Parse(txtPotCoin.text) + int.Parse(txtThrowCoin3.text)).ToString();
                        txtPacked3.text = "Playing";
                        // change player to playing
                        //txtPacked3.text = "Playing";
                        //txtPacked3.enabled = true;
                    }
                    if (Seat4.text != "EMPTY")
                    {
                        GameSoundFx.PlayOneShot(BootMoneySound);
                        // Collect pot money                        
                        //P4Coin.Play("ThrowCoin");
                        P4Coin.Play("PotCoinP4");
                        txtPotCoin.text = (int.Parse(txtPotCoin.text) + int.Parse(txtThrowCoin4.text)).ToString();
                        txtPacked4.text = "Playing";
                        // change player to playing
                        //txtPacked4.text = "Playing";
                        //txtPacked4.enabled = true;
                    }
                    if (Seat5.text != "EMPTY")
                    {
                        GameSoundFx.PlayOneShot(BootMoneySound);
                        // Collect pot money                        
                        //P5Coin.Play("ThrowCoin");
                        P5Coin.Play("PotCoinP5");
                        txtPotCoin.text = (int.Parse(txtPotCoin.text) + int.Parse(txtThrowCoin5.text)).ToString();
                        txtPacked5.text = "Playing";
                        // change player to playing
                        //txtPacked5.text = "Playing";
                        //txtPacked5.enabled = true;
                    }
                    GameSoundFx.PlayOneShot(BootMoneySound);
                    //P1Coin.Play("ThrowCoin");
                    P1Coin.Play("PotCoinP1");
                    txtPotCoin.text = (int.Parse(txtPotCoin.text) + int.Parse(txtThrowCoin.text)).ToString();
                    txtMyCoin.text = (int.Parse(txtMyCoin.text) - int.Parse(txtThrowCoin.text)).ToString();
                    txtAnnounce.text = "New Game Started!";
                    Mine.BM = txtPotCoin.text;
                    //Mine.GameState = OtherPlayer.GameState;
                    // Now send opcode Pot = done
                    //Mine.OC = "Pot";
                    Mine.OC = OpCodes.Pot;
                    //Mine.OP = "Done";
                    Mine.OP = OpCodes.PotDone;
                    GameState.pot = true;
                    // Convert data to json string
                    json = JsonUtility.ToJson(Mine);
                    // Send json string to socket
                    //--ws.Send(Encoding.UTF8.GetBytes(json));
                    // set to recieve; new message again
                    newMessage = false;
                    
                    PotFinished = false;
                    DealFinished = false;
                    DealMessageSent = false;
                    CardFinished = false;
                    PotFinished = false;
                    p1Card1 = false;
                    p1Card2 = false;
                    p1Card3 = false;
                    p2Card1 = false;
                    p2Card2 = false;
                    p2Card3 = false;
                    p3Card1 = false;
                    p3Card2 = false;
                    p3Card3 = false;
                    p4Card1 = false;
                    p4Card2 = false;
                    p4Card3 = false;
                    p5Card1 = false;
                    p5Card2 = false;
                    p5Card3 = false;
                    
                    GameState.CardAnimateFinished = false;
                    return;
                }
                //if (Mine.DN == DBManager.username && OtherPlayer.OC == "Pot" && OtherPlayer.OP == "Done" && !PotFinished)
                if (Mine.DN == DBManager.username && OtherPlayer.OC == OpCodes.Pot && OtherPlayer.OP == OpCodes.PotDone && !PotFinished)
                {
                    PotFinished = true;

                    txtAnnounce.text = "New Game Started!";

                    //Mine.OC = "Cards";
                    Mine.OC = OpCodes.Cards;
                    //Mine.OP = "Start";
                    Mine.OP = OpCodes.CardStart;
                    // Convert data to json string
                    json = JsonUtility.ToJson(Mine);
                    // Send json string to socket
                    //--ws.Send(Encoding.UTF8.GetBytes(json));
                    // set to recieve; new message again 
                    newMessage = false;
                    DealMessageSent = true;
                    return;
                }
                // DealMessageSent = true;

                //if (OtherPlayer.OC == "Cards" && OtherPlayer.OP == "Start")
                if (OtherPlayer.OC == OpCodes.Cards && OtherPlayer.OP == OpCodes.CardStart)
                {
                    //txtAnnounce.text = "Trapped 1";
                    DealMessageSent = true;
                    return;
                }

                //if (Mine.DN==DBManager.username && OtherPlayer.OC == "CardDeal" && OtherPlayer.OP == "Done" && !DealFinished)
                if (Mine.DN == DBManager.username && OtherPlayer.OC == OpCodes.Deal && OtherPlayer.OP == OpCodes.DealDone && !DealFinished)
                {
                    DealFinished = true;
                    p1Finished = false;
                    p2Finished = false;
                    p3Finished = false;
                    p4Finished = false;
                    p5Finished = false;
                    // Now save your cards and send other players cards to the socket
                    //txtAnnounce.text = "Card Weight started";
                    // reset dealing cards
                    // restore any player that joined when dealing
                    
                    MyGame.ResetCards();
                    // reset card storages
                    
                    Mine.OP = "";
                    int nCard = 0;
                    //send my cards
                    nCard = MyGame.GetRandomCard;
                    MyGame.RemoveRandomCard(nCard);
                    tmpCards1 = nCard.ToString() + ",";
                    nCard = MyGame.GetRandomCard;
                    MyGame.RemoveRandomCard(nCard);
                    tmpCards1 = tmpCards1 + nCard.ToString() + ",";
                    nCard = MyGame.GetRandomCard;
                    MyGame.RemoveRandomCard(nCard);
                    tmpCards1 = tmpCards1 + nCard.ToString();
                    cList1 = tmpCards1.Split(',');
                    MyGame.FirstPlayerCardWeight = SavePlayerCardValue(int.Parse(cList1[0]), int.Parse(cList1[1]), int.Parse(cList1[2]));
                    StartCoroutine(SavePlayerCards(RoomId.text, DBManager.username, cList1[0], cList1[1], cList1[2], MyGame.FirstPlayerCardWeight.ToString()));                   

                    if (Seat2.text!="EMPTY")
                    {                         
                            nCard = MyGame.GetRandomCard;
                            MyGame.RemoveRandomCard(nCard);
                            tmpCards2= nCard.ToString() + ",";                            
                            nCard = MyGame.GetRandomCard;
                            MyGame.RemoveRandomCard(nCard);
                            tmpCards2 = tmpCards2 + nCard.ToString() + ",";                            
                            nCard = MyGame.GetRandomCard;
                            MyGame.RemoveRandomCard(nCard);
                            tmpCards2 = tmpCards2 + nCard.ToString();                            
                            cList2 = tmpCards2.Split(',');
                            MyGame.SecondPlayerCardWeight = SavePlayerCardValue(int.Parse(cList2[0]), int.Parse(cList2[1]), int.Parse(cList2[2]));
                            StartCoroutine(SavePlayerCards(RoomId.text, Seat2.text, cList2[0], cList2[1], cList2[2], MyGame.SecondPlayerCardWeight.ToString()));
                            txtPacked2.text = "Playing";
                        }
                        else
                        {
                            tmpCards2 = "0,0,0";
                        }
                        
                        if (Seat3.text != "EMPTY")
                        {
                            nCard = MyGame.GetRandomCard;
                            MyGame.RemoveRandomCard(nCard);
                            tmpCards3 = nCard.ToString() + ",";
                            nCard = MyGame.GetRandomCard;
                            MyGame.RemoveRandomCard(nCard);
                            tmpCards3 = tmpCards3 + nCard.ToString() + ",";
                            nCard = MyGame.GetRandomCard;
                            MyGame.RemoveRandomCard(nCard);
                            tmpCards3 = tmpCards3 + nCard.ToString();
                            cList3 = tmpCards3.Split(',');
                            MyGame.ThirdPlayerCardWeight = SavePlayerCardValue(int.Parse(cList3[0]), int.Parse(cList3[1]), int.Parse(cList3[2]));
                            StartCoroutine(SavePlayerCards(RoomId.text, Seat3.text, cList3[0], cList3[1], cList3[2], MyGame.ThirdPlayerCardWeight.ToString()));
                            txtPacked3.text = "Playing";
                    }
                    else
                    {
                        tmpCards3 = "0,0,0";
                    }


                    if (Seat4.text != "EMPTY")
                        {
                            nCard = MyGame.GetRandomCard;
                            MyGame.RemoveRandomCard(nCard);
                            tmpCards4 = nCard.ToString() + ",";
                            nCard = MyGame.GetRandomCard;
                            MyGame.RemoveRandomCard(nCard);
                            tmpCards4 = tmpCards4 + nCard.ToString() + ",";
                            nCard = MyGame.GetRandomCard;
                            MyGame.RemoveRandomCard(nCard);
                            tmpCards4 = tmpCards4 + nCard.ToString();
                            cList4 = tmpCards4.Split(',');
                            MyGame.FourthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList4[0]), int.Parse(cList4[1]), int.Parse(cList4[2]));
                            StartCoroutine(SavePlayerCards(RoomId.text, Seat4.text, cList4[0], cList4[1], cList4[2], MyGame.FourthPlayerCardWeight.ToString()));
                            txtPacked4.text = "Playing";

                    }
                    else
                    {
                        tmpCards4 = "0,0,0";
                    }


                    if (Seat5.text != "EMPTY")
                        {
                            nCard = MyGame.GetRandomCard;
                            MyGame.RemoveRandomCard(nCard);
                            tmpCards5 = nCard.ToString() + ",";
                            nCard = MyGame.GetRandomCard;
                            MyGame.RemoveRandomCard(nCard);
                            tmpCards5 = tmpCards5 + nCard.ToString() + ",";
                            nCard = MyGame.GetRandomCard;
                            MyGame.RemoveRandomCard(nCard);
                            tmpCards5 = tmpCards5 + nCard.ToString();
                            cList5 = tmpCards5.Split(',');
                            MyGame.FifthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList5[0]), int.Parse(cList5[1]), int.Parse(cList5[2]));
                            StartCoroutine(SavePlayerCards(RoomId.text, Seat5.text, cList5[0], cList5[1], cList5[2], MyGame.FifthPlayerCardWeight.ToString()));
                            txtPacked5.text = "Playing";
                    }
                    else
                    {
                        tmpCards5 = "0,0,0";
                    }
                    
                    Mine.OC = OpCodes.AllCards;
                    Mine.OP = Seat1.text+"="+tmpCards1+"|"+Seat2.text+"="+tmpCards2+"|"+Seat3.text+"="+tmpCards3+"|"+Seat4.text+"="+tmpCards4+"|"+Seat5.text+"="+tmpCards5;
                    //Mine.NP = DBManager.username;
                    txtSee.text = "SEE";
                    btnSee.SetActive(true);
                    //txtAnnounce.text = "Dealer done Card Weight, cards: "+cList1[0]+" "+cList1[1]+" "+cList1[2];
                    // Convert data to json string
                    json = JsonUtility.ToJson(Mine);
                    // Send json string to socket
                    //--ws.Send(Encoding.UTF8.GetBytes(json));
                    //SendingCards = 1;
                    newMessage = false;
                    return;                    
                }
                if(OtherPlayer.OC==OpCodes.AllCards && Mine.DN!=DBManager.username)
                {
                    txtSee.text = "SEE";
                    btnSee.SetActive(true);
                    string[] PlayerCardsPair = OtherPlayer.OP.Split('|');
                    string[] p1c = PlayerCardsPair[0].Split('=');
                    string[] p2c = PlayerCardsPair[1].Split('=');
                    string[] p3c = PlayerCardsPair[2].Split('=');
                    string[] p4c = PlayerCardsPair[3].Split('=');
                    string[] p5c = PlayerCardsPair[4].Split('=');

                    if(Seat1.text==p1c[0])
                    {
                        tmpCards1 = p1c[1];
                        cList1 = tmpCards1.Split(',');
                        MyGame.FirstPlayerCardWeight = SavePlayerCardValue(int.Parse(cList1[0]), int.Parse(cList1[1]), int.Parse(cList1[2]));
                    }
                    else if(Seat1.text == p2c[0])
                    {
                        tmpCards1 = p2c[1];
                        cList1 = tmpCards1.Split(',');
                        MyGame.FirstPlayerCardWeight = SavePlayerCardValue(int.Parse(cList1[0]), int.Parse(cList1[1]), int.Parse(cList1[2]));
                    }
                    else if (Seat1.text == p3c[0])
                    {
                        tmpCards1 = p3c[1];
                        cList1 = tmpCards1.Split(',');
                        MyGame.FirstPlayerCardWeight = SavePlayerCardValue(int.Parse(cList1[0]), int.Parse(cList1[1]), int.Parse(cList1[2]));
                    }
                    else if (Seat1.text == p4c[0])
                    {
                        tmpCards1 = p4c[1];
                        cList1 = tmpCards1.Split(',');
                        MyGame.FirstPlayerCardWeight = SavePlayerCardValue(int.Parse(cList1[0]), int.Parse(cList1[1]), int.Parse(cList1[2]));
                    }
                    else if (Seat1.text == p5c[0])
                    {
                        tmpCards1 = p5c[1];
                        cList1 = tmpCards1.Split(',');
                        MyGame.FirstPlayerCardWeight = SavePlayerCardValue(int.Parse(cList1[0]), int.Parse(cList1[1]), int.Parse(cList1[2]));
                    }
                    if(Seat2.text!="EMPTY")
                    {
                        if (Seat2.text == p1c[0])
                        {
                            tmpCards2 = p1c[1];
                            cList2 = tmpCards2.Split(',');
                            MyGame.SecondPlayerCardWeight = SavePlayerCardValue(int.Parse(cList2[0]), int.Parse(cList2[1]), int.Parse(cList2[2]));
                        }
                        else if (Seat2.text == p2c[0])
                        {
                            tmpCards2 = p2c[1];
                            cList2 = tmpCards2.Split(',');
                            MyGame.SecondPlayerCardWeight = SavePlayerCardValue(int.Parse(cList2[0]), int.Parse(cList2[1]), int.Parse(cList2[2]));
                        }
                        else if (Seat2.text == p3c[0])
                        {
                            tmpCards2 = p3c[1];
                            cList2 = tmpCards2.Split(',');
                            MyGame.SecondPlayerCardWeight = SavePlayerCardValue(int.Parse(cList2[0]), int.Parse(cList2[1]), int.Parse(cList2[2]));
                        }
                        else if (Seat2.text == p4c[0])
                        {
                            tmpCards2 = p4c[1];
                            cList2 = tmpCards2.Split(',');
                            MyGame.SecondPlayerCardWeight = SavePlayerCardValue(int.Parse(cList2[0]), int.Parse(cList2[1]), int.Parse(cList2[2]));
                        }
                        else if (Seat2.text == p5c[0])
                        {
                            tmpCards2 = p5c[1];
                            cList2 = tmpCards2.Split(',');
                            MyGame.SecondPlayerCardWeight = SavePlayerCardValue(int.Parse(cList2[0]), int.Parse(cList2[1]), int.Parse(cList2[2]));
                        }
                    }
                    if (Seat3.text != "EMPTY")
                    {
                        if (Seat3.text == p1c[0])
                        {
                            tmpCards3 = p1c[1];
                            cList3 = tmpCards3.Split(',');
                            MyGame.ThirdPlayerCardWeight = SavePlayerCardValue(int.Parse(cList3[0]), int.Parse(cList3[1]), int.Parse(cList3[2]));
                        }
                        else if (Seat3.text == p2c[0])
                        {
                            tmpCards3 = p2c[1];
                            cList3 = tmpCards3.Split(',');
                            MyGame.ThirdPlayerCardWeight = SavePlayerCardValue(int.Parse(cList3[0]), int.Parse(cList3[1]), int.Parse(cList3[2]));
                        }
                        else if (Seat3.text == p3c[0])
                        {
                            tmpCards3 = p3c[1];
                            cList3 = tmpCards3.Split(',');
                            MyGame.ThirdPlayerCardWeight = SavePlayerCardValue(int.Parse(cList3[0]), int.Parse(cList3[1]), int.Parse(cList3[2]));
                        }
                        else if (Seat3.text == p4c[0])
                        {
                            tmpCards3 = p4c[1];
                            cList3 = tmpCards3.Split(',');
                            MyGame.ThirdPlayerCardWeight = SavePlayerCardValue(int.Parse(cList3[0]), int.Parse(cList3[1]), int.Parse(cList3[2]));
                        }
                        else if (Seat3.text == p5c[0])
                        {
                            tmpCards3 = p5c[1];
                            cList3 = tmpCards3.Split(',');
                            MyGame.ThirdPlayerCardWeight = SavePlayerCardValue(int.Parse(cList3[0]), int.Parse(cList3[1]), int.Parse(cList3[2]));
                        }
                    }
                    if (Seat4.text != "EMPTY")
                    {
                        if (Seat4.text == p1c[0])
                        {
                            tmpCards4 = p1c[1];
                            cList4 = tmpCards4.Split(',');
                            MyGame.FourthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList4[0]), int.Parse(cList4[1]), int.Parse(cList4[2]));
                        }
                        else if (Seat4.text == p2c[0])
                        {
                            tmpCards4 = p2c[1];
                            cList4 = tmpCards4.Split(',');
                            MyGame.FourthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList4[0]), int.Parse(cList4[1]), int.Parse(cList4[2]));
                        }
                        else if (Seat4.text == p3c[0])
                        {
                            tmpCards4 = p3c[1];
                            cList4 = tmpCards4.Split(',');
                            MyGame.FourthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList4[0]), int.Parse(cList4[1]), int.Parse(cList4[2]));
                        }
                        else if (Seat4.text == p4c[0])
                        {
                            tmpCards4 = p4c[1];
                            cList4 = tmpCards4.Split(',');
                            MyGame.FourthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList4[0]), int.Parse(cList4[1]), int.Parse(cList4[2]));
                        }
                        else if (Seat4.text == p5c[0])
                        {
                            tmpCards4 = p5c[1];
                            cList4 = tmpCards4.Split(',');
                            MyGame.FourthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList4[0]), int.Parse(cList4[1]), int.Parse(cList4[2]));
                        }
                    }
                    if (Seat5.text != "EMPTY")
                    {
                        if (Seat5.text == p1c[0])
                        {
                            tmpCards5 = p1c[1];
                            cList5 = tmpCards5.Split(',');
                            MyGame.FifthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList5[0]), int.Parse(cList5[1]), int.Parse(cList5[2]));
                        }
                        else if (Seat5.text == p2c[0])
                        {
                            tmpCards5 = p2c[1];
                            cList5 = tmpCards5.Split(',');
                            MyGame.FifthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList5[0]), int.Parse(cList5[1]), int.Parse(cList5[2]));
                        }
                        else if (Seat5.text == p3c[0])
                        {
                            tmpCards5 = p3c[1];
                            cList5 = tmpCards5.Split(',');
                            MyGame.FifthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList5[0]), int.Parse(cList5[1]), int.Parse(cList5[2]));
                        }
                        else if (Seat5.text == p4c[0])
                        {
                            tmpCards5 = p4c[1];
                            cList5 = tmpCards5.Split(',');
                            MyGame.FifthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList5[0]), int.Parse(cList5[1]), int.Parse(cList5[2]));
                        }
                        else if (Seat5.text == p5c[0])
                        {
                            tmpCards5 = p5c[1];
                            cList5 = tmpCards5.Split(',');
                            MyGame.FifthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList5[0]), int.Parse(cList5[1]), int.Parse(cList5[2]));
                        }
                    }
                    btnLobby.enabled = true;
                    Mine.OC = OpCodes.CardsReceived;
                    //Mine.OP = tmpCards5;
                    //Mine.NP = Seat5.text;
                    // Convert data to json string
                    json = JsonUtility.ToJson(Mine);
                    // Send json string to socket
                    //--ws.Send(Encoding.UTF8.GetBytes(json));
                    newMessage = false;
                    return;
                }
                
                if (OtherPlayer.OC==OpCodes.SendingP1 && Mine.DN!=DBManager.username)
                {                
                    if(OtherPlayer.NP==Seat2.text)
                    {
                        
                        tmpCards2 = OtherPlayer.OP;
                        cList2 = OtherPlayer.OP.Split(',');
                        MyGame.SecondPlayerCardWeight = SavePlayerCardValue(int.Parse(cList2[0]), int.Parse(cList2[1]), int.Parse(cList2[2]));
                        

                    }
                    else if (OtherPlayer.NP == Seat3.text)
                    {
                        tmpCards3 = OtherPlayer.OP;
                        cList3 = OtherPlayer.OP.Split(',');
                        MyGame.ThirdPlayerCardWeight = SavePlayerCardValue(int.Parse(cList3[0]), int.Parse(cList3[1]), int.Parse(cList3[2]));
                                                
                    }
                    else if (OtherPlayer.NP == Seat4.text)
                    {
                        tmpCards4 = OtherPlayer.OP;
                        cList4 = OtherPlayer.OP.Split(',');
                        MyGame.FourthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList4[0]), int.Parse(cList4[1]), int.Parse(cList4[2]));
                        
                    }
                    else if (OtherPlayer.NP == Seat5.text)
                    {
                        tmpCards5 = OtherPlayer.OP;
                        cList5 = OtherPlayer.OP.Split(',');
                        MyGame.FifthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList5[0]), int.Parse(cList5[1]), int.Parse(cList5[2]));
                        
                    }
                    Mine.OC = OpCodes.GotP1;
                    //Mine.OP = tmpCards5;
                    //Mine.NP = Seat5.text;
                    // Convert data to json string
                    json = JsonUtility.ToJson(Mine);
                    // Send json string to socket
                    //--ws.Send(Encoding.UTF8.GetBytes(json));
                    newMessage = false;
                    return;
                }
                if(OtherPlayer.OC==OpCodes.GotP1 && Mine.DN==DBManager.username && !p1Finished)
                {
                    p1Finished = true;
                        Mine.OC = OpCodes.SendingP2;
                        Mine.OP = tmpCards2;
                        Mine.NP = Seat2.text;
                        // Convert data to json string
                        json = JsonUtility.ToJson(Mine);
                        // Send json string to socket
                        //--ws.Send(Encoding.UTF8.GetBytes(json));
                        //SendingCards = 1;
                        newMessage = false;
                    
                    
                    return;
                }
                if (OtherPlayer.OC == OpCodes.SendingP2 && Mine.DN != DBManager.username)
                {
                    if(OtherPlayer.OP=="")
                    {
                        Mine.OC = OpCodes.GotP2;
                        //Mine.OP = tmpCards5;
                        //Mine.NP = Seat5.text;
                        // Convert data to json string
                        json = JsonUtility.ToJson(Mine);
                        // Send json string to socket
                        //--ws.Send(Encoding.UTF8.GetBytes(json));
                        newMessage = false;
                        return;
                    }

                    if (OtherPlayer.NP == Seat1.text)
                    {
                        tmpCards1 = OtherPlayer.OP;
                        cList1 = OtherPlayer.OP.Split(',');
                        MyGame.FirstPlayerCardWeight = SavePlayerCardValue(int.Parse(cList1[0]), int.Parse(cList1[1]), int.Parse(cList1[2]));
                        txtSee.text = "SEE";
                        btnSee.SetActive(true);

                    }
                    else if (OtherPlayer.NP == Seat2.text)
                    {

                        tmpCards2 = OtherPlayer.OP;
                        cList2 = OtherPlayer.OP.Split(',');
                        MyGame.SecondPlayerCardWeight = SavePlayerCardValue(int.Parse(cList2[0]), int.Parse(cList2[1]), int.Parse(cList2[2]));


                    }
                    else if (OtherPlayer.NP == Seat3.text)
                    {
                        tmpCards3 = OtherPlayer.OP;
                        cList3 = OtherPlayer.OP.Split(',');
                        MyGame.ThirdPlayerCardWeight = SavePlayerCardValue(int.Parse(cList3[0]), int.Parse(cList3[1]), int.Parse(cList3[2]));

                    }
                    else if (OtherPlayer.NP == Seat4.text)
                    {
                        tmpCards4 = OtherPlayer.OP;
                        cList4 = OtherPlayer.OP.Split(',');
                        MyGame.FourthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList4[0]), int.Parse(cList4[1]), int.Parse(cList4[2]));

                    }
                    else if (OtherPlayer.NP == Seat5.text)
                    {
                        tmpCards5 = OtherPlayer.OP;
                        cList5 = OtherPlayer.OP.Split(',');
                        MyGame.FifthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList5[0]), int.Parse(cList5[1]), int.Parse(cList5[2]));

                    }
                    Mine.OC = OpCodes.GotP2;
                    //Mine.OP = tmpCards5;
                    //Mine.NP = Seat5.text;
                    // Convert data to json string
                    json = JsonUtility.ToJson(Mine);
                    // Send json string to socket
                    //--ws.Send(Encoding.UTF8.GetBytes(json));
                    newMessage = false;
                    return;
                }
                if (OtherPlayer.OC == OpCodes.GotP2 && Mine.DN == DBManager.username && !p2Finished)
                {
                    p2Finished = true;
                        Mine.OC = OpCodes.SendingP3;
                        Mine.OP = tmpCards3;
                        Mine.NP = Seat3.text;
                        // Convert data to json string
                        json = JsonUtility.ToJson(Mine);
                        // Send json string to socket
                        //--ws.Send(Encoding.UTF8.GetBytes(json));
                        //SendingCards = 1;
                        newMessage = false;
                   

                    return;
                }
                if (OtherPlayer.OC == OpCodes.SendingP3 && Mine.DN != DBManager.username)
                {
                    if (OtherPlayer.OP == "")
                    {
                        Mine.OC = OpCodes.GotP3;
                        //Mine.OP = tmpCards5;
                        //Mine.NP = Seat5.text;
                        // Convert data to json string
                        json = JsonUtility.ToJson(Mine);
                        // Send json string to socket
                        //--ws.Send(Encoding.UTF8.GetBytes(json));
                        newMessage = false;
                        return;
                    }
                    if (OtherPlayer.NP == Seat1.text)
                    {
                        tmpCards1 = OtherPlayer.OP;
                        cList1 = OtherPlayer.OP.Split(',');
                        MyGame.FirstPlayerCardWeight = SavePlayerCardValue(int.Parse(cList1[0]), int.Parse(cList1[1]), int.Parse(cList1[2]));
                        txtSee.text = "SEE";
                        btnSee.SetActive(true);

                    }
                    else if (OtherPlayer.NP == Seat2.text)
                    {

                        tmpCards2 = OtherPlayer.OP;
                        cList2 = OtherPlayer.OP.Split(',');
                        MyGame.SecondPlayerCardWeight = SavePlayerCardValue(int.Parse(cList2[0]), int.Parse(cList2[1]), int.Parse(cList2[2]));


                    }
                    else if (OtherPlayer.NP == Seat3.text)
                    {
                        tmpCards3 = OtherPlayer.OP;
                        cList3 = OtherPlayer.OP.Split(',');
                        MyGame.ThirdPlayerCardWeight = SavePlayerCardValue(int.Parse(cList3[0]), int.Parse(cList3[1]), int.Parse(cList3[2]));

                    }
                    else if (OtherPlayer.NP == Seat4.text)
                    {
                        tmpCards4 = OtherPlayer.OP;
                        cList4 = OtherPlayer.OP.Split(',');
                        MyGame.FourthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList4[0]), int.Parse(cList4[1]), int.Parse(cList4[2]));

                    }
                    else if (OtherPlayer.NP == Seat5.text)
                    {
                        tmpCards5 = OtherPlayer.OP;
                        cList5 = OtherPlayer.OP.Split(',');
                        MyGame.FifthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList5[0]), int.Parse(cList5[1]), int.Parse(cList5[2]));

                    }
                    Mine.OC = OpCodes.GotP3;
                    //Mine.OP = tmpCards5;
                    //Mine.NP = Seat5.text;
                    // Convert data to json string
                    json = JsonUtility.ToJson(Mine);
                    // Send json string to socket
                    //--ws.Send(Encoding.UTF8.GetBytes(json));
                    newMessage = false;
                    return;
                }
                if (OtherPlayer.OC == OpCodes.GotP3 && Mine.DN == DBManager.username && !p3Finished)
                {
                    p3Finished = true;
                    Mine.OC = OpCodes.SendingP4;
                        Mine.OP = tmpCards4;
                        Mine.NP = Seat4.text;
                        // Convert data to json string
                        json = JsonUtility.ToJson(Mine);
                        // Send json string to socket
                        //--ws.Send(Encoding.UTF8.GetBytes(json));
                        //SendingCards = 1;
                        newMessage = false;
                    

                    return;
                }
                if (OtherPlayer.OC == OpCodes.SendingP4 && Mine.DN != DBManager.username)
                {
                    if (OtherPlayer.OP == "")
                    {
                        Mine.OC = OpCodes.GotP4;
                        //Mine.OP = tmpCards5;
                        //Mine.NP = Seat5.text;
                        // Convert data to json string
                        json = JsonUtility.ToJson(Mine);
                        // Send json string to socket
                        //--ws.Send(Encoding.UTF8.GetBytes(json));
                        newMessage = false;
                        return;
                    }
                    if (OtherPlayer.NP == Seat1.text)
                    {
                        tmpCards1 = OtherPlayer.OP;
                        cList1 = OtherPlayer.OP.Split(',');
                        MyGame.FirstPlayerCardWeight = SavePlayerCardValue(int.Parse(cList1[0]), int.Parse(cList1[1]), int.Parse(cList1[2]));
                        txtSee.text = "SEE";
                        btnSee.SetActive(true);

                    }
                    else if (OtherPlayer.NP == Seat2.text)
                    {

                        tmpCards2 = OtherPlayer.OP;
                        cList2 = OtherPlayer.OP.Split(',');
                        MyGame.SecondPlayerCardWeight = SavePlayerCardValue(int.Parse(cList2[0]), int.Parse(cList2[1]), int.Parse(cList2[2]));


                    }
                    else if (OtherPlayer.NP == Seat3.text)
                    {
                        tmpCards3 = OtherPlayer.OP;
                        cList3 = OtherPlayer.OP.Split(',');
                        MyGame.ThirdPlayerCardWeight = SavePlayerCardValue(int.Parse(cList3[0]), int.Parse(cList3[1]), int.Parse(cList3[2]));

                    }
                    else if (OtherPlayer.NP == Seat4.text)
                    {
                        tmpCards4 = OtherPlayer.OP;
                        cList4 = OtherPlayer.OP.Split(',');
                        MyGame.FourthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList4[0]), int.Parse(cList4[1]), int.Parse(cList4[2]));

                    }
                    else if (OtherPlayer.NP == Seat5.text)
                    {
                        tmpCards5 = OtherPlayer.OP;
                        cList5 = OtherPlayer.OP.Split(',');
                        MyGame.FifthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList5[0]), int.Parse(cList5[1]), int.Parse(cList5[2]));

                    }
                    Mine.OC = OpCodes.GotP4;
                    //Mine.OP = tmpCards5;
                    //Mine.NP = Seat5.text;
                    // Convert data to json string
                    json = JsonUtility.ToJson(Mine);
                    // Send json string to socket
                    //--ws.Send(Encoding.UTF8.GetBytes(json));
                    newMessage = false;
                    return;
                }
                if (OtherPlayer.OC == OpCodes.GotP4 && Mine.DN == DBManager.username && !p4Finished)
                {
                    p4Finished = true;
                    Mine.OC = OpCodes.SendingP5;
                    Mine.OP = tmpCards5;
                    Mine.NP = Seat5.text;
                    // Convert data to json string
                    json = JsonUtility.ToJson(Mine);
                    // Send json string to socket
                    //--ws.Send(Encoding.UTF8.GetBytes(json));
                    //SendingCards = 1;
                    newMessage = false;


                    return;
                }
                if (OtherPlayer.OC == OpCodes.SendingP5 && Mine.DN != DBManager.username)
                {
                    if (OtherPlayer.OP == "")
                    {
                        Mine.OC = OpCodes.GotP5;
                        //Mine.OP = tmpCards5;
                        //Mine.NP = Seat5.text;
                        // Convert data to json string
                        json = JsonUtility.ToJson(Mine);
                        // Send json string to socket
                        //--ws.Send(Encoding.UTF8.GetBytes(json));
                        newMessage = false;
                        return;
                    }
                    if (OtherPlayer.NP == Seat1.text)
                    {
                        tmpCards1 = OtherPlayer.OP;
                        cList1 = OtherPlayer.OP.Split(',');
                        MyGame.FirstPlayerCardWeight = SavePlayerCardValue(int.Parse(cList1[0]), int.Parse(cList1[1]), int.Parse(cList1[2]));
                        txtSee.text = "SEE";
                        btnSee.SetActive(true);

                    }
                    else if (OtherPlayer.NP == Seat2.text)
                    {

                        tmpCards2 = OtherPlayer.OP;
                        cList2 = OtherPlayer.OP.Split(',');
                        MyGame.SecondPlayerCardWeight = SavePlayerCardValue(int.Parse(cList2[0]), int.Parse(cList2[1]), int.Parse(cList2[2]));


                    }
                    else if (OtherPlayer.NP == Seat3.text)
                    {
                        tmpCards3 = OtherPlayer.OP;
                        cList3 = OtherPlayer.OP.Split(',');
                        MyGame.ThirdPlayerCardWeight = SavePlayerCardValue(int.Parse(cList3[0]), int.Parse(cList3[1]), int.Parse(cList3[2]));

                    }
                    else if (OtherPlayer.NP == Seat4.text)
                    {
                        tmpCards4 = OtherPlayer.OP;
                        cList4 = OtherPlayer.OP.Split(',');
                        MyGame.FourthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList4[0]), int.Parse(cList4[1]), int.Parse(cList4[2]));

                    }
                    else if (OtherPlayer.NP == Seat5.text)
                    {
                        tmpCards5 = OtherPlayer.OP;
                        cList5 = OtherPlayer.OP.Split(',');
                        MyGame.FifthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList5[0]), int.Parse(cList5[1]), int.Parse(cList5[2]));

                    }
                    Mine.OC = OpCodes.GotP5;
                    //Mine.OP = tmpCards5;
                    //Mine.NP = Seat5.text;
                    // Convert data to json string
                    json = JsonUtility.ToJson(Mine);
                    // Send json string to socket
                    //--ws.Send(Encoding.UTF8.GetBytes(json));
                    newMessage = false;
                    return;
                }
                // if(OtherPlayer.OC == "RecievedCards" && Mine.DN == DBManager.username && !CardFinished)
                if (OtherPlayer.OC == OpCodes.CardsReceived && Mine.DN == DBManager.username && !CardFinished)
                {
                    CardFinished = true;
                    //p5Finished = true;
                    // Start Playing Cards now
                    // Unhide the PlayPanel
                    
                    playPanel.SetBool("Show", true);
                    // Start the 15 second Timer
                    //pClock1.Play("Start");
                    Clock1.SetActive(true);
                    pClock1.Play("Clock1");
                    //GameSoundFx.PlayOneShot(ClockStart);
                    // push the status to socket
                    //Mine.OC = "Timer";
                    Mine.OC = OpCodes.Timer;
                    //Mine.OP = "Running";
                    Mine.OP = OpCodes.TimerRunning;
                    // Change next dealer
                    //Mine.DN = (Seat2.text != "EMPTY") ? Seat2.text : ((Seat3.text!="EMPTY")?Seat3.text:(Seat4.text!="EMPTY")?Seat4.text:Seat5.text);
                    if (txtPacked2.text == "Playing")
                        Mine.NP = Seat2.text;
                    else if (txtPacked3.text == "Playing")
                        Mine.NP = Seat3.text;
                    else if (txtPacked4.text == "Playing")
                        Mine.NP = Seat4.text;
                    else if (txtPacked5.text == "Playing")
                        Mine.NP = Seat5.text;
                    else
                        Mine.NP = "";
                    //Mine.NP = (txtPacked2.text=="Playing") ? Seat2.text : ((txtPacked3.text == "Playing") ? Seat3.text :(txtPacked4.text == "Playing") ? Seat4.text : Seat5.text);
                   // Mine.GameState = "On";
                    json = JsonUtility.ToJson(Mine);
                    // Send json string to socket
                    //--ws.Send(Encoding.UTF8.GetBytes(json));
                    // set to recieve; new message again                    
                    newMessage = false;
                    txtSee.text = "SEE";
                    btnSee.SetActive(true);
                    btnLobby.enabled = true;
                    return;
                }
                //if(OtherPlayer.OC=="Timer" && OtherPlayer.OP=="Running")
                if (OtherPlayer.OC == OpCodes.Timer && OtherPlayer.OP == OpCodes.TimerRunning)
                {
                    // Show See Button
                    if(txtPacked1.text=="Playing")
                    {
                        txtSee.text = "SEE";
                        btnSee.SetActive(true);
                    }
                    
                    // Mine.GameState = OtherPlayer.GameState;
                    //Mine.DN = OtherPlayer.DN;
                    Mine.NP = OtherPlayer.NP;
                    if(OtherPlayer.NP == Seat2.text)
                    {
                        //pClock2.Play("Start");
                        Clock2.SetActive(true);
                        pClock2.Play("Clock2");
                    }
                    else if (OtherPlayer.NP == Seat3.text)
                    {
                        //pClock3.Play("Start");
                        Clock3.SetActive(true);
                        pClock3.Play("Clock3");
                    }
                    else if (OtherPlayer.NP == Seat4.text)
                    {
                        //pClock4.Play("Start");
                        Clock4.SetActive(true);
                        pClock4.Play("Clock4");
                    }
                    else if (OtherPlayer.NP == Seat5.text)
                    {
                        //pClock5.Play("Start");
                        Clock5.SetActive(true);
                        pClock5.Play("Clock5");
                    }
                    else
                    {
                        return;
                    }
                    
                    Mine.OC = OpCodes.Timer;
                    Mine.OP = OpCodes.TimerDone;
                    //txtAnnounce.text = "Other player showing dealer clock animation";
                    json = JsonUtility.ToJson(Mine);
                    // Send json string to socket
                    //--ws.Send(Encoding.UTF8.GetBytes(json));
                    // set to recieve; new message again
                    newMessage = false;
                    
                    return;
                }
                // Dealer Ends--------------------------------------------------------------------------------------------------------------
                // For new player Joing room and requesting a start. But he has to wait -------------------------------
                if (OtherPlayer.OC == OpCodes.Start && OtherPlayer.OP==OpCodes.CardsForNewPlayer)
                {
                    // Check if this other player is new player or existing
                    // He will be given an empty seat first if he is new

                    //if (OtherPlayer.PN != Seat2.text && OtherPlayer.PN != Seat3.text && OtherPlayer.PN != Seat4.text && OtherPlayer.PN != Seat5.text)
                    //{

                        //This player has just entered the room while the game is about to begin
                        // Arrange his seat first
                        int serialHis = int.Parse(OtherPlayer.SR);
                        int serialMine = int.Parse(Mine.SR);
                        if (serialHis > serialMine)
                        {
                            if (serialHis - serialMine == 1)
                            {

                                Seat2.text = OtherPlayer.PN;
                                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + OtherPlayer.PI);
                                imgP2.GetComponent<Image>().sprite = tmpPicute;
                                txtPacked2.text = "Watching";
                                txtChaal2.text = "W";
                            }
                            if (serialHis - serialMine == 2)
                            {

                                Seat3.text = OtherPlayer.PN;
                                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + OtherPlayer.PI);
                                imgP3.GetComponent<Image>().sprite = tmpPicute;
                                txtPacked3.text = "Watching";
                                txtChaal3.text = "W";
                            }
                            if (serialHis - serialMine == 3)
                            {

                                Seat4.text = OtherPlayer.PN;
                                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + OtherPlayer.PI);
                                imgP4.GetComponent<Image>().sprite = tmpPicute;
                                txtPacked4.text = "Watching";
                                txtChaal4.text = "W";
                            }
                            if (serialHis - serialMine == 4)
                            {

                                Seat5.text = OtherPlayer.PN;
                                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + OtherPlayer.PI);
                                imgP5.GetComponent<Image>().sprite = tmpPicute;
                                txtPacked5.text = "Watching";
                                txtChaal5.text = "W";
                            }
                        }
                        if (serialHis < serialMine)
                        {
                            if (serialMine - serialHis == 1)
                            {

                                Seat5.text = OtherPlayer.PN;
                                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + OtherPlayer.PI);
                                imgP5.GetComponent<Image>().sprite = tmpPicute;
                                txtPacked5.text = "Watching";
                                txtChaal5.text = "W";

                            }
                            if (serialMine - serialHis == 2)
                            {

                                Seat4.text = OtherPlayer.PN;
                                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + OtherPlayer.PI);
                                imgP4.GetComponent<Image>().sprite = tmpPicute;
                                txtPacked4.text = "Watching";
                                txtChaal4.text = "W";

                            }
                            if (serialMine - serialHis == 3)
                            {

                                Seat3.text = OtherPlayer.PN;
                                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + OtherPlayer.PI);
                                imgP3.GetComponent<Image>().sprite = tmpPicute;
                                txtPacked3.text = "Watching";
                                txtChaal3.text = "W";

                            }
                            if (serialMine - serialHis == 4)
                            {

                                Seat2.text = OtherPlayer.PN;
                                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + OtherPlayer.PI);
                                imgP2.GetComponent<Image>().sprite = tmpPicute;
                                txtPacked2.text = "Watching";
                                txtChaal2.text = "W";

                            }
                        }
                        if (txtPacked1.text == "Playing")
                        {
                            Mine.OC = OpCodes.CardsForNewPlayer;
                            Mine.OP = tmpCards1;
                            //string tmp = Mine.PI;
                            //Mine.PI = OtherPlayer.PN;
                            // Convert data to json string
                            json = JsonUtility.ToJson(Mine);
                            // Send json string to socket
                            //--ws.Send(Encoding.UTF8.GetBytes(json));
                        // set to recieve; new message again

                        //Mine.PI = tmp;
                        newMessage = false;
                        return;
                    }
                    //}
                    
                    newMessage = false;
                    return;
                }
                if (OtherPlayer.OC == OpCodes.CardsForNewPlayer && txtPacked1.text=="Watching")
                {
                    if (OtherPlayer.PN == Seat2.text)
                    {
                        tmpCards2 = OtherPlayer.OP;
                        cList2 = OtherPlayer.OP.Split(',');
                        MyGame.SecondPlayerCardWeight = SavePlayerCardValue(int.Parse(cList2[0]), int.Parse(cList2[1]), int.Parse(cList2[2]));
                        txtPacked2.text = "Playing";
                        newMessage = false;
                        
                    }
                    else if (OtherPlayer.PN == Seat3.text)
                    {
                        tmpCards3 = OtherPlayer.OP;
                        cList3 = OtherPlayer.OP.Split(',');
                        MyGame.ThirdPlayerCardWeight = SavePlayerCardValue(int.Parse(cList3[0]), int.Parse(cList3[1]), int.Parse(cList3[2]));
                        txtPacked3.text = "Playing";
                        
                        
                    }
                    else if (OtherPlayer.PN == Seat4.text)
                    {
                        tmpCards4 = OtherPlayer.OP;
                        cList4 = OtherPlayer.OP.Split(',');
                        MyGame.FourthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList4[0]), int.Parse(cList4[1]), int.Parse(cList4[2]));
                        txtPacked4.text = "Playing";
                        
                        
                    }
                    else if (OtherPlayer.PN == Seat5.text)
                    {
                        tmpCards5 = OtherPlayer.OP;
                        cList5 = OtherPlayer.OP.Split(',');
                        MyGame.FifthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList5[0]), int.Parse(cList5[1]), int.Parse(cList5[2]));
                        txtPacked5.text = "Playing";
                        
                        
                    }
                    
                    newMessage = false;
                    return;
                }
                // New player joining and getting cards finish ---------------------------------------------------------
                // Play Begins-----------------------------------------------------------------------------------------------------------
                //if (OtherPlayer.OC == "BLIND" || OtherPlayer.OC == "CHAAL")
                if (OtherPlayer.OC == OpCodes.Blind || OtherPlayer.OC == OpCodes.Chaal)
                {
                    GameSoundFx.PlayOneShot(BlindSound);
                    //Anouce the Action
                    if(OtherPlayer.OC== OpCodes.Blind)
                        txtAnnounce.text = OtherPlayer.PN + " has played a BLIND";
                    if (OtherPlayer.OC == OpCodes.Chaal)
                        txtAnnounce.text = OtherPlayer.PN + " has played a CHAAL";
                    pnlAnnounce.SetActive(true);
                    // If I'm a watcher, I should enable potcoin
                    txtPotCoin.enabled = true;
                    // Find the player's seat and show the coin throw animation and other info
                    if (Seat2.text == OtherPlayer.PN)
                    {
                        txtThrowCoin2.text = OtherPlayer.OP;
                        txtLastCoin2.text = OtherPlayer.OP;
                        //P2Coin.Play("ThrowCoin");
                        P2PotCoin.SetActive(false);
                        P2PotCoin.SetActive(true);
                        P2Coin.Play("PotCoinP2");
                        txtChaal2.text = OtherPlayer.OC == OpCodes.Blind ? "BLIND":"CHAAL" ;
                        //chaal2.Play("HideChaal");
                        chaal2.Play("ShowChaal");
                        // Stop that player's clock
                        pClock2.Play("Start");
                        Clock2.SetActive(false);
                    }
                    else if (Seat3.text == OtherPlayer.PN)
                    {
                        txtThrowCoin3.text = OtherPlayer.OP;
                        txtLastCoin3.text = OtherPlayer.OP;
                        //P3Coin.Play("ThrowCoin");
                        P3PotCoin.SetActive(false);
                        P3PotCoin.SetActive(true);
                        P3Coin.Play("PotCoinP3");
                        txtChaal3.text = OtherPlayer.OC == OpCodes.Blind ? "BLIND" : "CHAAL";
                        //chaal3.Play("HideChaal");
                        chaal3.Play("ShowChaal");
                        // Stop that player's clock
                        pClock3.Play("Start");
                        Clock3.SetActive(false);
                    }
                    else if (Seat4.text == OtherPlayer.PN)
                    {
                        txtThrowCoin4.text = OtherPlayer.OP;
                        txtLastCoin4.text = OtherPlayer.OP;
                        //P4Coin.Play("ThrowCoin");
                        P4PotCoin.SetActive(false);
                        P4PotCoin.SetActive(true);
                        P4Coin.Play("PotCoinP4");
                        txtChaal4.text = OtherPlayer.OC == OpCodes.Blind ? "BLIND" : "CHAAL";
                        //chaal4.Play("HideChaal");
                        chaal4.Play("ShowChaal");
                        // Stop that player's clock
                        pClock4.Play("Start");
                        Clock4.SetActive(false);
                    }
                    else if (Seat5.text == OtherPlayer.PN)
                    {
                        txtThrowCoin5.text = OtherPlayer.OP;
                        txtLastCoin5.text = OtherPlayer.OP;
                        //P5Coin.Play("ThrowCoin");
                        P5PotCoin.SetActive(false);
                        P5PotCoin.SetActive(true);
                        P5Coin.Play("PotCoinP5");
                        txtChaal5.text = OtherPlayer.OC == OpCodes.Blind ? "BLIND" : "CHAAL";
                        //chaal5.Play("HideChaal");
                        chaal5.Play("ShowChaal");
                        // Stop that player's clock
                        pClock5.Play("Start");
                        Clock5.SetActive(false);
                    }
                    // Add coin to the pot coin amount
                    // Total pot coin is in the board money
                    txtPotCoin.text = OtherPlayer.BM;
                   
                    // Start Next Player's Clock
                    if (OtherPlayer.NP == Seat2.text)
                    {
                        //pClock2.Play("Start");
                        Clock2.SetActive(true);
                        pClock2.Play("Clock2");
                    }
                    else if (OtherPlayer.NP == Seat3.text)
                    {
                        //pClock3.Play("Start");
                        Clock3.SetActive(true);
                        pClock3.Play("Clock3");
                    }
                    else if (OtherPlayer.NP == Seat4.text)
                    {
                        //pClock4.Play("Start");
                        Clock4.SetActive(true);
                        pClock4.Play("Clock4");
                    }
                    else if (OtherPlayer.NP == Seat5.text)
                    {
                        //pClock5.Play("Start");
                        Clock5.SetActive(true);
                        pClock5.Play("Clock5");
                    }
                    else if(OtherPlayer.NP == Seat1.text)
                    {
                        
                        //GameSoundFx.PlayOneShot(ClockStart);
                        btnMinus.interactable = false;
                        btnPlus.interactable = true;
                        btnPack.interactable = true;
                        if(OtherPlayer.OC== OpCodes.Blind && txtBlind.text=="BLIND")
                        {
                            //string tmpAmount = txtLastCoin5.text != "" ? txtLastCoin5.text : txtLastCoin4.text != "" ? txtLastCoin4.text : txtLastCoin3.text != "" ? txtLastCoin3.text : txtLastCoin2.text;
                            txtAmount.text = OtherPlayer.OP;
                        }
                        if (OtherPlayer.OC == OpCodes.Blind && txtBlind.text == "CHAAL")
                        {
                            //string tmpAmount = txtLastCoin5.text != "" ? txtLastCoin5.text : txtLastCoin4.text != "" ? txtLastCoin4.text : txtLastCoin3.text != "" ? txtLastCoin3.text : txtLastCoin2.text;
                            txtAmount.text = (int.Parse(OtherPlayer.OP)*2).ToString();
                        }
                        if (OtherPlayer.OC == OpCodes.Chaal && txtBlind.text == "CHAAL")
                        {
                            //string tmpAmount = txtLastCoin5.text != "" ? txtLastCoin5.text : txtLastCoin4.text != "" ? txtLastCoin4.text : txtLastCoin3.text != "" ? txtLastCoin3.text : txtLastCoin2.text;
                            txtAmount.text = OtherPlayer.OP;
                        }
                        if (OtherPlayer.OC == OpCodes.Chaal && txtBlind.text == "BLIND")
                        {
                            //string tmpAmount = txtLastCoin5.text != "" ? txtLastCoin5.text : txtLastCoin4.text != "" ? txtLastCoin4.text : txtLastCoin3.text != "" ? txtLastCoin3.text : txtLastCoin2.text;
                            txtAmount.text = (int.Parse(OtherPlayer.OP)/2).ToString();
                        }
                        if (int.Parse(txtMyCoin.text) < 16)
                        {
                            DialogMsg.text = "You don't have the minimum balance of 16 coins. Please buy more coins.";
                            DialogMsg2.text = "";
                            BackToLobby = true;
                            pnlOK.SetActive(true);
                            newMessage = false;
                            return;
                        }                        
                        if (int.Parse(txtAmount.text) > int.Parse(txtMyCoin.text))
                        {
                            GameSoundFx.PlayOneShot(PackSound);
                            DialogMsg.text = "You don't have enough balance. You are packed.";
                            DialogMsg2.text = "";
                            pnlOK.SetActive(true);
                            OnPack();
                            //txtPacked1.text = "Packed";                                                  
                            newMessage = false;
                            return;
                        }
                        int playerCount = 1;
                        if (txtPacked2.text == "Playing")
                            playerCount++;
                        if (txtPacked3.text == "Playing")
                            playerCount++;
                        if (txtPacked4.text == "Playing")
                            playerCount++;
                        if (txtPacked5.text == "Playing")
                            playerCount++;
                        if (playerCount == 2)
                        {
                            txtShow.text = "SHOW";
                            btnShow.interactable = true;
                        }
                        if (playerCount > 2 && txtBlind.text=="CHAAL")
                        {
                            txtShow.text = "SIDE SHOW";
                            if (txtPacked5.text == "Playing")
                            {
                                if (txtChaal5.text == "CHAAL")
                                {
                                    btnShow.interactable = true;
                                    sideshow = Seat5.text;
                                }
                                else
                                {
                                    btnShow.interactable = false;

                                }
                            }
                            else if (txtPacked4.text == "Playing")
                            {
                                if (txtChaal4.text == "CHAAL")
                                {
                                    
                                    btnShow.interactable = true;
                                    sideshow = Seat4.text;
                                }
                                else
                                {
                                    btnShow.interactable = false;
                                }
                            }
                            else if (txtPacked3.text == "Playing")
                            {
                                if (txtChaal3.text == "CHAAL")
                                {
                                    
                                    btnShow.interactable = true;
                                    sideshow = Seat3.text;
                                }
                                else
                                {
                                    btnShow.interactable = false;
                                }
                            }
                            
                        }
                        
                        // Unhide the PlayPanel
                        playPanel.SetBool("Show", true);
                        GameSoundFx.PlayOneShot(ClockStart);
                        //pClock1.Play("Start");
                        Clock1.SetActive(true);
                        pClock1.Play("Clock1");
                    }
                    //Mine.OC = "Blind";
                    //Mine.OP = "Updated";
                    //json = JsonUtility.ToJson(Mine);
                    // Send json string to socket
                    //ws.Send(Encoding.UTF8.GetBytes(json));
                    
                    // set to recieve new message again
                    newMessage = false;
                    return;
                }

                //if (OtherPlayer.OC == "Seen")
                if (OtherPlayer.OC == OpCodes.Seen)
                {
                    //Anouce the Action
                    txtAnnounce.text = OtherPlayer.PN + " has seen their Cards";
                    if (Seat2.text == OtherPlayer.PN)
                    {
                        txtChaal2.text = "SEEN";
                        //chaal2.Play("HideChaal");
                        chaal2.Play("ShowChaal");
                    }
                    if (Seat3.text == OtherPlayer.PN)
                    {
                        txtChaal3.text = "SEEN";
                        //chaal3.Play("HideChaal");
                        chaal3.Play("ShowChaal");
                    }
                    if (Seat4.text == OtherPlayer.PN)
                    {
                        txtChaal4.text = "SEEN";
                        //chaal4.Play("HideChaal");
                        chaal4.Play("ShowChaal");
                    }
                    if (Seat5.text == OtherPlayer.PN)
                    {
                        txtChaal5.text = "SEEN";
                        //chaal5.Play("HideChaal");
                        chaal5.Play("ShowChaal");
                    }
                    // set to recieve new message again
                    newMessage = false;
                    return;
                }
                if(OtherPlayer.OC==OpCodes.Message)
                {
                    GameSoundFx.PlayOneShot(PackSound);
                    if (Seat2.text == OtherPlayer.PN)
                    {
                        StartCoroutine(ShowMessage(pnlText2,pText2, OtherPlayer.OP, 3.0f));
                    }
                    else if (Seat3.text == OtherPlayer.PN)
                    {
                        StartCoroutine(ShowMessage(pnlText3,pText3, OtherPlayer.OP, 3.0f));
                    }
                    else if (Seat4.text == OtherPlayer.PN)
                    {
                        StartCoroutine(ShowMessage(pnlText4,pText4, OtherPlayer.OP, 3.0f));
                    }
                    else if (Seat5.text == OtherPlayer.PN)
                    {
                        StartCoroutine(ShowMessage(pnlText5,pText5, OtherPlayer.OP, 3.0f));
                    }
                    newMessage = false;
                    return;
                }
                //Tips
                if(OtherPlayer.OC==OpCodes.Tips)
                {
                    GameSoundFx.PlayOneShot(BlindSound);
                    txtAnnounce.text = OtherPlayer.PN + " has paid a tip money!";
                    if(OtherPlayer.PN==Seat2.text)
                    {
                        txtThrowCoin2.text = "2";                        
                        txtLastCoin2.text = txtThrowCoin2.text;
                        //P2Coin.Play("ThrowCoin");
                        P2PotCoin.SetActive(false);
                        P2PotCoin.SetActive(true);
                        P2Coin.Play("PotCoinP2");
                        txtChaal2.text = "TIPS";
                        //chaal2.Play("HideChaal");
                        chaal2.Play("ShowChaal");
                    }
                    else if (OtherPlayer.PN == Seat3.text)
                    {
                        txtThrowCoin3.text = "2";
                        txtLastCoin3.text = txtThrowCoin2.text;
                        //P2Coin.Play("ThrowCoin");
                        P3PotCoin.SetActive(false);
                        P3PotCoin.SetActive(true);
                        P3Coin.Play("PotCoinP3");
                        txtChaal3.text = "TIPS";
                        //chaal2.Play("HideChaal");
                        chaal3.Play("ShowChaal");
                    }
                    else if (OtherPlayer.PN == Seat4.text)
                    {
                        txtThrowCoin4.text = "2";
                        txtLastCoin4.text = txtThrowCoin4.text;
                        //P2Coin.Play("ThrowCoin");
                        P4PotCoin.SetActive(false);
                        P4PotCoin.SetActive(true);
                        P4Coin.Play("PotCoinP4");
                        txtChaal4.text = "TIPS";
                        //chaal2.Play("HideChaal");
                        chaal4.Play("ShowChaal");
                    }
                    else if (OtherPlayer.PN == Seat5.text)
                    {
                        txtThrowCoin5.text = "2";
                        txtLastCoin5.text = txtThrowCoin5.text;
                        //P2Coin.Play("ThrowCoin");
                        P5PotCoin.SetActive(false);
                        P5PotCoin.SetActive(true);
                        P5Coin.Play("PotCoinP5");
                        txtChaal5.text = "TIPS";
                        //chaal2.Play("HideChaal");
                        chaal5.Play("ShowChaal");
                    }
                    newMessage = false;
                }
                //if (OtherPlayer.OC == "Packed")
                if (OtherPlayer.OC == OpCodes.Packed)
                {
                    GameSoundFx.PlayOneShot(PackSound);
                    //Anouce the Action
                    txtAnnounce.text = OtherPlayer.PN + " has packed";
                    if (Seat2.text == OtherPlayer.PN)
                    {
                        txtChaal2.text = "PACKED";
                        //chaal2.Play("HideChaal");
                        chaal2.Play("ShowChaal");
                        // Stop that player's clock                        
                        pClock2.Play("Start");
                        Clock2.SetActive(false);
                        txtPacked2.text = "Watching";
                       // txtPacked2.enabled = true;
                    }
                    else if (Seat3.text == OtherPlayer.PN)
                    {
                        txtChaal3.text = "PACKED";
                        //chaal3.Play("HideChaal");
                        chaal3.Play("ShowChaal");
                        // Stop that player's clock                        
                        pClock3.Play("Start");
                        Clock3.SetActive(false);
                        txtPacked3.text = "Watching";
                        //txtPacked3.enabled = true;
                    }
                    else if (Seat4.text == OtherPlayer.PN)
                    {
                        txtChaal4.text = "PACKED";
                        // chaal4.Play("HideChaal");
                        
                        chaal4.Play("ShowChaal");
                        // Stop that player's clock                        
                        pClock4.Play("Start");
                        Clock4.SetActive(false);
                        txtPacked4.text = "Watching";
                        //txtPacked4.enabled = true;
                    }
                    else if (Seat5.text == OtherPlayer.PN)
                    {
                        txtChaal5.text = "PACKED";
                        //chaal5.Play("HideChaal");
                        chaal5.Play("ShowChaal");
                        // Stop that player's clock                        
                        pClock5.Play("Start");
                        Clock5.SetActive(false);
                        txtPacked5.text = "Watching";
                        //txtPacked5.enabled = true;
                    }
                    // Determine if I'm the only player now
                    int playerCount = 1;
                    if (txtPacked2.text == "Playing")
                        playerCount++;
                    if (txtPacked3.text == "Playing")
                        playerCount++;
                    if (txtPacked4.text == "Playing")
                        playerCount++;
                    if (txtPacked5.text == "Playing")
                        playerCount++;
                    if (playerCount == 1 && txtPacked1.text=="Playing")
                    {
                        
                        // I'm the only player. So I win the match
                        // Stop the clock                        
                        pClock1.Play("Start");
                        Clock1.SetActive(false);
                        // Hide panel
                        playPanel.SetBool("Show", false);
                        // hide the see button
                        btnSee.SetActive(false);
                        // Show Board coin animation to player
                        txtThrowCoin.text = txtPotCoin.text;
                        P1Coin.Play("PotCoinP1R");
                        // I'm the winner. I get all the board coins
                        txtMyCoin.text = (int.Parse(txtMyCoin.text) + int.Parse(txtPotCoin.text)).ToString();
                        // Show Board coin animation to player
                        txtPotCoin.text = "0";
                        //GameSoundFx.PlayOneShot(WinningSound);
                        
                        //StartCoroutine(PlayWinningSound());
                        // Show Winner Animation on my player tab
                        pWin1.Play("Play");
                        // Disable the lobby button
                        btnLobby.enabled = false;
                            txtAnnounce.text = DBManager.username + " has won the match!";
                            // Signal the other player and return null card info
                            //Mine.OC = "WINNER";
                            Mine.OC = OpCodes.Winner;
                            //Mine.OP = "NULL";
                            Mine.OP = OpCodes.Null;
                            // Send winner and winning cards in the NP
                            //Mine.NP = DBManager.username + "," + CardDegree;
                                                
                       
                        
                        // I'm going to be the next dealer
                        Mine.DN = DBManager.username;
                        // Switch player status to watching
                        txtPacked1.text = "Watching";
                        json = JsonUtility.ToJson(Mine);
                        // Send json string to socket
                        //--ws.Send(Encoding.UTF8.GetBytes(json));
                        // set to recieve new message again
                        newMessage = false;
                        // Wait few seconds then send signals for next game
                        wait = true;
                        update = 0.0f;
                        return;
                    }      
                   
                    // Start Next Player's Clock
                    if (OtherPlayer.NP == Seat1.text)
                    {

                        //pClock1.Play("Start");
                        
                        Clock1.SetActive(true);
                        pClock1.Play("Clock1");
                        GameSoundFx.PlayOneShot(ClockStart);
                        playPanel.SetBool("Show", true);
                    }
                    else if (OtherPlayer.NP == Seat2.text)
                    {
                        //pClock2.Play("Start");
                        Clock2.SetActive(true);
                        pClock2.Play("Clock2");
                    }
                    else if (OtherPlayer.NP == Seat3.text)
                    {
                        //pClock3.Play("Start");
                        Clock3.SetActive(true);
                        pClock3.Play("Clock3");
                    }
                    else if (OtherPlayer.NP == Seat4.text)
                    {
                        //pClock4.Play("Start");
                        Clock4.SetActive(true);
                        pClock4.Play("Clock4");
                    }
                    else if (OtherPlayer.NP == Seat5.text)
                    {
                        //pClock5.Play("Start");
                        Clock5.SetActive(true);
                        pClock5.Play("Clock5");
                    }
                    // set to recieve new message again
                    newMessage = false;
                    return;
                }
                //if(OtherPlayer.OC=="SHOW")
                if (OtherPlayer.OC == OpCodes.Show)
                {
                    
                    GameSoundFx.PlayOneShot(ShowSound);
                    // hide the seen button
                    btnSee.SetActive(false);
                    // Show my cards first
                    if (txtSee.text == "SEE")
                    {
                        txtSee.text = "SEEN";
                        if(cList1[0]=="0" || cList1[1] == "0" || cList1[2] == "0")
                        {
                            StartCoroutine(ShowCards(DBManager.username, 1));
                        }
                        else
                        {
                            sP1C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList1[0]);
                            P1C1.GetComponent<Image>().sprite = sP1C1;
                            sP1C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList1[1]);
                            P1C2.GetComponent<Image>().sprite = sP1C2;
                            sP1C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList1[2]);
                            P1C3.GetComponent<Image>().sprite = sP1C3;
                        }
                        
                    }
                    // Next match will be dealed by the shower that's clear
                    // I'm not the dealer any way
                    Mine.DN = OtherPlayer.PN;
                    //Anouce the Action
                    txtAnnounce.text =OtherPlayer.PN+ " has offered a SHOW";
                    long WinnerCard = 0;
                    bool MeWinner = false;
                    if (Seat2.text == OtherPlayer.PN)
                    {
                        txtThrowCoin2.text = OtherPlayer.BM;
                        txtLastCoin2.text = OtherPlayer.BM;
                        //P2Coin.Play("ThrowCoin");
                        P2PotCoin.SetActive(false);
                        P2PotCoin.SetActive(true);
                        P2Coin.Play("PotCoinP2");
                        txtChaal2.text = "SHOW";
                        //chaal2.Play("HideChaal");
                        chaal2.Play("ShowChaal");
                        // Stop that player's clock
                        
                        pClock2.Play("Start");
                        Clock2.SetActive(false);
                        //Show the cards
                        //string[] cTemp = OtherPlayer.OP.Split(',');
                        if (cList2[0] == "0" || cList2[1] == "0" || cList2[2] == "0")
                        {
                            StartCoroutine(ShowCards(Seat2.text, 2));
                        }
                        else
                        {                        
                        sP2C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[0]);
                        iP2C1.GetComponent<Image>().sprite = sP2C1;
                        sP2C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[1]);
                        iP2C2.GetComponent<Image>().sprite = sP2C2;
                        sP2C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[2]);
                        iP2C3.GetComponent<Image>().sprite = sP2C3;
                        ShowCardsP2.SetActive(true);
                        }
                        //long otherCardWeight = SavePlayerCardValue(int.Parse(cTemp[0]), int.Parse(cTemp[1]), int.Parse(cTemp[2]));
                        WinnerCard = Math.Max(MyGame.FirstPlayerCardWeight, MyGame.SecondPlayerCardWeight);
                        MeWinner = MyGame.FirstPlayerCardWeight > WinnerCard;

                    }
                    else if (Seat3.text == OtherPlayer.PN)
                    {
                        txtThrowCoin3.text = OtherPlayer.BM;
                        txtLastCoin3.text = OtherPlayer.BM;
                        //P2Coin.Play("ThrowCoin");
                        P3PotCoin.SetActive(false);
                        P3PotCoin.SetActive(true);
                        P3Coin.Play("PotCoinP3");
                        txtChaal3.text = "SHOW";
                        //chaal2.Play("HideChaal");
                        chaal3.Play("ShowChaal");
                        // Stop that player's clock
                        pClock3.Play("Start");
                        Clock3.SetActive(false);

                        //Show the cards
                        //string[] cTemp = OtherPlayer.OP.Split(',');
                        if (cList3[0] == "0" || cList3[1] == "0" || cList3[2] == "0")
                        {
                            StartCoroutine(ShowCards(Seat3.text, 3));
                        }
                        else
                        {
                            sP3C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[0]);
                            iP3C1.GetComponent<Image>().sprite = sP3C1;
                            sP3C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[1]);
                            iP3C2.GetComponent<Image>().sprite = sP3C2;
                            sP3C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[2]);
                            iP3C3.GetComponent<Image>().sprite = sP3C3;
                            ShowCardsP3.SetActive(true);
                        }
                        //long otherCardWeight = SavePlayerCardValue(int.Parse(cTemp[0]), int.Parse(cTemp[1]), int.Parse(cTemp[2]));
                        WinnerCard = Math.Max(MyGame.FirstPlayerCardWeight, MyGame.ThirdPlayerCardWeight);
                        MeWinner = MyGame.FirstPlayerCardWeight > WinnerCard;
                    }
                    else if (Seat4.text == OtherPlayer.PN)
                    {
                        txtThrowCoin4.text = OtherPlayer.BM;
                        txtLastCoin4.text = OtherPlayer.BM;
                        //P2Coin.Play("ThrowCoin");
                        P4PotCoin.SetActive(false);
                        P4PotCoin.SetActive(true);
                        P4Coin.Play("PotCoinP4");
                        txtChaal4.text = "SHOW";
                        //chaal2.Play("HideChaal");
                        chaal4.Play("ShowChaal");
                        // Stop that player's clock
                        pClock4.Play("Start");
                        Clock4.SetActive(false);

                        //Show the cards
                        //string[] cTemp = OtherPlayer.OP.Split(',');
                        if (cList4[0] == "0" || cList4[1] == "0" || cList4[2] == "0")
                        {
                            StartCoroutine(ShowCards(Seat4.text, 4));
                        }
                        else
                        {
                            sP4C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[0]);
                            iP4C1.GetComponent<Image>().sprite = sP4C1;
                            sP4C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[1]);
                            iP4C2.GetComponent<Image>().sprite = sP4C2;
                            sP4C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[2]);
                            iP4C3.GetComponent<Image>().sprite = sP4C3;
                            ShowCardsP4.SetActive(true);
                        }
                        //long otherCardWeight = SavePlayerCardValue(int.Parse(cTemp[0]), int.Parse(cTemp[1]), int.Parse(cTemp[2]));
                        WinnerCard = Math.Max(MyGame.FirstPlayerCardWeight, MyGame.FourthPlayerCardWeight);
                        MeWinner = MyGame.FirstPlayerCardWeight > WinnerCard;
                    }
                    else if (Seat5.text == OtherPlayer.PN)
                    {
                        txtThrowCoin5.text = OtherPlayer.BM;
                        txtLastCoin5.text = OtherPlayer.BM;
                        //P2Coin.Play("ThrowCoin");
                        P5PotCoin.SetActive(false);
                        P5PotCoin.SetActive(true);
                        P5Coin.Play("PotCoinP5");
                        txtChaal5.text = "SHOW";
                        //chaal2.Play("HideChaal");
                        chaal5.Play("ShowChaal");
                        // Stop that player's clock
                        pClock5.Play("Start");
                        Clock5.SetActive(false);

                        //Show the cards
                        //string[] cTemp = OtherPlayer.OP.Split(',');
                        if (cList5[0] == "0" || cList5[1] == "0" || cList5[2] == "0")
                        {
                            StartCoroutine(ShowCards(Seat5.text, 5));
                        }
                        else
                        {
                            sP5C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[0]);
                            iP5C1.GetComponent<Image>().sprite = sP5C1;
                            sP5C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[1]);
                            iP5C2.GetComponent<Image>().sprite = sP5C2;
                            sP5C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[2]);
                            iP5C3.GetComponent<Image>().sprite = sP5C3;
                            ShowCardsP5.SetActive(true);
                        }
                        //long otherCardWeight = SavePlayerCardValue(int.Parse(cTemp[0]), int.Parse(cTemp[1]), int.Parse(cTemp[2]));
                        WinnerCard = Math.Max(MyGame.FirstPlayerCardWeight, MyGame.FifthPlayerCardWeight);
                        MeWinner = MyGame.FirstPlayerCardWeight > WinnerCard;
                    }
                    // Add coin to the pot coin amount
                    // this time throwcoin comes in BM
                    txtPotCoin.text = (int.Parse(txtPotCoin.text)+int.Parse(OtherPlayer.BM)).ToString();
                    // check if I'm the show target
                    if(txtPacked1.text=="Playing")
                    {
                        // So I'm the other Show Candidate
                        // Stop the clock
                        pClock1.Play("Start");
                        Clock1.SetActive(false);
                        
                        // Hide panel
                        playPanel.SetBool("Show", false);
                        // Compare the hands and decide winner
                        //cList2 = OtherPlayer.OP.Split(',');
                       // MyGame.SecondPlayerCardWeight = SavePlayerCardValue(int.Parse(cList2[0]), int.Parse(cList2[1]), int.Parse(cList2[2]));
                        //if(MyGame.FirstPlayerCardWeight>MyGame.SecondPlayerCardWeight || MyGame.FirstPlayerCardWeight == MyGame.SecondPlayerCardWeight)
                        if(MyGame.FirstPlayerCardWeight>=WinnerCard)
                        {
                            // Show Board coin animation to player
                            txtThrowCoin.text = txtPotCoin.text;
                            P1Coin.Play("PotCoinP1R");
                            // I'm the winner. I get all the board coins
                            txtMyCoin.text = (int.Parse(txtMyCoin.text) + int.Parse(txtPotCoin.text)).ToString();
                            // Show Board coin animation to player
                            txtPotCoin.text = "0";
                            // Declare the winner
                            string CardDegree = (MyGame.FirstPlayerCardWeight > 1000000 && MyGame.FirstPlayerCardWeight < 2000000) ? "High Cards" 
                                                : (MyGame.FirstPlayerCardWeight > 2000000 && MyGame.FirstPlayerCardWeight < 3000000) ? "Pair of Cards" 
                                                : (MyGame.FirstPlayerCardWeight > 3000000 && MyGame.FirstPlayerCardWeight < 4000000) ? "One Color" 
                                                : (MyGame.FirstPlayerCardWeight > 4000000 && MyGame.FirstPlayerCardWeight < 5000000) ? "Sequence" 
                                                : (MyGame.FirstPlayerCardWeight > 5000000 && MyGame.FirstPlayerCardWeight < 6000000) ? "Colored Sequence" 
                                                : (MyGame.FirstPlayerCardWeight > 6000000 && MyGame.FirstPlayerCardWeight < 7000000) ? "Tripple of a Card" 
                                                : "Error";
                            txtAnnounce.text = DBManager.username + " has won the match with "+CardDegree;
                            
                            // Signal the other player and return my card info
                            Mine.OC = OpCodes.Winner;
                            Mine.OP = CardDegree;
                            // Send winner and winning cards in the NP
                            Mine.NP = DBManager.username;
                            json = JsonUtility.ToJson(Mine);
                            // Send json string to socket
                            //--ws.Send(Encoding.UTF8.GetBytes(json));
                            // set to recieve new message again
                            newMessage = false;
                            //GameSoundFx.Stop();
                            //GameSoundFx.PlayOneShot(WinningSound);
                            //StartCoroutine(PlayWinningSound());
                            // Show Winner Animation on my player tab
                            pWin1.Play("Play");
                            return;
                        }
                        else
                        {
                              string CardDegree = (WinnerCard > 1000000 && WinnerCard < 2000000) ? "High Cards"
                                                : (WinnerCard > 2000000 && WinnerCard < 3000000) ? "Pair of Cards"
                                                : (WinnerCard > 3000000 && WinnerCard < 4000000) ? "One Color"
                                                : (WinnerCard > 4000000 && WinnerCard < 5000000) ? "Sequence"
                                                : (WinnerCard > 5000000 && WinnerCard < 6000000) ? "Colored Sequence"
                                                : (WinnerCard > 6000000 && WinnerCard < 7000000) ? "Tripple of a Card"
                                                : "Error";
                            txtAnnounce.text = OtherPlayer.PN + " has won the match with " + CardDegree;
                            // Show Winner Animation on other player tab
                            //StartCoroutine(PlayWinningSound());
                            if (Seat2.text == OtherPlayer.PN)
                            {
                                txtThrowCoin2.text = txtPotCoin.text;
                                P2Coin.Play("PotCoinP2R");
                                //GameSoundFx.Stop();
                                GameSoundFx.PlayOneShot(WinningSound);
                                pWin2.Play("Play");
                            }                                
                            else if (Seat3.text == OtherPlayer.PN)
                            {
                                txtThrowCoin3.text = txtPotCoin.text;
                                P3Coin.Play("PotCoinP3R");
                                //GameSoundFx.Stop();
                                //GameSoundFx.PlayOneShot(WinningSound);
                                pWin3.Play("Play");
                            }                                
                            else if (Seat4.text == OtherPlayer.PN)
                            {
                                txtThrowCoin4.text = txtPotCoin.text;
                                P4Coin.Play("PotCoinP4R");
                                //GameSoundFx.Stop();
                                //GameSoundFx.PlayOneShot(WinningSound);
                                pWin4.Play("Play");
                            }                                
                            else if (Seat5.text == OtherPlayer.PN)
                            {
                                txtThrowCoin5.text = txtPotCoin.text;
                                P5Coin.Play("PotCoinP5R");
                                //GameSoundFx.Stop();
                                //GameSoundFx.PlayOneShot(WinningSound);
                                pWin5.Play("Play");
                            }
                            txtPotCoin.text = "0";
                            // Signal the other player and return card info
                            Mine.OC = OpCodes.Winner;
                            Mine.OP = CardDegree;
                            // Send winner and winning cards in the NP
                            Mine.NP = OtherPlayer.PN;
                            json = JsonUtility.ToJson(Mine);
                            // Send json string to socket
                            //--ws.Send(Encoding.UTF8.GetBytes(json));
                            // set to recieve new message again
                            newMessage = false;
                            return;
                        }                        

                    }
                    newMessage = false;
                    return;

                }
                //if(OtherPlayer.OC=="WINNER")
                if (OtherPlayer.OC == OpCodes.Winner)
                {
                    
                    // Announce the winner
                    // hide see button
                    btnSee.SetActive(false);
                    //if (OtherPlayer.OP=="NULL")
                    if (OtherPlayer.OP == OpCodes.Null)
                    {

                        txtAnnounce.text = OtherPlayer.PN+ " has won the match with Everyone packing!";
                        // Stop all the clock first
                        //pClock1.Play("Start");
                        //pClock2.Play("Start");
                        //pClock3.Play("Start");
                        //pClock4.Play("Start");
                        //pClock5.Play("Start");
                        Clock1.SetActive(false);
                        Clock2.SetActive(false);
                        Clock3.SetActive(false);
                        Clock4.SetActive(false);
                        Clock5.SetActive(false);

                        btnLobby.enabled = false;

                        if (Seat2.text == OtherPlayer.PN && txtPacked1.text=="Playing")
                        {
                            GameSoundFx.PlayOneShot(WinningSound);
                            pWin2.Play("Play");
                            // Show Board coin animation to player
                            txtThrowCoin2.text = txtPotCoin.text;
                            P2Coin.Play("PotCoinP2R");
                            //Empty Board coin
                            txtPotCoin.text = "0";

                        }                            
                        else if (Seat3.text == OtherPlayer.PN && txtPacked1.text == "Playing")
                        {
                            GameSoundFx.PlayOneShot(WinningSound);
                            pWin3.Play("Play");
                            // Show Board coin animation to player
                            txtThrowCoin3.text = txtPotCoin.text;
                            P3Coin.Play("PotCoinP3R");
                            //Empty Board coin
                            txtPotCoin.text = "0";
                        }                            
                        else if (Seat4.text == OtherPlayer.PN && txtPacked1.text == "Playing")
                        {
                            GameSoundFx.PlayOneShot(WinningSound);
                            pWin4.Play("Play");
                            // Show Board coin animation to player
                            txtThrowCoin4.text = txtPotCoin.text;
                            P4Coin.Play("PotCoinP4R");
                            //Empty Board coin
                            txtPotCoin.text = "0";
                        }                            
                        else if (Seat5.text == OtherPlayer.PN && txtPacked1.text == "Playing")
                        {
                            GameSoundFx.PlayOneShot(WinningSound);
                            pWin5.Play("Play");
                            // Show Board coin animation to player
                            txtThrowCoin5.text = txtPotCoin.text;
                            P5Coin.Play("PotCoinP5R");
                            //Empty Board coin
                            txtPotCoin.text = "0";
                        }
                        // The winner is a winner through everyone packing or pot money reaching upper limit
                        // In this case winner will be the next dealer
                        return;
                    }
                    else
                    {
                        // stop all clock first
                        //pClock1.Play("Start");
                        //pClock2.Play("Start");
                        //pClock3.Play("Start");
                        //pClock4.Play("Start");
                        //pClock5.Play("Start");
                        Clock1.SetActive(false);
                        Clock2.SetActive(false);
                        Clock3.SetActive(false);
                        Clock4.SetActive(false);
                        Clock5.SetActive(false);

                        btnLobby.enabled = false;

                        //NP has the winner info
                        //string[] tmp = OtherPlayer.NP.Split(',');
                        //txtAnnounce.text = tmp[0] + " has won the match with " + tmp[1];
                        txtAnnounce.text = OtherPlayer.NP + " has won the match with " + OtherPlayer.OP;
                        // Show other shower's Cards
                        if (Seat2.text == OtherPlayer.PN )
                        {

                            //Show the cards
                            //string[] tmpCC = OtherPlayer.OP.Split(',');
                            if (cList2[0] == "0" || cList2[1] == "0" || cList2[2] == "0")
                            {
                                StartCoroutine(ShowCards(Seat2.text, 2));
                            }
                            else
                            {
                                sP2C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[0]);
                                iP2C1.GetComponent<Image>().sprite = sP2C1;
                                sP2C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[1]);
                                iP2C2.GetComponent<Image>().sprite = sP2C2;
                                sP2C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[2]);
                                iP2C3.GetComponent<Image>().sprite = sP2C3;
                                ShowCardsP2.SetActive(true);
                            }
                        }

                        else if (Seat3.text == OtherPlayer.PN)
                        {
                            //txtAnnounce.text = OtherPlayer.PN + " " + OtherPlayer.OP;
                            //Show the cards
                            //string[] tmpCC = OtherPlayer.OP.Split(',');
                            if (cList3[0] == "0" || cList3[1] == "0" || cList3[2] == "0")
                            {
                                StartCoroutine(ShowCards(Seat3.text, 3));
                            }
                            else
                            {
                                sP3C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[0]);
                                iP3C1.GetComponent<Image>().sprite = sP3C1;
                                sP3C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[1]);
                                iP3C2.GetComponent<Image>().sprite = sP3C2;
                                sP3C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[2]);
                                iP3C3.GetComponent<Image>().sprite = sP3C3;
                                ShowCardsP3.SetActive(true);
                            }
                        }
                        else if (Seat4.text == OtherPlayer.PN)
                        {
                            //txtAnnounce.text = OtherPlayer.PN + " " + OtherPlayer.OP;
                            //Show the cards
                            // string[] tmpCC = OtherPlayer.OP.Split(',');
                            if (cList4[0] == "0" || cList4[1] == "0" || cList4[2] == "0")
                            {
                                StartCoroutine(ShowCards(Seat4.text, 4));
                            }
                            else
                            {
                                sP4C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[0]);
                                iP4C1.GetComponent<Image>().sprite = sP4C1;
                                sP4C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[1]);
                                iP4C2.GetComponent<Image>().sprite = sP4C2;
                                sP4C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[2]);
                                iP4C3.GetComponent<Image>().sprite = sP4C3;
                                ShowCardsP4.SetActive(true);
                            }
                        }
                        else if (Seat5.text == OtherPlayer.PN)
                        {
                            //txtAnnounce.text = OtherPlayer.PN + " " + OtherPlayer.OP;
                            //Show the cards
                            //string[] tmpCC = OtherPlayer.OP.Split(',');
                            if (cList5[0] == "0" || cList5[1] == "0" || cList5[2] == "0")
                            {
                                StartCoroutine(ShowCards(Seat5.text, 5));
                            }
                            else
                            {
                                sP5C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[0]);
                                iP5C1.GetComponent<Image>().sprite = sP5C1;
                                sP5C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[1]);
                                iP5C2.GetComponent<Image>().sprite = sP5C2;
                                sP5C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[2]);
                                iP5C3.GetComponent<Image>().sprite = sP5C3;
                                ShowCardsP5.SetActive(true);
                            }
                        }
                        // Show Winner Animation on other player tab
                        if (Seat1.text == OtherPlayer.NP && txtPacked1.text == "Playing")
                        {
                            txtThrowCoin.text = txtPotCoin.text;
                            P1Coin.Play("PotCoinP1R");
                            //GameSoundFx.PlayOneShot(WinningSound);
                            //StartCoroutine(PlayWinningSound());
                            pWin1.Play("Play");
                            // I'm the winner. I get all the board coins
                            txtMyCoin.text = (int.Parse(txtMyCoin.text) + int.Parse(txtPotCoin.text)).ToString();
                            txtPotCoin.text = "0";
                        }                            
                        else if (Seat2.text == OtherPlayer.NP && txtPacked1.text == "Playing")
                        {
                            txtThrowCoin2.text = txtPotCoin.text;
                            P2Coin.Play("PotCoinP2R");
                            //GameSoundFx.PlayOneShot(WinningSound);
                            //StartCoroutine(PlayWinningSound());
                            pWin2.Play("Play");
                            txtPotCoin.text = "0";
                        }
                            
                        else if (Seat3.text == OtherPlayer.NP && txtPacked1.text == "Playing")
                        {
                            txtThrowCoin3.text = txtPotCoin.text;
                            P3Coin.Play("PotCoinP3R");
                            //GameSoundFx.PlayOneShot(WinningSound);
                            //StartCoroutine(PlayWinningSound());
                            pWin3.Play("Play");
                            txtPotCoin.text = "0";
                        }
                            
                        else if (Seat4.text == OtherPlayer.NP && txtPacked1.text == "Playing")
                        {
                            txtThrowCoin4.text = txtPotCoin.text;
                            P4Coin.Play("PotCoinP4R");
                            //GameSoundFx.PlayOneShot(WinningSound);
                           //tartCoroutine(PlayWinningSound());
                            pWin4.Play("Play");
                            txtPotCoin.text = "0";
                        }
                            
                        else if (Seat5.text == OtherPlayer.NP && txtPacked1.text == "Playing")
                        {
                            txtThrowCoin5.text = txtPotCoin.text;
                            P5Coin.Play("PotCoinP5R");
                            //GameSoundFx.PlayOneShot(WinningSound);
                            //StartCoroutine(PlayWinningSound());
                            pWin5.Play("Play");
                            txtPotCoin.text = "0";
                        }  
                       
                        // Wait few seconds then send signals for next game
                        if(txtPacked1.text=="Playing" && Mine.DN==DBManager.username)
                        {
                            wait = true;
                            update = 0.0f;
                        }
                        newMessage = false;
                        return;
                    } 
                }
                //if(OtherPlayer.OC=="NEW" && OtherPlayer.OP=="Game")
                if (OtherPlayer.OC == OpCodes.New && OtherPlayer.OP == OpCodes.Game)
                {
                    //ShowFlashMessage();
                    //newMessage = false;
                    //return;
                    //GameSoundFx.Stop();
                    // Reset all the throw coin animation 
                    P1Coin.Play("ThrowCoin");
                    P2Coin.Play("ThrowCoin");
                    P3Coin.Play("ThrowCoin");
                    P4Coin.Play("ThrowCoin");
                    P5Coin.Play("ThrowCoin");
                    // Reset throwcoin values
                    txtThrowCoin.text = "2";
                    txtThrowCoin2.text = "2";
                    txtThrowCoin3.text = "2";
                    txtThrowCoin4.text = "2";
                    txtThrowCoin5.text = "2";
                    // Reset the seen cards
                    sP1C1 = Resources.Load<Sprite>("Sprites/CardBack");
                    P1C1.GetComponent<Image>().sprite = sP1C1;
                    sP1C2 = Resources.Load<Sprite>("Sprites/CardBack");
                    P1C2.GetComponent<Image>().sprite = sP1C2;
                    sP1C3 = Resources.Load<Sprite>("Sprites/CardBack");
                    P1C3.GetComponent<Image>().sprite = sP1C3;
                    // reset the card animators
                    Animator cAnim = P2C1.GetComponent<Animator>();
                    cAnim.Play("DealerHand");
                    cAnim = P2C2.GetComponent<Animator>();
                    cAnim.Play("DealerHand");
                    cAnim = P2C3.GetComponent<Animator>();
                    cAnim.Play("DealerHand");

                    cAnim = P3C1.GetComponent<Animator>();
                    cAnim.Play("DealerHand");
                    cAnim = P3C2.GetComponent<Animator>();
                    cAnim.Play("DealerHand");
                    cAnim = P3C3.GetComponent<Animator>();
                    cAnim.Play("DealerHand");

                    cAnim = P4C1.GetComponent<Animator>();
                    cAnim.Play("DealerHand");
                    cAnim = P4C2.GetComponent<Animator>();
                    cAnim.Play("DealerHand");
                    cAnim = P4C3.GetComponent<Animator>();
                    cAnim.Play("DealerHand");

                    cAnim = P5C1.GetComponent<Animator>();
                    cAnim.Play("DealerHand");
                    cAnim = P5C2.GetComponent<Animator>();
                    cAnim.Play("DealerHand");
                    cAnim = P5C3.GetComponent<Animator>();
                    cAnim.Play("DealerHand");

                    cAnim = P1C1.GetComponent<Animator>();
                    cAnim.Play("DealerHand");
                    cAnim = P1C2.GetComponent<Animator>();
                    cAnim.Play("DealerHand");
                    cAnim = P1C3.GetComponent<Animator>();
                    cAnim.Play("DealerHand");
                    // Reset the winner animation
                    pWin1.Play("Stop");
                    pWin2.Play("Stop");
                    pWin3.Play("Stop");
                    pWin4.Play("Stop");
                    pWin5.Play("Stop");
                    // Reset the cards
                    tmpCards1 = "";
                    tmpCards2 = "";
                    tmpCards3 = "";
                    tmpCards4 = "";
                    tmpCards5 = "";
                    cList1 = new string[] { "0", "0", "0" };
                    cList2 = new string[] { "0", "0", "0" };
                    cList3 = new string[] { "0", "0", "0" };
                    cList4 = new string[] { "0", "0", "0" };
                    cList5 = new string[] { "0", "0", "0" };
                    ShowCardsP2.SetActive(false);
                    ShowCardsP3.SetActive(false);
                    ShowCardsP4.SetActive(false);
                    ShowCardsP5.SetActive(false);
                    MyGame.FirstPlayerCardWeight = 0;
                    MyGame.SecondPlayerCardWeight = 0;
                    MyGame.ThirdPlayerCardWeight = 0;
                    MyGame.FourthPlayerCardWeight = 0;
                    MyGame.FifthPlayerCardWeight = 0;
                    Mine.DN = "";
                    sideshow = "";
                    txtPacked1.text = "Watching";
                    btnLobby.enabled = false;
                    //Mine.OC = "START";
                    Mine.OC = OpCodes.Start;
                    Mine.OP = DBManager.username;
                    json = JsonUtility.ToJson(Mine);
                    // Send json string to socket
                    //--ws.Send(Encoding.UTF8.GetBytes(json));
                    // set to recieve new message again
                    newMessage = false;
                    return;
                }
                //if(OtherPlayer.OC== "BREAK")
                if (OtherPlayer.OC == OpCodes.Break)
                {
                    
                    // Show the coin animation first and add to board money
                    if (Seat2.text == OtherPlayer.PN)
                    {
                        txtThrowCoin2.text = OtherPlayer.OP;
                        txtLastCoin2.text = OtherPlayer.OP;
                        //P2Coin.Play("ThrowCoin");
                        P2PotCoin.SetActive(false);
                        P2PotCoin.SetActive(true);
                        P2Coin.Play("PotCoinP2");
                        txtChaal2.text = "BREAK";
                        //chaal2.Play("HideChaal");
                        chaal2.Play("ShowChaal");                        
                    }
                    else if (Seat3.text == OtherPlayer.PN)
                    {
                        txtThrowCoin3.text = OtherPlayer.OP;
                        txtLastCoin3.text = OtherPlayer.OP;
                        //P2Coin.Play("ThrowCoin");
                        P3PotCoin.SetActive(false);
                        P3PotCoin.SetActive(true);
                        P3Coin.Play("PotCoinP3");
                        txtChaal3.text = "BREAK";
                        //chaal2.Play("HideChaal");
                        chaal3.Play("ShowChaal");
                    }
                    else if (Seat4.text == OtherPlayer.PN)
                    {
                        txtThrowCoin4.text = OtherPlayer.OP;
                        txtLastCoin4.text = OtherPlayer.OP;
                        //P2Coin.Play("ThrowCoin");
                        P4PotCoin.SetActive(false);
                        P4PotCoin.SetActive(true);
                        P4Coin.Play("PotCoinP4");
                        txtChaal4.text = "BREAK";
                        //chaal2.Play("HideChaal");
                        chaal4.Play("ShowChaal");
                    }
                    else if (Seat5.text == OtherPlayer.PN)
                    {
                        txtThrowCoin5.text = OtherPlayer.OP;
                        txtLastCoin5.text = OtherPlayer.OP;
                        //P2Coin.Play("ThrowCoin");
                        P5PotCoin.SetActive(false);
                        P5PotCoin.SetActive(true);
                        P5Coin.Play("PotCoinP5");
                        txtChaal5.text = "BREAK";
                        //chaal2.Play("HideChaal");
                        chaal5.Play("ShowChaal");
                    }
                    // Add coin to the pot coin amount
                    // Total pot coin is in the board money
                    txtPotCoin.text = OtherPlayer.BM;

                    // Now stop all the clocks. no more play. pot limit reached.
                    pClock1.Play("Start");
                    pClock2.Play("Start");
                    pClock3.Play("Start");
                    pClock4.Play("Start");
                    pClock5.Play("Start");
                    Clock1.SetActive(false);
                    Clock2.SetActive(false);
                    Clock3.SetActive(false);
                    Clock4.SetActive(false);
                    Clock5.SetActive(false);
                    if (txtPacked2.text=="Playing")
                    {
                        

                        txtPacked2.text = "Watching";
                        //Show the cards
                        //string[] tmpstr = OtherPlayer.OP.Split('+');
                        //cList2 = tmpstr[0].Split(',');
                        if (cList2[0] == "0" || cList2[1] == "0" || cList2[2] == "0")
                        {
                            StartCoroutine(ShowCards(Seat2.text, 2));
                        }
                        else
                        {
                            sP2C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[0]);
                            iP2C1.GetComponent<Image>().sprite = sP2C1;
                            sP2C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[1]);
                            iP2C2.GetComponent<Image>().sprite = sP2C2;
                            sP2C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[2]);
                            iP2C3.GetComponent<Image>().sprite = sP2C3;
                            ShowCardsP2.SetActive(true);
                        }
                        // save the player weight
                        //MyGame.SecondPlayerCardWeight = int.Parse(tmpstr[1]);
                    }
                    if (txtPacked3.text == "Playing")
                    {
                        
                        txtPacked3.text = "Watching";

                        //Show the cards
                        //string[] tmpstr = OtherPlayer.OP.Split('+');
                        //cList2 = tmpstr[0].Split(',');
                        if (cList3[0] == "0" || cList3[1] == "0" || cList3[2] == "0")
                        {
                            StartCoroutine(ShowCards(Seat3.text, 3));
                        }
                        else
                        {
                            sP3C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[0]);
                            iP3C1.GetComponent<Image>().sprite = sP3C1;
                            sP3C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[1]);
                            iP3C2.GetComponent<Image>().sprite = sP3C2;
                            sP3C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[2]);
                            iP3C3.GetComponent<Image>().sprite = sP3C3;
                            ShowCardsP3.SetActive(true);
                        }
                        // save the player weight
                        //MyGame.SecondPlayerCardWeight = int.Parse(tmpstr[1]);
                    }
                    if (txtPacked4.text == "Playing")
                    {
                        
                        txtPacked4.text = "Watching";
                        //Show the cards
                        //string[] tmpstr = OtherPlayer.OP.Split('+');
                        //cList2 = tmpstr[0].Split(',');
                        if (cList4[0] == "0" || cList4[1] == "0" || cList4[2] == "0")
                        {
                            StartCoroutine(ShowCards(Seat4.text, 4));
                        }
                        else
                        {
                            sP4C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[0]);
                            iP4C1.GetComponent<Image>().sprite = sP4C1;
                            sP4C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[1]);
                            iP4C2.GetComponent<Image>().sprite = sP4C2;
                            sP4C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[2]);
                            iP4C3.GetComponent<Image>().sprite = sP4C3;
                            ShowCardsP4.SetActive(true);
                        }
                        // save the player weight
                        //MyGame.SecondPlayerCardWeight = int.Parse(tmpstr[1]);
                    }
                    if (txtPacked5.text == "Playing")
                    {
                        // Stop the clock
                        pClock5.Play("Start");
                        Clock5.SetActive(false);
                        txtPacked5.text = "Watching";
                        //Show the cards
                        //string[] tmpstr = OtherPlayer.OP.Split('+');
                        //cList2 = tmpstr[0].Split(',');
                        if (cList5[0] == "0" || cList5[1] == "0" || cList5[2] == "0")
                        {
                            StartCoroutine(ShowCards(Seat5.text, 5));
                        }
                        else
                        {
                            sP5C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[0]);
                            iP5C1.GetComponent<Image>().sprite = sP5C1;
                            sP5C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[1]);
                            iP5C2.GetComponent<Image>().sprite = sP5C2;
                            sP5C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[2]);
                            iP5C3.GetComponent<Image>().sprite = sP5C3;
                            ShowCardsP5.SetActive(true);
                        }
                        // save the player weight
                        //MyGame.SecondPlayerCardWeight = int.Parse(tmpstr[1]);
                    }
                    if(txtPacked1.text=="Playing")
                    {
                        // hide the panel
                        playPanel.SetBool("Show", false);
                        
                        txtPacked1.text = "Watching";
                        if (txtSee.text == "SEE")
                        {
                            txtSee.text = "SEEN";
                            //Show the cards
                            //string[] tmpstr = OtherPlayer.OP.Split('+');
                            //cList2 = tmpstr[0].Split(',');
                            if (cList1[0] == "0" || cList1[1] == "0" || cList1[2] == "0")
                            {
                                StartCoroutine(ShowCards(DBManager.username, 1));
                            }
                            else
                            {
                                sP1C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList1[0]);
                                P1C1.GetComponent<Image>().sprite = sP1C1;
                                sP1C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList1[1]);
                                P1C2.GetComponent<Image>().sprite = sP1C2;
                                sP1C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList1[2]);
                                P1C3.GetComponent<Image>().sprite = sP1C3;
                            }
                            //ShowCardsP1.SetActive(true);
                        }
                    }
                                        
                    long maxCard = Math.Max(Math.Max(Math.Max(Math.Max(MyGame.FirstPlayerCardWeight, MyGame.SecondPlayerCardWeight), MyGame.ThirdPlayerCardWeight), MyGame.FourthPlayerCardWeight), MyGame.FifthPlayerCardWeight);
                    string CardDegree = (maxCard > 1000000 && maxCard < 2000000) ? "High Cards"
                                                : (maxCard > 2000000 && maxCard < 3000000) ? "Pair of Cards"
                                                : (maxCard > 3000000 && maxCard < 4000000) ? "One Color"
                                                : (maxCard > 4000000 && maxCard < 5000000) ? "Sequence"
                                                : (maxCard > 5000000 && maxCard < 6000000) ? "Colored Sequence"
                                                : (maxCard > 6000000 && maxCard < 7000000) ? "Tripple of a Card"
                                                : "Error";
                    if (maxCard==MyGame.FirstPlayerCardWeight)
                    {
                        // me winner
                        txtAnnounce.text = DBManager.username + " has won the match with a " + CardDegree;
                        // Show Board coin animation to player
                        txtThrowCoin.text = txtPotCoin.text;
                        P1Coin.Play("PotCoinP1R");
                        
                        // I get all the board coins
                        txtMyCoin.text = (int.Parse(txtMyCoin.text) + int.Parse(txtPotCoin.text)).ToString();
                        
                        txtPotCoin.text = "0";
                        //GameSoundFx.PlayOneShot(WinningSound);
                        //StartCoroutine(PlayWinningSound());
                        // Play winning animation
                        pWin1.Play("Play");
                        // I'm going to be the next dealer
                        Mine.DN = DBManager.username;
                        // Switch player status to watching
                        txtPacked1.text = "Watching";
                        // json = JsonUtility.ToJson(Mine);
                        // Send json string to socket
                        // ws.Send(Encoding.UTF8.GetBytes(json));
                        // set to recieve new message again
                        newMessage = false;
                        // Wait few seconds then send signals for next game
                        wait = true;
                        update = 0.0f;
                        return;
                    }
                    if (maxCard == MyGame.SecondPlayerCardWeight)
                    {
                        // second player winner
                        txtAnnounce.text = Seat2.text + " has won the match with a " + CardDegree;
                        // Show Board coin animation to player
                        txtThrowCoin2.text = txtPotCoin.text;
                        P2Coin.Play("PotCoinP2R");                        
                        txtPotCoin.text = "0";
                        //GameSoundFx.PlayOneShot(WinningSound);
                        //StartCoroutine(PlayWinningSound());
                        // Play winning animation
                        pWin2.Play("Play");
                        // seat2 is going to be the next dealer
                        Mine.DN = Seat2.text;
                        // Switch player status to watching
                        txtPacked2.text = "Watching";
                        // json = JsonUtility.ToJson(Mine);
                        // Send json string to socket
                        // ws.Send(Encoding.UTF8.GetBytes(json));
                        // set to recieve new message again
                        newMessage = false;                        
                        return;
                    }
                    if (maxCard == MyGame.ThirdPlayerCardWeight)
                    {
                        // second player winner
                        txtAnnounce.text = Seat3.text + " has won the match with a " + CardDegree;
                        // Show Board coin animation to player
                        txtThrowCoin3.text = txtPotCoin.text;
                        P3Coin.Play("PotCoinP3R");                       
                        txtPotCoin.text = "0";
                        // GameSoundFx.PlayOneShot(WinningSound);
                        //StartCoroutine(PlayWinningSound());
                        // Play winning animation
                        pWin3.Play("Play");
                        // I'm going to be the next dealer
                        Mine.DN = Seat3.text;
                        // Switch player status to watching
                        txtPacked3.text = "Watching";
                        // json = JsonUtility.ToJson(Mine);
                        // Send json string to socket
                        // ws.Send(Encoding.UTF8.GetBytes(json));
                        // set to recieve new message again
                        newMessage = false;

                        return;
                    }

                    if (maxCard == MyGame.FourthPlayerCardWeight)
                    {
                        // second player winner
                        txtAnnounce.text = Seat4.text + " has won the match with a " + CardDegree;
                        // Show Board coin animation to player
                        txtThrowCoin4.text = txtPotCoin.text;
                        P4Coin.Play("PotCoinP4R");
                        //GameSoundFx.PlayOneShot(WinningSound);
                        //StartCoroutine(PlayWinningSound());
                        txtPotCoin.text = "0";
                        // Play winning animation
                        pWin4.Play("Play");
                        // I'm going to be the next dealer
                        Mine.DN = Seat4.text;
                        // Switch player status to watching
                        txtPacked4.text = "Watching";
                        // json = JsonUtility.ToJson(Mine);
                        // Send json string to socket
                        // ws.Send(Encoding.UTF8.GetBytes(json));
                        // set to recieve new message again
                        newMessage = false;

                        return;
                    }
                    if (maxCard == MyGame.FifthPlayerCardWeight)
                    {
                        // second player winner
                        txtAnnounce.text = Seat5.text + " has won the match with a " + CardDegree;
                        // Show Board coin animation to player
                        txtThrowCoin5.text = txtPotCoin.text;
                        P5Coin.Play("PotCoinP5R");
                        //GameSoundFx.PlayOneShot(WinningSound);
                        //StartCoroutine(PlayWinningSound());
                        txtPotCoin.text = "0";
                        // Play winning animation
                        pWin5.Play("Play");
                        // I'm going to be the next dealer
                        Mine.DN = Seat5.text;
                        // Switch player status to watching
                        txtPacked5.text = "Watching";
                        // json = JsonUtility.ToJson(Mine);
                        // Send json string to socket
                        // ws.Send(Encoding.UTF8.GetBytes(json));
                        // set to recieve new message again
                        newMessage = false;

                        return;
                    }

                    newMessage = false;
                    return;
                }
                
                    //if(OtherPlayer.OC=="SIDE")
                if (OtherPlayer.OC == OpCodes.SideShow)
                {
                    
                    //string[] strside = OtherPlayer.OP.Split('-');
                    if (OtherPlayer.OP==DBManager.username)
                    {
                        ssPlayer = OtherPlayer.PN;
                        if (OtherPlayer.PN == Seat2.text)
                            ssCards = tmpCards2;
                        else if(OtherPlayer.PN==Seat3.text)
                            ssCards = tmpCards3;
                        else if (OtherPlayer.PN == Seat4.text)
                            ssCards = tmpCards4;
                        else if (OtherPlayer.PN == Seat5.text)
                            ssCards = tmpCards5;
                        //ssCards = strside[1];
                        txtSide.text = "Accept Side Show Offer from "+OtherPlayer.PN+"?";
                        
                        pnlSide.SetActive(true);
                        return;

                    }
                }
                //if(OtherPlayer.OC=="YouPack" )
                if (OtherPlayer.OC == OpCodes.YouPack)
                {
                    //string[] strside = OtherPlayer.OP.Split('-');

                    if (OtherPlayer.OP == DBManager.username)
                    {

                        //string[] tmpC = strside[1].Split(',');
                        //Show the cards
                        if (Seat5.text == OtherPlayer.PN)
                        {
                            if (cList5[0] == "0" || cList5[1] == "0" || cList5[2] == "0")
                            {
                                StartCoroutine(ShowCards(Seat5.text, 5));
                            }
                            else
                            {
                                sP5C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[0]);
                                iP5C1.GetComponent<Image>().sprite = sP5C1;
                                sP5C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[1]);
                                iP5C2.GetComponent<Image>().sprite = sP5C2;
                                sP5C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[2]);
                                iP5C3.GetComponent<Image>().sprite = sP5C3;
                                ShowCardsP5.SetActive(true);
                            }
                        }
                        else if (Seat4.text == OtherPlayer.PN)
                        {
                            if (cList4[0] == "0" || cList4[1] == "0" || cList4[2] == "0")
                            {
                                StartCoroutine(ShowCards(Seat4.text, 4));
                            }
                            else
                            {
                                sP4C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[0]);
                                iP4C1.GetComponent<Image>().sprite = sP4C1;
                                sP4C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[1]);
                                iP4C2.GetComponent<Image>().sprite = sP4C2;
                                sP4C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[2]);
                                iP4C3.GetComponent<Image>().sprite = sP4C3;
                                ShowCardsP4.SetActive(true);
                            }
                        }
                        else if (Seat3.text == OtherPlayer.PN)
                        {
                            if (cList3[0] == "0" || cList3[1] == "0" || cList3[2] == "0")
                            {
                                StartCoroutine(ShowCards(Seat3.text, 3));
                            }
                            else
                            {
                                sP3C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[0]);
                                iP3C1.GetComponent<Image>().sprite = sP3C1;
                                sP3C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[1]);
                                iP3C2.GetComponent<Image>().sprite = sP3C2;
                                sP3C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[2]);
                                iP3C3.GetComponent<Image>().sprite = sP3C3;
                                ShowCardsP3.SetActive(true);
                            }
                        }
                        else if (Seat2.text == OtherPlayer.PN)
                        {
                            if (cList2[0] == "0" || cList2[1] == "0" || cList2[2] == "0")
                            {
                                StartCoroutine(ShowCards(Seat2.text, 2));
                            }
                            else
                            {
                                sP2C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[0]);
                                iP2C1.GetComponent<Image>().sprite = sP2C1;
                                sP2C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[1]);
                                iP2C2.GetComponent<Image>().sprite = sP2C2;
                                sP2C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[2]);
                                iP2C3.GetComponent<Image>().sprite = sP2C3;
                                ShowCardsP2.SetActive(true);
                            }
                        }
                        OnPack();

                    }
                    newMessage = false;
                    return;
                    
                }
                //if(OtherPlayer.OC=="QUIT")
                if (OtherPlayer.OC == OpCodes.Quit)
                {
                    GameSoundFx.PlayOneShot(NewPlayerSound);
                    //Anouce the Action

                    txtAnnounce.text = OtherPlayer.PN + " has quit";
                    if (Seat2.text == OtherPlayer.PN)
                    {
                        Seat2.text = "EMPTY";
                        Sprite tmpPicute = Resources.Load<Sprite>("Images/" + "EmptySeat");
                        imgP2.GetComponent<Image>().sprite = tmpPicute;
                        txtChaal2.text = "QUIT";
                        //chaal2.Play("HideChaal");
                        chaal2.Play("ShowChaal");
                        // Stop that player's clock
                        pClock2.Play("Start");
                        Clock2.SetActive(false);
                        
                        txtPacked2.text = "Left";
                        //txtPacked2.enabled = true;
                    }
                    else if (Seat3.text == OtherPlayer.PN)
                    {
                        Seat3.text = "EMPTY";
                        Sprite tmpPicute = Resources.Load<Sprite>("Images/" + "EmptySeat");
                        imgP3.GetComponent<Image>().sprite = tmpPicute;
                        txtChaal3.text = "QUIT";
                        //chaal3.Play("HideChaal");
                        chaal3.Play("ShowChaal");
                        // Stop that player's clock
                        pClock3.Play("Start");
                        Clock3.SetActive(false);
                        
                        txtPacked3.text = "Left";
                        //txtPacked3.enabled = true;
                    }
                    else if (Seat4.text == OtherPlayer.PN)
                    {
                        Seat4.text = "EMPTY";
                        Sprite tmpPicute = Resources.Load<Sprite>("Images/" + "EmptySeat");
                        imgP4.GetComponent<Image>().sprite = tmpPicute;
                        txtChaal4.text = "QUIT";
                        // chaal4.Play("HideChaal");
                        chaal4.Play("ShowChaal");
                        // Stop that player's clock
                        pClock4.Play("Start");
                        Clock4.SetActive(false);
                       
                        txtPacked4.text = "Left";
                        //txtPacked4.enabled = true;
                    }
                    else if (Seat5.text == OtherPlayer.PN)
                    {
                        Seat5.text = "EMPTY";
                        Sprite tmpPicute = Resources.Load<Sprite>("Images/" + "EmptySeat");
                        imgP5.GetComponent<Image>().sprite = tmpPicute;
                        txtChaal5.text = "QUIT";
                        //chaal5.Play("HideChaal");
                        chaal5.Play("ShowChaal");
                        // Stop that player's clock
                        pClock5.Play("Start");
                        Clock5.SetActive(false);
                       
                        txtPacked5.text = "Left";
                        //txtPacked5.enabled = true;
                    }
                    // Determine if I'm the only player now
                    int playerCount = 1;
                    if (txtPacked2.text == "Playing")
                        playerCount++;
                    if (txtPacked3.text == "Playing")
                        playerCount++;
                    if (txtPacked4.text == "Playing")
                        playerCount++;
                    if (txtPacked5.text == "Playing")
                        playerCount++;
                    nPlayers = playerCount;
                    if (playerCount == 1 && txtPacked1.text == "Playing" && txtPotCoin.text!="0" && txtPotCoin.text!="")
                    {
                       
                        // I'm the only player. So I win the match
                        // Stop the clock
                        pClock1.Play("Start");
                        Clock1.SetActive(false);
                        
                        // Hide panel
                        playPanel.SetBool("Show", false);

                        // Show Board coin animation to player
                        txtThrowCoin.text = txtPotCoin.text;
                        P1Coin.Play("PotCoinP1R");
                        // I'm the winner. I get all the board coins
                        txtMyCoin.text = (int.Parse(txtMyCoin.text) + int.Parse(txtPotCoin.text)).ToString();
                        // Show Board coin animation to player
                        txtPotCoin.text = "0";
                        //GameSoundFx.PlayOneShot(WinningSound);
                        //StartCoroutine(PlayWinningSound());
                        // Show Winner Animation on my player tab
                        pWin1.Play("Play");
                        btnLobby.enabled = false;
                        txtAnnounce.text = DBManager.username + " has won the match because everyone packed!";
                        // Signal the other player and return null card info
                        //Mine.OC = "WINNER";
                        Mine.OC = OpCodes.Winner;
                        //Mine.OP = "NULL";
                        Mine.OP = OpCodes.Null;
                        Mine.NP = DBManager.username;
                        // I'm going to be the next dealer
                        Mine.DN = DBManager.username;
                        // Switch player status to watching
                        txtPacked1.text = "Watching";
                        btnSee.SetActive(false);
                        json = JsonUtility.ToJson(Mine);
                        // Send json string to socket
                        //--ws.Send(Encoding.UTF8.GetBytes(json));
                        // set to recieve new message again
                        newMessage = false;
                        // Wait few seconds then send signals for next game
                        wait = true;
                        update = 0.0f;
                        return;
                    }
                    /*
                    if(playerCount==1)
                    {
                        txtAnnounce.text = "Wait for a player to join the room.";
                        newMessage = false;
                        return;
                    }
                    
                    // Start Next Player's Clock
                    if (OtherPlayer.NP == Seat1.text)
                    {
                       
                        //pClock1.Play("Start");
                        Clock1.SetActive(true);
                        pClock1.Play("Clock1");
                        GameSoundFx.PlayOneShot(ClockStart);
                        playPanel.SetBool("Show", true);
                    }
                    else if (OtherPlayer.NP == Seat2.text)
                    {
                        //pClock2.Play("Start");
                        Clock2.SetActive(true);
                        pClock2.Play("Clock2");
                    }
                    else if (OtherPlayer.NP == Seat3.text)
                    {
                        //pClock3.Play("Start");
                        Clock3.SetActive(true);
                        pClock3.Play("Clock3");
                    }
                    else if (OtherPlayer.NP == Seat4.text)
                    {
                        //pClock4.Play("Start");
                        Clock4.SetActive(true);
                        pClock4.Play("Clock4");
                    }
                    else if (OtherPlayer.NP == Seat5.text)
                    {
                        //pClock5.Play("Start");
                        Clock5.SetActive(true);
                        pClock5.Play("Clock5");
                    }
                    // set to recieve new message again
                    newMessage = false;
                    return;                   

                }
                if(OtherPlayer.OC==OpCodes.SendQuit && OtherPlayer.OP==DBManager.username)
                {
                    OnBack();
                    newMessage = false;
                    return;
                }

            }                   
        }
       */ 
    }
   
    
    IEnumerator SendCards(string cards, string player)
    {
        Mine.OC = OpCodes.AllCards;
        Mine.OP = cards;
        Mine.NP = player;
        // Convert data to json string
        json = JsonUtility.ToJson(Mine);
        // Send json string to socket
        //--ws.Send(Encoding.UTF8.GetBytes(json));
        yield return true;
    }
    void OnDestroy()
    {
        //OnPack();
        //--ws.Close();
        destroy = true;
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();

        formData.Add(new MultipartFormDataSection("PlayerName", DBManager.username));

        formData.Add(new MultipartFormDataSection("RoomId", RoomId.text));

        UnityWebRequest www = UnityWebRequest.Post(LeaveRoomURL, formData);

        www.SendWebRequest();
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
            //DialogMsg.text = www.downloadHandler.text;
            //pnlOK.SetActive(true);
            Debug.Log(www.downloadHandler.text);
            //SubmitButton.interactable = false;
        }

        
        
        //Debug.Log("OnDestroy2");
    }

    void OnApplicationQuit()
    {
        //if(DBManager.username!="")
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();

        formData.Add(new MultipartFormDataSection("PlayerName", DBManager.username));

        formData.Add(new MultipartFormDataSection("RoomId", RoomId.text));

        UnityWebRequest www = UnityWebRequest.Post(LeaveRoomURL, formData);

        www.SendWebRequest();
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
            //DialogMsg.text = www.downloadHandler.text;
            //pnlOK.SetActive(true);
            Debug.Log(www.downloadHandler.text);
            //SubmitButton.interactable = false;
        }

        destroy = true;

    }

    public void HideDialog()
    {
        pnlOK.SetActive(false);
        /*
        if(FlashMessage)
        {
            FlashMessage = false;
            Mine.OC = OpCodes.Ready;
            Mine.OP = DBManager.username;
            json = JsonUtility.ToJson(Mine);
            // Send json string to socket
            ws.Send(Encoding.UTF8.GetBytes(json));
            // set to recieve new message again
            newMessage = false;

        }
        */

    }
    // Start is called before the first frame update
    void ShowFlashMessage()
    {
        
        DialogMsg.text = "Boot-amount\nBlind-limit\nChaal-limit\nPot-limit";
        DialogMsg2.text = "2\n4\n256\n2000";
        pnlOK.SetActive(true);
        FlashMessage = true;
    }
    
    IEnumerator JoinRoomClassic()
    {
        Seat1.text = DBManager.username;
        Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + DBManager.userpic);
        imgP1.GetComponent<Image>().sprite = tmpPicute;
        yield return new WaitForSeconds(1.5f);
        if (socketConnected)
        {
            JSONObject data = new JSONObject();            
            data.AddField("name", DBManager.username);            
            data.AddField("pic", DBManager.userpic);
            socket.Emit("JoinRoom", data);
        }
        
        // wait 1 seconds and continue
        
        
    }

    public void AddOldPlayer(SocketIOEvent e)
    {
        playerInfo oldPlayer = new playerInfo();        
        oldPlayer = JsonUtility.FromJson<playerInfo>(e.data.ToString());
        if(oldPlayer.seatNo=="")
        { }

    }
    
    public void StartNewGame(SocketIOEvent e)
    {
        btnLobby.enabled = false;
        txtAnnounce.text = "Game Starting!";
        //Debug.Log("Game Starting");
        //btnLobby.enabled = false;
        //reset all the globals
        JSONObject reset = new JSONObject();
        reset.AddField("room", myInfo.roomName);
        socket.Emit("ResetRoom", reset);
        tmpCards1 = "";
        tmpCards2 = "";
        tmpCards3 = "";
        tmpCards4 = "";
        tmpCards5 = "";
        cList1 = new string[] { "0", "0", "0" };
        cList2 = new string[] { "0", "0", "0" };
        cList3 = new string[] { "0", "0", "0" };
        cList4 = new string[] { "0", "0", "0" };
        cList5 = new string[] { "0", "0", "0" };
        MyGame.FirstPlayerCardWeight = 0;
        MyGame.SecondPlayerCardWeight = 0;
        MyGame.ThirdPlayerCardWeight = 0;
        MyGame.FourthPlayerCardWeight = 0;
        MyGame.FifthPlayerCardWeight = 0;
        sideshow = "";
        txtPacked1.text = "Playing";
        // Reset Player counter      
        
        txtLastCoin2.text = "";
        txtLastCoin3.text = "";
        txtLastCoin4.text = "";
        txtLastCoin5.text = "";
        // Reset my chaal amount to lowest
        txtAmount.text = "2";
        // Reset all player's pot amount to lowest
        txtThrowCoin.text = "2";
        txtThrowCoin2.text = "2";
        txtThrowCoin3.text = "2";
        txtThrowCoin4.text = "2";
        txtThrowCoin5.text = "2";
        // reset BM to zero
        txtPotCoin.text = "0";
        // Reset all the player's chaal
        txtChaal2.text = "";
        txtChaal3.text = "";
        txtChaal4.text = "";
        txtChaal5.text = "";

        // Reset see and blind button
        txtSee.text = "SEE";
        btnSee.SetActive(false);
        txtBlind.text = "BLIND";
        // Reset GamePanel
        btnBlind.interactable = true;
        btnMinus.interactable = false;
        btnPlus.interactable = true;
        btnPack.interactable = true;
        btnShow.interactable = false;
        BlindLimit = 0;
        sideshow = "";
        // Hide all the show cards slots
        ShowCardsP2.SetActive(false);
        ShowCardsP3.SetActive(false);
        ShowCardsP4.SetActive(false);
        ShowCardsP5.SetActive(false);

        sP1C1 = Resources.Load<Sprite>("Sprites/CardBack");
        P1C1.GetComponent<Image>().sprite = sP1C1;
        sP1C2 = Resources.Load<Sprite>("Sprites/CardBack");
        P1C2.GetComponent<Image>().sprite = sP1C2;
        sP1C3 = Resources.Load<Sprite>("Sprites/CardBack");
        P1C3.GetComponent<Image>().sprite = sP1C3;

        P1Coin.Play("ThrowCoin");
        P2Coin.Play("ThrowCoin");
        P3Coin.Play("ThrowCoin");
        P4Coin.Play("ThrowCoin");
        P5Coin.Play("ThrowCoin");
        Animator cAnim = P2C1.GetComponent<Animator>();
        cAnim.Play("DealerHand");

        cAnim = P2C2.GetComponent<Animator>();
        cAnim.Play("DealerHand");
        cAnim = P2C3.GetComponent<Animator>();
        cAnim.Play("DealerHand");

        cAnim = P3C1.GetComponent<Animator>();
        cAnim.Play("DealerHand");
        cAnim = P3C2.GetComponent<Animator>();
        cAnim.Play("DealerHand");
        cAnim = P3C3.GetComponent<Animator>();
        cAnim.Play("DealerHand");

        cAnim = P4C1.GetComponent<Animator>();
        cAnim.Play("DealerHand");
        cAnim = P4C2.GetComponent<Animator>();
        cAnim.Play("DealerHand");
        cAnim = P4C3.GetComponent<Animator>();
        cAnim.Play("DealerHand");

        cAnim = P5C1.GetComponent<Animator>();
        cAnim.Play("DealerHand");
        cAnim = P5C2.GetComponent<Animator>();
        cAnim.Play("DealerHand");
        cAnim = P5C3.GetComponent<Animator>();
        cAnim.Play("DealerHand");

        cAnim = P1C1.GetComponent<Animator>();
        cAnim.Play("DealerHand");
        cAnim = P1C2.GetComponent<Animator>();
        cAnim.Play("DealerHand");
        cAnim = P1C3.GetComponent<Animator>();
        cAnim.Play("DealerHand");
        
        // Reset the winner animation
        pWin1.Play("Stop");
        pWin2.Play("Stop");
        pWin3.Play("Stop");
        pWin4.Play("Stop");
        pWin5.Play("Stop");
        // Reset My status to watching
        //txtPacked1.text = "Watching";

        StartCoroutine(DealCards(0.25f));     
        txtAnnounce.text = "New Game Started!";
        
        return;
    }
    IEnumerator DealCards(float time)
    {
        if (Seat2.text != "EMPTY")
        {
            GameSoundFx.PlayOneShot(BootMoneySound);
            // Collect pot money                        
            P2Coin.Play("PotCoinP2");
            txtPotCoin.text = (int.Parse(txtPotCoin.text) + int.Parse(txtThrowCoin2.text)).ToString();
            // change player to playing
            txtPacked2.text = "Playing";
        }
        if (Seat3.text != "EMPTY")
        {
            GameSoundFx.PlayOneShot(BootMoneySound);
            // Collect pot money   
            P3Coin.Play("PotCoinP3");
            txtPotCoin.text = (int.Parse(txtPotCoin.text) + int.Parse(txtThrowCoin3.text)).ToString();
            // change player to playing
            txtPacked3.text = "Playing";
        }
        if (Seat4.text != "EMPTY")
        {
            GameSoundFx.PlayOneShot(BootMoneySound);
            // Collect pot money           
            P4Coin.Play("PotCoinP4");
            txtPotCoin.text = (int.Parse(txtPotCoin.text) + int.Parse(txtThrowCoin4.text)).ToString();
            // change player to playing
            txtPacked4.text = "Playing";
        }
        if (Seat5.text != "EMPTY")
        {
            GameSoundFx.PlayOneShot(BootMoneySound);
            // Collect pot money             
            P5Coin.Play("PotCoinP5");
            txtPotCoin.text = (int.Parse(txtPotCoin.text) + int.Parse(txtThrowCoin5.text)).ToString();
            // change player to playing
            txtPacked5.text = "Playing";
        }

        GameSoundFx.PlayOneShot(BootMoneySound);
        //P1Coin.Play("ThrowCoin");
        P1Coin.Play("PotCoinP1");
        txtPotCoin.text = (int.Parse(txtPotCoin.text) + int.Parse(txtThrowCoin.text)).ToString();
        txtMyCoin.text = (int.Parse(txtMyCoin.text) - int.Parse(txtThrowCoin.text)).ToString();
        yield return new WaitForSeconds(1.0f);

        if (txtPacked2.text == "Playing")
        {
            Animator cAnim = P2C1.GetComponent<Animator>();
            cAnim.Play("P2C1Animation");
            yield return new WaitForSeconds(time);
        }
        
        if (txtPacked3.text == "Playing")
        {
            Animator cAnim = P3C1.GetComponent<Animator>();
            cAnim.Play("P3C1Animation");
            yield return new WaitForSeconds(time);
        }
        
        if (txtPacked4.text == "Playing")
        {
            Animator cAnim = P4C1.GetComponent<Animator>();
            cAnim.Play("P4C1Animation");
            yield return new WaitForSeconds(time);
        }
        if (txtPacked5.text == "Playing")
        {
            Animator cAnim = P5C1.GetComponent<Animator>();
            cAnim.Play("P5C1Animation");
            yield return new WaitForSeconds(time);
        }
        Animator cAnimme = P1C1.GetComponent<Animator>();
        cAnimme.Play("P1C1Animation");
        yield return new WaitForSeconds(time);
        if (txtPacked2.text == "Playing")
        {
            Animator cAnim = P2C2.GetComponent<Animator>();
            cAnim.Play("P2C2Animation");
            yield return new WaitForSeconds(time);
        }
        if (txtPacked3.text == "Playing")
        {
            Animator cAnim = P3C2.GetComponent<Animator>();
            cAnim.Play("P3C2Animation");
            yield return new WaitForSeconds(time);
        }
        if (txtPacked4.text == "Playing")
        {
            Animator cAnim = P4C2.GetComponent<Animator>();
            cAnim.Play("P4C2Animation");
            yield return new WaitForSeconds(time);
        }
        if (txtPacked5.text == "Playing")
        {
            Animator cAnim = P5C2.GetComponent<Animator>();
            cAnim.Play("P5C2Animation");
            yield return new WaitForSeconds(time);
        }
        cAnimme = P1C2.GetComponent<Animator>();
        cAnimme.Play("P1C2Animation");
        yield return new WaitForSeconds(time);
        if (txtPacked2.text == "Playing")
        {
            Animator cAnim = P2C3.GetComponent<Animator>();
            cAnim.Play("P2C3Animation");
            yield return new WaitForSeconds(time);
        }
        if (txtPacked3.text == "Playing")
        {
            Animator cAnim = P3C3.GetComponent<Animator>();
            cAnim.Play("P3C3Animation");
            yield return new WaitForSeconds(time);
        }
        if (txtPacked4.text == "Playing")
        {
            Animator cAnim = P4C3.GetComponent<Animator>();
            cAnim.Play("P4C3Animation");
            yield return new WaitForSeconds(time);
        }
        if (txtPacked5.text == "Playing")
        {
            Animator cAnim = P5C3.GetComponent<Animator>();
            cAnim.Play("P5C3Animation");
            yield return new WaitForSeconds(time);
        }
        cAnimme = P1C3.GetComponent<Animator>();
        cAnimme.Play("P1C3Animation");        

        // calculate cards
        MyGame.ResetCards();
        int nCard = MyGame.GetRandomCard;
        MyGame.RemoveRandomCard(nCard);
        tmpCards1 = nCard.ToString() + ",";
        nCard = MyGame.GetRandomCard;
        MyGame.RemoveRandomCard(nCard);
        tmpCards1 = tmpCards1 + nCard.ToString() + ",";
        nCard = MyGame.GetRandomCard;
        MyGame.RemoveRandomCard(nCard);
        tmpCards1 = tmpCards1 + nCard.ToString();
        //cList1 = tmpCards1.Split(',');
        //MyGame.FirstPlayerCardWeight = SavePlayerCardValue(int.Parse(cList1[0]), int.Parse(cList1[1]), int.Parse(cList1[2]));
        //StartCoroutine(SavePlayerCards(RoomId.text, DBManager.username, cList1[0], cList1[1], cList1[2], MyGame.FirstPlayerCardWeight.ToString()));
        
        JSONObject data = new JSONObject();
        data.AddField("room", rn1.text);
        data.AddField("p1", Seat1.text);
        data.AddField("c1", tmpCards1);

        if(Seat2.text!="EMPTY")
        {
             nCard = MyGame.GetRandomCard;
            MyGame.RemoveRandomCard(nCard);
            tmpCards2 = nCard.ToString() + ",";
            nCard = MyGame.GetRandomCard;
            MyGame.RemoveRandomCard(nCard);
            tmpCards2 = tmpCards2 + nCard.ToString() + ",";
            nCard = MyGame.GetRandomCard;
            MyGame.RemoveRandomCard(nCard);
            tmpCards2 = tmpCards2 + nCard.ToString();
            // = tmpCards2.Split(',');
            //MyGame.SecondPlayerCardWeight = SavePlayerCardValue(int.Parse(cList2[0]), int.Parse(cList2[1]), int.Parse(cList2[2]));
            data.AddField("p2", Seat2.text);
            data.AddField("c2", tmpCards2);
        }
        else
        {
            data.AddField("p2", Seat2.text);
            data.AddField("c2", "null");
        }
        if (Seat3.text != "EMPTY")
        {
            nCard = MyGame.GetRandomCard;
            MyGame.RemoveRandomCard(nCard);
            tmpCards3 = nCard.ToString() + ",";
            nCard = MyGame.GetRandomCard;
            MyGame.RemoveRandomCard(nCard);
            tmpCards3 = tmpCards3 + nCard.ToString() + ",";
            nCard = MyGame.GetRandomCard;
            MyGame.RemoveRandomCard(nCard);
            tmpCards3 = tmpCards3 + nCard.ToString();
            //cList3 = tmpCards3.Split(',');
            //MyGame.ThirdPlayerCardWeight = SavePlayerCardValue(int.Parse(cList3[0]), int.Parse(cList3[1]), int.Parse(cList3[2]));
            data.AddField("p3", Seat3.text);
            data.AddField("c3", tmpCards3);
        }
        else
        {
            data.AddField("p3", Seat3.text);
            data.AddField("c3", "null");
        }
        
        if (Seat4.text != "EMPTY")
        {
            nCard = MyGame.GetRandomCard;
            MyGame.RemoveRandomCard(nCard);
            tmpCards4 = nCard.ToString() + ",";
            nCard = MyGame.GetRandomCard;
            MyGame.RemoveRandomCard(nCard);
            tmpCards4 = tmpCards4 + nCard.ToString() + ",";
            nCard = MyGame.GetRandomCard;
            MyGame.RemoveRandomCard(nCard);
            tmpCards4 = tmpCards4 + nCard.ToString();
            //cList4 = tmpCards4.Split(',');
            //MyGame.FourthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList4[0]), int.Parse(cList4[1]), int.Parse(cList4[2]));
            data.AddField("p4", Seat4.text);
            data.AddField("c4", tmpCards4);
        }
        else
        {
            data.AddField("p4", Seat4.text);
            data.AddField("c4", "null");
        }
        if (Seat5.text != "EMPTY")
        {
            nCard = MyGame.GetRandomCard;
            MyGame.RemoveRandomCard(nCard);
            tmpCards5 = nCard.ToString() + ",";
            nCard = MyGame.GetRandomCard;
            MyGame.RemoveRandomCard(nCard);
            tmpCards5 = tmpCards5 + nCard.ToString() + ",";
            nCard = MyGame.GetRandomCard;
            MyGame.RemoveRandomCard(nCard);
            tmpCards5 = tmpCards5 + nCard.ToString();
            //cList5 = tmpCards5.Split(',');
            //MyGame.FifthPlayerCardWeight = SavePlayerCardValue(int.Parse(cList5[0]), int.Parse(cList5[1]), int.Parse(cList5[2]));
            data.AddField("p5", Seat5.text);
            data.AddField("c5", tmpCards5);
        }
        else
        {
            data.AddField("p5", Seat5.text);
            data.AddField("c5", "null");
        }
        socket.Emit("Card", data);
        yield return new WaitForSeconds(2.0f);
        JSONObject reset = new JSONObject();
        reset.AddField("room", myInfo.roomName);
        socket.Emit("ResetCard",reset);
        btnSee.SetActive(true);
        int mySeatNO = Int32.Parse(ps1.text);
        List<int> seatList = new List<int>();
        seatList.Add(mySeatNO);

        //int n1, n2, n3, n4, n5;
        //n1 = Int32.Parse(ps1.text);
        int playerCount = 1;
        if (ps2.text!="n")
        {
            seatList.Add(Int32.Parse(ps2.text));
            playerCount++;
        }
        if (ps3.text != "n")
        {
            seatList.Add(Int32.Parse(ps3.text));
            playerCount++;
        }
        if (ps4.text != "n")
        {
            seatList.Add(Int32.Parse(ps4.text));
            playerCount++;
        }
        if (ps5.text != "n")
        {
            seatList.Add(Int32.Parse(ps5.text));
            playerCount++;
        }
        int startSeat = seatList.Min(z => z);
        //int nextSeat= seatList.OrderBy(z => z).Skip(1).First();
        if (playerCount > 2)
        {
            txtShow.text = "SIDE SHOW";
            btnShow.interactable = false;
        }
        else
        {
            txtShow.text = "SHOW";
            btnShow.interactable = true;
        }
        if (startSeat==mySeatNO)
        {
            
            playPanel.SetBool("Show", true);
            
            
            // Start the 15 second Timer            
            Clock1.SetActive(true);
            pClock1.Play("Clock1");
            txtSee.text = "SEE";           
            
        }
        else if(ps2.text!="n" && startSeat==Int32.Parse(ps2.text))
        {
            Clock2.SetActive(true);
            pClock2.Play("Clock2");
        }
        else if (ps3.text != "n" && startSeat == Int32.Parse(ps3.text))
        {
            Clock3.SetActive(true);
            pClock3.Play("Clock3");
        }
        else if (ps4.text != "n" && startSeat == Int32.Parse(ps4.text))
        {
            Clock4.SetActive(true);
            pClock4.Play("Clock4");
        }
        else if (ps5.text != "n" && startSeat == Int32.Parse(ps5.text))
        {
            Clock5.SetActive(true);
            pClock5.Play("Clock5");
        }
        btnLobby.enabled = true;
    }
    public void DeletePlayer(SocketIOEvent e)
    {
        playerInfo quittingPlayer = new playerInfo();
        quittingPlayer = JsonUtility.FromJson<playerInfo>(e.data.ToString());
        if(quittingPlayer.playerName==Seat2.text)
        {
            Seat2.text = "EMPTY";
            ps2.text = "n";
            ss2.text = "n";
            rn2.text = "n";
            Sprite tmpPicute = Resources.Load<Sprite>("Images/" + "EmptySeat");
            imgP2.GetComponent<Image>().sprite = tmpPicute;
            txtChaal2.text = "QUIT";
            //chaal2.Play("HideChaal");
            chaal2.Play("ShowChaal");
            // Stop that player's clock
            pClock2.Play("Start");
            Clock2.SetActive(false);
            txtPacked2.text = "Left";           
        }
        if (quittingPlayer.playerName == Seat3.text)
        {
            Seat3.text = "EMPTY";
            ps3.text = "n";
            ss3.text = "n";
            rn3.text = "n";
            Sprite tmpPicute = Resources.Load<Sprite>("Images/" + "EmptySeat");
            imgP3.GetComponent<Image>().sprite = tmpPicute;
            txtChaal3.text = "QUIT";
            //chaal2.Play("HideChaal");
            chaal3.Play("ShowChaal");
            // Stop that player's clock
            pClock3.Play("Start");
            Clock3.SetActive(false);
            txtPacked3.text = "Left";
        }
        if (quittingPlayer.playerName == Seat4.text)
        {
            Seat4.text = "EMPTY";
            ps4.text = "n";
            ss4.text = "n";
            rn4.text = "n";
            Sprite tmpPicute = Resources.Load<Sprite>("Images/" + "EmptySeat");
            imgP4.GetComponent<Image>().sprite = tmpPicute;
            txtChaal4.text = "QUIT";
            //chaal2.Play("HideChaal");
            chaal4.Play("ShowChaal");
            // Stop that player's clock
            pClock4.Play("Start");
            Clock4.SetActive(false);
            txtPacked4.text = "Left";
        }
        if (quittingPlayer.playerName == Seat5.text)
        {
            Seat5.text = "EMPTY";
            ps5.text = "n";
            ss5.text = "n";
            rn5.text = "n";
            Sprite tmpPicute = Resources.Load<Sprite>("Images/" + "EmptySeat");
            imgP5.GetComponent<Image>().sprite = tmpPicute;
            txtChaal5.text = "QUIT";
            //chaal2.Play("HideChaal");
            chaal5.Play("ShowChaal");
            // Stop that player's clock
            pClock5.Play("Start");
            Clock5.SetActive(false);
            txtPacked5.text = "Left";
        }
        // Determine if I'm the only player now
        int playerCount = 1;
        if (txtPacked2.text == "Playing")
            playerCount++;
        if (txtPacked3.text == "Playing")
            playerCount++;
        if (txtPacked4.text == "Playing")
            playerCount++;
        if (txtPacked5.text == "Playing")
            playerCount++;
        if (playerCount == 1 && txtPacked1.text == "Playing")
        {
            JSONObject data = new JSONObject();
            //data.AddField("socket", myInfo.roomName);
            data.AddField("room", myInfo.roomName);
            data.AddField("name", Seat1.text);
            data.AddField("by", "Everyone Packing");
            socket.Emit("Winner", data);
            // I'm the only player. So I win the match
            // Stop the clock                        
            pClock1.Play("Start");
            Clock1.SetActive(false);
            // Hide panel
            playPanel.SetBool("Show", false);
            // hide the see button
            btnSee.SetActive(false);
            // Show Board coin animation to player
            txtThrowCoin.text = txtPotCoin.text;
            P1Coin.Play("PotCoinP1R");
            // I'm the winner. I get all the board coins
            txtMyCoin.text = (int.Parse(txtMyCoin.text) + int.Parse(txtPotCoin.text)).ToString();
            // Show Board coin animation to player
            txtPotCoin.text = "0";
            GameSoundFx.PlayOneShot(WinningSound);

            //StartCoroutine(PlayWinningSound());
            // Show Winner Animation on my player tab
            pWin1.Play("Play");
            // Disable the lobby button
            //--btnLobby.enabled = false;
            txtAnnounce.text = DBManager.username + " has won the match with everyone packing!";
            return;
        }
        if (playerCount == 2)
        {
            txtShow.text = "SHOW";
            btnShow.interactable = true;
        }
        if (playerCount > 2)
        {
            txtShow.text = "SIDE SHOW";
        }
    }
    public void AddNewPlayer(SocketIOEvent e)
    {
        playerInfo newPlayer = new playerInfo();        
        newPlayer = JsonUtility.FromJson<playerInfo>(e.data.ToString());
        
        if (myInfo.seatNo=="1")
        {
            if(newPlayer.seatNo=="2")
            {
                Seat2.text = newPlayer.playerName;
                ps2.text = newPlayer.seatNo;
                ss2.text = newPlayer.socketId;
                rn2.text = newPlayer.roomName;
                txtPacked2.text = newPlayer.playingStatus;
                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + newPlayer.playerPic);
                imgP2.GetComponent<Image>().sprite = tmpPicute;
                
            }
            if (newPlayer.seatNo == "3")
            {
                Seat3.text = newPlayer.playerName;
                ps3.text = newPlayer.seatNo;
                ss3.text = newPlayer.socketId;
                rn3.text = newPlayer.roomName;
                txtPacked3.text = newPlayer.playingStatus;
                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + newPlayer.playerPic);
                imgP3.GetComponent<Image>().sprite = tmpPicute;
            }
            if (newPlayer.seatNo == "4")
            {
                Seat4.text = newPlayer.playerName;
                ps4.text = newPlayer.seatNo;
                ss4.text = newPlayer.socketId;
                rn4.text = newPlayer.roomName;
                txtPacked4.text = newPlayer.playingStatus;
                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + newPlayer.playerPic);
                imgP4.GetComponent<Image>().sprite = tmpPicute;
            }
            if (newPlayer.seatNo == "5")
            {
                Seat5.text = newPlayer.playerName;
                ps5.text = newPlayer.seatNo;
                ss5.text = newPlayer.socketId;
                rn5.text = newPlayer.roomName;
                txtPacked5.text = newPlayer.playingStatus;
                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + newPlayer.playerPic);
                imgP5.GetComponent<Image>().sprite = tmpPicute;
            }
        }
        if (myInfo.seatNo == "2")
        {
            if (newPlayer.seatNo == "3")
            {
                Seat2.text = newPlayer.playerName;
                ps2.text = newPlayer.seatNo;
                ss2.text = newPlayer.socketId;
                rn2.text = newPlayer.roomName;
                txtPacked2.text = newPlayer.playingStatus;
                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + newPlayer.playerPic);
                imgP2.GetComponent<Image>().sprite = tmpPicute;
            }
            if (newPlayer.seatNo == "4")
            {
                Seat3.text = newPlayer.playerName;
                ps3.text = newPlayer.seatNo;
                ss3.text = newPlayer.socketId;
                rn3.text = newPlayer.roomName;
                txtPacked3.text = newPlayer.playingStatus;
                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + newPlayer.playerPic);
                imgP3.GetComponent<Image>().sprite = tmpPicute;
            }
            if (newPlayer.seatNo == "5")
            {
                Seat4.text = newPlayer.playerName;
                ps4.text = newPlayer.seatNo;
                ss4.text = newPlayer.socketId;
                rn4.text = newPlayer.roomName;
                txtPacked4.text = newPlayer.playingStatus;
                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + newPlayer.playerPic);
                imgP4.GetComponent<Image>().sprite = tmpPicute;
            }
            if (newPlayer.seatNo == "1")
            {
                Seat5.text = newPlayer.playerName;
                ps5.text = newPlayer.seatNo;
                ss5.text = newPlayer.socketId;
                rn5.text = newPlayer.roomName;
                txtPacked5.text = newPlayer.playingStatus;
                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + newPlayer.playerPic);
                imgP5.GetComponent<Image>().sprite = tmpPicute;
            }
        }
        if (myInfo.seatNo == "3")
        {
            if (newPlayer.seatNo == "4")
            {
                Seat2.text = newPlayer.playerName;
                ps2.text = newPlayer.seatNo;
                ss2.text = newPlayer.socketId;
                rn2.text = newPlayer.roomName;
                txtPacked2.text = newPlayer.playingStatus;
                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + newPlayer.playerPic);
                imgP2.GetComponent<Image>().sprite = tmpPicute;
            }
            if (newPlayer.seatNo == "5")
            {
                Seat3.text = newPlayer.playerName;
                ps3.text = newPlayer.seatNo;
                ss3.text = newPlayer.socketId;
                rn3.text = newPlayer.roomName;
                txtPacked3.text = newPlayer.playingStatus;
                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + newPlayer.playerPic);
                imgP3.GetComponent<Image>().sprite = tmpPicute;
            }
            if (newPlayer.seatNo == "1")
            {
                Seat4.text = newPlayer.playerName;
                ps4.text = newPlayer.seatNo;
                ss4.text = newPlayer.socketId;
                rn4.text = newPlayer.roomName;
                txtPacked4.text = newPlayer.playingStatus;
                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + newPlayer.playerPic);
                imgP4.GetComponent<Image>().sprite = tmpPicute;
            }
            if (newPlayer.seatNo == "2")
            {
                Seat5.text = newPlayer.playerName;
                ps5.text = newPlayer.seatNo;
                ss5.text = newPlayer.socketId;
                rn5.text = newPlayer.roomName;
                txtPacked5.text = newPlayer.playingStatus;
                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + newPlayer.playerPic);
                imgP5.GetComponent<Image>().sprite = tmpPicute;
            }
        }
        if (myInfo.seatNo == "4")
        {
            if (newPlayer.seatNo == "5")
            {
                Seat2.text = newPlayer.playerName;
                ps2.text = newPlayer.seatNo;
                ss2.text = newPlayer.socketId;
                rn2.text = newPlayer.roomName;
                txtPacked2.text = newPlayer.playingStatus;
                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + newPlayer.playerPic);
                imgP2.GetComponent<Image>().sprite = tmpPicute;
            }
            if (newPlayer.seatNo == "1")
            {
                Seat3.text = newPlayer.playerName;
                ps3.text = newPlayer.seatNo;
                ss3.text = newPlayer.socketId;
                rn3.text = newPlayer.roomName;
                txtPacked3.text = newPlayer.playingStatus;
                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + newPlayer.playerPic);
                imgP3.GetComponent<Image>().sprite = tmpPicute;
            }
            if (newPlayer.seatNo == "2")
            {
                Seat4.text = newPlayer.playerName;
                ps4.text = newPlayer.seatNo;
                ss4.text = newPlayer.socketId;
                rn4.text = newPlayer.roomName;
                txtPacked4.text = newPlayer.playingStatus;
                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + newPlayer.playerPic);
                imgP4.GetComponent<Image>().sprite = tmpPicute;
            }
            if (newPlayer.seatNo == "3")
            {
                Seat5.text = newPlayer.playerName;
                ps5.text = newPlayer.seatNo;
                ss5.text = newPlayer.socketId;
                rn5.text = newPlayer.roomName;
                txtPacked5.text = newPlayer.playingStatus;
                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + newPlayer.playerPic);
                imgP5.GetComponent<Image>().sprite = tmpPicute;
            }
        }
        if (myInfo.seatNo == "5")
        {
            if (newPlayer.seatNo == "1")
            {
                Seat2.text = newPlayer.playerName;
                ps2.text = newPlayer.seatNo;
                ss2.text = newPlayer.socketId;
                rn2.text = newPlayer.roomName;
                txtPacked2.text = newPlayer.playingStatus;
                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + newPlayer.playerPic);
                imgP2.GetComponent<Image>().sprite = tmpPicute;
            }
            if (newPlayer.seatNo == "2")
            {
                Seat3.text = newPlayer.playerName;
                ps3.text = newPlayer.seatNo;
                ss3.text = newPlayer.socketId;
                rn3.text = newPlayer.roomName;
                txtPacked3.text = newPlayer.playingStatus;
                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + newPlayer.playerPic);
                imgP3.GetComponent<Image>().sprite = tmpPicute;
            }
            if (newPlayer.seatNo == "3")
            {
                Seat4.text = newPlayer.playerName;
                ps4.text = newPlayer.seatNo;
                ss4.text = newPlayer.socketId;
                rn4.text = newPlayer.roomName;
                txtPacked4.text = newPlayer.playingStatus;
                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + newPlayer.playerPic);
                imgP4.GetComponent<Image>().sprite = tmpPicute;
            }
            if (newPlayer.seatNo == "4")
            {
                Seat5.text = newPlayer.playerName;
                ps5.text = newPlayer.seatNo;
                ss5.text = newPlayer.socketId;
                rn5.text = newPlayer.roomName;
                txtPacked5.text = newPlayer.playingStatus;
                Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + newPlayer.playerPic);
                imgP5.GetComponent<Image>().sprite = tmpPicute;
            }
        }
        // If I'm playing the game I should send my cards to new joining player
        if(txtPacked1.text=="Playing")
        {
            JSONObject data = new JSONObject();
            data.AddField("name", Seat1.text);      
            data.AddField("cards", tmpCards1);
            data.AddField("socketId", newPlayer.socketId);
            data.AddField("status", txtPacked1.text);
            socket.Emit("Playing", data);            
        }
        

    }
    public void TestOpen(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
        if(e.name=="open")
        {
            socketConnected = true;
        }
    }


    public void CheckRoom(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Room received: " + e.name + " " + e.data);

        if (e.data == null) { return; }
        else
        {
            
            //myObject = e.data.GetField("name").str;
            //Debug.Log(e.data.GetField("name").str);
            myInfo = JsonUtility.FromJson<playerInfo>(e.data.ToString());
            ps1.text = myInfo.seatNo;
            ss1.text = myInfo.socketId;
            rn1.text = myInfo.roomName;
            Debug.Log(myInfo.roomName);
            Debug.Log(myInfo.socketId);
        }
        /*
        Debug.Log(
            "#####################################################" +
            "THIS: " + e.data.GetField("this").str +
            "#####################################################"
        );
        */
    }

    public void TestError(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Error received: " + e.name + " " + e.data);
    }

    public void TestClose(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Close received: " + e.name + " " + e.data);
    }
    IEnumerator LeaveClassic()
    {

        
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        
        formData.Add(new MultipartFormDataSection("PlayerName", DBManager.username));

        formData.Add(new MultipartFormDataSection("RoomId", RoomId.text));

        UnityWebRequest www = UnityWebRequest.Post(LeaveRoomURL, formData);

        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
            DialogMsg.text = www.error;
            pnlOK.SetActive(true);
            
        }
        else
        {
            
           Debug.Log(www.downloadHandler.text);
            
        }
        SceneManager.LoadScene(3);

    }
    
    

    

    public long SavePlayerCardValue(int C1, int C2, int C3)
    {
        int nC1 = 0;
        int nC2 = 0;
        int nC3 = 0;
        // Get the card digits first
        if (C1 < 200)
        {
            nC1 = C1 - 100;
        }
        else if (C1 > 200 && C1 < 300)
        {
            nC1 = C1 - 200;
        }
        else if (C1 > 300 && C1 < 400)
        {
            nC1 = C1 - 300;
        }
        else
        {
            nC1 = C1 - 400;
        }

        if (C2 < 200)
        {
            nC2 = C2 - 100;
        }
        else if (C2 > 200 && C2 < 300)
        {
            nC2 = C2 - 200;
        }
        else if (C2 > 300 && C2 < 400)
        {
            nC2 = C2 - 300;
        }
        else
        {
            nC2 = C2 - 400;
        }

        if (C3 < 200)
        {
            nC3 = C3 - 100;
        }
        else if (C3 > 200 && C3 < 300)
        {
            nC3 = C3 - 200;
        }
        else if (C3 > 300 && C3 < 400)
        {
            nC3 = C3 - 300;
        }
        else
        {
            nC3 = C3 - 400;
        }

        //Check if Flash or Run
        if ((C1 < 200 && C2 < 200 && C3 < 200) ||
            ((C1 < 300 && C1 > 200) && (C2 < 300 && C2 > 200) && (C3 < 300 && C3 > 200)) ||
            ((C1 < 400 && C1 > 300) && (C2 < 400 && C2 > 300) && (C3 < 400 && C3 > 300)) ||
            (C1 > 400 && C2 > 400 && C3 > 400))
        {
            var list = new List<int>(new[] { C1, C2, C3 });
            int minValue = list.Min();
            int maxValue = list.Count;
            List<int> test = Enumerable.Range(minValue, maxValue).ToList();
            var result = Enumerable.Range(minValue, maxValue).Except(list);
            if (result.ToList().Count == 0)
            {
                //Run Card
                int[] arr = new int[] { nC1, nC2, nC3 };
                // Sort array in ascending order. 
                Array.Sort(arr);
                // reverse array 
                Array.Reverse(arr);
                return (5000000 + arr[0] * 10000 + arr[1] * 100 + arr[2]);
            }
            else
            {
                //Flash Flash
                int[] arr = new int[] { nC1, nC2, nC3 };
                // Sort array in ascending order. 
                Array.Sort(arr);
                // reverse array 
                Array.Reverse(arr);
                return (3000000 + arr[0] * 10000 + arr[1] * 100 + arr[2]);
            }
        }
        else
        {
            var list = new List<int>(new[] { nC1, nC2, nC3 });
            int minValue = list.Min();
            int maxValue = list.Count;
            List<int> test = Enumerable.Range(minValue, maxValue).ToList();
            var result = Enumerable.Range(minValue, maxValue).Except(list);
            if (result.ToList().Count == 0)
            {
                //Serial Card
                int[] arr = new int[] { nC1, nC2, nC3 };
                // Sort array in ascending order. 
                Array.Sort(arr);
                // reverse array 
                Array.Reverse(arr);
                return (4000000 + arr[0] * 10000 + arr[1] * 100 + arr[2]);
            }

        }
        if (nC1 == nC2 && nC1 == nC3 && nC2 == nC3)
        {
            //Tripple Card
            int[] arr = new int[] { nC1, nC2, nC3 };
            return (6000000 + arr[0] * 10000 + arr[1] * 100 + arr[2]);
        }
        else if (nC1 == nC2 || nC1 == nC3 || nC2 == nC3)
        {
            //Pair
            int[] arr = new int[] { nC1, nC2, nC3 };
            // Sort array in ascending order. 
            //Array.Sort(arr);
            // reverse array 
            //Array.Reverse(arr);
            if(arr[0]==arr[1])
            {
                // we got the pair in 1,2
                return (2000000 + arr[0] * 10000 + arr[1] * 100 + arr[2]);
            }
            else if(arr[1]==arr[2])
            {
                // we got the pair in 2,3
                return (2000000 + arr[1] * 10000 + arr[2] * 100 + arr[0]);
            }
            else
            {
                // we got the pair in 3,1
                return (2000000 + arr[2] * 10000 + arr[0] * 100 + arr[1]);
            }
            //return (2000000 + arr[0] * 10000 + arr[1] * 100 + arr[2]);
        }
        else
        {
            //High Card
            int[] arr = new int[] { nC1, nC2, nC3 };
            // Sort array in ascending order. 
            Array.Sort(arr);
            // reverse array 
            Array.Reverse(arr);
            return (1000000 + arr[0] * 10000 + arr[1] * 100 + arr[2]);

        }
        
    }

    public void OnSeeCards()
    {
        if (txtSee.text == "SEEN")
            return;

        txtSee.text = "SEEN";        
        txtBlind.text = "CHAAL";
        txtAmount.text = (int.Parse(txtAmount.text) * 2).ToString();
        //Mine.OC = "Seen";
        JSONObject data = new JSONObject();
        data.AddField("name", Seat1.text);
        data.AddField("room", myInfo.roomName);
        socket.Emit("Seen", data);    
        sP1C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList1[0]);
        P1C1.GetComponent<Image>().sprite = sP1C1;
        sP1C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList1[1]);
        P1C2.GetComponent<Image>().sprite = sP1C2;
        sP1C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList1[2]);
        P1C3.GetComponent<Image>().sprite = sP1C3;
        txtAnnounce.text = Seat1.text + " has seen their card!";
        
    }
    public void OnShow()
    {
        if(txtShow.text=="SHOW")
        {
            JSONObject data = new JSONObject();
            data.AddField("room", myInfo.roomName);
            data.AddField("name", Seat1.text);
            GameSoundFx.PlayOneShot(ShowSound);
            // Throw Coin
            txtThrowCoin.text = txtAmount.text;

            P1PotCoin.SetActive(false);
            P1PotCoin.SetActive(true);
            P1Coin.Play("PotCoinP1");
            // Add coin to the pot coin amount
            txtPotCoin.text = (int.Parse(txtPotCoin.text) + int.Parse(txtAmount.text)).ToString();
            data.AddField("board", txtPotCoin.text);
            // Adjust My Total Coin
            txtMyCoin.text = (int.Parse(txtMyCoin.text) - int.Parse(txtAmount.text)).ToString();
            txtAnnounce.text = "SHOW";
            // Stop the clock
            pClock1.Play("Start");
            Clock1.SetActive(false);

            // Hide panel
            playPanel.SetBool("Show", false);
            
            //Show Cards if Hidden
            if (txtSee.text=="SEE")
            {
                txtSee.text = "SEEN";
                sP1C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList1[0]);
                P1C1.GetComponent<Image>().sprite = sP1C1;
                sP1C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList1[1]);
                P1C2.GetComponent<Image>().sprite = sP1C2;
                sP1C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList1[2]);
                P1C3.GetComponent<Image>().sprite = sP1C3;
            }
            // Hide seen button
            //txtSee.text = "SEE";
            btnSee.SetActive(false);

            string winner = "";
            string CardDegree;
            long WinnerCard = 0;
            if(txtPacked2.text=="Playing")
            {
                sP2C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[0]);
                iP2C1.GetComponent<Image>().sprite = sP2C1;
                sP2C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[1]);
                iP2C2.GetComponent<Image>().sprite = sP2C2;
                sP2C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[2]);
                iP2C3.GetComponent<Image>().sprite = sP2C3;
                ShowCardsP2.SetActive(true);
                data.AddField("target", Seat2.text);
                winner = MyGame.FirstPlayerCardWeight > MyGame.SecondPlayerCardWeight ? Seat1.text : Seat2.text;
                WinnerCard = Math.Max(MyGame.FirstPlayerCardWeight, MyGame.SecondPlayerCardWeight);
                
                //if()
            }
            else if(txtPacked3.text == "Playing")
            {
                sP3C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[0]);
                iP3C1.GetComponent<Image>().sprite = sP3C1;
                sP3C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[1]);
                iP3C2.GetComponent<Image>().sprite = sP3C2;
                sP3C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[2]);
                iP3C3.GetComponent<Image>().sprite = sP3C3;
                ShowCardsP3.SetActive(true);
                data.AddField("target", Seat3.text);
                winner = MyGame.FirstPlayerCardWeight > MyGame.ThirdPlayerCardWeight ? Seat1.text : Seat3.text;
                WinnerCard = Math.Max(MyGame.FirstPlayerCardWeight, MyGame.ThirdPlayerCardWeight);
            }
            else if (txtPacked4.text == "Playing")
            {
                sP4C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[0]);
                iP4C1.GetComponent<Image>().sprite = sP4C1;
                sP4C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[1]);
                iP4C2.GetComponent<Image>().sprite = sP4C2;
                sP4C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[2]);
                iP4C3.GetComponent<Image>().sprite = sP4C3;
                ShowCardsP4.SetActive(true);
                data.AddField("target", Seat4.text);
                winner = MyGame.FirstPlayerCardWeight > MyGame.FourthPlayerCardWeight ? Seat1.text : Seat4.text;
                WinnerCard = Math.Max(MyGame.FirstPlayerCardWeight, MyGame.FourthPlayerCardWeight);
            }
            else if (txtPacked5.text == "Playing")
            {
                sP5C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[0]);
                iP5C1.GetComponent<Image>().sprite = sP5C1;
                sP5C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[1]);
                iP5C2.GetComponent<Image>().sprite = sP5C2;
                sP5C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[2]);
                iP5C3.GetComponent<Image>().sprite = sP5C3;
                ShowCardsP5.SetActive(true);
                data.AddField("target", Seat5.text);
                winner = MyGame.FirstPlayerCardWeight > MyGame.FifthPlayerCardWeight ? Seat1.text : Seat5.text;
                WinnerCard = Math.Max(MyGame.FirstPlayerCardWeight, MyGame.FifthPlayerCardWeight);
            }

            // Signal other players and send target player's name
            
            CardDegree = (WinnerCard > 1000000 && WinnerCard < 2000000) ? "High Cards"
                                                : (WinnerCard > 2000000 && WinnerCard < 3000000) ? "Pair of Cards"
                                                : (WinnerCard > 3000000 && WinnerCard < 4000000) ? "One Color"
                                                : (WinnerCard > 4000000 && WinnerCard < 5000000) ? "Sequence"
                                                : (WinnerCard > 5000000 && WinnerCard < 6000000) ? "Colored Sequence"
                                                : (WinnerCard > 6000000 && WinnerCard < 7000000) ? "Tripple of a Card"
                                                : "Error";
            data.AddField("winner", winner);
            data.AddField("rank", CardDegree);
            socket.Emit("Show", data);
            StartCoroutine(DelayedDeclareWinner(2.0f, winner, CardDegree));            
            return;
        }
        if(txtShow.text== "SIDE SHOW")
        {
            
            OnBlind();
            txtAnnounce.text = "SIDE SHOW";
            JSONObject data = new JSONObject();
            data.AddField("name", Seat1.text);
            data.AddField("target", sideshow);
            data.AddField("cards", tmpCards1);
            data.AddField("room", myInfo.roomName);
            socket.Emit("SideShow", data);
            
            if (sideshow == Seat5.text)
                txtChaal5.text = "Side Showing";
            if (sideshow == Seat4.text)
                txtChaal4.text = "Side Showing";
            if (sideshow == Seat3.text)
                txtChaal3.text = "Side Showing";
            if (sideshow == Seat2.text)
                txtChaal2.text = "Side Showing";          
            
        }
    }

    IEnumerator DelayedDeclareWinner(float seconds,string winner, string ranks)
    {
        yield return new WaitForSeconds(seconds);
        txtAnnounce.text = winner + " has won the match with " + ranks;
        if (winner==Seat1.text)
        {

            // Show Winner Animation            
            // Show Board coin animation to player
            txtThrowCoin.text = txtPotCoin.text;
            P1Coin.Play("PotCoinP1R");
            // I'm the winner. I get all the board coins
            txtMyCoin.text = (int.Parse(txtMyCoin.text) + int.Parse(txtPotCoin.text)).ToString();
            // Show Board coin animation to player
            txtPotCoin.text = "0";
            pWin1.Play("Play");
        }
        else if (winner == Seat2.text)
        {

            txtThrowCoin2.text = txtPotCoin.text;
            P2Coin.Play("PotCoinP2R");
            //GameSoundFx.Stop();
            GameSoundFx.PlayOneShot(WinningSound);
            pWin2.Play("Play");
            // Show Board coin animation to player
            txtPotCoin.text = "0";            
        }
        else if (winner == Seat3.text)
        {

            txtThrowCoin3.text = txtPotCoin.text;
            P3Coin.Play("PotCoinP3R");
            //GameSoundFx.Stop();
            GameSoundFx.PlayOneShot(WinningSound);
            pWin3.Play("Play");
            // Show Board coin animation to player
            txtPotCoin.text = "0";
        }
        else if (winner == Seat4.text)
        {

            txtThrowCoin4.text = txtPotCoin.text;
            P4Coin.Play("PotCoinP4R");
            //GameSoundFx.Stop();
            GameSoundFx.PlayOneShot(WinningSound);
            pWin4.Play("Play");
            // Show Board coin animation to player
            txtPotCoin.text = "0";
        }
        else if (winner == Seat5.text)
        {

            txtThrowCoin5.text = txtPotCoin.text;
            P5Coin.Play("PotCoinP5R");
            //GameSoundFx.Stop();
            GameSoundFx.PlayOneShot(WinningSound);
            pWin5.Play("Play");
            // Show Board coin animation to player
            txtPotCoin.text = "0";
        }

    }
    public void SideShowYes()
    {
        pnlSide.SetActive(false);
        string[] tmpC = ssCards.Split(',');
        long tmpValue = SavePlayerCardValue(int.Parse(tmpC[0]), int.Parse(tmpC[1]), int.Parse(tmpC[2]));
        bool winnerMe = MyGame.FirstPlayerCardWeight > tmpValue;
        if (!winnerMe)
        {
            //Show the cards
            if(Seat5.text== ssPlayer)
            {
                sP5C1 = Resources.Load<Sprite>("Sprites/Cards/" + tmpC[0]);
                iP5C1.GetComponent<Image>().sprite = sP5C1;
                sP5C2 = Resources.Load<Sprite>("Sprites/Cards/" + tmpC[1]);
                iP5C2.GetComponent<Image>().sprite = sP5C2;
                sP5C3 = Resources.Load<Sprite>("Sprites/Cards/" + tmpC[2]);
                iP5C3.GetComponent<Image>().sprite = sP5C3;
                ShowCardsP5.SetActive(true);
            }
            else if (Seat4.text == ssPlayer)
            {
                sP4C1 = Resources.Load<Sprite>("Sprites/Cards/" + tmpC[0]);
                iP4C1.GetComponent<Image>().sprite = sP4C1;
                sP4C2 = Resources.Load<Sprite>("Sprites/Cards/" + tmpC[1]);
                iP4C2.GetComponent<Image>().sprite = sP4C2;
                sP4C3 = Resources.Load<Sprite>("Sprites/Cards/" + tmpC[2]);
                iP4C3.GetComponent<Image>().sprite = sP4C3;
                ShowCardsP4.SetActive(true);
            }
            else if (Seat3.text == ssPlayer)
            {
                sP3C1 = Resources.Load<Sprite>("Sprites/Cards/" + tmpC[0]);
                iP3C1.GetComponent<Image>().sprite = sP3C1;
                sP3C2 = Resources.Load<Sprite>("Sprites/Cards/" + tmpC[1]);
                iP3C2.GetComponent<Image>().sprite = sP3C2;
                sP3C3 = Resources.Load<Sprite>("Sprites/Cards/" + tmpC[2]);
                iP3C3.GetComponent<Image>().sprite = sP3C3;
                ShowCardsP3.SetActive(true);
            }
            else if (Seat2.text == ssPlayer)
            {
                sP2C1 = Resources.Load<Sprite>("Sprites/Cards/" + tmpC[0]);
                iP2C1.GetComponent<Image>().sprite = sP2C1;
                sP2C2 = Resources.Load<Sprite>("Sprites/Cards/" + tmpC[1]);
                iP2C2.GetComponent<Image>().sprite = sP2C2;
                sP2C3 = Resources.Load<Sprite>("Sprites/Cards/" + tmpC[2]);
                iP2C3.GetComponent<Image>().sprite = sP2C3;
                ShowCardsP2.SetActive(true);
            }
            OnPack();
        }
        else
        {
            JSONObject data = new JSONObject();
            data.AddField("target", ssPlayer);
            data.AddField("room", myInfo.roomName);
            data.AddField("cards", tmpCards1);
            data.AddField("sender", Seat1.text);
            socket.Emit("YouPack", data);            
        }      
    }
    public void SideShowNo()  
    {
        GameSoundFx.PlayOneShot(ShowSound);
        pnlSide.SetActive(false);
        JSONObject data = new JSONObject();
        data.AddField("room", myInfo.roomName);
        data.AddField("name", Seat1.text);
        socket.Emit("Reject", data);      
    }
    public void OnBlind()
    {
        GameSoundFx.Stop();
        GameSoundFx.PlayOneShot(BlindSound);
        // Throw Coin
        txtThrowCoin.text = txtAmount.text;
        
        P1PotCoin.SetActive(false);
        P1PotCoin.SetActive(true);        
        P1Coin.Play("PotCoinP1");
        // Add coin to the pot coin amount
        txtPotCoin.text = (int.Parse(txtPotCoin.text) + int.Parse(txtAmount.text)).ToString();
        // Adjust My Total Coin
        txtMyCoin.text = (int.Parse(txtMyCoin.text) - int.Parse(txtAmount.text)).ToString();
        string emit = txtBlind.text == "BLIND" ? "Blind" : "Chaal";
        if (int.Parse(txtPotCoin.text)>=2000)
        {
            //hide the seen button
            btnSee.SetActive(false);
            // Pot money has reached the limit
            txtAnnounce.text = "Pot money has reached the limit. So here is the winner . . .";
            // save next player clock first
            //--Mine.NP = (txtPacked2.text == "Playing") ? Seat2.text : ((txtPacked3.text == "Playing") ? Seat3.text : (txtPacked4.text == "Playing") ? Seat4.text : Seat5.text);
            //--Mine.NP = (txtPacked2.text == "Playing") ? Seat2.text : ((txtPacked3.text == "Playing") ? Seat3.text : (txtPacked4.text == "Playing") ? Seat4.text : Seat5.text);
            // upload the chaal ammount and board money also
            JSONObject data = new JSONObject();
            data.AddField("room", myInfo.roomName);                      
            data.AddField("board", txtPotCoin.text);
            socket.Emit("Break", data);
            //--Mine.BM = txtPotCoin.text;
            //--Mine.OP = txtAmount.text;
            // Show the cards if already not seen
            if (txtPacked1.text == "Playing")
            {
                // hide the panel
                playPanel.SetBool("Show", false);
                // Stop the clock
                pClock1.Play("Start");
                Clock1.SetActive(false);
                txtPacked1.text = "Watching";

                if (txtSee.text == "SEE")
                {
                    txtSee.text = "SEEN";
                    sP1C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList1[0]);
                    P1C1.GetComponent<Image>().sprite = sP1C1;
                    sP1C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList1[1]);
                    P1C2.GetComponent<Image>().sprite = sP1C2;
                    sP1C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList1[2]);
                    P1C3.GetComponent<Image>().sprite = sP1C3;

                }

            }

            if (txtPacked2.text == "Playing")
            {
                // Stop the clock
                pClock2.Play("Start");
                Clock2.SetActive(false);
                txtPacked2.text = "Watching";
                //Show the cards
                //string[] tmpstr = OtherPlayer.OP.Split('+');
                //cList2 = tmpstr[0].Split(',');
                
                sP2C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[0]);
                iP2C1.GetComponent<Image>().sprite = sP2C1;
                sP2C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[1]);
                iP2C2.GetComponent<Image>().sprite = sP2C2;
                sP2C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList2[2]);
                iP2C3.GetComponent<Image>().sprite = sP2C3;
                ShowCardsP2.SetActive(true);
                
                // save the player weight
                //MyGame.SecondPlayerCardWeight = int.Parse(tmpstr[1]);
            }
            if (txtPacked3.text == "Playing")
            {
                // Stop the clock
                pClock3.Play("Start");
                Clock3.SetActive(false);
                txtPacked3.text = "Watching";
                //Show the cards
                //string[] tmpstr = OtherPlayer.OP.Split('+');
                //cList2 = tmpstr[0].Split(',');
                
                sP3C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[0]);
                iP3C1.GetComponent<Image>().sprite = sP3C1;
                sP3C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[1]);
                iP3C2.GetComponent<Image>().sprite = sP3C2;
                sP3C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList3[2]);
                iP3C3.GetComponent<Image>().sprite = sP3C3;
                ShowCardsP3.SetActive(true);
                
                // save the player weight
                //MyGame.SecondPlayerCardWeight = int.Parse(tmpstr[1]);
            }
            if (txtPacked4.text == "Playing")
            {
                // Stop the clock
                pClock4.Play("Start");
                Clock4.SetActive(false);
                txtPacked4.text = "Watching";
                //Show the cards
                //string[] tmpstr = OtherPlayer.OP.Split('+');
                //cList2 = tmpstr[0].Split(',');
                
                sP4C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[0]);
                iP4C1.GetComponent<Image>().sprite = sP4C1;
                sP4C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[1]);
                iP4C2.GetComponent<Image>().sprite = sP4C2;
                sP4C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList4[2]);
                iP4C3.GetComponent<Image>().sprite = sP4C3;
                ShowCardsP4.SetActive(true);
               
                // save the player weight
                //MyGame.SecondPlayerCardWeight = int.Parse(tmpstr[1]);
            }
            if (txtPacked5.text == "Playing")
            {
                // Stop the clock
                pClock5.Play("Start");
                Clock5.SetActive(false);
                txtPacked5.text = "Watching";
                //Show the cards
                //string[] tmpstr = OtherPlayer.OP.Split('+');
                //cList2 = tmpstr[0].Split(',');
                
                sP5C1 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[0]);
                iP5C1.GetComponent<Image>().sprite = sP5C1;
                sP5C2 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[1]);
                iP5C2.GetComponent<Image>().sprite = sP5C2;
                sP5C3 = Resources.Load<Sprite>("Sprites/Cards/" + cList5[2]);
                iP5C3.GetComponent<Image>().sprite = sP5C3;
                ShowCardsP5.SetActive(true);
                
                // save the player weight
                //MyGame.SecondPlayerCardWeight = int.Parse(tmpstr[1]);
            }
            
            long maxCard = Math.Max(Math.Max(Math.Max(Math.Max(MyGame.FirstPlayerCardWeight, MyGame.SecondPlayerCardWeight), MyGame.ThirdPlayerCardWeight), MyGame.FourthPlayerCardWeight), MyGame.FifthPlayerCardWeight);
            string CardDegree = (maxCard > 1000000 && maxCard < 2000000) ? "High Cards"
                                        : (maxCard > 2000000 && maxCard < 3000000) ? "Pair of Cards"
                                        : (maxCard > 3000000 && maxCard < 4000000) ? "One Color"
                                        : (maxCard > 4000000 && maxCard < 5000000) ? "Sequence"
                                        : (maxCard > 5000000 && maxCard < 6000000) ? "Colored Sequence"
                                        : (maxCard > 6000000 && maxCard < 7000000) ? "Tripple of a Card"
                                        : "Error";
            if (maxCard == MyGame.FirstPlayerCardWeight)
            {
                // me winner
                txtAnnounce.text = DBManager.username + " has won the match with a " + CardDegree;
                
                // Show Board coin animation to player
                txtThrowCoin.text = txtPotCoin.text;
                P1Coin.Play("PotCoinP1R");                
                // I get all the board coins
                txtMyCoin.text = (int.Parse(txtMyCoin.text) + int.Parse(txtPotCoin.text)).ToString();
                // Show Board coin animation to player
                txtPotCoin.text = "0";
                // Play winning animation
                pWin1.Play("Play");
                // I'm going to be the next dealer
                //--Mine.DN = DBManager.username;
                // Switch player status to watching
                txtPacked1.text = "Watching";
                // json = JsonUtility.ToJson(Mine);
                // Send json string to socket
                // ws.Send(Encoding.UTF8.GetBytes(json));
                // set to recieve new message again

                // Wait few seconds then send signals for next game
                //--wait = true;
                //--update = 0.0f;

            }
            if (maxCard == MyGame.SecondPlayerCardWeight)
            {
                // second player winner
                txtAnnounce.text = Seat2.text + " has won the match with a " + CardDegree;
                // Show Board coin animation to player
                txtThrowCoin2.text = txtPotCoin.text;
                P2Coin.Play("PotCoinP2R");
                // Show Board coin animation to player
                txtPotCoin.text = "0";
                // Play winning animation
                pWin2.Play("Play");
                
                //--Mine.DN = Seat2.text;
                // Switch player status to watching
                txtPacked2.text = "Watching";
                // json = JsonUtility.ToJson(Mine);
                // Send json string to socket
                // ws.Send(Encoding.UTF8.GetBytes(json));
                // set to recieve new message again

            }
            if (maxCard == MyGame.ThirdPlayerCardWeight)
            {
                // second player winner
                txtAnnounce.text = Seat3.text + " has won the match with a " + CardDegree;
                // Show Board coin animation to player
                txtThrowCoin3.text = txtPotCoin.text;
                P3Coin.Play("PotCoinP3R");
                // Show Board coin animation to player
                txtPotCoin.text = "0";
                // Play winning animation
                pWin3.Play("Play");
                
                //--Mine.DN = Seat3.text;
                // Switch player status to watching
                txtPacked3.text = "Watching";
                // json = JsonUtility.ToJson(Mine);
                // Send json string to socket
                // ws.Send(Encoding.UTF8.GetBytes(json));
                // set to recieve new message again
            }

            if (maxCard == MyGame.FourthPlayerCardWeight)
            {
                // second player winner
                txtAnnounce.text = Seat4.text + " has won the match with a " + CardDegree;
                // Show Board coin animation to player
                txtThrowCoin4.text = txtPotCoin.text;
                P4Coin.Play("PotCoinP4R");
                // Show Board coin animation to player
                txtPotCoin.text = "0";
                // Play winning animation
                pWin4.Play("Play");
                // I'm going to be the next dealer
                //--Mine.DN = Seat4.text;
                // Switch player status to watching
                txtPacked4.text = "Watching";
                // json = JsonUtility.ToJson(Mine);
                // Send json string to socket
                // ws.Send(Encoding.UTF8.GetBytes(json));
                // set to recieve new message again

            }
            if (maxCard == MyGame.FifthPlayerCardWeight)
            {
                // second player winner
                txtAnnounce.text = Seat5.text + " has won the match with a " + CardDegree;
                // Show Board coin animation to player
                txtThrowCoin5.text = txtPotCoin.text;
                P5Coin.Play("PotCoinP5R");
                // Show Board coin animation to player
                txtPotCoin.text = "0";
                // Play winning animation
                pWin5.Play("Play");
                // I'm going to be the next dealer
                //--Mine.DN = Seat5.text;
                // Switch player status to watching
                txtPacked5.text = "Watching";
                // json = JsonUtility.ToJson(Mine);
                // Send json string to socket
                // ws.Send(Encoding.UTF8.GetBytes(json));
                // set to recieve new message again
            }

            return;
        }
        txtAnnounce.text = DBManager.username + " has played a "+txtBlind.text;
        // Stop the clock
        
        pClock1.Play("Start");
        Clock1.SetActive(false);
        // Hide panel
        playPanel.SetBool("Show", false);

        // upload the data
        
        //--Mine.OC = txtBlind.text=="BLIND"?OpCodes.Blind:OpCodes.Chaal;
        //emit= txtBlind.text == "BLIND" ? "Blind" : "Chaal";
        JSONObject emitData = new JSONObject();
        emitData.AddField("name", Seat1.text);
        emitData.AddField("room", myInfo.roomName);
        emitData.AddField("amount", txtAmount.text);
        emitData.AddField("board", txtPotCoin.text);
        
        if (txtPacked2.text == "Playing")
        {
            Clock2.SetActive(true);
            pClock2.Play("Clock2");
            //--Mine.NP = Seat2.text;
            emitData.AddField("next", Seat2.text);
        }
        else if (txtPacked3.text == "Playing")
        {
            Clock3.SetActive(true);
            pClock3.Play("Clock3");
            //--Mine.NP = Seat3.text;
            emitData.AddField("next", Seat3.text);
        }
        else if (txtPacked4.text == "Playing")
        {
            Clock4.SetActive(true);
            pClock4.Play("Clock4");
            //--Mine.NP = Seat4.text;
            emitData.AddField("next", Seat4.text);
        }
        else if (txtPacked5.text == "Playing")
        {
            Clock5.SetActive(true);
            pClock5.Play("Clock5");
            //--Mine.NP = Seat5.text;
            emitData.AddField("next", Seat5.text);
        }
        
        socket.Emit(emit, emitData);
        BlindLimit++;
        if (BlindLimit == 4)
            StartCoroutine(MakeCardsSeenAfterPause(1.0f));
        //--newMessage = false;
    }
    public void OnTips()
    {
        GameSoundFx.PlayOneShot(BlindSound);
        //txtPotCoin.text = (int.Parse(txtPotCoin.text) + 2).ToString();
        txtMyCoin.text = (int.Parse(txtMyCoin.text) - 2).ToString();
        txtAnnounce.text = DBManager.username + " has paid a tip money!";        
        txtThrowCoin.text = "2";            
        //P2Coin.Play("ThrowCoin");
        P1PotCoin.SetActive(false);
        P1PotCoin.SetActive(true);
        P1Coin.Play("PotCoinP1");
        JSONObject data = new JSONObject();
        data.AddField("room", myInfo.roomName);
        data.AddField("name", Seat1.text);
        socket.Emit("Tips", data);
        //--Mine.OC = OpCodes.Tips;
        //--json = JsonUtility.ToJson(Mine);
        // Send json string to socket
        //--ws.Send(Encoding.UTF8.GetBytes(json));

        // set to recieve new message again
        //--newMessage = false;
        
    }

    private Button btnMessage;
    

    public void onMessage(Button button)
    {
        pnlMessage.SetActive(true);
        btnMessage = button;
        button.enabled = false;
    }
    public void onClose()
    {
        pnlMessage.SetActive(false);
        btnMessage.enabled = true;
    }
    
    public void onBtnMessage(Button button)
    {
        JSONObject data = new JSONObject();
        data.AddField("room", myInfo.roomName);
        data.AddField("name", Seat1.text);
        switch (button.name)
        {
            case "btnMsg01":
                //--Mine.OP = "Hi";
                data.AddField("text", "Hi");
                StartCoroutine(ShowMessage(pnlText1,pText1,"Hi", 3.0f));
                pnlMessage.SetActive(false);
                btnMessage.enabled = true;
                break;
            case "btnMsg02":
                //--Mine.OP = "Hello";
                data.AddField("text", "Hello");
                StartCoroutine(ShowMessage(pnlText1,pText1,"Hello", 3.0f));
                pnlMessage.SetActive(false);
                btnMessage.enabled = true;
                break;
            case "btnMsg03":
                //--Mine.OP = "Play Fast";
                data.AddField("text", "Play Fast");
                StartCoroutine(ShowMessage(pnlText1,pText1,"Play Fast", 3.0f));
                pnlMessage.SetActive(false);
                btnMessage.enabled = true;
                break;
            case "btnMsg04":
                //--Mine.OP = "I Won";
                data.AddField("text", "I Won");
                StartCoroutine(ShowMessage(pnlText1, pText1, "I Won", 3.0f));
                pnlMessage.SetActive(false);
                btnMessage.enabled = true;
                break;
            case "btnMsg05":
                //--Mine.OP = "Play Blind";
                data.AddField("text", "Play Blind");
                StartCoroutine(ShowMessage(pnlText1, pText1, "Play Blind", 3.0f));
                pnlMessage.SetActive(false);
                btnMessage.enabled = true;
                break;
            case "btnMsg06":
                //--Mine.OP = "Bad Luck";
                data.AddField("text", "Bad Luck");
                StartCoroutine(ShowMessage(pnlText1, pText1, "Bad Luck", 3.0f));
                pnlMessage.SetActive(false);
                btnMessage.enabled = true;
                break;
            case "btnMsg07":
                //--Mine.OP = "Good Luck";
                data.AddField("text", "Good Luck");
                StartCoroutine(ShowMessage(pnlText1, pText1, "Good Luck", 3.0f));
                pnlMessage.SetActive(false);
                btnMessage.enabled = true;
                break;
            case "btnMsg08":
                //--Mine.OP = "Challenge You";
                data.AddField("text", "Challenge You");
                StartCoroutine(ShowMessage(pnlText1, pText1, "Challenge You", 3.0f));
                pnlMessage.SetActive(false);
                btnMessage.enabled = true;
                break;
            case "btnMsg09":
                //--Mine.OP = "Well Played";
                data.AddField("text", "Well Played");
                StartCoroutine(ShowMessage(pnlText1, pText1, "Well Played", 3.0f));
                pnlMessage.SetActive(false);
                btnMessage.enabled = true;
                break;
            case "btnMsg10":
                //--Mine.OP = "Brilliant";
                data.AddField("text", "Brilliant");
                StartCoroutine(ShowMessage(pnlText1, pText1, "Brilliant", 3.0f));
                pnlMessage.SetActive(false);
                btnMessage.enabled = true;
                break;
            case "btnMsg11":
                //--Mine.OP = "Fooled You";
                data.AddField("text", "Fooled You");
                StartCoroutine(ShowMessage(pnlText1, pText1, "Fooled You", 3.0f));
                pnlMessage.SetActive(false);
                btnMessage.enabled = true;
                break;
            case "btnMsg12":
                //--Mine.OP = "Wow";
                data.AddField("text", "Wow");
                StartCoroutine(ShowMessage(pnlText1, pText1, "Wow", 3.0f));
                pnlMessage.SetActive(false);
                btnMessage.enabled = true;
                break;
            case "btnMsg13":
                //--Mine.OP = "Hahaha";
                data.AddField("text", "Hahaha");
                StartCoroutine(ShowMessage(pnlText1, pText1, "Hahaha", 3.0f));
                pnlMessage.SetActive(false);
                btnMessage.enabled = true;
                break;
            case "btnMsg14":
                //--Mine.OP = "Ohh No";
                data.AddField("text", "Ohh No");
                StartCoroutine(ShowMessage(pnlText1, pText1, "Ohh No", 3.0f));
                pnlMessage.SetActive(false);
                btnMessage.enabled = true;
                break;
            case "btnMsg15":
                //--Mine.OP = "So Lazy";
                data.AddField("text", "So Lazy");
                StartCoroutine(ShowMessage(pnlText1, pText1, "So Lazy", 3.0f));
                pnlMessage.SetActive(false);
                btnMessage.enabled = true;
                break;
            case "btnMsg16":
                //--Mine.OP = "Thank You";
                data.AddField("text", "Thank You");
                StartCoroutine(ShowMessage(pnlText1, pText1, "Thank You", 3.0f));
                pnlMessage.SetActive(false);
                btnMessage.enabled = true;
                break;
            default:
                break;
        }
        
        socket.Emit("Chat", data);
        //--Mine.OC = OpCodes.Message;
        
        //--json = JsonUtility.ToJson(Mine);
        // Send json string to socket
        //--ws.Send(Encoding.UTF8.GetBytes(json));
        // set to recieve; new message again        
        //--newMessage = false;
    }
    IEnumerator ShowMessage(GameObject pnlText,Text pText, string text, float seconds)
    {
        pText.text = text;
        pnlText.SetActive(true);        
        yield return new WaitForSeconds(seconds);
        pnlText.SetActive(false);
    }
    IEnumerator MakeCardsSeenAfterPause(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        OnSeeCards();
    }
    public void OnBack()
    {
        JSONObject data = new JSONObject();
        if (txtPacked2.text == "Playing")
        {            
            data.AddField("nextPlayer", Seat2.text);
        }
        else if (txtPacked3.text == "Playing")
        {
           
            data.AddField("nextPlayer", Seat3.text);
        }
        else if (txtPacked4.text == "Playing")
        {
           
            data.AddField("nextPlayer", Seat4.text);
        }
        else if (txtPacked5.text == "Playing")
        {
           
            data.AddField("nextPlayer", Seat5.text);
        }
        data.AddField("room", myInfo.roomName);
        socket.Emit("Next", data);
        socket.Close();        
        IQuit();        
        SceneManager.LoadScene(3);
           
    }
    public void IQuit()
    {
        GameSoundFx.PlayOneShot(NewPlayerSound);
        // Stop the clock
        
        pClock1.Play("Start");
        Clock1.SetActive(false);
        playPanel.SetBool("Show", false);
        // Hide panel after 2 second
        //StartCoroutine(HidePanelAfterPause(2.0f));
        Seat1.text = "EMPTY";
        Sprite tmpPicute = Resources.Load<Sprite>("Images/" + "EmptySeat");
        imgP1.GetComponent<Image>().sprite = tmpPicute;
        txtPacked1.text = "Quit";
        //txtPacked1.enabled = true;
        // Hide seen button
        btnSee.SetActive(false);
        //Mine.OC = "QUIT";
        
    }
    public void SendQuit()
    {
        Mine.OC = OpCodes.SendQuit;
        Mine.OP = DBManager.QuiterName;
        json = JsonUtility.ToJson(Mine);
        // Send json string to socket
        //--ws.Send(Encoding.UTF8.GetBytes(json));
        // set to recieve new message again
        newMessage = false;
    }
    public void OnPack()
    {

        GameSoundFx.PlayOneShot(PackSound);
        // Stop the clock
       
        pClock1.Play("Start");
        Clock1.SetActive(false);
        playPanel.SetBool("Show", false);
        // Hide panel after 2 second
        //StartCoroutine(HidePanelAfterPause(2.0f));
        txtPacked1.text = "Packed";        
        // Hide seen button
        btnSee.SetActive(false);
        //Mine.OC = "Packed";
        JSONObject data = new JSONObject();
        data.AddField("name", Seat1.text);
        data.AddField("room", myInfo.roomName);

        //--Mine.OC = OpCodes.Packed;
        //Mine.OP = txtAmount.text;
        if (txtPacked2.text == "Playing")
        {
            Clock2.SetActive(true);
            pClock2.Play("Clock2");
            //--Mine.NP = Seat2.text;
            data.AddField("nextPlayer", Seat2.text);
        }
        else if (txtPacked3.text == "Playing")
        {
            Clock3.SetActive(true);
            pClock3.Play("Clock3");
            //--Mine.NP = Seat3.text;
            data.AddField("nextPlayer", Seat3.text);
        }
        else if (txtPacked4.text == "Playing")
        {
            Clock4.SetActive(true);
            pClock4.Play("Clock4");
            //--Mine.NP = Seat4.text;
            data.AddField("nextPlayer", Seat4.text);
        }
        else if (txtPacked5.text == "Playing")
        {
            Clock5.SetActive(true);
            pClock5.Play("Clock5");
            //--Mine.NP = Seat5.text;
            data.AddField("nextPlayer", Seat5.text);
        }
       
        socket.Emit("Pack", data);
        //--json = JsonUtility.ToJson(Mine);
        // Send json string to socket
        //--ws.Send(Encoding.UTF8.GetBytes(json));
        // set to recieve; new message again        
        //newMessage = false;

    }
    public void IncreaseChaalAmount()
    {

        
        int temp = int.Parse(txtAmount.text);
        if(txtBlind.text=="BLIND")
        {
            if(temp==128)
            {
                return;
            }
        }
        if(temp==256)
        {
            return;
        }
        else
        {
            if (temp * 2 > int.Parse(txtMyCoin.text))
            {
                GameSoundFx.PlayOneShot(PackSound);
                DialogMsg.text = "You don't have enough balance to double the amount.";
                DialogMsg2.text = "";
                pnlOK.SetActive(true);
                btnPlus.interactable = false;
            }
            else
            {
                GameSoundFx.PlayOneShot(BlindSound);
                txtAmount.text = (temp * 2).ToString();
                btnPlus.interactable = false;
                btnMinus.interactable = true;
            }
              

        }
    }
    public void DecreaseChaalAmount()
    {

        int temp = int.Parse(txtAmount.text);
        if (temp == 2)
        {
            return;
        }
        else
        {
            GameSoundFx.PlayOneShot(BlindSound);
            txtAmount.text = (temp / 2).ToString();
            btnMinus.interactable = false;
            btnPlus.interactable = true;
        }
    }

    IEnumerator SavePlayerCards(string rId, string PlayerName, string Card1, string Card2, string Card3, string CardValue)
    {
        List<IMultipartFormSection> Cards = new List<IMultipartFormSection>();        
        Cards.Add(new MultipartFormDataSection("RoomId", rId));
        Cards.Add(new MultipartFormDataSection("PlayerName", PlayerName));
        Cards.Add(new MultipartFormDataSection("Card1", Card1));
        Cards.Add(new MultipartFormDataSection("Card2", Card2));
        Cards.Add(new MultipartFormDataSection("Card3", Card3));
        Cards.Add(new MultipartFormDataSection("CardValue", CardValue));

        UnityWebRequest SaveCard = UnityWebRequest.Post(SaveCardURL, Cards);
        yield return SaveCard.SendWebRequest();
        if (SaveCard.isNetworkError || SaveCard.isHttpError)
        {
            Debug.LogError(SaveCard.error);
            DialogMsg.text = SaveCard.error;
            pnlOK.SetActive(true);
        }
    }

    IEnumerator ShowCards(string PlayerName, int serial)
    {

        string GameRecord = "kopotron.com/php_rest_threecards/api/GamePlay/GetPlayerCards.php?RoomId=" + RoomId.text + "&PlayerName=" + PlayerName;
        UnityWebRequest www = UnityWebRequest.Get(GameRecord);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
            yield break;
        }
        //JSONNode GameRecords = JSON.Parse(www.downloadHandler.text);

        GamePlayerInfo PlayersInfo = new GamePlayerInfo();
        PlayersInfo = GamePlayerInfo.CreateFromJSON(www.downloadHandler.text);
        //Debug.Log(myGameInfo.PN);

        //sP1C1 = null;
        //sP1C2 = null;
        //sP1C3 = null;

        if (PlayersInfo.Card1 != 0 && PlayersInfo.Card2 != 0 && PlayersInfo.Card3 != 0)
        {
            if(serial==1)
            {
                sP1C1 = Resources.Load<Sprite>("Sprites/Cards/" + PlayersInfo.Card1.ToString());
                P1C1.GetComponent<Image>().sprite = sP1C1;
                sP1C2 = Resources.Load<Sprite>("Sprites/Cards/" + PlayersInfo.Card2.ToString());
                P1C2.GetComponent<Image>().sprite = sP1C2;
                sP1C3 = Resources.Load<Sprite>("Sprites/Cards/" + PlayersInfo.Card3.ToString());
                P1C3.GetComponent<Image>().sprite = sP1C3;
                MyGame.FirstPlayerCardWeight = PlayersInfo.CardValue;
            }
            if (serial == 2)
            {                
                sP2C1 = Resources.Load<Sprite>("Sprites/Cards/" + PlayersInfo.Card1.ToString());
                iP2C1.GetComponent<Image>().sprite = sP2C1;
                sP2C2 = Resources.Load<Sprite>("Sprites/Cards/" + PlayersInfo.Card2.ToString());
                iP2C2.GetComponent<Image>().sprite = sP2C2;
                sP2C3 = Resources.Load<Sprite>("Sprites/Cards/" + PlayersInfo.Card3.ToString());
                iP2C3.GetComponent<Image>().sprite = sP2C3;
                ShowCardsP2.SetActive(true);
                MyGame.SecondPlayerCardWeight = PlayersInfo.CardValue;
            }
            if (serial == 3)
            {
                sP3C1 = Resources.Load<Sprite>("Sprites/Cards/" + PlayersInfo.Card1.ToString());
                iP3C1.GetComponent<Image>().sprite = sP3C1;
                sP3C2 = Resources.Load<Sprite>("Sprites/Cards/" + PlayersInfo.Card2.ToString());
                iP3C2.GetComponent<Image>().sprite = sP3C2;
                sP3C3 = Resources.Load<Sprite>("Sprites/Cards/" + PlayersInfo.Card3.ToString());
                iP3C3.GetComponent<Image>().sprite = sP3C3;
                ShowCardsP3.SetActive(true);
                MyGame.ThirdPlayerCardWeight = PlayersInfo.CardValue;
            }
            if (serial == 4)
            {
                sP4C1 = Resources.Load<Sprite>("Sprites/Cards/" + PlayersInfo.Card1.ToString());
                iP4C1.GetComponent<Image>().sprite = sP4C1;
                sP4C2 = Resources.Load<Sprite>("Sprites/Cards/" + PlayersInfo.Card2.ToString());
                iP4C2.GetComponent<Image>().sprite = sP4C2;
                sP4C3 = Resources.Load<Sprite>("Sprites/Cards/" + PlayersInfo.Card3.ToString());
                iP4C3.GetComponent<Image>().sprite = sP4C3;
                ShowCardsP4.SetActive(true);
                MyGame.FourthPlayerCardWeight = PlayersInfo.CardValue;
            }
            if (serial == 5)
            {
                sP5C1 = Resources.Load<Sprite>("Sprites/Cards/" + PlayersInfo.Card1.ToString());
                iP5C1.GetComponent<Image>().sprite = sP5C1;
                sP5C2 = Resources.Load<Sprite>("Sprites/Cards/" + PlayersInfo.Card2.ToString());
                iP5C2.GetComponent<Image>().sprite = sP5C2;
                sP5C3 = Resources.Load<Sprite>("Sprites/Cards/" + PlayersInfo.Card3.ToString());
                iP5C3.GetComponent<Image>().sprite = sP5C3;
                ShowCardsP5.SetActive(true);
                MyGame.FifthPlayerCardWeight = PlayersInfo.CardValue;
            }

        }
        


    }
    IEnumerator JoinClassic()
    {
        GameSoundFx.PlayOneShot(NewPlayerSound);
        DialogMsg.text = "Boot-amount\nBlind-limit\nChaal-limit\nPot-limit";
        DialogMsg2.text = "2\n4\n256\n2000";
        pnlOK.SetActive(true);
        Seat1.text = DBManager.username;


        //socket.Connect();
        // Reset some global vars
        tmpCards1 = "";
        tmpCards2 = "";
        tmpCards3 = "";
        tmpCards4 = "";
        tmpCards5 = "";
        cList1 = new string[] { "0", "0", "0" };
        cList2 = new string[] { "0", "0", "0" };
        cList3 = new string[] { "0", "0", "0" };
        cList4 = new string[] { "0", "0", "0" };
        cList5 = new string[] { "0", "0", "0" };
        MyGame.FirstPlayerCardWeight = 0;
        MyGame.SecondPlayerCardWeight = 0;
        MyGame.ThirdPlayerCardWeight = 0;
        MyGame.FourthPlayerCardWeight = 0;
        MyGame.FifthPlayerCardWeight = 0;
        sideshow = "";

        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();

        formData.Add(new MultipartFormDataSection("PlayerName", DBManager.username));

        formData.Add(new MultipartFormDataSection("Coins", "500"));

        UnityWebRequest www = UnityWebRequest.Post(JoinRoomURL, formData);

        yield return www.SendWebRequest();
        /*
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
            DialogMsg.text = www.error;
            pnlOK.SetActive(true);
            
        }
        else
        {
            if (www.responseCode == 200)
            {

                RoomId.text = www.downloadHandler.text;
                
                Debug.Log(RoomId);
                string RoomRecord = "kopotron.com/php_rest_threecards/api/RoomPlayers/GetRoomPlayers.php?RoomId=" + RoomId.text;
                UnityWebRequest rr = UnityWebRequest.Get(RoomRecord);
                yield return rr.SendWebRequest();
                if (rr.isNetworkError || rr.isHttpError)
                {
                    Debug.LogError(rr.error);
                    yield break;
                }

                myRoomInfo = RoomPlayerInfo.GetRoomInfoFromJSON(rr.downloadHandler.text);
                // If I'm the only player in the room, then send my info and wait for respond.
                if (myRoomInfo.PlayerCount == 1)
                {
                    txtAnnounce.text = "Wait for a player to join!";
                    RoomPlayerCount = 1;
                    Seat1.text = DBManager.username;
                    DBManager.userpic = myRoomInfo.Seat1Icon;
                    Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + DBManager.userpic);
                    imgP1.GetComponent<Image>().sprite = tmpPicute;
                    //myRoomInfo.Seat1Icon
                    Seat2.text = myRoomInfo.Seat2;
                    Seat3.text = myRoomInfo.Seat3;
                    Seat4.text = myRoomInfo.Seat4;
                    Seat5.text = myRoomInfo.Seat5;
                    txtPacked1.text = "Watching";
                    Mine.PN = DBManager.username;
                    Mine.PI = DBManager.userpic;
                    Mine.RI = RoomId.text;
                    //Mine.RoomPlayerCount = "1";
                   // Mine.GameState = "Off";
                    Mine.SR = "1";
                    Mine.BM = "0";
                    Mine.DN = Mine.PN;
                    Mine.OC = OpCodes.Start;
                    Mine.OP = "";
                    json = JsonUtility.ToJson(Mine);
                    
                }
                else if(myRoomInfo.PlayerCount==2)
                {
                    // I'm the second player to enter room.
                    // I'm requesting for new game start
                    // Before that fix my serial first
                    if (myRoomInfo.Seat1 == DBManager.username)
                    {
                        Seat1.text = myRoomInfo.Seat1;
                        DBManager.userpic = myRoomInfo.Seat1Icon;
                        Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + DBManager.userpic);
                        imgP1.GetComponent<Image>().sprite = tmpPicute;
                        Seat2.text = myRoomInfo.Seat2;
                        if(Seat2.text!="EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat2Icon);
                            imgP2.GetComponent<Image>().sprite = tmpPicute;
                            Mine.DN = Seat2.text;
                        }
                        Seat3.text = myRoomInfo.Seat3;
                        if (Seat3.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat3Icon);
                            imgP3.GetComponent<Image>().sprite = tmpPicute;
                            Mine.DN = Seat3.text;
                        }
                        Seat4.text = myRoomInfo.Seat4;
                        if (Seat4.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat4Icon);
                            imgP4.GetComponent<Image>().sprite = tmpPicute;
                            Mine.DN = Seat4.text;
                        }
                        Seat5.text = myRoomInfo.Seat5;
                        if (Seat5.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat5Icon);
                            imgP5.GetComponent<Image>().sprite = tmpPicute;
                            Mine.DN = Seat5.text;
                        }
                        mySeat = "1";
                    }
                    if (myRoomInfo.Seat2 == DBManager.username)
                    {
                        Seat1.text = myRoomInfo.Seat2;
                        DBManager.userpic = myRoomInfo.Seat2Icon;
                        Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + DBManager.userpic);
                        imgP1.GetComponent<Image>().sprite = tmpPicute;
                        Seat2.text = myRoomInfo.Seat3;
                        if (Seat2.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat3Icon);
                            imgP2.GetComponent<Image>().sprite = tmpPicute;
                            Mine.DN = Seat2.text;
                        }
                        Seat3.text = myRoomInfo.Seat4;
                        if (Seat3.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat4Icon);
                            imgP3.GetComponent<Image>().sprite = tmpPicute;
                            Mine.DN = Seat3.text;
                        }
                        Seat4.text = myRoomInfo.Seat5;
                        if (Seat4.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat5Icon);
                            imgP4.GetComponent<Image>().sprite = tmpPicute;
                            Mine.DN = Seat4.text;
                        }
                        Seat5.text = myRoomInfo.Seat1;
                        if (Seat5.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat1Icon);
                            imgP5.GetComponent<Image>().sprite = tmpPicute;
                            Mine.DN = Seat5.text;
                        }
                        mySeat = "2";
                    }
                    if (myRoomInfo.Seat3 == DBManager.username)
                    {
                        Seat1.text = myRoomInfo.Seat3;
                        DBManager.userpic = myRoomInfo.Seat3Icon;
                        Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + DBManager.userpic);
                        imgP1.GetComponent<Image>().sprite = tmpPicute;
                        Seat2.text = myRoomInfo.Seat4;
                        if (Seat2.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat4Icon);
                            imgP2.GetComponent<Image>().sprite = tmpPicute;
                            Mine.DN = Seat2.text;
                        }
                        Seat3.text = myRoomInfo.Seat5;
                        if (Seat3.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat5Icon);
                            imgP3.GetComponent<Image>().sprite = tmpPicute;
                            Mine.DN = Seat3.text;
                        }
                        Seat4.text = myRoomInfo.Seat1;
                        if (Seat4.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat1Icon);
                            imgP4.GetComponent<Image>().sprite = tmpPicute;
                            Mine.DN = Seat4.text;
                        }
                        Seat5.text = myRoomInfo.Seat2;
                        if (Seat5.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat2Icon);
                            imgP5.GetComponent<Image>().sprite = tmpPicute;
                            Mine.DN = Seat5.text;
                        }
                        mySeat = "3";
                    }
                    if (myRoomInfo.Seat4 == DBManager.username)
                    {
                        Seat1.text = myRoomInfo.Seat4;
                        DBManager.userpic = myRoomInfo.Seat4Icon;
                        Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + DBManager.userpic);
                        imgP1.GetComponent<Image>().sprite = tmpPicute;
                        Seat2.text = myRoomInfo.Seat5;
                        if (Seat2.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat5Icon);
                            imgP2.GetComponent<Image>().sprite = tmpPicute;
                            Mine.DN = Seat2.text;
                        }
                        Seat3.text = myRoomInfo.Seat1;
                        if (Seat3.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat1Icon);
                            imgP3.GetComponent<Image>().sprite = tmpPicute;
                            Mine.DN = Seat3.text;
                        }
                        Seat4.text = myRoomInfo.Seat2;
                        if (Seat4.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat2Icon);
                            imgP4.GetComponent<Image>().sprite = tmpPicute;
                            Mine.DN = Seat4.text;
                        }
                        Seat5.text = myRoomInfo.Seat3;
                        if (Seat5.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat3Icon);
                            imgP5.GetComponent<Image>().sprite = tmpPicute;
                            Mine.DN = Seat5.text;
                        }
                        mySeat = "4";
                    }
                    if (myRoomInfo.Seat5 == DBManager.username)
                    {
                        Seat1.text = myRoomInfo.Seat5;
                        DBManager.userpic = myRoomInfo.Seat5Icon;
                        Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + DBManager.userpic);
                        imgP1.GetComponent<Image>().sprite = tmpPicute;
                        Seat2.text = myRoomInfo.Seat1;
                        if (Seat2.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat1Icon);
                            imgP2.GetComponent<Image>().sprite = tmpPicute;
                            Mine.DN = Seat2.text;
                        }
                        Seat3.text = myRoomInfo.Seat2;
                        if (Seat3.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat2Icon);
                            imgP3.GetComponent<Image>().sprite = tmpPicute;
                            Mine.DN = Seat3.text;
                        }
                        Seat4.text = myRoomInfo.Seat3;
                        if (Seat4.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat3Icon);
                            imgP4.GetComponent<Image>().sprite = tmpPicute;
                            Mine.DN = Seat4.text;
                        }
                        Seat5.text = myRoomInfo.Seat4;
                        if (Seat5.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat4Icon);
                            imgP5.GetComponent<Image>().sprite = tmpPicute;
                            Mine.DN = Seat5.text;
                        }
                        mySeat = "5";
                    }
                    txtPacked1.text = "Watching";
                    Mine.PN = DBManager.username;
                    Mine.PI = DBManager.userpic;
                    Mine.RI = RoomId.text;
                    //Mine.RoomPlayerCount = myRoomInfo.PlayerCount.ToString();
                    //Mine.GameState = "Off";
                    Mine.SR = mySeat;
                    Mine.BM = "0";                    
                    //Mine.OC = "START";
                    Mine.OC = OpCodes.Start;
                    Mine.OP = "";
                    json = JsonUtility.ToJson(Mine);

                }
                else
                {
                    txtAnnounce.text = "Wait for the running game to finish!";
                    // I have entered a room where a game is going on or about to begin
                    if (myRoomInfo.Seat1 == DBManager.username)
                    {
                        Seat1.text = myRoomInfo.Seat1;
                        DBManager.userpic = myRoomInfo.Seat1Icon;
                        Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + DBManager.userpic);
                        imgP1.GetComponent<Image>().sprite = tmpPicute;
                        Seat2.text = myRoomInfo.Seat2;
                        if (Seat2.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat2Icon);
                            imgP2.GetComponent<Image>().sprite = tmpPicute;
                        }
                        Seat3.text = myRoomInfo.Seat3;
                        if (Seat3.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat3Icon);
                            imgP3.GetComponent<Image>().sprite = tmpPicute;
                        }
                        Seat4.text = myRoomInfo.Seat4;
                        if (Seat4.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat4Icon);
                            imgP4.GetComponent<Image>().sprite = tmpPicute;
                        }
                        Seat5.text = myRoomInfo.Seat5;
                        if (Seat5.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat5Icon);
                            imgP5.GetComponent<Image>().sprite = tmpPicute;
                        }
                        mySeat = "1";
                    }
                    if (myRoomInfo.Seat2 == DBManager.username)
                    {
                        Seat1.text = myRoomInfo.Seat2;
                        DBManager.userpic = myRoomInfo.Seat2Icon;
                        Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + DBManager.userpic);
                        imgP1.GetComponent<Image>().sprite = tmpPicute;
                        Seat2.text = myRoomInfo.Seat3;
                        if (Seat2.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat3Icon);
                            imgP2.GetComponent<Image>().sprite = tmpPicute;
                        }
                        Seat3.text = myRoomInfo.Seat4;
                        if (Seat3.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat4Icon);
                            imgP3.GetComponent<Image>().sprite = tmpPicute;
                        }
                        Seat4.text = myRoomInfo.Seat5;
                        if (Seat4.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat5Icon);
                            imgP4.GetComponent<Image>().sprite = tmpPicute;
                        }
                        Seat5.text = myRoomInfo.Seat1;
                        if (Seat5.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat1Icon);
                            imgP5.GetComponent<Image>().sprite = tmpPicute;
                        }
                        mySeat = "2";
                    }
                    if (myRoomInfo.Seat3 == DBManager.username)
                    {
                        Seat1.text = myRoomInfo.Seat3;
                        DBManager.userpic = myRoomInfo.Seat3Icon;
                        Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + DBManager.userpic);
                        imgP1.GetComponent<Image>().sprite = tmpPicute;
                        Seat2.text = myRoomInfo.Seat4;
                        if (Seat2.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat4Icon);
                            imgP2.GetComponent<Image>().sprite = tmpPicute;
                        }
                        Seat3.text = myRoomInfo.Seat5;
                        if (Seat3.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat5Icon);
                            imgP3.GetComponent<Image>().sprite = tmpPicute;
                        }
                        Seat4.text = myRoomInfo.Seat1;
                        if (Seat4.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat1Icon);
                            imgP4.GetComponent<Image>().sprite = tmpPicute;
                        }
                        Seat5.text = myRoomInfo.Seat2;
                        if (Seat5.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat2Icon);
                            imgP5.GetComponent<Image>().sprite = tmpPicute;
                        }
                        mySeat = "3";
                    }
                    if (myRoomInfo.Seat4 == DBManager.username)
                    {
                        Seat1.text = myRoomInfo.Seat4;
                        DBManager.userpic = myRoomInfo.Seat4Icon;
                        Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + DBManager.userpic);
                        imgP1.GetComponent<Image>().sprite = tmpPicute;
                        Seat2.text = myRoomInfo.Seat5;
                        if (Seat2.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat5Icon);
                            imgP2.GetComponent<Image>().sprite = tmpPicute;
                        }
                        Seat3.text = myRoomInfo.Seat1;
                        if (Seat3.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat1Icon);
                            imgP3.GetComponent<Image>().sprite = tmpPicute;
                        }
                        Seat4.text = myRoomInfo.Seat2;
                        if (Seat4.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat2Icon);
                            imgP4.GetComponent<Image>().sprite = tmpPicute;
                        }
                        Seat5.text = myRoomInfo.Seat3;
                        if (Seat5.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat3Icon);
                            imgP5.GetComponent<Image>().sprite = tmpPicute;
                        }
                        mySeat = "4";
                    }
                    if (myRoomInfo.Seat5 == DBManager.username)
                    {
                        Seat1.text = myRoomInfo.Seat5;
                        DBManager.userpic = myRoomInfo.Seat5Icon;
                        Sprite tmpPicute = Resources.Load<Sprite>("Images/emoji/" + DBManager.userpic);
                        imgP1.GetComponent<Image>().sprite = tmpPicute;
                        Seat2.text = myRoomInfo.Seat1;
                        if (Seat2.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat1Icon);
                            imgP2.GetComponent<Image>().sprite = tmpPicute;
                        }
                        Seat3.text = myRoomInfo.Seat2;
                        if (Seat3.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat2Icon);
                            imgP3.GetComponent<Image>().sprite = tmpPicute;
                        }
                        Seat4.text = myRoomInfo.Seat3;
                        if (Seat4.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat3Icon);
                            imgP4.GetComponent<Image>().sprite = tmpPicute;
                        }
                        Seat5.text = myRoomInfo.Seat4;
                        if (Seat5.text != "EMPTY")
                        {
                            tmpPicute = Resources.Load<Sprite>("Images/emoji/" + myRoomInfo.Seat4Icon);
                            imgP5.GetComponent<Image>().sprite = tmpPicute;
                        }
                        mySeat = "5";
                    }
                    // Reset some global vars
                    tmpCards1 = "";
                    tmpCards2 = "";
                    tmpCards3 = "";
                    tmpCards4 = "";
                    tmpCards5 = "";
                    cList1 = new string[] { "0", "0", "0" };
                    cList2 = new string[] { "0", "0", "0" };
                    cList3 = new string[] { "0", "0", "0" };
                    cList4 = new string[] { "0", "0", "0" };
                    cList5 = new string[] { "0", "0", "0" };
                    MyGame.FirstPlayerCardWeight = 0;
                    MyGame.SecondPlayerCardWeight = 0;
                    MyGame.ThirdPlayerCardWeight = 0;
                    MyGame.FourthPlayerCardWeight = 0;
                    MyGame.FifthPlayerCardWeight = 0;
                    txtPacked1.text = "Watching";
                    // Reset all the chaal amount to nothing
                    txtLastCoin2.text = "";
                    txtLastCoin3.text = "";
                    txtLastCoin4.text = "";
                    txtLastCoin5.text = "";
                    // Reset my chaal amount to lowest
                    txtAmount.text = "2";
                    // Reset all player's pot amount to lowest
                    txtThrowCoin.text = "2";
                    txtThrowCoin2.text = "2";
                    txtThrowCoin3.text = "2";
                    txtThrowCoin4.text = "2";
                    txtThrowCoin5.text = "2";
                    // Reset board money to zero
                    txtPotCoin.text = "0";
                    // Reset all the player's chaal
                    txtChaal2.text = "";
                    txtChaal3.text = "";
                    txtChaal4.text = "";
                    txtChaal5.text = "";
                    Mine.PN = DBManager.username;
                    Mine.PI = DBManager.userpic;
                    Mine.RI = RoomId.text;
                    //Mine.RoomPlayerCount = myRoomInfo.PlayerCount.ToString();
                    //Mine.GameState = "Off";
                    Mine.SR = mySeat;
                    Mine.BM = "0";
                    Mine.DN = "";
                    //Mine.OC = "START";
                    Mine.OC = OpCodes.Start;
                    Mine.OP = OpCodes.CardsForNewPlayer;                    
                    json = JsonUtility.ToJson(Mine);
                }

                //Connect the room through socket
                //--ws = WebSocketFactory.CreateInstance("ws://server.kopotron.com:8443/GameServer.php");
                //ws = WebSocketFactory.CreateInstance("ws://server.kopotron.com:8443/ws_test.php");
               
                // Add OnOpen event listener
                ws.OnOpen += () =>
                {
                    Debug.Log("WS connected!");
                    Debug.Log("WS state: " + ws.GetState().ToString());
                    ws.Send(Encoding.UTF8.GetBytes(json));
                };
                
               
                // Add OnMessage event listener
                ws.OnMessage += (byte[] msg) =>
                {
                    retJson = Encoding.UTF8.GetString(msg);
                    if(retJson.Contains("RI"))
                        {
                        OtherPlayer = JsonUtility.FromJson<PlayerText>(retJson);
                    }
                    else
                    {
                        OtherPlayer.PN = "null";
                    }
                    newMessage = true;
                    Debug.Log("WS received message: " + Encoding.UTF8.GetString(msg));
                    //ws.Close();
                };
                
                
                // Add OnError event listener
                ws.OnError += (string errMsg) =>
                {
                    Debug.Log("WS error: " + errMsg);
                };
               
                // Add OnClose event listener
                
                ws.OnClose += (WebSocketCloseCode code) =>
                {
                   
                    //Mine.PN = DBManager.username;
                    //Mine.OC = "QUIT";
                    //json = JsonUtility.ToJson(Mine);
                    //ws.Send(Encoding.UTF8.GetBytes(json));
                    
                    Debug.Log("WS closed with code: " + code.ToString());
                };
           
                // Connect to the server
                //--ws.Connect();


            }
            

        }

        */
    }
}



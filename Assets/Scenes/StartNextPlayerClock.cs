using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class StartNextPlayerClock : MonoBehaviour
{
    public Text Seat1, Seat2, Seat3, Seat4, Seat5, RoomId,txtPotCoin, p2Chaal, p3Chaal, p4Chaal, p5Chaal;
    public Text txtStatus1, txtStatus2, txtStatus3, txtStatus4, txtStatus5;
    public GameObject showChaal2, showChaal3, showChaal4, showChaal5;
    public Button btnPack;
    public Button btnLoby;
    public Button btnSendQuit;
    //private readonly string SaveActivePlayerURL = "https://server.kopotron.com/SaveActivePlayer.php";
    //private readonly string SaveCurrentChaalURL = "https://server.kopotron.com/SaveGamePlay.php";
    //private readonly string SavePackedPlayerURL = "https://server.kopotron.com/SavePackedPlayer.php";

    private Animator pClock1,pClock2, pClock3, pClock4, pClock5;
    public GameObject P1Clock, P2Clock, P3Clock, P4Clock, P5Clock;
    public GameObject Clock1, Clock2, Clock3, Clock4, Clock5;
    public GameObject GamePlayPanel;
    private Animator playPanel;

    // audio for clock start
    public AudioSource GameSoundFx;
    public AudioClip ClockStart;
    public AudioClip ClockWarning;
    // Start is called before the first frame update
    public void FromSeat1NextPlayerClock()
    {
        playPanel = GamePlayPanel.GetComponent<Animator>();
        playPanel.SetBool("Show", false);
        txtStatus1.text = "Quit";
        //btnPack.onClick.Invoke();
        btnLoby.onClick.Invoke();
        
        /*
        if (txtStatus2.text == "Playing")
        {
            Clock2.SetActive(true);
            pClock2 = P2Clock.GetComponent<Animator>();
            pClock2.Play("Clock2");
            ClockSequencer.PN = Seat2.text;
            ClockSequencer.ClockChanged = true;
            return;
        }
        if (txtStatus3.text == "Playing")
        {
            Clock3.SetActive(true);
            pClock3 = P3Clock.GetComponent<Animator>();
            pClock3.Play("Clock3");
            ClockSequencer.PN = Seat3.text;
            ClockSequencer.ClockChanged = true;
            return;
        }
        if (txtStatus4.text == "Playing")
        {
            Clock4.SetActive(true);
            pClock4 = P4Clock.GetComponent<Animator>();
            pClock4.Play("Clock4");
            ClockSequencer.PN = Seat4.text;
            ClockSequencer.ClockChanged = true;
            return;
        }
        if (txtStatus5.text == "Playing")
        {
            Clock5.SetActive(true);
            pClock5 = P5Clock.GetComponent<Animator>();
            pClock5.Play("Clock5");
            ClockSequencer.PN = Seat5.text;
            ClockSequencer.ClockChanged = true;
            return;
        }
        */
        //StartCoroutine(CheckActiveSeat2()); 

    }
    public void FromSeat2NextPlayerClock()
    {

        p2Chaal.text = "Quit";
        Animator gAnim = showChaal2.GetComponent<Animator>();
        gAnim.Play("ShowChaal");
        txtStatus2.text = "Quit";
        DBManager.QuiterName = Seat2.text;
        //btnSendQuit.onClick.Invoke();
        //SendQuitAfterDelay(1.0f);
        //btnPack.onClick.Invoke();
        if (txtStatus3.text == "Playing")
        {
            Clock3.SetActive(true);
            pClock3 = P3Clock.GetComponent<Animator>();
            pClock3.Play("Clock3");
            ClockSequencer.PN = Seat3.text;
            ClockSequencer.ClockChanged = true;
            return;
        }
        if (txtStatus4.text == "Playing")
        {
            Clock4.SetActive(true);
            pClock4 = P4Clock.GetComponent<Animator>();
            pClock4.Play("Clock4");
            ClockSequencer.PN = Seat4.text;
            ClockSequencer.ClockChanged = true;
            return;
        }
        if (txtStatus5.text == "Playing")
        {
            Clock5.SetActive(true);
            pClock5 = P5Clock.GetComponent<Animator>();
            pClock5.Play("Clock5");
            ClockSequencer.PN = Seat5.text;
            ClockSequencer.ClockChanged = true;
            return;
        }
        if (txtStatus1.text == "Playing")
        {
            Clock1.SetActive(true);
            pClock1 = P1Clock.GetComponent<Animator>();
            pClock1.Play("Clock1");
            ClockSequencer.PN = Seat1.text;
            ClockSequencer.ClockChanged = true;
            return;
        }

        //StartCoroutine(CheckActiveSeat3());

    }
    public void FromSeat3NextPlayerClock()
    {
        p3Chaal.text = "Quit";
        Animator gAnim = showChaal3.GetComponent<Animator>();
        gAnim.Play("ShowChaal");
        txtStatus3.text = "Quit";
        DBManager.QuiterName = Seat3.text;
        //btnSendQuit.onClick.Invoke();
        //SendQuitAfterDelay(1.0f);
        //btnPack.onClick.Invoke();
        //StartCoroutine(CheckActiveSeat4());

        if (txtStatus4.text == "Playing")
        {
            Clock4.SetActive(true);
            pClock4 = P4Clock.GetComponent<Animator>();
            pClock4.Play("Clock4");
            ClockSequencer.PN = Seat4.text;
            ClockSequencer.ClockChanged = true;
            return;
        }
        if (txtStatus5.text == "Playing")
        {
            Clock5.SetActive(true);
            pClock5 = P5Clock.GetComponent<Animator>();
            pClock5.Play("Clock5");
            ClockSequencer.PN = Seat5.text;
            ClockSequencer.ClockChanged = true;
            return;
        }
        if (txtStatus1.text == "Playing")
        {
            Clock1.SetActive(true);
            pClock1 = P1Clock.GetComponent<Animator>();
            pClock1.Play("Clock1");
            ClockSequencer.PN = Seat1.text;
            ClockSequencer.ClockChanged = true;
            return;
        }
        if (txtStatus2.text == "Playing")
        {
            Clock2.SetActive(true);
            pClock2 = P2Clock.GetComponent<Animator>();
            pClock2.Play("Clock2");
            ClockSequencer.PN = Seat2.text;
            ClockSequencer.ClockChanged = true;
            return;
        }

    }
    public void FromSeat4NextPlayerClock()
    {

        p4Chaal.text = "Quit";
        Animator gAnim = showChaal4.GetComponent<Animator>();
        gAnim.Play("ShowChaal");
        txtStatus4.text = "Quit";
        DBManager.QuiterName = Seat4.text;
        //btnSendQuit.onClick.Invoke();
        //SendQuitAfterDelay(1.0f);
        //btnPack.onClick.Invoke();
        //StartCoroutine(CheckActiveSeat5());
        if (txtStatus5.text == "Playing")
        {
            Clock5.SetActive(true);
            pClock5 = P5Clock.GetComponent<Animator>();
            pClock5.Play("Clock5");
            ClockSequencer.PN = Seat5.text;
            ClockSequencer.ClockChanged = true;
            return;
        }
        if (txtStatus1.text == "Playing")
        {
            Clock1.SetActive(true);
            pClock1 = P1Clock.GetComponent<Animator>();
            pClock1.Play("Clock1");
            ClockSequencer.PN = Seat1.text;
            ClockSequencer.ClockChanged = true;
            return;
        }
        if (txtStatus2.text == "Playing")
        {
            Clock2.SetActive(true);
            pClock2 = P2Clock.GetComponent<Animator>();
            pClock2.Play("Clock2");
            ClockSequencer.PN = Seat2.text;
            ClockSequencer.ClockChanged = true;
            return;
        }
        if (txtStatus3.text == "Playing")
        {
            Clock3.SetActive(true);
            pClock3 = P3Clock.GetComponent<Animator>();
            pClock3.Play("Clock3");
            ClockSequencer.PN = Seat3.text;
            ClockSequencer.ClockChanged = true;
            return;
        }


    }
    public void FromSeat5NextPlayerClock()
    {
        p5Chaal.text = "Quit";
        Animator gAnim = showChaal5.GetComponent<Animator>();
        gAnim.Play("ShowChaal");
        txtStatus5.text = "Quit";
        //StartCoroutine(CheckActiveSeat5());
        DBManager.QuiterName = Seat5.text;
        //btnSendQuit.onClick.Invoke();
        //SendQuitAfterDelay(1.0f);
        if (txtStatus1.text == "Playing")
        {
            Clock1.SetActive(true);
            pClock1 = P1Clock.GetComponent<Animator>();
            pClock1.Play("Clock1");
            ClockSequencer.PN = Seat1.text;
            ClockSequencer.ClockChanged = true;
            return;
        }
        if (txtStatus2.text == "Playing")
        {
            Clock2.SetActive(true);
            pClock2 = P2Clock.GetComponent<Animator>();
            pClock2.Play("Clock2");
            ClockSequencer.PN = Seat2.text;
            ClockSequencer.ClockChanged = true;
            return;
        }
        if (txtStatus3.text == "Playing")
        {
            Clock3.SetActive(true);
            pClock3 = P3Clock.GetComponent<Animator>();
            pClock3.Play("Clock3");
            ClockSequencer.PN = Seat3.text;
            ClockSequencer.ClockChanged = true;
            return;
        }
        if (txtStatus4.text == "Playing")
        {
            Clock4.SetActive(true);
            pClock4 = P4Clock.GetComponent<Animator>();
            pClock4.Play("Clock4");
            ClockSequencer.PN = Seat4.text;
            ClockSequencer.ClockChanged = true;
            return;
        }
        /*
        p5Chaal.text = "Packed";
        Animator gAnim = showChaal5.GetComponent<Animator>();
        gAnim.SetBool("Show", true);
        StartCoroutine(CheckActiveSeat1());
        */
    }

    public void PlayClockStartSound(int nClock)
    {
        if(nClock==1)
        {
            GameSoundFx.PlayOneShot(ClockStart);
            DBManager.ActiveClock = 1;
        }
        else
        {
            DBManager.ActiveClock = nClock;
        }
        

    }
    public void PlayClockWarningSound()
    {
        GameSoundFx.PlayOneShot(ClockWarning);
    }
    IEnumerator SendQuitAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        btnSendQuit.onClick.Invoke();
    }
    /*
    private IEnumerator CheckActiveSeat2()
    {
        
        
        // push next active player who will sit in seat2 . . .
        if (Seat2.text != "EMPTY")
        {
            // Check if next seat is playing the game

            // Save this seat's player as next active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", Seat2.text));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);
                

            }
        }
        else if (Seat3.text != "EMPTY")
        {
            // Check if next seat is playing the game

            // Save this seat's player as next active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", Seat3.text));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);
               

            }
        }
        else if (Seat4.text != "EMPTY")
        {
            // Check if next seat is playing the game

            // Save this seat's player as next active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", Seat4.text));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);
                

            }
        }
        else if (Seat5.text != "EMPTY")
        {
            // Check if next seat is playing the game

            // Save this seat's player as next active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", Seat5.text));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);
                

            }
        }
        else
        {
            // Check if next seat is playing the game

            // All the other seats are empty. So save EMPTY as active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", "EMPTY"));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);
                

            }
        }

    }

    private IEnumerator CheckActiveSeat3()
    {
        /*
        // Get this seat packed first
        List<IMultipartFormSection> PlayData = new List<IMultipartFormSection>();
        PlayData.Add(new MultipartFormDataSection("RoomId", RoomId.text));
        PlayData.Add(new MultipartFormDataSection("LastPlayer", Seat2.text));
        PlayData.Add(new MultipartFormDataSection("PlayType", "Packed"));
        UnityWebRequest SavePlay = UnityWebRequest.Post(SavePackedPlayerURL, PlayData);
        yield return SavePlay.SendWebRequest();
        if (SavePlay.isNetworkError || SavePlay.isHttpError)
        {
            Debug.LogError(SavePlay.error);

        }
        
        
        // push next active player who will sit in seat2 . . .
        if (Seat3.text != "EMPTY")
        {
            // Check if next seat is playing the game

            // Save this seat's player as next active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", Seat3.text));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);


            }
        }
        else if (Seat4.text != "EMPTY")
        {
            // Check if next seat is playing the game

            // Save this seat's player as next active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", Seat4.text));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);


            }
        }
        else if (Seat5.text != "EMPTY")
        {
            // Check if next seat is playing the game

            // Save this seat's player as next active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", Seat5.text));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);


            }
        }
        else if (Seat1.text != "EMPTY")
        {
            // Check if next seat is playing the game

            // Save this seat's player as next active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", Seat1.text));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);


            }
        }
        else
        {
            // Check if next seat is playing the game

            // All the other seats are empty. So save EMPTY as active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", "EMPTY"));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);


            }
        }

    }

    private IEnumerator CheckActiveSeat4()
    {
        /*
        // Get this seat packed first
        List<IMultipartFormSection> PlayData = new List<IMultipartFormSection>();
        PlayData.Add(new MultipartFormDataSection("RoomId", RoomId.text));
        PlayData.Add(new MultipartFormDataSection("LastPlayer", Seat3.text));        
        PlayData.Add(new MultipartFormDataSection("PlayType", "Packed"));
        UnityWebRequest SavePlay = UnityWebRequest.Post(SavePackedPlayerURL, PlayData);
        yield return SavePlay.SendWebRequest();
        if (SavePlay.isNetworkError || SavePlay.isHttpError)
        {
            Debug.LogError(SavePlay.error);

        }
        
        // push next active player who will sit in seat2 . . .
        if (Seat4.text != "EMPTY")
        {
            // Check if next seat is playing the game

            // Save this seat's player as next active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", Seat4.text));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);


            }
        }
        else if (Seat5.text != "EMPTY")
        {
            // Check if next seat is playing the game

            // Save this seat's player as next active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", Seat5.text));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);


            }
        }
        else if (Seat1.text != "EMPTY")
        {
            // Check if next seat is playing the game

            // Save this seat's player as next active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", Seat1.text));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);


            }
        }
        else if (Seat2.text != "EMPTY")
        {
            // Check if next seat is playing the game

            // Save this seat's player as next active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", Seat2.text));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);


            }
        }
        else
        {
            // Check if next seat is playing the game

            // All the other seats are empty. So save EMPTY as active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", "EMPTY"));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);


            }
        }
        //yield return true;

    }

    private IEnumerator CheckActiveSeat5()
    {
        /*
        // Get this seat packed first
        List<IMultipartFormSection> PlayData = new List<IMultipartFormSection>();
        PlayData.Add(new MultipartFormDataSection("RoomId", RoomId.text));
        PlayData.Add(new MultipartFormDataSection("LastPlayer", Seat4.text));        
        PlayData.Add(new MultipartFormDataSection("PlayType", "Packed"));
        UnityWebRequest SavePlay = UnityWebRequest.Post(SavePackedPlayerURL, PlayData);
        yield return SavePlay.SendWebRequest();
        if (SavePlay.isNetworkError || SavePlay.isHttpError)
        {
            Debug.LogError(SavePlay.error);

        }
        
        // push next active player who will sit in seat2 . . .
        if (Seat5.text != "EMPTY")
        {
            // Check if next seat is playing the game

            // Save this seat's player as next active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", Seat5.text));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);


            }
        }
        else if (Seat1.text != "EMPTY")
        {
            // Check if next seat is playing the game

            // Save this seat's player as next active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", Seat1.text));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);


            }
        }
        else if (Seat2.text != "EMPTY")
        {
            // Check if next seat is playing the game

            // Save this seat's player as next active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", Seat2.text));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);


            }
        }
        else if (Seat3.text != "EMPTY")
        {
            // Check if next seat is playing the game

            // Save this seat's player as next active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", Seat3.text));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);


            }
        }
        else
        {
            // Check if next seat is playing the game

            // All the other seats are empty. So save EMPTY as active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", "EMPTY"));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);


            }
        }

    }

    private IEnumerator CheckActiveSeat1()
    {
                
        // push next active player who will sit in seat2 . . .
        if (Seat1.text != "EMPTY")
        {
            // Check if next seat is playing the game

            // Save this seat's player as next active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", Seat1.text));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);


            }
        }
        else if (Seat2.text != "EMPTY")
        {
            // Check if next seat is playing the game

            // Save this seat's player as next active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", Seat2.text));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);


            }
        }
        else if (Seat3.text != "EMPTY")
        {
            // Check if next seat is playing the game

            // Save this seat's player as next active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", Seat3.text));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);


            }
        }
        else if (Seat4.text != "EMPTY")
        {
            // Check if next seat is playing the game

            // Save this seat's player as next active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", Seat4.text));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);


            }
        }
        
        else
        {
            
            // Check if next seat is playing the game

            // All the other seats are empty. So save EMPTY as active player
            List<IMultipartFormSection> ActivePlayerInfo = new List<IMultipartFormSection>();
            ActivePlayerInfo.Add(new MultipartFormDataSection("RoomId", RoomId.text));
            ActivePlayerInfo.Add(new MultipartFormDataSection("ActivePlayer", "EMPTY"));

            UnityWebRequest SaveActive = UnityWebRequest.Post(SaveActivePlayerURL, ActivePlayerInfo);
            yield return SaveActive.SendWebRequest();
            if (SaveActive.isNetworkError || SaveActive.isHttpError)
            {
                Debug.LogError(SaveActive.error);


            }
        }
       

    }
    */
}

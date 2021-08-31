using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DealNextCard : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource GameSoundFx;
    public AudioClip CardDealSound;
    public void BeginCardAnimation()
    {
        GameState.CardAnimateFinished = false;
        GameSoundFx.PlayOneShot(CardDealSound);
    }
    public void EndCardAnimation()
    {
        GameState.CardAnimateFinished = true;
    }
    

    
}

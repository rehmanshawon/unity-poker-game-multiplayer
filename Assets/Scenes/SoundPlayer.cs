using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource GameSoundFx;
    public AudioClip WinningSound;
    // Start is called before the first frame update
    public void PlayWinAudio()
    {
        GameSoundFx.PlayOneShot(WinningSound);
    }
    
}

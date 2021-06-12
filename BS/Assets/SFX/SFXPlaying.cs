using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaying : MonoBehaviour
{
    public AudioSource Bounce;
    public AudioSource Hit;
    
    public void PlayBounce()
    {
        Bounce.Play();
    }
    public void PlayHit()
    {
        Hit.Play();
    }
}

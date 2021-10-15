using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {
    public bool Sapivangas;
    public AudioSource[] AudioS;
    public bool questBegin;
    public bool danger;
    public bool questDeliver;
    public Animator porta;

    public void PlayHiveTheme()
    {
        AudioS[1].Stop();
        AudioS[0].Stop();
        AudioS[2].Stop();
        AudioS[3].Play();
    }


    void Update ()
    {//MUDAR ISSO TUDO! PRA Q UPDATE MEU DEUS

        if (AudioS[2].isPlaying)
        {
            AudioS[1].Stop();
            AudioS[0].Stop();
        }
		if (Sapivangas)
        {
            Sapivangas = false;
            AudioS[0].Stop();
            
            AudioS[1].Play();
        }
        if (questBegin)
        {
            questBegin = false;
            AudioS[1].Stop();
            AudioS[0].Play();
        }
        if (danger)
        {
            danger = false;
            porta.SetBool("Close", true);
            AudioS[1].Stop();
            AudioS[0].Stop();
            if (!AudioS[2].isPlaying)
            {
                AudioS[2].Play();
            }
            
        }
        if (questDeliver)
        {
            questBegin = false;
            if (!AudioS[1].isPlaying)
            {
                AudioS[1].Play();
                AudioS[0].Stop();
                AudioS[2].Stop();
            }
            
        }
        
    }

    public void PlayDangerTheme()
    {
        AudioS[0].Stop();
        AudioS[2].Play();
        AudioS[1].Stop();
        AudioS[3].Stop();
        AudioS[4].Stop();
    }

    public void PlayIntroTheme()
    {
        AudioS[0].Play();
        AudioS[3].Stop();
        AudioS[2].Stop();
        AudioS[1].Stop();
        AudioS[4].Stop();
    }
    public void PlayOgreTheme()
    {
        AudioS[0].Stop();
        AudioS[3].Stop();
        AudioS[2].Stop();
        AudioS[1].Stop();
        AudioS[4].Play();
    }
    public void StopOgreTheme()
    {
        AudioS[0].Stop();
        AudioS[3].Stop();
        AudioS[2].Play();
        AudioS[1].Stop();
        AudioS[4].Stop();
    }
    public void StopDangerStartOgre()
    {
        AudioS[0].Stop();
        AudioS[3].Stop();
        AudioS[2].Stop();
        AudioS[1].Stop();
        AudioS[4].Play();
    }
}

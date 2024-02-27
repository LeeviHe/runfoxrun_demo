using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundEffects : MonoBehaviour {

    public AudioSource mainMenuMusic;
    public AudioSource levelMusic;
    public AudioSource deathSong;

    public bool MainMenuSong = false;
    public bool LevelSong = false;
    public bool DeathSong = false;

    public void MainMenuMusic()
    {
        if (deathSong.isPlaying) 
        { 
            deathSong.Stop();
        }
        if (!mainMenuMusic.isPlaying && MainMenuSong == false) 
        { 
            mainMenuMusic.Play();
            MainMenuSong = true;
        }
        else if (MainMenuSong == false) 
        {
            mainMenuMusic.Play();
            MainMenuSong = true;
        } 
    }

    public void LevelMusic()
    {
        if (mainMenuMusic.isPlaying) 
        { 
            mainMenuMusic.Stop();
        }
        if (!levelMusic.isPlaying && LevelSong == false)
        {
            levelMusic.Play();
            LevelSong = true;
        }

    }

    public void DeathSound()
    {
        if (levelMusic.isPlaying) 
            LevelSong = false;
        { 
            levelMusic.Stop();
        }  
        if (!deathSong.isPlaying && DeathSong == false)
        {
            deathSong.Play();
            DeathSong = true;
        }

    }
}

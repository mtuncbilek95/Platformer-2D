using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject LoopMusic;
    [SerializeField] private GameObject SFXMusic;

    public static AudioClip playerTakeDamage, jumpSound, playerHitDamage, swing, winTheGame, dead;
    public static AudioClip gameSong, menuSong;
    static AudioSource sfxSource;
    static AudioSource loopSource;

    private void Start()
    {
        playerTakeDamage = Resources.Load<AudioClip>("GameSFX/DamageTaken");
        jumpSound = Resources.Load<AudioClip>("GameSFX/Jump");
        playerHitDamage = Resources.Load<AudioClip>("GameSFX/Attack");
        swing = Resources.Load<AudioClip>("GameSFX/Swing");
        winTheGame = Resources.Load<AudioClip>("GameSFX/WinTheGame");
        dead = Resources.Load<AudioClip>("GameSFX/Dead");

        gameSong = Resources.Load<AudioClip>("GameMusic/gameSong1");
        menuSong = Resources.Load<AudioClip>("GameMusic/menuSong");
        sfxSource = SFXMusic.GetComponent<AudioSource>();
        loopSource = LoopMusic.GetComponent<AudioSource>();

        SoundManagerScript.PlayLoop("gameSong1");
    }

    public static void PlayLoop(string sound)
    {
        switch (sound)
        {
            case "gameSong1":
                loopSource.Stop();
                loopSource.clip = gameSong;
                loopSource.Play();
                break;
            case "menuSong":
                loopSource.Stop();
                loopSource.clip = menuSong;
                loopSource.Play();
                break;
        }
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "damageTaken":
                sfxSource.PlayOneShot(playerTakeDamage);
                break;
            case "jump":
                sfxSource.PlayOneShot(jumpSound);
                break;
            case "attack":
                sfxSource.PlayOneShot(playerHitDamage);
                break;
            case "swing":
                sfxSource.PlayOneShot(swing);
                break;
            case "winTheGame":
                loopSource.Stop();
                sfxSource.PlayOneShot(winTheGame);
                break;
            case "dead":
                loopSource.Stop();
                sfxSource.PlayOneShot(dead);
                break;

        }
    }
}

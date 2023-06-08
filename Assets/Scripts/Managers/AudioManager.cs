using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip GameLoop,BuffMusic;
    public AudioClip HitSound1,HitSound2,GameOverSound,EnemyHitSound,PanelSound,ButtonSound,OpeningSound,NextRoundSound;

    AudioSource musicSource,effectSource;

    private bool hit;

    private void Start() {
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = GameLoop;
        //musicSource.Play();
        effectSource = gameObject.AddComponent<AudioSource>();
        effectSource.volume=0.4f;
        effectSource.PlayOneShot(OpeningSound);
    }

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnTargetHit,OnHit);
        EventManager.AddHandler(GameEvent.OnGameOver,OnGameOver);
        EventManager.AddHandler(GameEvent.OnEnemyHit,OnEnemyHit);
        EventManager.AddHandler(GameEvent.OnPanelChange,OnPanelChange);
        EventManager.AddHandler(GameEvent.OnButtonPressed,OnButtonPressed);
        EventManager.AddHandler(GameEvent.OnNextRound,OnNextRound);
    }
    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnTargetHit,OnHit);
        EventManager.RemoveHandler(GameEvent.OnGameOver,OnGameOver);
        EventManager.RemoveHandler(GameEvent.OnEnemyHit,OnEnemyHit);
        EventManager.RemoveHandler(GameEvent.OnPanelChange,OnPanelChange);
        EventManager.RemoveHandler(GameEvent.OnButtonPressed,OnButtonPressed);
        EventManager.RemoveHandler(GameEvent.OnNextRound,OnNextRound);
    }

    void OnHit()
    {
        hit=!hit;
        if(hit)
            effectSource.PlayOneShot(HitSound1);
        else
            effectSource.PlayOneShot(HitSound2);
        //effectSource.PlayOneShot(HitSound2);
    }

    void OnGameOver()
    {
        effectSource.PlayOneShot(GameOverSound);
    }

    void OnEnemyHit()
    {
        effectSource.PlayOneShot(EnemyHitSound);
    }
    
    void OnPanelChange()
    {
        effectSource.PlayOneShot(PanelSound);
    }

    void OnButtonPressed()
    {
        effectSource.PlayOneShot(ButtonSound);
    }

    void OnNextRound()
    {
        effectSource.PlayOneShot(NextRoundSound);
    }

    

}

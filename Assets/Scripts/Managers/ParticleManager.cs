using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public List<ParticleSystem> textParticles=new List<ParticleSystem>();

    private int index;

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnTargetHit,OnTargetHit);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnTargetHit,OnTargetHit);
    }

    private void OnTargetHit()
    {
        MakeRandomIndex();
        textParticles[index].Play();
    }

    private int MakeRandomIndex()
    {
        index=Random.Range(0,textParticles.Count);
        return index;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyTrigger : Obstacable
{
    [SerializeField] private ParticleSystem hitParticle;

    [SerializeField] private int health;
    [SerializeField] private Animator animator;
    [SerializeField] private SkinnedMeshRenderer meshRenderer;


    public PlayerData playerData;

    private void Start() 
    {
        SetRigidbodyState(true);
        SetColliderState(false);
        
    }
    internal override void DoAction(PlayerTrigger player)
    {
        EventManager.Broadcast(GameEvent.OnEnemyHit);
        hitParticle.Play();

        if(health<=0)
        {
            transform.DOLocalJump(new Vector3(transform.position.x,transform.position.y,transform.position.z+3),5,1,.5f).OnComplete(()=>{
                animator.enabled=false;
                SetRigidbodyState(false);
                SetColliderState(true);
                EventManager.Broadcast(GameEvent.OnEnemyDead);
                //Havai fisek kutlama filan.
                //Bar sistemi eklenecek. Saglik olayi.
            });
            meshRenderer.material.color=Color.grey;
            animator.SetTrigger("Hit");
        }

        else
        {
            health-=playerData.DamageAmount;
            
            animator.SetTrigger("OneHit");
        }
    }

    

    private void SetRigidbodyState(bool state)
    {
        Rigidbody[] rigidbodies=GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic=state;
        }

        GetComponent<Rigidbody>().isKinematic=!state;
    } 

    private void SetColliderState(bool state)
    {
        Collider[] colliders=GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled=state;
        }

        GetComponent<Collider>().enabled=!state;
    } 
}

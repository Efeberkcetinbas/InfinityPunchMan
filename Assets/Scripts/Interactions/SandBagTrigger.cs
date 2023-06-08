using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using TMPro;
public class SandBagTrigger : Obstacable
{
    [SerializeField] private GameObject particleEffect;

    [SerializeField] private float duration;

    private Vector3 oldScale;
    
    [SerializeField] private Transform particlePos;
    [SerializeField] private Transform pointPos;


    [SerializeField] private GameObject increaseScorePrefab;

    [SerializeField] private GameData gameData;

    [SerializeField] private Camera mainCam;



    


    private void Start() 
    {
        oldScale=transform.localScale;
    }
    internal override void DoAction(PlayerTrigger player)
    {
        transform.DOLocalMoveZ(transform.position.z+5,duration).OnComplete(()=>gameObject.SetActive(false));
        //transform.DOLocalRotate();
        //transform.DOScale(oldScale/3f,duration);
        //EventManager.Broadcast(GameEvent.OnTargetHit);
        Instantiate(particleEffect,particlePos.position,Quaternion.identity);
        StartCoinMove(gameObject);
        
        
    }

    

    private void StartCoinMove(GameObject a)
    {
        GameObject coin=Instantiate(increaseScorePrefab,pointPos.transform.position,increaseScorePrefab.transform.rotation);
        coin.transform.DOLocalJump(coin.transform.localPosition,1,1,1,false);
        //coin.transform.DOScale(Vector3.zero,1.5f);
        coin.transform.GetChild(0).GetComponent<TextMeshPro>().text=" + " + gameData.multipleDamageAmount.ToString();
        coin.transform.GetChild(0).GetComponent<TextMeshPro>().DOFade(0,1.5f).OnComplete(()=>coin.transform.GetChild(0).gameObject.SetActive(false));
        coin.transform.LookAt(mainCam.transform.position);
        Destroy(coin,2);
    }
}

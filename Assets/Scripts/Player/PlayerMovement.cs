using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerMovement : MonoBehaviour
{
    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnTouchScreen,OnTouchScreen);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnTouchScreen,OnTouchScreen);
    }

    private void OnTouchScreen()
    {
        transform.DOMoveZ(transform.position.z+5,1).OnComplete(()=>EventManager.Broadcast(GameEvent.OnMoveFinish));
    }
}

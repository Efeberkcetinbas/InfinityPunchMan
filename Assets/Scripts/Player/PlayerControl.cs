using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerControl : MonoBehaviour
{
    private Vector3 firstPosition;
    private Vector3 lastPosition;



    public PlayerData playerData;

    [SerializeField] private Transform rightGlove,leftGlove;

    [SerializeField] private PowerBar powerBar;


    private bool isLeft;




    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnMoveFinish,OnMoveFinish);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnMoveFinish,OnMoveFinish);
    }

   
    

    void Update()
    {
        CheckMove();
    }

    private void OnMoveFinish()
    {
        playerData.playerCanMove=true;
    }

    private void CheckMove()
    {

        if(Input.touchCount>0 && playerData.playerCanMove)
        {
            Touch touch=Input.GetTouch(0);
            if(touch.phase==TouchPhase.Began)
            {
                firstPosition=touch.position;
                lastPosition=touch.position;
                Debug.Log("PUNCH");
                powerBar.GetThePoint();
                playerData.playerCanMove=false;
                EventManager.Broadcast(GameEvent.OnTouchScreen);
                //Paneli set Active False yap sonra da acilinca playercanMove true yap event ile

            }

            else if(touch.phase==TouchPhase.Moved)
            {
                lastPosition=touch.position;
            }

            else if(touch.phase==TouchPhase.Ended)
            {
                lastPosition=touch.position;
                

                if(Mathf.Abs(lastPosition.x-firstPosition.x)>Mathf.Abs(lastPosition.y-firstPosition.y))
                {
                    if(lastPosition.x>firstPosition.x)
                    {
                        //Right
                    }
                    else
                    {
                        //Left
                    }
                }

                else
                {
                    if(lastPosition.y>firstPosition.y)
                    {
                        //Up
                    }
                    
                    else if(lastPosition.x==firstPosition.x && lastPosition.y==firstPosition.y)
                    {
                        //Center
                    }
                    else 
                    {
                        //Down
                    }
                    
                }
            }
        }
    }
}

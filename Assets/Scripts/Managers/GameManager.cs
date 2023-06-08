using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameData gameData;
    public PlayerData playerData;

    [SerializeField] private GameObject FailPanel;
    [SerializeField] private Ease ease;

    public float InitialDifficultyValue;

    [SerializeField] private GameObject PowerBar;


    private void Awake() 
    {
        ClearData();
    }

    

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnIncreaseScore, OnIncreaseScore);
        EventManager.AddHandler(GameEvent.OnUpdateGameOverManager,OnGameOver);
        EventManager.AddHandler(GameEvent.OnMoveFinish,OnMoveFinish);
        EventManager.AddHandler(GameEvent.OnTouchScreen,OnTouchScreen);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnIncreaseScore, OnIncreaseScore);
        EventManager.RemoveHandler(GameEvent.OnUpdateGameOverManager,OnGameOver);
        EventManager.RemoveHandler(GameEvent.OnMoveFinish,OnMoveFinish);
        EventManager.RemoveHandler(GameEvent.OnTouchScreen,OnTouchScreen);
    }
    
    void OnGameOver()
    {
        FailPanel.SetActive(true);
        FailPanel.transform.DOScale(Vector3.one,1f).SetEase(ease);
        playerData.playerCanMove=false;
        gameData.isGameEnd=true;

        if(gameData.score>gameData.highScore)
        {
            gameData.highScore=gameData.score;
            PlayerPrefs.SetInt("highscore",gameData.highScore);
        }

        EventManager.Broadcast(GameEvent.OnUpdateGameOverUI);
    }
    
    private void OnMoveFinish()
    {
        PowerBar.SetActive(true);
    }

    private void OnTouchScreen()
    {
        PowerBar.SetActive(false);
    }

    void OnIncreaseScore()
    {
        DOTween.To(GetScore,ChangeScore,gameData.score+gameData.increaseScore,.25f).OnUpdate(UpdateUI);
        CheckScore();
    }

    private int GetScore()
    {
        return gameData.score;
    }

    private void ChangeScore(int value)
    {
        gameData.score=value;
    }

    private void UpdateUI()
    {
        EventManager.Broadcast(GameEvent.OnUpdateUI);
    }

    private void CheckScore()
    {
        /*if(gameData.score>500)
            EventManager.Broadcast(GameEvent.OnShuffle);*/
        //Effect
    }

    
    void ClearData(){
        gameData.increaseScore=25;
        gameData.highScore=PlayerPrefs.GetInt("highscore");
        gameData.score = 0;
        gameData.isGameEnd=true;
        gameData.TotalDamageAmount=0;

        //Acilis Panelinde Touch To Start Yaptigimizda olsun bu
        playerData.playerCanMove=true;
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(0);
    }
}

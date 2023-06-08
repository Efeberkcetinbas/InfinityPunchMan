using UnityEngine;

[CreateAssetMenu(fileName = "New GameData", menuName = "Data/Game Data", order = 1)]
public class GameData : ScriptableObject
{
    public int score = 0;
    public int highScore=0;
    public int increaseScore=25;
    public int increaseDamageAmount=20;

    public float TotalDamageAmount=0;

    public bool isGameEnd=false;



}

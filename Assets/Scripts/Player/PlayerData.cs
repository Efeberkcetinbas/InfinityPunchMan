using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "Data/Player Data", order = 0)]
public class PlayerData : ScriptableObject
{
    public float speed = 10f;
    public bool isInvulnerable = false;
    public bool playerCanMove=true;

    public int DamageAmount=1;
}

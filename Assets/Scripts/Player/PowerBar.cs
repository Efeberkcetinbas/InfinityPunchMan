using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI powerToShow;
    [SerializeField] private TextMeshProUGUI totalPower;
    [SerializeField] private Transform Hand;
    [SerializeField] private Animator handAnim;
    public GameData gameData;

    private void Start() 
    {
        handAnim=GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("RewardNo"))
        {
            var multiplier=other.gameObject.name;
            powerToShow.text=(gameData.increaseDamageAmount*float.Parse(multiplier)).ToString();
            PlayerPrefs.SetFloat("reward",float.Parse(powerToShow.text));
        }
        //https://www.youtube.com/watch?v=TRUOqUGAfLM
        //yukaridaki link ile dotween baglantisini saglayabilirsin
    }

    public void GetThePoint()
    {
        handAnim.enabled=false;
        gameData.TotalDamageAmount+=PlayerPrefs.GetFloat("reward");
        totalPower.text=gameData.TotalDamageAmount.ToString();
        //Debug.Log(gameData.TotalDamageAmount);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float currentTime;
    [SerializeField] private float timeToCalc;
    public bool isCounting = true;
    [SerializeField] TMP_Text textComponent;
    
    void Start()
    {
        currentTime = timeToCalc + 1;        
    }

   
    void Update()
    {
        if (GameManager.playGame && isCounting && currentTime >= 0)
        {
            currentTime -= 1 * Time.deltaTime;
            textComponent.text = ("TIME : " + (int)currentTime + " S");
        }

        if (currentTime < 0)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.BroadcastMessage("CheckIfEndOfGame", SendMessageOptions.DontRequireReceiver);
        }

        if (GameManager.endOfGame)
        {
            isCounting = false;
            textComponent.text = ("");
        }

    }

    public int TimeStamp()
    {
        return (int)currentTime;
    }

    public void ResetTimer()
    {
        currentTime = timeToCalc + 1;
    }


}

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
        if (isCounting && currentTime >= 0)
        {
            currentTime -= 1 * Time.deltaTime;
            textComponent.text = ("TIME : " + (int)currentTime + " S");
        }

        if (currentTime < 0)
        {
            GameManager.win = false;
            GameManager.playGame = false;
        }

        if (!GameManager.playGame)
        {
            isCounting = false;
            textComponent.text = ("");
        }

    }

    public int TimeStamp()
    {
        return (int)currentTime;
    }


}

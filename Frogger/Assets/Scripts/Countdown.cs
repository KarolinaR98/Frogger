using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] TMP_Text countdownTXT;
    [SerializeField] GameObject countdownTXT_;
    private float startTime;
    void Start()
    {
        startTime = 4;
    }

    void Update()
    {
        if(startTime >= 0)
        {
            startTime -= 1 * Time.deltaTime;
            countdownTXT.text = (((int)startTime).ToString());
        }
        if (startTime <= 0)
        {
            GameManager.playGame = true;
            countdownTXT_.SetActive(false);
        }
        
    }
}

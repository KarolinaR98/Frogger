using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndOfGamePanel : MonoBehaviour
{
    [SerializeField] GameObject endOfGamePanel;
    [SerializeField] TMP_Text endOfGameText;

    private void Update()
    {
        if (GameManager.endOfGame)
        {
            endOfGamePanel.SetActive(true);

            if (GameManager.win)
            {
                endOfGameText.text = ("Wygrałeś!\nZdobyte punkty: " + GameManager.points);
            }
            else
            {
                endOfGameText.text = ("GAME OVER!");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    [SerializeField] TMP_Text pointsText;


    void Update()
    {
        pointsText.text = ("Points : " + GameManager.points);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePoints : MonoBehaviour
{
    [SerializeField] List<Image> lifePoints;

    private void Update()
    {
        if (GameManager.endOfGame)
        {
            HideLifePoints();
        }
    }
    void DeleteLifePoint()
    {
        int numOfLivePoints = lifePoints.Count;
        if(numOfLivePoints > 0)
        {
            lifePoints[numOfLivePoints -1].enabled = false;
            lifePoints.RemoveAt(numOfLivePoints - 1);
        }
           
    }

    void HideLifePoints()
    {
        int numOfLivePoint = lifePoints.Count;
        for(int i = numOfLivePoint - 1; i >= 0; i--)
        {
            lifePoints[i].enabled = false;
        } 
    }
}

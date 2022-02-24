using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsBorder : MonoBehaviour
{
    private int triggerCounter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            triggerCounter++;
        }
    }

    public void ResetPoints()
    {
        triggerCounter = 0;
    }

    public void UpdatePoints()
    {
        if(triggerCounter == 1)
        {
            GameManager.points += 10;
        }
    }
}

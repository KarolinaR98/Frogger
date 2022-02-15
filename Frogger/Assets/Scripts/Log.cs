using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Car
{
    [SerializeField] private bool canDive;
    [SerializeField] private float minRandomValue;
    [SerializeField] private float maxRandomValue;
    [SerializeField] private float divingTime;

    



    protected override void Start()
    {
        base.Start();

    }
    protected override void Update()
    {
        base.Update();
        
        
    }

    private protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

    private void Dive()
    { }

    }

}

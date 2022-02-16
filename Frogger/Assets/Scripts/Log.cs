using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Car
{
    [SerializeField] private bool canDive;
    [SerializeField] private float divingTime;
    [SerializeField] private float randomMinValue;
    [SerializeField] private float randomMaxValue;

    Renderer rend;
    BoxCollider2D collider2D_;

    protected override void Start()
    {
        base.Start();

        if (canDive)
        {
            rend = GetComponentInChildren<Renderer>();
            collider2D_ = GetComponent<BoxCollider2D>();
            StartCoroutine("Dive");
            
        }

    }

    protected override void Update()
    {
        base.Update();
    }

    private protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }

   IEnumerator Dive()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0f, 1.5f));
            StartCoroutine("FadeOut");
            collider2D_.enabled = false;
            yield return new WaitForSeconds(divingTime);
            StartCoroutine("FadeIn");
            collider2D_.enabled = true;
            yield return new WaitForSeconds(Random.Range(randomMinValue, randomMaxValue));
        }
           

    }

    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1f; f += 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }

    }

 


    

}

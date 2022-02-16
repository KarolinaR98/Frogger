using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool right;
    Vector3 scale;


    protected virtual void Start()
    {
        if (right)
        {
            scale = GetComponentInChildren<Transform>().localScale;
            GetComponentInChildren<Transform>().localScale = new Vector3(-scale.x, scale.y, scale.z);
        }
    }

    protected virtual void Update()
    {
        if (right)
        {
            
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
    }

    protected virtual private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}

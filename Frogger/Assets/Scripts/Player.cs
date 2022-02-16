using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    [SerializeField] private float speed;

    [SerializeField] float leftBorder;
    [SerializeField] float rightBorder;
    [SerializeField] float bottomBorder;

    private bool isMoving;
    private Vector3 currentpos;
    private Vector3 origPos;
    private Vector3 targetPos;
    private float timeToMove = 0.2f;
    


    void Start()
    {
       
    }

  
    void Update()
    {
        currentpos = transform.position;

        //Movement
        if (Input.GetKey("up") && !isMoving)
            StartCoroutine(MovePlayer(Vector3.up));

        if (Input.GetKey("left") && !isMoving)
            if (currentpos.x > leftBorder)
            {
                StartCoroutine(MovePlayer(Vector3.left));
            }            

        if (Input.GetKey("down") && !isMoving)
            if(currentpos.y > bottomBorder)
            {
                StartCoroutine(MovePlayer(Vector3.down));
            }            

        if (Input.GetKey("right") && !isMoving)
            if(currentpos.x < rightBorder)
            {
                StartCoroutine(MovePlayer(Vector3.right));
            }
            

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Tree")
        {
            transform.parent = collision.transform;
        }

        if(collision.gameObject.tag == "Car")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Water")
        {
            Debug.Log("Water");
        }

        if (collision.gameObject.tag == "Grass")
        {

        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Tree")
        {
            transform.parent = null;
        }
    }


    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0f;

        origPos = transform.position;
        targetPos = origPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    } 
}

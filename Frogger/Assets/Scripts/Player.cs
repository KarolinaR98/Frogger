using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    [SerializeField] private float speed;
    private bool isMoving;
    private Vector3 origPos;
    private Vector3 targetPos;
    private float timeToMove = 0.2f;


    void Start()
    {
        
    }

  
    void Update()
    {
        //Movement
        if (Input.GetKey("up") && !isMoving)
            StartCoroutine(MovePlayer(Vector3.up));

        if (Input.GetKey("left") && !isMoving)
            StartCoroutine(MovePlayer(Vector3.left));

        if (Input.GetKey("down") && !isMoving)
            StartCoroutine(MovePlayer(Vector3.down));

        if (Input.GetKey("right") && !isMoving)
            StartCoroutine(MovePlayer(Vector3.right));


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

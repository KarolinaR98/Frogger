using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    [SerializeField] float leftBorder;
    [SerializeField] float rightBorder;
    [SerializeField] float bottomBorder;

    private bool isMoving;
    private Vector3 currentpos;
    private Vector3 origPos;
    private Vector3 targetPos;
    private float timeToMove = 0;

    private float raycastDistance = 5;
    private bool isDone = false;

    private int numOfLives;
    private Vector3 setPlayer = new Vector3(0f,-2.5f, 0f);
    [SerializeField] GameObject playerPrefab;
    private GameObject canvas;

    private int attemptsStreet;
    private int attemotsRiver;


    void Start()
    {
        gameObject.transform.position = setPlayer;
        canvas = GameObject.Find("Canvas");
    }

  
    void Update()
    {
        currentpos = transform.position;

        
        if (Input.GetKeyDown("up") && !isMoving)
            StartCoroutine(MovePlayer(Vector3.up));

        if (Input.GetKeyDown("left") && !isMoving)
            if (currentpos.x > leftBorder)
            {
                StartCoroutine(MovePlayer(Vector3.left));
            }            

        if (Input.GetKeyDown("down") && !isMoving)
            if(currentpos.y > bottomBorder)
            {
                StartCoroutine(MovePlayer(Vector3.down));
            }            

        if (Input.GetKeyDown("right") && !isMoving)
            if(currentpos.x < rightBorder)
            {
                StartCoroutine(MovePlayer(Vector3.right));
            }

        Ray ray = new Ray(transform.position, new Vector3(0, 0, 1));
        RaycastHit hit;
        Debug.DrawRay(transform.position, new Vector3(0,0,1) * raycastDistance, Color.red);
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
           if(hit.collider.tag == "Water" && !isDone)
            {
                CheckIfEndOfGame();                
            }

           if(hit.collider.tag == "Tree")
            {
                transform.parent = hit.collider.transform;
            }
        }
        else if (isDone)
        {
            isDone = false;
        }
        else if (transform.parent != null)
        {
            transform.parent = null;
        }

        CheckBorders(currentpos);
        DestroyGameObject();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Car")
        {
            CheckIfEndOfGame();
        }

        if(collision.gameObject.tag == "Grass")
        {
            GameManager.points += canvas.GetComponent<Timer>().TimeStamp();
            CheckIfWin();
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

    private void CheckIfEndOfGame()
    {
        numOfLives--;
        canvas.BroadcastMessage("DeleteLifePoint", SendMessageOptions.DontRequireReceiver);
        if(numOfLives == -3)
        {
            GameManager.playGame = false;
            GameManager.win = false;
        }
        else
        {
            gameObject.transform.position = setPlayer;
        }
    }

    private void CheckBorders(Vector3 currentPos_)
    {
        if(currentPos_.x > rightBorder || currentPos_.x < leftBorder)
        {
            CheckIfEndOfGame();
        }
    }

    private void SpawnNewPlayer()
    {
        Instantiate(playerPrefab, setPlayer, transform.rotation);
    }

    private void CheckIfWin()
    {
        GameManager.frogOnGrass++;    
        if (GameManager.frogOnGrass == 3)
        {
            GameManager.win = true;
            GameManager.playGame = false;
        }
        else
        {
            SpawnNewPlayer();
            Destroy(GetComponent<Player>());
        }
    }
  
    private void DestroyGameObject()
    {
        if (!GameManager.playGame)
        {
            Destroy(gameObject);
        }
    }
}

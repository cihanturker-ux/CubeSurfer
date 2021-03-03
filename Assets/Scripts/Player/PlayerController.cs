using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    //public Vector3 move;
    Vector3 movementDelta;
    float mouseStart;
    public float horizontalSpeed;
    public float deadZone = 0.1f;
    Rigidbody rb;
    public int cubeCount;
    public GameObject prevCube;
    public GameObject artiBir;
    
    CoinsManager coinsManager;

    private Animator anim;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        coinsManager = FindObjectOfType<CoinsManager>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!GameManager.isStarted)
            return;
        movementDelta = Vector3.forward * speed;
        if (Input.GetMouseButtonDown(0))
        {
            mouseStart = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            float delta = Input.mousePosition.x - mouseStart;
            mouseStart = Input.mousePosition.x;
            if (Mathf.Abs(delta) <= deadZone)
            {
                delta = 0;
            }
            else
            {
                delta = Mathf.Sign(delta);
            }
            if (transform.position.x > 2.5f && delta > 0)
            {
                return;
            }
            else if (transform.position.x < -2.6f && delta < 0)
            {
                return;
            }
            movementDelta += Vector3.right * horizontalSpeed * delta;
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.isStarted)
            return;
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TakeCubes")
        {
            transform.GetChild(0).GetChild(cubeCount).gameObject.SetActive(true);
            cubeCount++;
            Debug.Log(cubeCount);
            other.gameObject.SetActive(false);

            Vector3 playerPos = transform.localPosition;
            playerPos.y += 1.2f;
            transform.localPosition = playerPos;
            Destroy(Instantiate(artiBir, transform.position, Quaternion.identity), 0.5f);

        }
        if (other.CompareTag("Coins"))
        {
            coinsManager.AddCoins(other.transform.position, 1);
            Destroy(other.gameObject);
        }
        if (other.tag == ("LevelEndZone") && cubeCount > 0)
        {
            if (cubeCount > 0)
            {
                cubeCount--;
                Debug.Log(cubeCount);
                transform.GetChild(0).GetChild(cubeCount).gameObject.SetActive(false);


                Vector3 playerPos = transform.localPosition;
                playerPos.y += 0.0002f;
                transform.localPosition = playerPos;

                if (cubeCount == 0)
                {
                    anim.Play("win");
                } 
            }
            else
            {
                GameManager.isStarted = false;
                
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ("DropCubes"))
        {
            if (cubeCount > 0)
            {
                cubeCount--;
                Debug.Log(cubeCount);
                transform.GetChild(0).GetChild(cubeCount).gameObject.SetActive(false);

                Vector3 playerPos = transform.localPosition;
                playerPos.y -= 1.2f;
                transform.localPosition = playerPos;
                if (cubeCount == 0)
                {
                    anim.Play("down");
                    GameManager.isStarted = false;
                }
            }
            else
            {
                GameManager.isStarted = false;
            }
        }
        
    }

    void Move()
    {
        //transform.Translate(move * Time.deltaTime);
        //rb.AddForce(transform.forward * speed * Time.deltaTime);
        //rb.MovePosition(rb.position + move * Time.deltaTime);
        rb.MovePosition(rb.position + movementDelta * Time.smoothDeltaTime);
    }
}

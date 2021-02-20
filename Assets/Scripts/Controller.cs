using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller instance;
    public float speed;
    public GameObject cubesParent;
    public GameObject prevCube;
    private int cubeCount = 0;

    private Rigidbody rb;
    //private bool isMoving = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || MobileInput.Instance.swipeLeft)
        {
            rb.velocity = Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.D) || MobileInput.Instance.swipeRight)
        {
            rb.velocity = Vector3.right * speed * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.W) || MobileInput.Instance.swipeUp)
        {
            rb.velocity = Vector3.forward * speed * Time.deltaTime;
        }
    }

    public void TakeCubes(GameObject cubes)
    {
        cubes.transform.SetParent(cubesParent.transform);
        Vector3 pos = prevCube.transform.localPosition;
        pos.y -= 1.1f;
        cubes.transform.localPosition = pos;
        cubeCount++;

        Vector3 playerPos = transform.localPosition;
        playerPos.y += 1.1f;
        transform.localPosition = playerPos;
        prevCube = cubes;

        prevCube.GetComponent<BoxCollider>().isTrigger = false;
    }

    public void DropCubes(GameObject cubes)
    {
        transform.GetChild(0).GetChild(cubeCount).parent = null;
        cubeCount--;
        Vector3 playerPos = transform.localPosition;
        playerPos.y -= 1.1f;
        transform.localPosition = playerPos;
        prevCube = cubes;
    }
}

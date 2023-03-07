using UnityEngine;

public class Spear : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody rb;
    public float throwForce;

    public bool playerOutput;
    public bool playerInput;
    public bool isAttached;
    public int obstaclesHit = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerInput = Input.GetMouseButton(0);
        playerOutput = Input.GetMouseButtonUp(0);
        if (playerController.isOnBlue == true)
        {
            if (playerInput)
            {
                throwForce = 10000;
            }
            else if (playerOutput)
            {
                playerController.playerAnimator.SetBool("hasThrown", true);
                playerController.moveLeft.GetComponent<MoveLeft>().enabled = false;
                transform.parent = null;
                gameObject.transform.position = new Vector3(0, 1.17f, 1);
                transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
                rb.isKinematic = false;
            }
        }

        else if (playerController.isOnYellow == true)
        {
            if (playerOutput)
            {
                playerController.playerAnimator.SetBool("hasThrown", true);
                playerController.moveLeft.GetComponent<MoveLeft>().enabled = false;
                transform.parent = null;
                gameObject.transform.position = new Vector3(0, 1.17f, 1);
                transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
                rb.isKinematic = false;
                throwForce = 30000;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (playerController.isOnBlue == true && playerController.isOnYellow == false)
            {
                obstaclesHit++;
                if (obstaclesHit == 3)
                {
                    Destroy(gameObject);
                }
                else
                {
                    rb.AddForce(Vector3.forward * throwForce * Time.deltaTime, ForceMode.Impulse);
                }
            }

            if (playerController.isOnYellow == true && playerController.isOnBlue == false)
            {
                obstaclesHit++; 
                if (obstaclesHit == 6)
                {
                    Destroy(gameObject);
                }
                else
                {
                    rb.AddForce(Vector3.forward * throwForce * Time.deltaTime, ForceMode.Impulse);
                }
            }
            Destroy(gameObject, 6f);
        }
    }
}

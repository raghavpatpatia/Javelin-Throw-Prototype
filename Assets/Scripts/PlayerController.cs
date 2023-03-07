using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    public GameObject moveLeft;
    public bool isOnBlue = false;
    public bool isOnYellow = false;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAnimator.SetBool("hasFalled", true);
            moveLeft.GetComponent<MoveLeft>().enabled = false;
        }
        
        if (collision.gameObject.CompareTag("Blue"))
        {
            isOnBlue = true;
            isOnYellow = false;
        }
        
        else if (collision.gameObject.CompareTag("Yellow"))
        {
            isOnYellow = true;
            isOnBlue = false;
        }
    }
}

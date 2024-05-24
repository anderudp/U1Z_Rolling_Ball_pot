using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float jumpForce = 300f;
    public float sideSpeed = 5f;
    bool canJump = false;
    Rigidbody playerRb;
    Vector3 startPos = new Vector3(0f, 1f, 5f);

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Folyamatosan előre
        transform.Translate(0f, 0f, speed * Time.deltaTime);

        PcControls();
    }

    void VrControls()
    {
        
    }

    void PcControls()
    {
        transform.Translate(Input.GetAxis("Horizontal") * sideSpeed * Time.deltaTime, 0f, 0f);
        float jumpInput = Input.GetAxis("Jump");
        if(jumpInput > 0.2f && canJump)
        {
            canJump = false;
            playerRb.AddForce(0f, jumpInput * jumpForce, 0f);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag != "Bounds") canJump = true;
        if(other.gameObject.tag == "Obstacle")
        {
            playerRb.velocity = Vector3.zero;
            canJump = false;
            transform.position = startPos;
        }
        if(other.gameObject.tag == "Finish")
        {
            playerRb.velocity = Vector3.zero;
            canJump = false;
            transform.position = startPos;
        }
        if(other.gameObject.tag == "Bouncy")
        {
            canJump = false;
            playerRb.AddForce(0f, 600f, 0f);
        }
    }
}

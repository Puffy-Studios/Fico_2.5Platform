using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerRb;
    Animator dogAnim;
    [SerializeField] private float speed;
    [SerializeField] private float force;
    bool jump = true;
    bool side = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        dogAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetAxis("Horizontal") == 0)
        {
            dogAnim.SetBool("run", false);
            dogAnim.SetBool("run_reverse", false);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            dogAnim.SetBool("run", true);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            side = false;
            dogAnim.SetBool("run_reverse", true);
            
        }
        playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, Input.GetAxis("Horizontal") * speed);

        if (Input.GetKeyDown(KeyCode.Space) && jump)
        {
            jump = false;
            playerRb.AddForce(Vector3.up * force);
            dogAnim.SetTrigger("Jump");
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        jump = true;
    }

}

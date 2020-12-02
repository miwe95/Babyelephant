using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public float speed_ = 5.0f;
     Animator animator_;
     void Start()
    {
        //This gets the Animator, which should be attached to the GameObject you are intending to animate.
        animator_ = gameObject.GetComponent<Animator>();
        // The GameObject cannot jump

    }
	void Update ()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator_.SetBool("is_walking", false);
            speed_=20.0f;
            Vector3 playerMovement = new Vector3(hor, 0f, ver) * speed_ * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);
             if(hor != 0 || ver != 0)
                 animator_.SetBool("is_running", true);
             else
                 animator_.SetBool("is_running", false);
        }
        else
        {
            animator_.SetBool("is_running", false);
            speed_=5.0f;
            Vector3 playerMovement = new Vector3(hor, 0f, ver) * speed_ * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);
             if(hor != 0 || ver != 0)
                 animator_.SetBool("is_walking", true);
             else
                 animator_.SetBool("is_walking", false);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public float Speed = 5.0f;
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

        Vector3 playerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
        animator_.SetBool("is_running", true);
         if(hor != 0 || ver != 0)
            animator_.SetBool("is_running", true);

        else
            animator_.SetBool("is_running", false);

    }
}

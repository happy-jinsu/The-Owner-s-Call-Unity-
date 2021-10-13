using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{     // Update is called once per frame

    public bool IsJumping;
    void Update()
    {
        if(Input.GetKey (KeyCode.LeftArrow))  //왼쪽
        {
            if (!IsJumping)
            {
                this.transform.Translate(-0.1f, 0.0f, 0.0f);
            }

            else
            {
                return;
            }
        }

        if(Input.GetKey (KeyCode.RightArrow))  //오른쪽
        {
            if (!IsJumping)
            {
                this.transform.Translate(0.1f, 0.0f, 0.0f);
            }

            else
            {
                return;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }
    }
}

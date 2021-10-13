using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rigid;

    public int JumpPower;
    public bool IsJumping;

    // 처음 한번만 실행 되는 함수
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        IsJumping = false;
    }
    // 매 frame마다 실행 되는 함수
    void Update()
    {
        Jump();

        if (Input.GetKey(KeyCode.LeftArrow))  //왼쪽
        {
            if (IsJumping==false)
            {
                this.transform.Translate(-0.1f, 0.0f, 0.0f);
            }

            else
            {
                return;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))  //오른쪽
        {
            if (IsJumping == false)
            {
                this.transform.Translate(0.1f, 0.0f, 0.0f);
            }

            else
            {
                return;
            }
        }
    }

    void Jump()
    {
   
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!IsJumping)
            {
                IsJumping = true;
                rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
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
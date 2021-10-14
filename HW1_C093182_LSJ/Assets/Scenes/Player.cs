using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (IsJumping==false)       //점프 중에는 이동 불가
            {
                // rigid.AddForce(Vector3.left * 0.5f, ForceMode.Impulse);  // 포물선을 그리는 점프 가능
                this.transform.Translate(-0.1f, 0.0f, 0.0f);
            }

            else
            {
                return;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))  //오른쪽
        {
            if (IsJumping == false)     //점프 중에는 이동 불가
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
            if(!IsJumping)     //땅에 닿았을 때만 다시 점프 가능
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

    private void OnCollisionEnter(Collision collision)       // 땅에 닿지 않으면 점프 불가
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }

        if (collision.gameObject.CompareTag("Obstacles"))
        {
            SceneManager.LoadScene("Main");
        }

    }
}
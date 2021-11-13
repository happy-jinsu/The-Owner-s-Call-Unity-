using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesJump : MonoBehaviour
{
    public Rigidbody rigid;
    public float speed;                  // 방해물이 이동 할 속도. public으로 밖에서 조정.
    public float movepos;                // 방해물을 이동 시킬 거리. public으로 밖에서 조정.
    public bool arrival;         // 도착 여부 판단. 
    bool isjump;
    float time;
    Vector3 targetPoint;                 // 이동 할 타겟 지점.
    Vector3 startPoint;                  // 돌아올 지점.(원래 위치)

    private void Start()
    {
        time = 0;
        isjump = false;
        arrival = false;
        targetPoint = new Vector3(transform.position.x + movepos, transform.position.y, transform.position.z);  // 이동 할 타겟 지점의 위치.
        startPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);           // 돌아올 지점 위치 기억. (원래 자리)
    }

    void Update()
    {
        time += Time.deltaTime;

        if (transform.position.x == targetPoint.x)      // x값이 이동 타겟 지점의 x값과 같을 경우, 도착 했다고 표시.
            arrival = true;

        if (transform.position.x == startPoint.x)       // x값이 원래 자리의 x값과 같을 경우, 도착하지 않았다고 표시. -> 왕복 이동을 위함.
            arrival = false;

        if (isjump == false && arrival == false)     // 도착하지 않았다고 하면 타겟 지점까지 계속 이동.
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed);
        }

        if (isjump == false && arrival == true)     // 도착 했다고 하면 원래 자리까지 계속 이동.
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint, speed);
        }

        if (time > 3f)     //땅에 닿았을 때만 다시 점프 가능
        {
            isjump = true;
            rigid.AddForce(Vector3.up * 25, ForceMode.Impulse);
            time = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)       // 땅에 닿지 않으면 점프 불가
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isjump = false;
        }
    }

}
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 5.0f;


    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, v, 0);

        //transform.translate

        transform.position += dir * speed * Time.deltaTime;

        // 물체의 이동 공식
        // P = P0 + vt
        // 미래의 위치 = 현재의 위치 + 속도 * 시간

        // 등가속도 운동
        // V = V0 + AT
        // 속도 = 현재속도 + 가속도 * 시간

        // 가속도
        // F = ma
        // 힘 = 질량 * 가속도


    }

 
}

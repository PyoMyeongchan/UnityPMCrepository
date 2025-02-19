using System;
using UnityEngine;



public class Monster : Character
{
    
    public float monsterSpeed;
    public float rate = 1f;

    protected override void Start()
    { 
        base.Start();
    
    }


    //액션 확인 코드
    public void MonsterSample()
    {
        Debug.Log("몬스터가 생성되었습니다.");
    }

    // Update is called once per frame
    void Update()
    {
        // 영점 기준으로 시선 변경
        transform.LookAt(Vector3.zero); 

        // 간격 설정
        float tagetDistance = Vector3.Distance(transform.position, Vector3.zero);

        if (tagetDistance <= rate) // 간격 거리와 가까워지면 이동 중지
        {
            SetMotionChange("isWalk", false);

        }
        else // 일반적인 경우에는 움직임을 진행
        {
            // 영점으로 몬스터의 속도만큼 앞으로 이동합니다.
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, Time.deltaTime * monsterSpeed);

            SetMotionChange("isWalk", true);

        }
       

    }


}

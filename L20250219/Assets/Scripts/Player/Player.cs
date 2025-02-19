using UnityEngine;

public class Player : Character
{
    Vector3 startPosition;
    Quaternion rotation;

    protected override void Start()
    {
        // 캐릭터 클래스의 Start 시작
        base.Start();
        // 시작 값 설정
        startPosition = transform.position;
        rotation = transform.rotation;
    }

    


    void Update()
    {
        if (target == null)
        {
            // 가까운 타켓 조사
            TargetSearch(Spawner.monsterList.ToArray());

            // 리스트명.ToArray()를 통해 List -> array

            float position = Vector3.Distance(transform.position, startPosition);

            if (position > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPosition, Time.deltaTime * 2.0f);
                transform.LookAt(startPosition);
                SetMotionChange("isWalk", true);
            }
            else
            { 
                transform.rotation = rotation;
                SetMotionChange("isWalk", false);
            }
            return; // 작업종료
                    
        }
        
        float distance = Vector3.Distance(transform.position,target.position);

        // 타켓 범위보다 작으면서 공격 범위보다 높은 경우
        if (distance <= targetRange && distance > attackRange)
        {
            SetMotionChange("isWalk", true);
            // 타켓 지점으로 이동
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * 2.0f);
        }
        // 공격 범위 안에 들어온 경우
        else if (distance <= attackRange)
        {
            //공격 자세로 넘어갑니다.
            SetMotionChange("isAttack", true);
        
            
        }

    }
}

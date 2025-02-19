using UnityEngine;

public class Player : Character
{
    Vector3 startPosition;
    Quaternion rotation;

    protected override void Start()
    {
        // ĳ���� Ŭ������ Start ����
        base.Start();
        // ���� �� ����
        startPosition = transform.position;
        rotation = transform.rotation;
    }

    


    void Update()
    {
        if (target == null)
        {
            // ����� Ÿ�� ����
            TargetSearch(Spawner.monsterList.ToArray());

            // ����Ʈ��.ToArray()�� ���� List -> array

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
            return; // �۾�����
                    
        }
        
        float distance = Vector3.Distance(transform.position,target.position);

        // Ÿ�� �������� �����鼭 ���� �������� ���� ���
        if (distance <= targetRange && distance > attackRange)
        {
            SetMotionChange("isWalk", true);
            // Ÿ�� �������� �̵�
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * 2.0f);
        }
        // ���� ���� �ȿ� ���� ���
        else if (distance <= attackRange)
        {
            //���� �ڼ��� �Ѿ�ϴ�.
            SetMotionChange("isAttack", true);
        
            
        }

    }
}

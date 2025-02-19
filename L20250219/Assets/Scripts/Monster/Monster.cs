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


    //�׼� Ȯ�� �ڵ�
    public void MonsterSample()
    {
        Debug.Log("���Ͱ� �����Ǿ����ϴ�.");
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �������� �ü� ����
        transform.LookAt(Vector3.zero); 

        // ���� ����
        float tagetDistance = Vector3.Distance(transform.position, Vector3.zero);

        if (tagetDistance <= rate) // ���� �Ÿ��� ��������� �̵� ����
        {
            SetMotionChange("isWalk", false);

        }
        else // �Ϲ����� ��쿡�� �������� ����
        {
            // �������� ������ �ӵ���ŭ ������ �̵��մϴ�.
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, Time.deltaTime * monsterSpeed);

            SetMotionChange("isWalk", true);

        }
       

    }


}

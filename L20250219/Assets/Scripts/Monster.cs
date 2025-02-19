using System;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class Monster : MonoBehaviour
{
    Animator animator;
    public float monsterSpeed;
    public float rate = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();   
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

    private void SetMotionChange(string motionName, bool parma)
    {
        animator.SetBool(motionName,parma);
    }
}

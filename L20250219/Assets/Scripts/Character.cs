using UnityEngine;


[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    Animator animator;

    // �Ϲ����� ��ġ�� ������ ü���̳� ���ݷ� ���� ��ġ�� �ſ� ���� �� ����.
    public double hp;
    public double atk;

    // ���ݼӵ��� �ʹ� ������ ������ �� �� ����.
    public float attackSpeed;

    // ���� ����
    protected float attackRange = 3.0f;
    
    // Ÿ�Ͽ� ���� ����
    protected float targetRange = 5.0f;

    // Ÿ�Ͽ� ���� ����(��ġ)
    protected Transform target; 

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected void SetMotionChange(string motionName, bool parma)
    {
        animator.SetBool(motionName, parma);
    }

    // animation event�� ���� ȣ��� �Լ�
    protected virtual void Arrow()
    {
        Debug.Log("�߻�");
    
    
    }



 
    // Ÿ���� ã�� ���
    protected void TargetSearch<T>(T[] targets) where T : Component
    {
        var units = targets; // ���޹��� ���� ���� �Ҵ�
        Transform closet = null; // ���� ����� ���� ���� null
        float maxDistance = targetRange; // �ִ� �Ÿ� == Ÿ���� �Ÿ�

        // Ÿ�ϵ� ��ü�� ������� �Ÿ��� üũ�մϴ�.
        foreach (var unit in units)
        {
            // ������ �Ÿ� üũ
            float distance = Vector3.Distance(transform.position, unit.transform.position);

            // Ÿ�� �Ÿ����� ������ ���� ����� ��

            if (distance > maxDistance)
            {
                closet = unit.transform;
                maxDistance = distance;
            }                        
        }
        // Ÿ�� ����
        target = closet;

        // Ÿ���� �����մϴ�.
        if (target != null)
        { 
            transform.LookAt(target.position); 
        }



    }

}

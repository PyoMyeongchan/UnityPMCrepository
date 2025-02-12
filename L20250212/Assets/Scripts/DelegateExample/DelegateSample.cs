using UnityEngine;

public class DelegateSample : MonoBehaviour
{
    //��������Ʈ(delegate)
    //�Լ��� ������ �� �ִ� ����, �Ϲ������� �븮�ڶ�� �θ��ϴ�.
    //�ش� �������� �Լ��� ���ԵǾ� �����Ƿ�, �ش� ������ �����ϸ�
    //������ �Լ��� ����Ǵ� ����� ������ �ֽ��ϴ�.

    //���� ���
    // ���������� delegate Ÿ�� ��������Ʈ��(�Ű�����)

    delegate void DelegateTest();
    delegate string DelegateText(float x);
    delegate int DelegateInt(int x, int y);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //��������Ʈ ���
        //��������Ʈ�� ������ = new ��������Ʈ��(�Լ���);
        DelegateTest dt = new DelegateTest(Attack);

        //�Լ�ó�� ȣ�� / ���������� �۵�
        dt();

        //���� ����
        //������ = �Լ���;

        dt = Gaurd;
        dt();
        // �Ϲ����� �Լ� ȣ���� �ƴ� delegate ������ ���� ��ü �Ҵ��ϴ� ����?
        // 1. delegate�� �Լ��� �ƴ� Ÿ���̱� ����
        //    �Ű������ε� Ȱ���� �����ϰ�, return Ÿ������ ����ִ� �͵� ����

        // 2. ��������Ʈ ü��(delegate chain)
        // delegate�� +=�� ���� �븮�� �Լ��� �� �߰��� �� �ְ�, -=�� ���� 
        // �븮�� �Լ��� �����ϴ� �͵� �����մϴ�.
        dt += Attack;
        dt += Attack;
        dt += Attack;
        dt();
    }

    void UseDelegate(DelegateTest dt)
    {
        dt();
    }

    DelegateTest Selection(int value)
    {
        if (value == 1)
            return Attack;
        if (value == 2)
            return Gaurd;
        if (value == 3)
            return MoveLeft;
        else
            return MoveRight;
    }



    void Attack()
    {
        Debug.Log("����");
    
    }

    void Gaurd()
    {
        Debug.Log("���");

    }

    void MoveLeft()
    {
        Debug.Log("���� �̵�");
    }

    void MoveRight()
    {
        Debug.Log("������ �̵�");
    }



}

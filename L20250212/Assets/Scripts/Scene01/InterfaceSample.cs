using UnityEngine;

//����Ƽ�� �������̽�(interface)
//�������� Ư¡�� ���� ���� ���� �� ȿ�����Դϴ�.
//�Լ��� ������Ƽ ���� ���Ǹ� ���� ���� ������ �� �ֵ��� �����ִ� ����Դϴ�.
//�������̽��� ����, ��ø� �ϱ� ������, ����ϱ� ���ؼ��� �ݵ�� ����� ���� �籸������ �����մϴ�.

public interface ICountAble
{ 
    // int a = 0; �������̽� �������� ���� �����մϴ�.
    int Count { get; set; }

    void CountPlus();
}

public interface IUseAble
{
    void Use();

}



//�������̽��� ���ó�� ����� �� �ֽ��ϴ�.
//�������̽��� ��� ���� ����� �����մϴ�.
class Potion : ICountAble, IUseAble
{
    public int count;
    private string name;

    public string Name { get => name; set => name = value; }
    public int Count
    {
        get
        {  
            return count;
        }
        set
        {
            if (count > 99)
            {
                Debug.Log("count�� 99���� �ִ��Դϴ�.");
                count = 99;
            }

            count = value;
        }
    }

    

    public void CountPlus()
    {
        Count++;
    }

    public void Use()
    {
        Debug.Log($"{Name}�� ����߽��ϴ�.");
        Count--;
    }
}

public class InterfaceSample : MonoBehaviour
{
    Potion potion = new Potion();

    void Start()
    {
        potion.Count = 99;
        potion.CountPlus();
        potion.Name = "���� ����";
        potion.Use();
    }

    void Update()
    {
        
    }
}

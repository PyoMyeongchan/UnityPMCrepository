using UnityEngine;

public interface Enemy
{
    void Action();
}

//�������̽��� �߻� Ŭ����(abstract class) ��� ���� 1. ����� ������ ������ ����� �ſ� ���� ����˴ϴ�.

public class Goblin : Enemy
{
    public void Action()
    {
        Debug.Log("����� ������ �մϴ�.");
    }


}

public class Slime : Enemy
{
    public void Action()
    {
        Debug.Log("�������� ���� ������ �մϴ�.");
    }

}

public class WildBoar : Enemy
{
    public void Action()
    {
        Debug.Log("������� �޷���� ������ �մϴ�.");
    }

}

using UnityEngine;

public class Door : MonoBehaviour
{
    public int arranged = 0; // �ĺ��� ��

    // �÷��̾ ���踦 ������ ���� ��� ���踦 1�� �Ҹ��ؼ� ������ �� �ֵ��� ����

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ItemKeeper.haskey > 0)
        {
            ItemKeeper.haskey--;
            Destroy(gameObject);

        }
        else
        {
            Debug.Log("�������");
        
        }

    }
}

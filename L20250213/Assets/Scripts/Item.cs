using UnityEngine;

//��ũ��Ʈ ������ �Ұ��ϴ�.
[CreateAssetMenu]

public class Item : ScriptableObject
{
    public GameObject gameObject; // ������ �����Ͱ� ������ �ִ� ���� ������Ʈ

    public int id;
    public string price;
    public string description;

}

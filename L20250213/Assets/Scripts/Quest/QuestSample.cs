using System;
using UnityEngine;

public enum QuestType
{ 
    normal, daily, weekly
}

//�Ϲ� ����Ʈ : Ŭ�����ϸ� �� �̻� �� �� �����ϴ�.
//���ϸ� ����Ʈ : ������ �������� ����Ʈ�� ���ŵ˴ϴ�.
//��Ŭ�� ����Ʈ : �ָ� �������� ����Ʈ�� ���ŵ˴ϴ�.

[CreateAssetMenu(fileName="Quest", menuName = "Quest/Quest")]
public class QuestSample : ScriptableObject
{
    public QuestType ����Ʈ����;
    public Reward ����;
    public Requirement �䱸����;


    [Header("����Ʈ ����")]
    public string ����; //����Ʈ�� ����
    public string ����; //����Ʈ�� ����
    [TextArea] public string ����; //����Ʈ�� ���� ����

    public bool ����; //����Ʈ�� ���� ���θ� üũ�մϴ�.
    public bool �������; //����Ʈ�� ���� �������� Ȯ���ϴ� �뵵�� ����մϴ�.

}

[Serializable]
[CreateAssetMenu(fileName = "Quest", menuName = "Quest/Requirement")]
public class Requirement : ScriptableObject
{
    public int ��ǥ���ͼ�;
    public int �����������ͼ�;


}

[Serializable]
[CreateAssetMenu(fileName = "Quest", menuName = "Quest/Reward")]

public class Reward : ScriptableObject
{
    public int ��;
    public float ����ġ;

}
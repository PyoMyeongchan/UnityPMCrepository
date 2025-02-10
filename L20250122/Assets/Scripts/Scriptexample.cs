using UnityEngine;

/// <summary>
/// ����Ƽ ��Ʈ����Ʈ(Unity Attribute)
/// ����Ƽ������ �����Ϳ� �°� ��ũ��Ʈ�� Ŀ�����ϴ� ���� �����մϴ�.
/// </summary>/// 

[AddComponentMenu("CustomUtility/ScriptExample")]
public class Scriptexample : MonoBehaviour
{
    [Range(1, 99)]
    public int level;

    [Range(0, 100)]
    public int volume;

    [Header("�÷��̾��� �̸�")]
    public string player_name;

    [TextArea]
    public string talk01;
    [TextArea(1,3)]
    public string talk02;
    [TextArea(5,7)]
    public string talk03;

    [Tooltip("üũ�Ǹ� ���� �������� �ǹ��մϴ�.")]
    public bool isdead = true;

    #region �Լ�
    //�Լ�(Function)
    //C#������ Ŭ���� ���ο� ����Ǵ� �Լ���
    //�޼ҵ�(method)��� �θ��ϴ�.

    //�Լ��� Ư�� �ϳ��� ����� �����ϱ� ���� �ۼ��� ��ɹ� ����ü
    //�ڵ� ������ ����� �Լ��� ���ϴ� ��ġ���� ȣ���� ����
    //����� �� �ֽ��ϴ�.

    //�Լ��� ���� ���

    //�ڷ��� �Լ��̸�(�Ű�����)
    //{
    //�Լ��� ȣ������ ��, ������ ��ɹ��� �ۼ��ϴ� �ڸ�;
    //}
    // �����ڵ忡 �� �����ؼ� ������ ��

    //�Լ� ȣ�� ���
    //�Լ��̸�(����);

    //�Ű����� : �Լ��� ȣ���� ��, ���޹��� �����Ϳ� ���� ǥ��
    //���� : �Լ��� ȣ���� ��, ������ ��
    #endregion
   
    [ContextMenu("HelloEveryone")]
    void HelloEveryone()
    {
        Debug.Log("�����е� ��� �ȳ��ϼ���!!");
    }


    void Hellosomeone(string who)
    {
        Debug.Log($"{who}�� �ȳ��ϼ���!");
    }
}
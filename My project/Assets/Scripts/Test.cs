using UnityEngine;
// using�� ������ ���� ���� �ڵ忡�� ����ϴ� ���Դϴٶ�� ���Դϴ�.
// ����Ƽ���� ����Ƽ�� Ȱ���� �۾��ϴ� ��ũ��Ʈ���
// ���� �ڵ带 �ݵ�� �߰����ּ���.(�ڵ����� �߰��Ǿ� �ֽ��ϴ�.)

//namespace�� Ư�� ����� �ϴ� Ŭ������ ��ǥ���� �̸����ν� ����մϴ�.
namespace Unitytutorial2
{
    //Unitytutorial �������� ������� SampleA Ŭ����
    public class SampleA
    {

    }

}

public class SampleA
{

}


/// <summary>
/// ó������ ���� ����Ƽ�� ��ũ��Ʈ
/// </summary>
public class Test : MonoBehaviour
    //MonoBehaviour�� Ŭ������ �������� ���
    //����Ƽ ���� �����ϴ� ������Ʈ�� ��ũ��Ʈ�� ������ �� �ְ� ���ݴϴ�.
    //�߰������� ����Ƽ���� �������ִ� ����� ����� �� ����մϴ�.
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("������ C# ��ũ��Ʈ�� ���� ���Դϴ�.");
    }

    int count = 0;


    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{count} �¿� �ݺ� �ٱ�");
        count++; //++ = 1 �����Ѵ�
    }
}
using UnityEditor;
using UnityEngine;

public class CreateObject3 : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private int dummy;


    //����ȭ
    //�����ͳ� ������Ʈ�� �籸���� �� �ִ� ����(����)�� ��ȯ�ϴ� ����
    //����Ƽ������ �����ϰ� private ������ �����͸� �ν����Ϳ��� ���� �� �ְ� �������شٶ�� �����غ��ô�.

    [SerializeField] GameObject sample;

    void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/Table_Body");
    }



    void Update()
    {
        //�Է¹��� Ű�� �����̽��� ���
        //GetKeyDown (Ű 1�� �Է�)
        //GetKeyUp (�Է� �� ���� ���)
        //GetKey (������ �ִ� ����)

        if (Input.GetKeyUp(KeyCode.Space))
        {
            //prefab = Resources.Load<GameObject>("Prefabs/Table_Body");
            //Resources.Load<T>("������ġ/���¸�");

            //T�� �������� ���¸� �����ִ� ��ġ�Դϴ�.
            //Sprite sprite = Resources.Load<Sprite>("Sprites/sprite01")

            sample = Instantiate(prefab);
            sample.AddComponent<VectorSample>();
            //GameObject.AddComponent<T>
            //������Ʈ�� ������Ʈ ����� �߰��ϴ� ����Դϴ�.
            //GetComponent<T>
            //������Ʈ�� ������ �ִ� ������Ʈ�� ����� ������ ���
            //��ũ��Ʈ���� �ش� ������Ʈ�� ����� �����ͼ� ����ϰ� ���� ��� ����մϴ�.
        }
    }

}

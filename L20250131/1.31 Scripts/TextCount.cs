using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class TextCount : MonoBehaviour
{
    //�ؽ�Ʈ�� ī��Ʈ�� ����ϴ� ����� �����մϴ�.
    //ī��Ʈ�� ��� 1�� �����ϴ� ���·� ó���մϴ�.
    public Text countText;
    private int count;
    

    void Start()
    {
        //�ڷ�ƾ ��� ���
        //StartCoroutine("�Լ��� �̸�(Enumerator ������ �Լ�)")
        //1. ���ڿ��� ���� �Լ��� ã�Ƽ� �����ϴ� ���
        // >> ��Ÿ �߻��� ���� �߻����� ����. ������ ����� ������� ����.
        //StopCoroutine()�� ���� �ܺο��� �����ϴ� ���� �����մϴ�.

        //StartCoroutine(�Լ��� �̸�());
        //2. �ش� �Լ��� ȣ���� ���� ����� ��ȯ�޴� ����
        // >> ��Ÿ �߻� �� ���� üũ ����, ���� ����

        //�� ������δ� StopCoroutine()�� ���� �ܺο����� ���� ����� ����� �� �����ϴ�.

        StartCoroutine("CountPlus");
        //�ش� �ڷ�ƾ ���� ���� ����
        //StopCoroutine("CountPlus");


        //StartCoroutine(CountPlus());
        //�Լ� ���� ���� ���


    }

    IEnumerator CountPlus()
    {
    while (true)
        { 

            count++;
            countText.text = count.ToString("N0");
            //C#�� ToString()�� ���� ���� ���·� ������ ����
            //N0�� ���� 3�ڸ� �������� ,�� ǥ���ϴ� format�Դϴ�. 1000 1,000

            yield return new WaitForSeconds(1.0f);
            //���� �������� �Ѿ�ϴ�.

            //yield�� �Ͻ������� CPU�� ������ �ٸ� �Լ��� �����ϴ� Ű�����Դϴ�.
            /*Debug.Log("����ũ �׽�Ʈ");
            yield return new WaitForSeconds(1);
            Debug.Log("�丸 �԰�ð�");
            yield return new WaitForSeconds(5);
            Debug.Log("�ٽ� ���� �غ���");*/
        }



    }


}

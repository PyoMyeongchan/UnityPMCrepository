using UnityEngine;

public class UserDataSystem : MonoBehaviour
{

public UserData data01;
public UserData data02;

    //PlayerPrefs ���
    //1. DeleteAll()  ���� ���
    //2. (Ű �̸�) : �ش� Ű�� �ش��ϴ� ���� �����մϴ�.
    //3. GetFloat/Int/String(Ű �̸�) :Ű�� �ش��ϴ� ���� return�մϴ�.
    //                                 ������ Ÿ�Կ� ���缭 ����մϴ�.
    //4. SetFloat/Int/String(Ű �̸�/��) : �ش� Ű -���� �����մϴ�.
    //                                     Ű���� ����Ű�� �ִٸ� ���� ����˴ϴ�.
    //5. HasKey(Ű �̸�) : �ش� Ű�� �����ϴ����� Ȯ���մϴ�.

    private void Start()
    {
        data01 = new UserData();
        //Ŭ���� ���� ���
        //Ŭ��������(���۷���)�� = new ������();
            
        data02 = new UserData("sample0206","Pyo","123456","Pyo@unity.com","010-1111-1111");

        //data02�� �����͸� ���̵�,�̸�,��й�ȣ,�̸���,��ȣ������ ����.
        string data_value = data02.GetData();
        Debug.Log(data_value);

        PlayerPrefs.SetString("Data01",data_value); //�� �����͸� Data01�� ����
        PlayerPrefs.Save(); //����� �� ���� ����

        data01 = UserData.SetData(data_value); //data01�� ���޹��� �����ͷ� ����

        Debug.Log(data01.GetData()); //data01�� ����� ���މ���� Ȯ��
       
    }




}

using UnityEngine;

public class DataSample : MonoBehaviour
{
    //1. ����Ƽ �������� ����
    //������ ���� �������� ���� �ٽ��� �Ǵ� �κ�(������)

    //�Ϲ����� �۾� ��, �÷��� �ϴ� ��쿡�� ���� ���� �����ǰ�
    //�ٽ� �÷����ϸ� ������ ��ϵ��� ���ŵ�.

    //���� ���ο� ���� �÷����� �� ������ ������ ������ �����ϴ� ���ӵ� ����

    //PlayerPrefs�� �ַ� �÷��̾ ���� ȯ�� ������ ������ �� ���Ǵ� Ŭ�����Դϴ�.
    //�ش� Ŭ������ ���ڿ�, �Ǽ�, ������ ������� �÷��� ������Ʈ���� ������ �� �ֽ��ϴ�.

    //PlayerPrefs�� key�� Value�� �����Ǿ� �ִ� �������Դϴ�.(C#�� Dictonary)

    //Key�� Value�� �����ϱ� ���� ������(���� �������� ��ġ)
    //Value�� Key�� ���� ������ �� �ִ� �������� ��

    //ex) userID : current147���� ����Ǿ� �ִٸ�,  userID�� Key, current147�� Value�� �ش��Ѵٰ� �����մϴ�.

    public UserData userData;
    //1. ����Ƽ �����Ϳ��� ���� userData�� ���� ������ �� �ۼ��ϰڽ��ϴ�.
    //2. ������Ʈ���� �ִ� Ű ���� �˻��غ��ڽ��ϴ�.
    //3. Ű ��ü ����

    private void Start()
    {
        /* 1. PlayerPrefs.SetString("ID", userData.UserID);
        PlayerPrefs.SetString("UserName", userData.UserName);
        PlayerPrefs.SetString("Password", userData.UserPassword);
        PlayerPrefs.SetString("Email", userData.UserEmail);
        PlayerPrefs.SetString("Phone", userData.UserPhone);*/

        //Debug.Log("�����Ͱ� ����Ǿ����ϴ�");

        /* 2. Debug.Log(PlayerPrefs.GetString("ID"));
        Debug.Log(PlayerPrefs.GetString("Email"));*/

        //PlayerPrefs.DeleteAll();//��ü ����
        Debug.Log("�����Ͱ� �����Ǿ����ϴ�.");

    }

    //���� �� ������Ʈ�� �����⿡�� ������ Ȯ��

}

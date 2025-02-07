using UnityEngine;

//Ŭ������ ���� ����ȭ
[System.Serializable]

public class UserData
{
    public string UserID;
    public string UserName;
    public string UserPassword;
    public string UserEmail;
    public string UserPhone;

    //������(Constructor)
    //Ŭ���� �̸��� ������ �޼ҵ带 �ǹ��մϴ�.
    //��ȯ Ÿ���� ���� ���� �޼ҵ��Դϴ�.
    //���� �������� ���� ��쿡�� �⺻ �����ڷ� ó���˴ϴ�.
    
    //�⺻ ������ = Ŭ������ �̸��� ������ �޼ҵ�, �Ű������� ���� ���� �ʽ��ϴ�.
    public UserData()
    {

    }
    

    //���̵�, �̸�, ��й�ȣ, �̸���, ��ȣ ������� �ۼ��ϸ� ������ �� �ִ�  UserData

    public UserData(string userID, string userName, string userPassword, string userEmail, string userPhone)
    {
        UserID = userID;
        UserName = userName;
        UserPassword = userPassword;
        UserEmail = userEmail;
        UserPhone = userPhone;
    }

    /// <summary>
    /// �����͸� �ϳ��� ���ڿ��� return�ϴ� �ڵ�
    /// </summary>
    /// <returns>���̵�,�̸�,��й�ȣ,�̸���,��ȣ</returns>
    public string GetData() => $"{UserID},{UserName},{UserPassword},{UserEmail},{UserPhone}";
    //1��¥�� return �ڵ带 ���� ��� {} ��� => �� �ۼ��� �����մϴ�.

    /// <summary>
    /// �����Ϳ� ���� ������ ���޹ް� UserData�� return�ϴ� �ڵ�
    /// </summary>
    /// <param name="data">���̵�,�̸�,��й�ȣ,�̸���,��ȣ������ �ۼ��� ������</param>
    /// <returns></returns>
    public static UserData SetData(string data)
    {
        string[] data_values = data.Split(',');
        //���ڿ�.Split(',') �ش� ���ڿ��� ()�ȿ� �־��� ,�� �������� �߶� �迭�� ������ݴϴ�.
        //�迭�� 0������ �����͸� üũ�մϴ�.(�ε���)
        return new UserData(data_values[0], data_values[1], data_values[2], data_values[3], data_values[4]);
    }
   

}

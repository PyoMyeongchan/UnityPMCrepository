using System.IO;
using UnityEngine;
//Json ��� ���
//1. ���� �� �ִ� ������ ���·� ������ݴϴ�.
//2. ���� ��� ������� json ������ ã�Ƽ� ������ �ؽ�Ʈ�� �о���ϴ�.
//3. �о �����͸� ���� Ŭ����ȭ�� �����մϴ�.
//4. ������ ���ø� �˴ϴ�.


[System.Serializable]
public class Item01
{
    public string name;
    public string description;

}

public class JsonLoadSample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string Load_json = File.ReadAllText(Application.dataPath + "/Item01.json");
        //�۾� ������ �ǹ��մϴ�.(����Ƽ������ Assets ���� ��ġ)


        var data = JsonUtility.FromJson<Item01>(Load_json);
        Debug.Log(data.name);

        data.name = "������� �ٲ㺸��";
        data.description = "��������";

        //json ���Ϸ� ��������(Save)
        File.WriteAllBytes(Application.dataPath + "/Item02.json", JsonUtility.ToJson(data)); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

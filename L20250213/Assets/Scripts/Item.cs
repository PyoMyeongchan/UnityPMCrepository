using UnityEngine;

//스크립트 연결은 불가하다.
[CreateAssetMenu]

public class Item : ScriptableObject
{
    public GameObject gameObject; // 아이템 데이터가 가지고 있는 게임 오브젝트

    public int id;
    public string price;
    public string description;

}

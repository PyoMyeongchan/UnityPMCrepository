using UnityEngine;

public class CreateObject2 : MonoBehaviour
{
    public GameObject prefab;

    private GameObject square;

    void Start()
    {
        square = Instantiate(prefab);

        Destroy(square, 5.0f); //5�� �ڿ� �ı��մϴ�.

        Debug.Log("�ı��Ǿ����ϴ�.");

    }

    void Update()
    {
        
    }
}

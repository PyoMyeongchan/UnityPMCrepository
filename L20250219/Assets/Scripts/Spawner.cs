using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //���ʹ� �ʿ� Ư�� ���� ���� �� �ʸ��� �ݺ��ؼ� ��ȯ�մϴ�.

    public GameObject monsterPrefab;
    public int monsterCount;
    public float monsterSpawnTime;
    public float summonRate = 5.0f; // �ش� ��ġ�� ������ ��� �����Ǵ� ����(��)�� ��ġ ���� ���� �о����ϴ�.
    public float reRate = 3.0f; // ���� ��ġ�� �������� �����Ǵ� ����(��)�� ������ �� �ֽ��ϴ�.

    private void Start()
    {
        StartCoroutine("SqawnMonster");
    }


    IEnumerator SqawnMonster()
    {
        Vector3 position; // ���� ��ǥ

        for (int i = 0; i < monsterCount; i++)
        {
            position = Vector3.zero + Random.insideUnitSphere * summonRate;
            
            position.y = 0.0f; // ������ ������ �ʿ� ����� �����ϱ� ���� ����


            // �ٷ� �տ� �������� ��� ���Ҵ�
            while (Vector3.Distance(position, Vector3.zero) <= reRate)
            {
                position = Vector3.zero + Random.insideUnitSphere * summonRate;

                position.y = 0.0f; 

            }


            GameObject go =Instantiate(monsterPrefab, position, Quaternion.identity);
        }

        yield return new WaitForSeconds(monsterSpawnTime);
        
        StartCoroutine("SqawnMonster");


    }

}



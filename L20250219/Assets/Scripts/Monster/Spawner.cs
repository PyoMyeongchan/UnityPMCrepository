using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //���ʹ� �ʿ� Ư�� ���� ���� �� �ʸ��� �ݺ��ؼ� ��ȯ�մϴ�.

    public GameObject monsterPrefab;
    public int monsterCount;
    public float monsterSpawnTime;
    public float summonRate = 5.0f; // �ش� ��ġ�� ������ ��� �����Ǵ� ����(��)�� ��ġ ���� ���� �о����ϴ�.
    public float reRate = 3.0f; // ���� ��ġ�� �������� �����Ǵ� ����(��)�� ������ �� �ֽ��ϴ�.

    public static List<Monster> monsterList = new List<Monster>(); // ������ ����
    public static List<Player> playerList = new List<Player>(); // ������ ĳ����

    private void Start()
    {
        StartCoroutine("SqawnMonsterPooling");
    }


    // �Ϲ����� ���� ���
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

    // ������Ʈ Ǯ�� ������� ����� ���
    IEnumerator SqawnMonsterPooling()
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

            /*
            var go = Manager.Pool.PoolObject("Skeleton").GetGameObject(); // ������ �Լ��� ���� ���(�Ϲ� ����)
            */

            // �׼��� ���� ��� ó��
            var go = Manager.Pool.PoolObject("Monster").GetGameObject((value) =>
            {
                //value.GetComponent<Monster>().MonsterSample();
                value.transform.position = position;
                value.transform.LookAt(Vector3.zero);
                // ������ ������ ���͸���Ʈ�� �߰�
                monsterList.Add(value.GetComponent<Monster>());

            }); // ������ �Լ��� �ִ� ��� Action<GameObject>

           // StartCoroutine(ReturnMonsterPooling(go));
            // Ǯ���� ���� ���� �ݳ�
        }


        yield return new WaitForSeconds(monsterSpawnTime);

        StartCoroutine("SqawnMonsterPooling");


    }
    // ���� Ǯ���� ���� ���� ���� �ڵ�
    /*IEnumerator ReturnMonsterPooling(GameObject ob)
    { 
    
        yield return new WaitForSeconds(1.0f);
        Manager.Pool.poolDict["Monster"].ObjectReturn(ob);
    }
    */




}



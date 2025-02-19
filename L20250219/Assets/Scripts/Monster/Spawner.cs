using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //몬스터는 맵에 특정 마리 수를 몇 초마다 반복해서 소환합니다.

    public GameObject monsterPrefab;
    public int monsterCount;
    public float monsterSpawnTime;
    public float summonRate = 5.0f; // 해당 수치를 수정할 경우 생성되는 영역(구)의 위치 값이 점점 넓어집니다.
    public float reRate = 3.0f; // 생성 위치를 기준으로 생성되는 영역(구)를 설정할 수 있습니다.

    public static List<Monster> monsterList = new List<Monster>(); // 생성된 몬스터
    public static List<Player> playerList = new List<Player>(); // 생성된 캐릭터

    private void Start()
    {
        StartCoroutine("SqawnMonsterPooling");
    }


    // 일반적인 생성 방법
    IEnumerator SqawnMonster()
    {
        Vector3 position; // 생성 좌표

        for (int i = 0; i < monsterCount; i++)
        {
            position = Vector3.zero + Random.insideUnitSphere * summonRate;
            
            position.y = 0.0f; // 생성된 유닛이 맵에 제대로 존재하기 위해 설정


            // 바로 앞에 생성됬을 경우 재할당
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

    // 오브젝트 풀링 기법으로 만드는 방법
    IEnumerator SqawnMonsterPooling()
    {
        Vector3 position; // 생성 좌표

        for (int i = 0; i < monsterCount; i++)
        {
            position = Vector3.zero + Random.insideUnitSphere * summonRate;

            position.y = 0.0f; // 생성된 유닛이 맵에 제대로 존재하기 위해 설정


            // 바로 앞에 생성됬을 경우 재할당
            while (Vector3.Distance(position, Vector3.zero) <= reRate)
            {
                position = Vector3.zero + Random.insideUnitSphere * summonRate;

                position.y = 0.0f;

            }

            /*
            var go = Manager.Pool.PoolObject("Skeleton").GetGameObject(); // 전달할 함수가 없는 경우(일반 생성)
            */

            // 액션을 통해 기능 처리
            var go = Manager.Pool.PoolObject("Monster").GetGameObject((value) =>
            {
                //value.GetComponent<Monster>().MonsterSample();
                value.transform.position = position;
                value.transform.LookAt(Vector3.zero);
                // 생성된 유닛을 몬스터리스트에 추가
                monsterList.Add(value.GetComponent<Monster>());

            }); // 전달할 함수가 있는 경우 Action<GameObject>

           // StartCoroutine(ReturnMonsterPooling(go));
            // 풀링한 값에 대한 반납
        }


        yield return new WaitForSeconds(monsterSpawnTime);

        StartCoroutine("SqawnMonsterPooling");


    }
    // 몬스터 풀링한 값에 대한 리턴 코드
    /*IEnumerator ReturnMonsterPooling(GameObject ob)
    { 
    
        yield return new WaitForSeconds(1.0f);
        Manager.Pool.poolDict["Monster"].ObjectReturn(ob);
    }
    */




}



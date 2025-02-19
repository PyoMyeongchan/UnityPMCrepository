using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //몬스터는 맵에 특정 마리 수를 몇 초마다 반복해서 소환합니다.

    public GameObject monsterPrefab;
    public int monsterCount;
    public float monsterSpawnTime;
    public float summonRate = 5.0f; // 해당 수치를 수정할 경우 생성되는 영역(구)의 위치 값이 점점 넓어집니다.
    public float reRate = 3.0f; // 생성 위치를 기준으로 생성되는 영역(구)를 설정할 수 있습니다.

    private void Start()
    {
        StartCoroutine("SqawnMonster");
    }


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

}



using UnityEngine;

public class EnemyManager : MonoBehaviour
{    
    float currentTime;
    public float createTime = 1.0f;
    public GameObject enemyFactory;
    float min = 1, max = 5;

    //오브젝트 풀

    public int poolSize = 10;
    GameObject[] enemyobjectPool;

    public Transform[] spawnPoints;






    public void Start()
    {
        createTime = Random.Range(min, max);

        enemyobjectPool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            var enemy = Instantiate(enemyFactory);
            enemyobjectPool[i] = enemy;
            enemy.SetActive(false);

        }
    }


    private void Update()
    {
        // 시간이 흐른다.
        currentTime += Time.deltaTime;

        // 현재 시간이 일정 시간에 도달한다면 적을 생성
        if (currentTime >= createTime)
        {
            for (int i = 0; i < poolSize; i++)
            {
                var enemy = enemyobjectPool[i];
                if (enemy.activeSelf == false)
                {
                    int index = Random.Range(0,spawnPoints.Length);

                    enemy.transform.position = spawnPoints[index].position;
                    enemy.SetActive(true);
                    break;
                }

            }
            // 소환 후 시간을 0으로 리셋합니다.
            currentTime = 0;
            createTime = Random.Range(min, max);
        }

    }

}

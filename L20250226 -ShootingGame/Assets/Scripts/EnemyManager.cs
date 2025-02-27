using UnityEngine;

public class EnemyManager : MonoBehaviour
{    
    float currentTime;
    public float createTime = 1.0f;
    public GameObject enemyFactory;
    float min = 1, max = 5;

    //������Ʈ Ǯ

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
        // �ð��� �帥��.
        currentTime += Time.deltaTime;

        // ���� �ð��� ���� �ð��� �����Ѵٸ� ���� ����
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
            // ��ȯ �� �ð��� 0���� �����մϴ�.
            currentTime = 0;
            createTime = Random.Range(min, max);
        }

    }

}

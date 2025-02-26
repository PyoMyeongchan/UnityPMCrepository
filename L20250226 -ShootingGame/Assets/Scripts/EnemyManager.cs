using UnityEngine;

public class EnemyManager : MonoBehaviour
{    
    float currentTime;
    public float createTime = 1.0f;
    public GameObject enemyFactory;
    float min = 1, max = 5;

    public void Start()
    {
        createTime = Random.Range(min, max);
    }


    private void Update()
    {
        // 시간이 흐른다.
        currentTime += Time.deltaTime;

        // 현재 시간이 일정 시간에 도달한다면 적을 생성
        if (currentTime >= createTime)
        { 
            GameObject enemy = Instantiate(enemyFactory);

            enemy.transform.position = transform.position;
            // 소환 후 시간을 0으로 리셋합니다.
            currentTime = 0;
            createTime = Random.Range(min, max);
        }

    }

}

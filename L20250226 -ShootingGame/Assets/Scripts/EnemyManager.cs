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
        // �ð��� �帥��.
        currentTime += Time.deltaTime;

        // ���� �ð��� ���� �ð��� �����Ѵٸ� ���� ����
        if (currentTime >= createTime)
        { 
            GameObject enemy = Instantiate(enemyFactory);

            enemy.transform.position = transform.position;
            // ��ȯ �� �ð��� 0���� �����մϴ�.
            currentTime = 0;
            createTime = Random.Range(min, max);
        }

    }

}

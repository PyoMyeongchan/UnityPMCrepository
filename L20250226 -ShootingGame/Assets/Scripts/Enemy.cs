using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    Vector3 dir;

    public GameObject explosinFactory;

    private void OnEnable() // Ȱ��ȭ �ܰ迡 ȣ��Ǵ� �Լ�
    {
  
        // ���� ���� ����

        int rand = Random.Range(0, 10);

        // 10�� �߿��� 3���̹Ƿ� �� 30% Ȯ���̶�� �� �� ����
        if (rand < 3)
        {
            var target = GameObject.Find("Player");

            dir = target.transform.position - transform.position;

            dir.Normalize(); // ������ ũ�⸦ 1�� �����մϴ�.
                             // ���� ���� : Vector3.up, Vector3.down, Vector3.left ...


        }
        else 
        {
            dir = Vector3.down;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        ScoreManager.instance.score++;


        GameObject explosion = Instantiate(explosinFactory);
        explosion.transform.position = transform.position;

        // �ε��� ��ü�� �̸��� bullet�� ���Եȴٸ�
        // ������Ʈ Ǯ�� ������� �̸��� Bullet
        if (other.gameObject.name.Contains("Bullet"))
        {
            other.gameObject.SetActive(false);

        }
        else
        { 
            Destroy(other.gameObject);
        }

        gameObject.SetActive(false); // ���� ��Ȱ��ȭ


    }
}

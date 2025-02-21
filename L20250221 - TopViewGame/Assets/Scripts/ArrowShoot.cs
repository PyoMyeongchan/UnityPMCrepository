using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ArrowShoot : MonoBehaviour
{
    public float speed = 12.0f;
    public float delay = 0.25f;
    public GameObject bowPrefab; // Ȱ
    public GameObject arrowPrefab;

    bool inAttack = false; // ���� ������� Ȯ��
    GameObject bowObject;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 pos = transform.position;
        bowObject = Instantiate(bowPrefab, pos, Quaternion.identity);
        // Ȱ ������Ʈ�� �θ�� �÷��̾��Դϴ�.
        bowObject.transform.SetParent(transform);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Attack();
        }

        //rotate bow, order
        float bowZ = -1; // ĳ���ͺ��� �տ� ������ �˴ϴ�.
        var playerController = GetComponent<PlayerController>();

        if (playerController.z > 30 && playerController.z < 150)
        {
            bowZ = 1;
        }
        bowObject.transform.rotation = Quaternion.Euler(0, 0, playerController.z);

        bowObject.transform.position = new Vector3(transform.position.x, transform.position.y, bowZ);

    }

    private void Attack()
    {
        // ȭ���� ������ �ְ�, ���� ���°� �ƴ� ���
        if (ItemKeeper.hasArrows > 0 && inAttack == false)
        {
            ItemKeeper.hasArrows--;
            inAttack = true; // ���� ���·� ��ȯ

            var playerController = GetComponent<PlayerController>();

            float z = playerController.z; // ȸ�� ��

            var rotation = Quaternion.Euler(0, 0, z);

            // ����� ȸ�� ������ ������Ʈ�� �����մϴ�
            var arrowObject = Instantiate(arrowPrefab, transform.position, rotation);

            float x = Mathf.Cos(z * Mathf.Deg2Rad);

            float y = Mathf.Sin(z * Mathf.Deg2Rad);

            Vector3 vector = new Vector3(x, y) * speed;

            var rbody = arrowObject.GetComponent<Rigidbody2D>();

            rbody.AddForce(vector, ForceMode2D.Impulse);

            //�߻� �����̸�ŭ ���� ���Ѽ� ���� ��带 �����մϴ�.
            Invoke("AttackChange", delay);

        }

    }


        public void AttackChange()
        {
        inAttack = false;
        }


}
   


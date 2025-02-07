using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class ObjectGenarate : MonoBehaviour
{
    // 1.�� Ŭ������ ������Ʈ�� �����ϴ� ����� ������ �ֽ��ϴ�.
    // 2.���콺 ��ư�� ������ ��, ī�޶��� ��ũ�� ������ ���� ��ü�� ������ �����մϴ�.
    // 3.��ü�� ���⿡ ���� �߻��ϴ� ����� ȣ���ؿ��ڽ��ϴ�. 


    public GameObject prefab; //������Ʈ ������ ���
    GameObject scoreTxet; //���� ǥ��ǥ
    public float power = 1000f; //��ô ���ݷ�
    public int score = 0; //����


    private void Start()
    {
        scoreTxet = GameObject.Find("score"); //���� ������ score�� ã�Ƽ� ���
        setscoreText(); //���� 1ȸ
    }

    /// <summary>
    /// ���� ȹ��
    /// </summary>
    /// <param name="value">��ġ</param>
    public void ScorePlus(int value)
    {
        score += value;
        setscoreText();


    }
    /// <summary>
    /// �� ������ ���� ��� 
    /// </summary>
    void setscoreText()
    {
        scoreTxet.GetComponent<TextMeshProUGUI>().text = $"���� : {score}";

    }

    // Update is called once per frame
    void Update()
    {
        // ~~down : Ŭ���� 1��
        // ~~up : ��ư�� ������ �� 1��
        // : Ŭ���ϰ� �ִ� ���� ����

        //���콺 0�� ��ư�� ������ ��
        //���콺 ��ư
        //0 : ����
        //1 : ������
        //2 : ��

        //������� ��ǥ Ȯ�� -�ͷ��� ���� �ݶ��δ��� �ֱ⶧���� ��ǥ�� �ͷ����̶� �´����� �� �� ����. 

        if (Input.GetMouseButtonDown(0))
        {   //as GameObject�� Instantiate�� ���� ����ϸ� ���ӿ�����Ʈ�ν� �����϶�� �ǹ��Դϴ�.
            var thrown = Instantiate(prefab);

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            #region//ray ����
            //������ ������ ������, �߻�Ǵ� ���� ������ ������ ������ �ֽ��ϴ�.
            //�Ϲ����� ray�� vector3�� ���� ������, ray2D�� ���� vector2�� ���� ������ �˴ϴ�.

            //�Ϲ����� ���� ����� ���
            //Vector3 origin = new Vector3(0, 0, 0);
            //Vector3 vect_dir = Vector3.forward;
            //Ray newRay = new Ray(origin, vect_dir);

            //���̴� �����͸� ������ �ִ� ����ü�̹Ƿ�, ��������δ� �� �� �ִ� ���� ������
            //ray�� �̿��� ���� ����̳� RayCast�� �̿��� ������Ʈ �浹 ������� Ȱ���մϴ�.
            #endregion

            Vector3 direction = ray.direction; // ���� ����

            thrown.GetComponent<ObjectShooter>().Shoot(direction.normalized * power);

        }
    }


    

}

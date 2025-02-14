using UnityEngine;


public class Tester : MonoBehaviour
{
    int point = 0;
    private void Start()
    {
        point = SingleTon.Instance.point; // �̱��濡 �ִ� ������Ƽ

        SingleTon.GetInstance().PointPlus(); //�Ǵ� �޼ҵ带 ���� Ŭ���� ������ ��ü�� �����ؼ� ��ü�� ������ �ִ� ������ ����� �� �ֽ��ϴ�.
    
        // �̱��� ������ ������ ������ ������ �ʿ���� �ٷ� �� ����� ����� �� ����.
        // ��� �̱��� �������� ������ �ν��Ͻ��� �ʹ� ���� �����͸� �����ϴ� ����� ������ ��ư� �׽�Ʈ�� ��ٷο����ϴ�.
    }

}


    //����Ƽ�� ������ ���� �ڵ� : Singleton

    //���������� ���Ǵ� �����͸� �ϳ��� ��ü(�ν��Ͻ�)�� �������ڽ��ϴ�.

    public class SingleTon : MonoBehaviour
{
    // 1. �ν��Ͻ��̸鼭 �������� ������ �� �ְ� �����մϴ�.
   private static SingleTon _instance;


    // 2.  Ŭ���� ���ο� ǥ���� ���� �����մϴ�.
    public int point = 0;

    public void PointPlus()
    {  
        point++; 
    }

    public void ViewPoint()
    {
        Debug.Log("���� ����Ʈ :" + point);
    
    }


    //�޼ҵ带 ���ؼ� ����
    public static SingleTon GetInstance()
    {
        //���� ���� ����ִٸ�,
        if (_instance == null)
        {   //���Ӱ� �Ҵ��մϴ�.
            _instance = new SingleTon();

        }
        //�Ϲ����� ����� ������ �ν��Ͻ��� return�մϴ�.
        return _instance;
    }

    //������Ƽ�� �����ϴ� �͵� �����մϴ�.
    public static SingleTon Instance
    {
        get
        {
           if(_instance == null)
           {
                _instance = new SingleTon();


           }
            return _instance;
        }
    
    
    }

}




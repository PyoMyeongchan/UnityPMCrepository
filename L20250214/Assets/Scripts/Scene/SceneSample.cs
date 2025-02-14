using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSample : MonoBehaviour
{
    //����Ƽ ������ ����Ŭ(life cycle)
    //�����׿����� ���� �ܰ���� ���� �ܰ������ �Լ��� �����մϴ�.
    //ex) Awake(���� ��) / Start(����) / Update(������)...

    //Ȱ��ȭ �Ǿ��� ���

    private void OnEnable()
    {
        Debug.Log("OnSceneLoad�� ��ϵǾ����ϴ�.");
        SceneManager.sceneLoaded += OnSceneLoad;
    }


    private void OnDisable()
    {
        Debug.Log("OnSceneLoad�� �����Ǿ����ϴ�.");
        SceneManager.sceneLoaded -= OnSceneLoad;
    }

    
    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"���� �ε�� ���� �̸��� {scene.name} �Դϴ�.");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            SceneManager.LoadScene("BRP Sample Scene");
            //���� �� ��带 �������� ������ LoadSceneMode�� Single�� ó���˴ϴ�.
            //Single ����� ������ ���� ����Ÿ���� �����մϴ�.
        }
        if (Input.GetKeyDown(KeyCode.I))
        {

            SceneManager.LoadScene("BRP Sample Scene",LoadSceneMode.Additive);
            //LoadSceneMode.Additive�� ��� ���� �� ���� ���ο� ���� �ߺ��ؼ� �ε��ϴ� ����
            //�翬�� �� �۾��� ������ ��� �⺻ ������Ʈ��(Main Camera, Direction Light) � �� �ε�Ǳ� ������ �����ؾ� �մϴ�.
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine("LoadSceneC");
            //SceneManager.LoadSceneAsync("BRP Sample Scene",LoadSceneMode.Additive);
            //�񵿱���(Async) �ε�
            //�Ϲ����� �۾��� ���������� ó���˴ϴ�.
            //���� �ε��� �� �ɶ����� �ٸ� ��ҵ��� �۵����� �ʰԵ˴ϴ�.

        }

    }

    IEnumerator LoadSceneC()
    { 
        yield return SceneManager.LoadSceneAsync("BRP Sample Scene", LoadSceneMode.Additive);

    }
}

using System.IO;
using System.Collections;
using UnityEngine;

public class LoadAssetsBundleManager : MonoBehaviour
{
    //��� �ۼ�
    string path = "Assets/Bundles/asset1";


    void Start()
    {
        StartCoroutine(LoadAsync(path));
    }

    IEnumerator LoadAsync(string path)
    { 
        AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));    
        
        //����Ʈ�� ���������� ���
        yield return request;

        //������Ʈ�� ���� �޾ƿ� ���� ������ ������ �����մϴ�.
        AssetBundle bundle = request.assetBundle;

        //���޹��� ������ ���� ������ �ε��մϴ�.
        GameObject prefab = bundle.LoadAsset<GameObject>("RedSphere");
        Instantiate(prefab);
        //LoadAssets<T>("�̸�");



    }

}

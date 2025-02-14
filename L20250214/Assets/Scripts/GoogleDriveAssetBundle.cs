using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GoogleDriveAssetBundle : MonoBehaviour
{
    //���۵���̺� �ٿ�ε� ������ ���� URL�ֱ�
    private string imageFileURL = "https://drive.usercontent.google.com/u/0/uc?id=11Tp6Vy-ajbF_H4-yHTqu9TEfTQ_05x23&export=download";
   
    public Image image;

    void Start()
    {
        StartCoroutine("DownLoadImage");        
    }

    IEnumerator DownLoadImage()
    {
        //�ش� �ּ�(URL)�� ���� �ؽ�ó�� ������Ʈ ��û�մϴ�.
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageFileURL);

        //������Ʈ�� �Ϸ�� ������ ����մϴ�.
        yield return www.SendWebRequest();

        //������Ʈ�� ����� �����̶��
        if (www.result == UnityWebRequest.Result.Success)
        {
            var texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

            //Texture2D�� UI���� ���� ���� Sprite ���·� ����
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1.0f);
            Debug.Log("�̹����� ���������� �����Խ��ϴ�.");
            image.sprite = sprite;

        }
        else
        {
            Debug.LogError("�̹����� �������� ���߽��ϴ�.");
        }
    }

    
    
}

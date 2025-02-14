using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GoogleDrive : MonoBehaviour
{
    private string imageFileURL = "https://drive.usercontent.google.com/u/0/uc?id=11Tp6Vy-ajbF_H4-yHTqu9TEfTQ_05x23&export=download";
    private string imageFileURL2 = "https://drive.usercontent.google.com/u/0/uc?id=1QZWYgj9V8MdrhCxqsGw9LP_k0dyewhHI&export=download";

    public Image image;
    

    public void Start()
    {
        
    }

    public void Button()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageFileURL); 
        

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

    public void Button2()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageFileURL2);

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

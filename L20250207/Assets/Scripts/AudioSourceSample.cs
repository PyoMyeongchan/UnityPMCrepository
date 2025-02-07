using Mono.Cecil;
using System.Collections;
using UnityEditor.Overlays;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AudioSourceSample : MonoBehaviour
{
    //0) �ν����Ϳ��� ���� �����ϴ� ���
    public AudioSource audioSourceBGM;

   
    //1) AudioSourceSample ��ü�� ��ü������ ����� �ҽ��� ������ �ִ� ���
    //private AudioSource own_audioSource;

    //3) ������ ã�Ƽ� �����ϴ� ���
    //4) Resource.Load() ����� �̿��� ���ҽ� ������ �ִ� ����� �ҽ��� Ŭ���� �޾ƿ��ڽ��ϴ�.
    public AudioSource audioSourceSFX;

    public AudioClip bgm; // ����� Ŭ���� ���� ����

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //1)�� ��� GetComponent<T>�� ���� �ش� ��ü�� ������ �ִ� ����� �ҽ� ���� ����
        // own_audioSource = GetComponent<AudioSource>();

        //3)�� ��� GameObject.Find() Ȱ��
        //GameObject.Find()�� ������ ã��  gameObject�� return�ϴ� ����� ������ ����. �� �� ���� gameObject��.
        //GameObject�̱� ������ GetComponent<T>�� �̾� �ۼ������ν� ������Ʈ�� ���� ������Ʈ�� ���� return�մϴ�.
        //���� �� ������� AudioSource�� �˴ϴ�.
        audioSourceSFX = GameObject.Find("SFX").GetComponent<AudioSource>();
        
        audioSourceBGM.clip = bgm;
        //����� �ҽ��� Ŭ���� bgm���� �����մϴ�.
        
        audioSourceSFX.clip = Resources.Load("Explosion") as AudioClip;
        //Resource.Load()�� ���ҽ� �������� ������Ʈ�� ã�� �ε��ϴ� ����Դϴ�.
        //�̶� �޾ƿ��� ���� Object�̹Ƿ�, as Ŭ�������� ���� �ش� �����Ͱ� � �������� ǥ�����ָ�
        //�� ���·� �޾ƿ��� �˴ϴ�.

        audioSourceSFX.clip = Resources.Load("Audio/BombCharge") as AudioClip;
        //���ҽ� �ε� �� ��ΰ� �������ִٸ� ������/���ϸ����� �ۼ��մϴ�.
        //���ҽ� �ε� �� �ۼ��ϴ� �̸����� Ȯ���ڸ�(EX) .json, .avi)�� �ۼ����� �ʽ��ϴ�.

        //UnityWebRequest�� GetAudioClip ��� Ȱ��
        StartCoroutine("GetAudioClip");

        audioSourceBGM.Play();
        //����� �ҽ� ��ũ��Ʈ ���
        //audioSourceBGM.Play(); Ŭ���� �����ϴ� ����
        //audioSourceBGM.Pause(); �Ͻ� ���� ���
        //audioSourceBGM.PlayOneShot(bgm); Ŭ�� �ϳ��� �Ѽ��� �÷��̸� �����մϴ�.
        //audioSourceBGM.Stop(); ����� Ŭ�� ��� ����
        //audioSourceBGM.UnPause(); �Ͻ� ���� ����
        //audioSourceBGM.PlayDelayed(1.0f); 1�� �ڿ� ���

        

    }

    IEnumerator GetAudioClip()
    {
        UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip("file:///"+Application.dataPath + "/Audio/" + "Explosion" + ".wav", AudioType.WAV);

        yield return uwr.SendWebRequest(); // ����

        var new_clip = DownloadHandlerAudioClip.GetContent(uwr);
        //���� ��θ� ������� �ٿ�ε� ����

        audioSourceBGM.clip = new_clip; //Ŭ�� ���
        audioSourceBGM.Play(); //�÷���
    }
    //�̰ɷ� ȣ���� ��� �۾� ������ �� �����.

    public void mute()
    {
            audioSourceBGM.Stop();


    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

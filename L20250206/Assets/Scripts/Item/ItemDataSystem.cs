using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemDataSystem : MonoBehaviour
{


    [Header("=== ��ǲ �ʵ� ===")]
    public TMP_InputField nameInputField;
    public TMP_InputField DescriptionInputField;

    [Header("=== ��ư ===")]
    public Button LoadButton;
    public Button SaveButton;
    public Button DeleteButton;

    [Header("=== ������ ���� ===")]
    public TMP_Text itemNameText;
    public TMP_Text itemDescriptionText;

    public string temp_name;
    public string temp_description;



    //public bool interactable;

    void Start()
    {
        //nameInputField.onEndEdit.AddListener(ValueChanged);
        //�� ������� ����� ����� ����Ƽ �ν����Ϳ��� ������ �ʽ��ϴ�.
        // DescriptionInputField.onEndEdit.AddListener(ValueChanged);

        //LoadButton.interactable = interactable;
        //��ư�� interactable�� ����ڿ��� ��ȣ�ۿ� ���θ� ������ �� ����ϴ� ���Դϴ�.
        nameInputField.onEndEdit.AddListener(Namechanged);
        DescriptionInputField.onEndEdit.AddListener(DescriptionChanged);
        LoadButton.onClick.AddListener(LoadData);
        SaveButton.onClick.AddListener(SaveData);
        DeleteButton.onClick.AddListener(DeleteData);

    }

    private void Update ()
    {
        LoadCheck();
    }

    // 1. public���� ���� �Լ��� ����Ƽ �ν����Ϳ��� ���� �����ϰڽ��ϴ�.
    // 2. public�� �ƴ� �Լ��� ��ũ��Ʈ �ڵ带 ���� ����� �������ְڽ��ϴ�.

    //public void Sample() 

    //{Debug.Log("INPUT FIELD'S ON VALUE CHANGED");}

    void Namechanged(string text)
    { 
    temp_name = text;
    }

    void DescriptionChanged(string text)
    {
        temp_description = text;
    }

    void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
    void SaveData()
    {
        if (temp_name != "" && temp_description != "")
        {
            PlayerPrefs.SetString("ItemName", temp_name);
            PlayerPrefs.SetString("ItemDescription", temp_description);
        }
        else
        {
            Debug.Log("������ �Է����ּ���");

        }
    }

    void LoadData()
    {
            itemNameText.text = $"������ �̸� : {PlayerPrefs.GetString("ItemName")}";
            itemDescriptionText.text = $"������ ���� : {PlayerPrefs.GetString("ItemDescription")}";

    }
    void LoadCheck()
        {
            if (PlayerPrefs.HasKey("ItemName") && PlayerPrefs.HasKey("ItemDescription"))
            {
                LoadButton.interactable = true;
            }
            else
            {
                LoadButton.interactable = false;
            }
        }

    }
    /// <summary>
    /// �۾��� �������Ǿ��� �� �ش� ������ �Է������� �˷��ִ� �Լ�
    /// </summary>
    /// <param name="text">����</param>

    //void ValueChanged(string text)
    /*{ 
        Debug.Log($"{text} �Է� �߽��ϴ�.");
    }*/
    




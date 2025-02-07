using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemDataSystem : MonoBehaviour
{


    [Header("=== 인풋 필드 ===")]
    public TMP_InputField nameInputField;
    public TMP_InputField DescriptionInputField;

    [Header("=== 버튼 ===")]
    public Button LoadButton;
    public Button SaveButton;
    public Button DeleteButton;

    [Header("=== 아이템 정보 ===")]
    public TMP_Text itemNameText;
    public TMP_Text itemDescriptionText;

    public string temp_name;
    public string temp_description;



    //public bool interactable;

    void Start()
    {
        //nameInputField.onEndEdit.AddListener(ValueChanged);
        //이 방식으로 등록한 기능은 유니티 인스펙터에서 보이지 않습니다.
        // DescriptionInputField.onEndEdit.AddListener(ValueChanged);

        //LoadButton.interactable = interactable;
        //버튼의 interactable은 사용자와의 상호작용 여부를 제어할 때 사용하는 값입니다.
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

    // 1. public에서 만든 함수는 유니티 인스펙터에서 직접 연결하겠습니다.
    // 2. public이 아닌 함수는 스크립트 코드를 통해 기능을 연결해주겠습니다.

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
            Debug.Log("내용을 입력해주세요");

        }
    }

    void LoadData()
    {
            itemNameText.text = $"아이템 이름 : {PlayerPrefs.GetString("ItemName")}";
            itemDescriptionText.text = $"아이템 설명 : {PlayerPrefs.GetString("ItemDescription")}";

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
    /// 작업이 마무리되었을 때 해당 문구를 입력했음을 알려주는 함수
    /// </summary>
    /// <param name="text">문구</param>

    //void ValueChanged(string text)
    /*{ 
        Debug.Log($"{text} 입력 했습니다.");
    }*/
    




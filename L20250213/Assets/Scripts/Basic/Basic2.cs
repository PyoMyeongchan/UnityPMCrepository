using System;
using UnityEngine;
using UnityEngine.UI;

public class Basic2 : MonoBehaviour
{
    //인풋 필드에 값을 입력하고 값이 변경되면 텍스트를 수정해주는 코드

    public InputField inputField;

    public Text text;

    public void Start()
    {
        inputField.onValueChanged.AddListener(inputText);
    }

    private void inputText(string arg0)
    {
        text.text = arg0;   
    }
}

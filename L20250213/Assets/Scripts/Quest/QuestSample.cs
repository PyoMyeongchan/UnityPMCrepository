using System;
using UnityEngine;

public enum QuestType
{ 
    normal, daily, weekly
}

//일반 퀘스트 : 클리어하면 더 이상 깰 수 없습니다.
//데일리 퀘스트 : 매일을 기준으로 퀘스트가 갱신됩니다.
//위클리 퀘스트 : 주를 기준으로 퀘스트가 갱신됩니다.

[CreateAssetMenu(fileName="Quest", menuName = "Quest/Quest")]
public class QuestSample : ScriptableObject
{
    public QuestType 퀘스트유형;
    public Reward 보상;
    public Requirement 요구조건;


    [Header("퀘스트 정보")]
    public string 제목; //퀘스트의 제목
    public string 내용; //퀘스트의 내용
    [TextArea] public string 설명; //퀘스트에 대한 설명

    public bool 성공; //퀘스트의 성공 여부를 체크합니다.
    public bool 진행상태; //퀘스트가 진행 중인지를 확인하는 용도로 사용합니다.

}

[Serializable]
[CreateAssetMenu(fileName = "Quest", menuName = "Quest/Requirement")]
public class Requirement : ScriptableObject
{
    public int 목표몬스터수;
    public int 현재잡은몬스터수;


}

[Serializable]
[CreateAssetMenu(fileName = "Quest", menuName = "Quest/Reward")]

public class Reward : ScriptableObject
{
    public int 돈;
    public float 경험치;

}
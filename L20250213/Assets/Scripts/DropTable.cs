using System.Collections.Generic;
using UnityEngine;

//CreateAssetMenu�� ����
//()�ȿ� fileName, menuName, order�� ������ �� �ֽ��ϴ�.
//fileName : �����Ǵ� ������ �̸�
//menuName : Create�� ���� ��������� �޴��� �̸��� �����մϴ�. /�� ���� ��� ��ΰ� �߰��˴ϴ�.
//order : �޴� �߿��� ���° ��ġ�� ������ �� ǥ���� �� �����ϴ� ��, ���� Ŭ���� �������� ǥ��˴ϴ�.

[CreateAssetMenu(fileName = "DropTable", menuName = "DropTable/drop_table")]
public class DropTable : ScriptableObject
{
    public List<GameObject> drop_table;


}

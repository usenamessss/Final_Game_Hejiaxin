using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerManager : MonoBehaviour
{
    public static TriggerManager Instance;

    // �洢�Ѵ����Ĵ���������
    private HashSet<string> triggeredObjects = new HashSet<string>();

    void Awake()
    {
        // ȷ������
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ��ֹ�����л�ʱ����
        }
        else
        {
            Destroy(gameObject);
        }

        // ÿ����Ϸ���¿�ʼʱ��մ�������¼
        ClearTriggeredObjects();
    }

    // ��մ�������¼
    public void ClearTriggeredObjects()
    {
        triggeredObjects.Clear();
        Debug.Log("���д�������¼�����");
    }

    // ��Ǵ������Ѵ���
    public void MarkTriggered(string triggerName)
    {
        if (!triggeredObjects.Contains(triggerName))
        {
            triggeredObjects.Add(triggerName);
            Debug.Log("������ " + triggerName + " �ѱ���¼");
        }
    }

    // ��鴥�����Ƿ��ѱ�����
    public bool IsTriggered(string triggerName)
    {
        return triggeredObjects.Contains(triggerName);
    }
}

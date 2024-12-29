using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerManager : MonoBehaviour
{
    public static TriggerManager Instance;

    // 存储已触发的触发器名称
    private HashSet<string> triggeredObjects = new HashSet<string>();

    void Awake()
    {
        // 确保单例
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 防止场景切换时销毁
        }
        else
        {
            Destroy(gameObject);
        }

        // 每次游戏重新开始时清空触发器记录
        ClearTriggeredObjects();
    }

    // 清空触发器记录
    public void ClearTriggeredObjects()
    {
        triggeredObjects.Clear();
        Debug.Log("所有触发器记录已清空");
    }

    // 标记触发器已触发
    public void MarkTriggered(string triggerName)
    {
        if (!triggeredObjects.Contains(triggerName))
        {
            triggeredObjects.Add(triggerName);
            Debug.Log("触发器 " + triggerName + " 已被记录");
        }
    }

    // 检查触发器是否已被触发
    public bool IsTriggered(string triggerName)
    {
        return triggeredObjects.Contains(triggerName);
    }
}

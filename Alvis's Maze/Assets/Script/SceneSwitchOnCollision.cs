using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchOnCollision : MonoBehaviour
{
    public GameObject player;  // 玩家对象
    void OnTriggerEnter2D(Collider2D other)
    {
        // 检查碰撞对象是否是玩家对象
        if (other.gameObject == player)
        {
            Debug.Log("切换场景！");
            LoadScene3();
        }
    }

    void LoadScene3()
    {
        // 使用 SceneManager.LoadScene 进行场景切换
        SceneManager.LoadScene("Scene3"); // 替换 "Scene2" 为你的实际场景名
    }
}

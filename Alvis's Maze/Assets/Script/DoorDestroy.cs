using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorDestroy : MonoBehaviour
{
    public GameObject player;  // 玩家对象


    void OnTriggerEnter2D(Collider2D other)
    {

        // 检测玩家是否碰撞到门
        if (other.gameObject == player)
        {
            Destroy(gameObject);  // 销毁门对象
            LoadScene3();

        }
    }
    void LoadScene3()
    {
        // 使用 SceneManager.LoadScene 进行场景切换
        SceneManager.LoadScene("Scene3"); // 替换 "Scene2" 为你的实际场景名
    }

}

using UnityEngine;

public class QuitGameManager : MonoBehaviour
{
    void Update()
    {
        // 检测 ESC 键
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    void QuitGame()
    {
        // 在编辑器中停止游戏，在构建后的应用中退出
#if UNITY_EDITOR
        Debug.Log("退出游戏！（编辑器模式）");
        UnityEditor.EditorApplication.isPlaying = false; // 停止播放模式
#else
        Debug.Log("退出游戏！（构建模式）");
        Application.Quit(); // 退出游戏
#endif
    }
}

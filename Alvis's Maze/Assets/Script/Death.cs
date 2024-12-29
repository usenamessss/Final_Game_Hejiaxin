using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GameObject player;        // 玩家物体
    public string sceneToLoad = "Scene3 1"; // 要加载的场景名

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player) // 确保玩家触发
        {
            Debug.Log("Player collided with death trigger.");
            AudioManager.Instance.PlayEffectMusic(0); // 播放死亡音乐（假设死亡音乐是 effectMusicClips[0]）
            Invoke("LoadScene", 10f); // 10秒后加载场景
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad); // 加载指定的场景
    }
}

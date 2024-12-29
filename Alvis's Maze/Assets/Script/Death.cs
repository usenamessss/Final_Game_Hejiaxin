using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GameObject player;        // �������
    public string sceneToLoad = "Scene3 1"; // Ҫ���صĳ�����

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player) // ȷ����Ҵ���
        {
            Debug.Log("Player collided with death trigger.");
            AudioManager.Instance.PlayEffectMusic(0); // �����������֣��������������� effectMusicClips[0]��
            Invoke("LoadScene", 10f); // 10�����س���
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad); // ����ָ���ĳ���
    }
}

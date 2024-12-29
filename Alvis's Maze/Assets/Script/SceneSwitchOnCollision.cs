using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchOnCollision : MonoBehaviour
{
    public GameObject player;  // ��Ҷ���
    void OnTriggerEnter2D(Collider2D other)
    {
        // �����ײ�����Ƿ�����Ҷ���
        if (other.gameObject == player)
        {
            Debug.Log("�л�������");
            LoadScene3();
        }
    }

    void LoadScene3()
    {
        // ʹ�� SceneManager.LoadScene ���г����л�
        SceneManager.LoadScene("Scene3"); // �滻 "Scene2" Ϊ���ʵ�ʳ�����
    }
}

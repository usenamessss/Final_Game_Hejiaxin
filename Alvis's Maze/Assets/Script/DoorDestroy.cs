using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorDestroy : MonoBehaviour
{
    public GameObject player;  // ��Ҷ���


    void OnTriggerEnter2D(Collider2D other)
    {

        // �������Ƿ���ײ����
        if (other.gameObject == player)
        {
            Destroy(gameObject);  // �����Ŷ���
            LoadScene3();

        }
    }
    void LoadScene3()
    {
        // ʹ�� SceneManager.LoadScene ���г����л�
        SceneManager.LoadScene("Scene3"); // �滻 "Scene2" Ϊ���ʵ�ʳ�����
    }

}

using UnityEngine;

public class QuitGameManager : MonoBehaviour
{
    void Update()
    {
        // ��� ESC ��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    void QuitGame()
    {
        // �ڱ༭����ֹͣ��Ϸ���ڹ������Ӧ�����˳�
#if UNITY_EDITOR
        Debug.Log("�˳���Ϸ�����༭��ģʽ��");
        UnityEditor.EditorApplication.isPlaying = false; // ֹͣ����ģʽ
#else
        Debug.Log("�˳���Ϸ��������ģʽ��");
        Application.Quit(); // �˳���Ϸ
#endif
    }
}

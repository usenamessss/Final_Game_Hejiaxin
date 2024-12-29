using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class textplayer : MonoBehaviour
{
    public TMP_Text textDisplay; // TextMeshPro UI ����
    private string[] storyLines = {
        "�ҵ������ݵ���ͣ������ҽӼ������һλ���ߡ�\r\n����Щ���ǲ����ˣ�����˵�������Ļ������ȴһֱ��߶�Ź��ڡ�ɽ���͡���������һЩ�ʻ㡣\r\n�ҽӹ������������һ�����ӣ�����д����һЩ���ҵ����ţ���������ɣ�ʵ�ڲ����������������ּ���\r\n������ֽ���ƣ�Ӧ���Ǳ����˺ܾ��˵�����������������������֢�ᡣ",
        "\r\n��ѯ���������֡�\r\n����������ά˹��\r\n����������������������������¼�ķ��š� \r\n�������Ĺ��º���ã�\r\nƴ����������һ������ɽ������֮��Ĺ�̸��\r\n����һ������ĳ��߾�����",
        "��ϧ���õĽ��ﾭ�����Ҳ������κλ��ߵ����£�\r\n����������������ʹ���ʡ�Ժͻ��ҵ��˳� \r\nΪ�˽⿪֢�ᣬ��Ҫ��������˵����ȷ����ʵ��\r\n��������һ�������Թ�����������ĳ���",
        "�����ڶԻ��в���\r\n�����������˳ƣ�\r\n �����������¼���\r\n ������������Ԫ�أ�\r\n��ԭ���ߵ�����\r\n �Թ������С���"
    };
    private int currentLineIndex = 0;

    void Start()
    {
        // ��ʾ��һ������
        UpdateText();
    }

    void Update()
    {
        // ���������� Horizontal ������
        if (Input.GetMouseButtonDown(0))
        {
            ShowNextLine();
        }
    }

    void ShowNextLine()
    {
        if (currentLineIndex < storyLines.Length - 1)
        {
            currentLineIndex++;
            UpdateText();
        }
        else
        {
            Debug.Log("�����ѽ�����");
            // ����������������߼���������ת��������ʾ��������
            // ���س���2
            LoadScene2();
        }
    }

    void UpdateText()
    {
        textDisplay.text = storyLines[currentLineIndex];
    }

    void LoadScene2()
    {
        // ʹ�� SceneManager.LoadScene ���г����л�
        SceneManager.LoadScene("Scene2"); // �滻 "Scene2" Ϊ���ʵ�ʳ�����
    }
}

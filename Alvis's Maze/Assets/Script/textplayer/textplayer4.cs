using UnityEngine;
using TMPro;
using UnityEngine.UI; // ���� UI �����ռ�

public class textplayer4 : MonoBehaviour
{
    public TMP_Text textDisplay;   // TextMeshPro UI ����
    public Button nextLineButton; // ��һ�а�ť
    public Button previousLineButton; // ��һ�а�ť
    public GameObject player;     // ��Ҷ���
    public GameObject train;       // �Ŷ���

    private string[] storyLines = {
         "��ʱ�Ҿ�֪��\r\n��ֻ����������ܼ�����Щ��",
        "����ά˹�������������� \r\nȻ����������Ÿոտ�ʼ"
    };
    private int currentLineIndex = 0;

    void Start()
    {
        // ��ʼ����ť����¼�
        nextLineButton.onClick.AddListener(ShowNextLine);
        previousLineButton.onClick.AddListener(ShowPreviousLine);

        // ��ʼ���ı���ʾ
        UpdateText();

        // ��ʼ����ť״̬
        UpdateButtonStates();
    }

    void ShowNextLine()
    {
        if (currentLineIndex < storyLines.Length - 1)
        {
            currentLineIndex++;
            UpdateText();
            UpdateButtonStates();
        }
    }

    void ShowPreviousLine()
    {
        if (currentLineIndex > 0)
        {
            currentLineIndex--;
            UpdateText();
            UpdateButtonStates();
        }
    }

    void UpdateText()
    {
        textDisplay.text = storyLines[currentLineIndex];
    }

    void UpdateButtonStates()
    {
        // ����ǵ�һ�У�������һ�а�ť
        previousLineButton.interactable = currentLineIndex > 0;

        // ��������һ�У�������һ�а�ť
        nextLineButton.interactable = currentLineIndex < storyLines.Length - 1;
    }
}
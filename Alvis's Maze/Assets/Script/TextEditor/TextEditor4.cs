using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // ����UI�����ռ�

public class TextEditor4 : MonoBehaviour
{
    public TMP_Text textDisplay;       // ������ʾ��ʼ�ı��� TextMeshPro ���
    public TMP_InputField inputField;  // ���ڱ༭�ı��� InputField ���
    public GameObject m1;              // �����е����壬��ʼʱ����
    public Button[] buttons;           // ������������Ҫ���Ƶİ�ť

    public TMP_Text hintText;          // ������ʾ�ı�
    public string sceneToLoad = "Scene3 3"; // Ҫ���صĳ�����

    private string[] storyLines = {   // Ԥ����ı�
        "��ʱ�Ҿ�֪��\r\n��ֻ����������ܼ�����Щ��",
        "����ά˹�������������� \r\nȻ����������Ÿոտ�ʼ"
    };

    private string initialText;        // ��ʼ�ı�
    private string currentText;        // ��ǰ���ı������ڴ洢�༭�������
    private int currentLineIndex = 0;  // ��ǰ�е�����
    private bool isEditing = false;    // ��ǵ�ǰ�Ƿ����ڱ༭
    private bool hasModified = false;  // �Ƿ��޸Ĺ��ı�

    void Start()
    {
        initialText = storyLines[currentLineIndex];
        currentText = initialText;
        textDisplay.text = initialText;
        inputField.gameObject.SetActive(false);
        m1.SetActive(false);

        UpdateButtonInteractable(); // ��ʼ����ť����״̬

    }

    void Update()
    {
        DetectCurrentLine();

        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleEditingMode();
        }

        if (isEditing)
        {
            hintText.gameObject.SetActive(false);

            string newText = inputField.text;
            hasModified = false;

            // ��Ⲣ�滻
            if (newText.Contains("������ά˹��") || newText.Contains("\"����ά˹\""))
            {
                Debug.Log("��⵽���롰����ά˹��");
                currentText = newText.Replace("������ά˹��", "��ɽ��");
                textDisplay.text = currentText;
                hasModified = true;
                m1.SetActive(true);
                Invoke("LoadScene", 2f);

                ShowRemainingStory(); // ��ʾ��������
                ToggleEditingMode(); // �Զ��˳��༭ģʽ
            }

            // ���û����Ч�޸ģ�����Ϊ��ǰ�е�ԭʼ�ı�
            if (!hasModified)
            {
                Debug.Log("������Ч�������û�������ı�");
                currentText = storyLines[currentLineIndex]; // ����Ϊ��ǰ�е�ԭʼ�ı�
                textDisplay.text = currentText;
            }
        }
        UpdateButtonInteractable(); // ÿ���л��༭ģʽʱ���°�ť״̬
    }

    void DetectCurrentLine()
    {
        for (int i = 0; i < storyLines.Length; i++)
        {
            if (textDisplay.text == storyLines[i])
            {
                currentLineIndex = i;
                Debug.Log("��ǰ������: " + currentLineIndex);
                break;
            }
        }
    }
    void UpdateButtonInteractable()
    {
        // ���ð�ť����״̬
        foreach (Button button in buttons)
        {
            button.interactable = !isEditing; // ��ť�ڱ༭ģʽ�½���
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad); // ����ָ���ĳ���
    }

    void ToggleEditingMode()
    {
        isEditing = !isEditing;

        if (isEditing)
        {
            inputField.gameObject.SetActive(true);
            inputField.text = textDisplay.text;
            inputField.Select();
            textDisplay.gameObject.SetActive(false);
        }
        else
        {
            textDisplay.text = currentText;
            textDisplay.gameObject.SetActive(true);
            inputField.gameObject.SetActive(false);
        }
    }

    void ShowRemainingStory()
    {
        if (hasModified && currentLineIndex < storyLines.Length - 1)
        {
            Debug.Log("��ʾ��������...");
            // ��˳����ʾ����������
            for (int i = currentLineIndex + 1; i < storyLines.Length; i++)
            {
                currentText += "\n\n" + storyLines[i];
            }

            textDisplay.text = currentText; // ������ʾ���ı�
        }
    }
   
}

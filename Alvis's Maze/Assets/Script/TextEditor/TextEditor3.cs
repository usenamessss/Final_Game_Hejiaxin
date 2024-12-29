using UnityEngine;
using TMPro;
using UnityEngine.UI; // ����UI�����ռ�

public class TextEditor3 : MonoBehaviour
{
    public TMP_Text textDisplay;       // ������ʾ��ʼ�ı��� TextMeshPro ���
    public TMP_InputField inputField;  // ���ڱ༭�ı��� InputField ���
    public GameObject m1;              // �����е����壬��ʼʱ����
    public GameObject m2;
    public GameObject m3;
    public TMP_Text hintText;          // ������ʾ�ı�
    public Button[] buttons;           // ������������Ҫ���Ƶİ�ť

    private string[] storyLines = {   // Ԥ����ı�
        "�������ǲ��������Ѿ��뿪��",
        "�����ھӵ����˷���",
        "������һ���峿",
        "��Ҳ��һ���޴�ĺ��������뿪��",
        "��ȷ�����ҵ�����"
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
        m2.SetActive(false);
        m3.SetActive(false);

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

            // ��Ⲣ�滻��������Ϊ�����衱
            if (newText.Contains("��������") || newText.Contains("\"����\""))
            {
                Debug.Log("��⵽���롰������");
                currentText = newText.Replace("��������", "�����衱");
                textDisplay.text = currentText;
                hasModified = true;
                m1.SetActive(true);
                m2.SetActive(false);
                m3.SetActive(false);
                ToggleEditingMode(); // �Զ��˳��༭ģʽ
            }

            // ��Ⲣ�滻���������ڲ�ͬ�еĳ���
            if (!hasModified && (newText.Contains("����") || newText.Contains("......") || newText.Contains("��")))
            {
                Debug.Log("��⵽����ʡ�Ժ�");

                // �Եڶ��еļ��
                if (currentLineIndex == 1) // �ڶ���
                {
                    int doorIndex = newText.IndexOf("����");
                    int questionMarkIndex = newText.IndexOf("����");

                    if (questionMarkIndex < doorIndex)
                    {
                        Debug.Log("��⵽�ڵڶ��еġ�������֮ǰ������'����'����");
                        currentText = newText.Replace("����", "\r\n �����ߺ������յ�������ѯ���ҵ�����");
                        textDisplay.text = currentText;
                        hasModified = true;
                        m2.SetActive(true);
                        m1.SetActive(false);
                        m3.SetActive(false);
                        ToggleEditingMode(); // �Զ��˳��༭ģʽ
                    }
                }

                // �����һ�еļ��
                else if (currentLineIndex == storyLines.Length - 1) // ���һ��
                {
                    int believeIndex = newText.IndexOf("��ȷ��");
                    int questionMarkIndex = newText.IndexOf("����");

                    if (questionMarkIndex < believeIndex)
                    {
                        Debug.Log("��⵽�����һ�еġ���ȷ�š�֮ǰ������'����'����");
                        currentText = newText.Replace("����", "\r\n �����������ľ�ͷ");
                        textDisplay.text = currentText;
                        hasModified = true;
                        m3.SetActive(true);
                        m1.SetActive(false);
                        m2.SetActive(false);
                        ToggleEditingMode(); // �Զ��˳��༭ģʽ
                    }
                }
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
}

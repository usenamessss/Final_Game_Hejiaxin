using UnityEngine;
using TMPro;
using UnityEngine.UI; // ����UI�����ռ�

public class TextEditor2 : MonoBehaviour
{
    public TMP_Text textDisplay;       // ������ʾ��ʼ�ı��� TextMeshPro ���
    public TMP_InputField inputField;  // ���ڱ༭�ı��� InputField ���
    public GameObject train;           // �����е� train ���壬��ʼʱ����
    public TMP_Text hintText;          // ������ʾ�ı�
    public Button[] buttons;           // ������������Ҫ���Ƶİ�ť

    private string[] storyLines = {   // Ԥ����ı�
        "������˵ɽ�Ǽ�ʻһ�������ؼҵ�",
        "ÿ��ɽ����ʱ \r\n������ᴫ��һ��޴�ĺ�����",
        "�Ҳ��뵱������������ʱ\r\n�����ҿ����뿪��ʱ��",
        "����˵��û��\r\n�ҳɹ��뿪��"
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
        train.SetActive(false);

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

            // ��Ⲣ�滻��������Ϊ��һ�������ƶ��İ׹⡱
            if (newText.Contains("��������") || newText.Contains("\"����\""))
            {
                Debug.Log("��⵽���롰������");
                currentText = newText.Replace("��������", "��һ�������ƶ��İ׹⡱");
                textDisplay.text = currentText;
                hasModified = true;
                train.SetActive(true);
                ToggleEditingMode(); // �Զ��˳��༭ģʽ
            }

            if (!hasModified && (newText.Contains("����") || newText.Contains("......") || newText.Contains("��")))
            {
                Debug.Log("��⵽����ʡ�Ժ�");

                // �������һ�м�⡰û���͡��ҳɹ���֮���ʡ�Ժ�
                if (currentLineIndex == storyLines.Length - 1) // ���һ��
                {
                    int doorIndex = newText.IndexOf("û��");
                    int successIndex = newText.IndexOf("�ҳɹ�");
                    int questionMarkIndex = newText.IndexOf("����");

                    if (doorIndex != -1 && questionMarkIndex > doorIndex && successIndex != -1 && questionMarkIndex < successIndex)
                    {
                        Debug.Log("��⵽�ڡ�û���͡��ҳɹ���֮��������'����'����");

                        // ֱ���滻�����ı�
                        currentText = "����˵��û�� ֻҪ������������ \r\n�ҳɹ��뿪��";
                        textDisplay.text = currentText;
                        hasModified = true;
                        ToggleEditingMode(); // �Զ��˳��༭ģʽ
                    }
                }
            }

            // ���û����Ч�޸ģ��ָ�ԭʼ�ı�
            if (!hasModified)
            {
                Debug.Log("������Ч���ָ�ԭʼ�ı�");
                currentText = storyLines[currentLineIndex]; // �ָ���ǰ�е�ԭʼ�ı�
                textDisplay.text = currentText;
            }


        }
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

            if (hasModified)
            {
                
            }
        }
        UpdateButtonInteractable(); // ÿ���л��༭ģʽʱ���°�ť״̬
    }
    void UpdateButtonInteractable()
    {
        // ���ð�ť����״̬
        foreach (Button button in buttons)
        {
            button.interactable = !isEditing; // ��ť�ڱ༭ģʽ�½���
        }
    }
}

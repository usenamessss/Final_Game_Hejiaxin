using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextEditor : MonoBehaviour
{
    public TMP_Text textDisplay;       // ������ʾ��ʼ�ı��� TextMeshPro ���
    public TMP_InputField inputField;  // ���ڱ༭�ı��� InputField ���
    public GameObject door;            // �����е� door ���壬��ʼʱ����
    public TMP_Text hintText;          // ������ʾ�ı�
    public TMP_Text hintText2;         // �ڶ�����ʾ�ı��������� "ɽ" �� "����" ʱ��ʾ��
    public Button[] buttons;           // ������������Ҫ���Ƶİ�ť

    private string[] storyLines = {   // Ԥ��������ı�
        "�Ҳ�֪��ΪʲôɽҪ�������� \r\n�������Ӷ��ھ��ҵ���",
        "���������˵�����",
        "��һ��ҹ�� ����������ֹͣ�� \r\n�Ҽƻ��뿪����ط�"
    };

    private string initialText;        // ��ʼ�ı�
    private string currentText;        // ��ǰ���ı������ڴ洢�༭�������
    private int currentLineIndex = 0;  // ��ǰ�е�����
    private bool isEditing = false;    // ��ǵ�ǰ�Ƿ����ڱ༭
    private bool hasFoundCorrectPosition = false;  // ���ڱ���Ƿ��Ѿ��ɹ��޸����ı�

    void Start()
    {
        initialText = storyLines[currentLineIndex];   // ʹ�õ�һ����Ϊ��ʼ�ı�
        currentText = initialText;
        textDisplay.text = initialText; // ��ʾ��ʼ�ı�
        inputField.gameObject.SetActive(false); // ��ʼʱ����ʾ InputField
        door.SetActive(false);           // ��ʼʱ���� door ����
        hintText.gameObject.SetActive(true); // ��ʾ��ʾ�ı�
        hintText2.gameObject.SetActive(false); // ���� hintText2

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
            hintText.gameObject.SetActive(false); // ������ʾ�ı�

            string newText = inputField.text; // ��ȡ������е��ı�

            // ����Ƿ������ˡ�ɽ���򡰺�����
            if (newText.Contains("��ɽ��") || newText.Contains("��������"))
            {
                Debug.Log("��⵽���롰ɽ���򡰺�����");
                hintText2.gameObject.SetActive(true); // ��ʾ hintText2
            }
            else
            {
                hintText2.gameObject.SetActive(false); // ���δ����ؼ��֣����� hintText2
            }

            // ��⡰���������ŵ�λ�ú�����
            if (newText.Contains("��������"))
            {
                Debug.Log("��⵽���롰������");
                int startIndex = newText.IndexOf("��������");
                currentText = "�Ҳ�֪��ΪʲôɽҪ������������ \r\n����Ҫ��������ط�ת����\r\n�����ڿ���\r\n"
                              + initialText.Substring(startIndex + 5);
                textDisplay.text = currentText; // ������ʾ���ı�

                // �Զ��˳��༭ģʽ
                ToggleEditingMode();
                return; // �������θ���
            }

            // �ж��Ƿ��С������������룬������λ���ж�
            if (newText.Contains("��") || newText.Contains("?"))
            {
                Debug.Log("��⵽���룿");

                int doorIndex = newText.IndexOf("����");
                Debug.Log("������������: " + doorIndex);

                int questionMarkIndex = newText.IndexOf("��");
                Debug.Log("����������: " + questionMarkIndex);

                if (doorIndex != -1 && questionMarkIndex < doorIndex)
                {
                    Debug.Log("��⵽��'����'֮ǰ������'��'����");

                    currentText = newText.Replace("������", "���⴫��");
                    textDisplay.text = currentText;

                    hasFoundCorrectPosition = true;

                    // �Զ��˳��༭ģʽ
                    ToggleEditingMode();
                    return; // �������θ���
                }
            }

            // ��ӷ�ֹ������Чʱ�ָ�ԭ�ı�
            if (!newText.Contains("��������") && !newText.Contains("��"))
            {
                Debug.Log("������Ч���ָ�ԭʼ�ı�");
                currentText = storyLines[currentLineIndex]; // �ָ���ǰ�г�ʼ�ı�
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
            inputField.gameObject.SetActive(true);        // ��ʾ�����
            inputField.text = textDisplay.text;           // ����ǰ�ı���ֵ�������
            inputField.interactable = true;               // ��������򽻻�
            textDisplay.gameObject.SetActive(false);      // ������ʾ���ı�
            inputField.Select();                          // �Զ�ѡ�������

        }
        else
        {
            // �˳��༭ģʽʱ���������벢չʾ�޸ĺ���ı�
            textDisplay.text = currentText;               // ʹ�ñ�����޸Ĺ����ı�
            textDisplay.gameObject.SetActive(true);       // ��ʾ�޸ĺ���ı�
            inputField.gameObject.SetActive(false);       // ���������
            inputField.interactable = false;              // ���������

            if (hasFoundCorrectPosition)
            {
                door.SetActive(true);                     // ��ʾ door ����
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

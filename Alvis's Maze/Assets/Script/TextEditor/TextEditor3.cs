using UnityEngine;
using TMPro;
using UnityEngine.UI; // 引入UI命名空间

public class TextEditor3 : MonoBehaviour
{
    public TMP_Text textDisplay;       // 用于显示初始文本的 TextMeshPro 组件
    public TMP_InputField inputField;  // 用于编辑文本的 InputField 组件
    public GameObject m1;              // 场景中的物体，初始时隐藏
    public GameObject m2;
    public GameObject m3;
    public TMP_Text hintText;          // 操作提示文本
    public Button[] buttons;           // 场景中所有需要控制的按钮

    private string[] storyLines = {   // 预设的文本
        "河流总是不相信我已经离开了",
        "她被邻居当成了疯子",
        "终于在一个清晨",
        "她也在一声巨大的轰鸣声中离开了",
        "她确信她找到了我"
    };

    private string initialText;        // 初始文本
    private string currentText;        // 当前的文本，用于存储编辑后的内容
    private int currentLineIndex = 0;  // 当前行的索引
    private bool isEditing = false;    // 标记当前是否正在编辑
    private bool hasModified = false;  // 是否修改过文本

    void Start()
    {
        initialText = storyLines[currentLineIndex];
        currentText = initialText;
        textDisplay.text = initialText;
        inputField.gameObject.SetActive(false);
        m1.SetActive(false);
        m2.SetActive(false);
        m3.SetActive(false);

        UpdateButtonInteractable(); // 初始化按钮交互状态
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

            // 检测并替换“河流”为“妈妈”
            if (newText.Contains("“河流”") || newText.Contains("\"河流\""))
            {
                Debug.Log("检测到输入“河流”");
                currentText = newText.Replace("“河流”", "“妈妈”");
                textDisplay.text = currentText;
                hasModified = true;
                m1.SetActive(true);
                m2.SetActive(false);
                m3.SetActive(false);
                ToggleEditingMode(); // 自动退出编辑模式
            }

            // 检测并替换“……”在不同行的场景
            if (!hasModified && (newText.Contains("……") || newText.Contains("......") || newText.Contains("…")))
            {
                Debug.Log("检测到输入省略号");

                // 对第二行的检测
                if (currentLineIndex == 1) // 第二行
                {
                    int doorIndex = newText.IndexOf("她被");
                    int questionMarkIndex = newText.IndexOf("……");

                    if (questionMarkIndex < doorIndex)
                    {
                        Debug.Log("检测到在第二行的“她被”之前输入了'……'符号");
                        currentText = newText.Replace("……", "\r\n 在我走后她日日到稻田里询问我的下落");
                        textDisplay.text = currentText;
                        hasModified = true;
                        m2.SetActive(true);
                        m1.SetActive(false);
                        m3.SetActive(false);
                        ToggleEditingMode(); // 自动退出编辑模式
                    }
                }

                // 对最后一行的检测
                else if (currentLineIndex == storyLines.Length - 1) // 最后一行
                {
                    int believeIndex = newText.IndexOf("她确信");
                    int questionMarkIndex = newText.IndexOf("……");

                    if (questionMarkIndex < believeIndex)
                    {
                        Debug.Log("检测到在最后一行的“她确信”之前输入了'……'符号");
                        currentText = newText.Replace("……", "\r\n 在那束光亮的尽头");
                        textDisplay.text = currentText;
                        hasModified = true;
                        m3.SetActive(true);
                        m1.SetActive(false);
                        m2.SetActive(false);
                        ToggleEditingMode(); // 自动退出编辑模式
                    }
                }
            }

            // 如果没有有效修改，重置为当前行的原始文本
            if (!hasModified)
            {
                Debug.Log("输入无效，保留用户输入的文本");
                currentText = storyLines[currentLineIndex]; // 重置为当前行的原始文本
                textDisplay.text = currentText;
            }
        }
        UpdateButtonInteractable(); // 每次切换编辑模式时更新按钮状态
    }

    void DetectCurrentLine()
    {
        for (int i = 0; i < storyLines.Length; i++)
        {
            if (textDisplay.text == storyLines[i])
            {
                currentLineIndex = i;
                Debug.Log("当前行索引: " + currentLineIndex);
                break;
            }
        }
    }
    void UpdateButtonInteractable()
    {
        // 设置按钮交互状态
        foreach (Button button in buttons)
        {
            button.interactable = !isEditing; // 按钮在编辑模式下禁用
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

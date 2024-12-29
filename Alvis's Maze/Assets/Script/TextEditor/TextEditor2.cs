using UnityEngine;
using TMPro;
using UnityEngine.UI; // 引入UI命名空间

public class TextEditor2 : MonoBehaviour
{
    public TMP_Text textDisplay;       // 用于显示初始文本的 TextMeshPro 组件
    public TMP_InputField inputField;  // 用于编辑文本的 InputField 组件
    public GameObject train;           // 场景中的 train 物体，初始时隐藏
    public TMP_Text hintText;          // 操作提示文本
    public Button[] buttons;           // 场景中所有需要控制的按钮

    private string[] storyLines = {   // 预设的文本
        "听河流说山是驾驶一条巨蟒回家的",
        "每当山到家时 \r\n稻田外会传来一阵巨大的轰鸣声",
        "我猜想当我听到轰鸣声时\r\n就是我可以离开的时候",
        "河流说的没错\r\n我成功离开了"
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
        train.SetActive(false);

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

            // 检测并替换“巨蟒”为“一束快速移动的白光”
            if (newText.Contains("“巨蟒”") || newText.Contains("\"巨蟒\""))
            {
                Debug.Log("检测到输入“巨蟒”");
                currentText = newText.Replace("“巨蟒”", "“一束快速移动的白光”");
                textDisplay.text = currentText;
                hasModified = true;
                train.SetActive(true);
                ToggleEditingMode(); // 自动退出编辑模式
            }

            if (!hasModified && (newText.Contains("……") || newText.Contains("......") || newText.Contains("…")))
            {
                Debug.Log("检测到输入省略号");

                // 仅在最后一行检测“没错”和“我成功”之间的省略号
                if (currentLineIndex == storyLines.Length - 1) // 最后一行
                {
                    int doorIndex = newText.IndexOf("没错");
                    int successIndex = newText.IndexOf("我成功");
                    int questionMarkIndex = newText.IndexOf("……");

                    if (doorIndex != -1 && questionMarkIndex > doorIndex && successIndex != -1 && questionMarkIndex < successIndex)
                    {
                        Debug.Log("检测到在“没错”和“我成功”之间输入了'……'符号");

                        // 直接替换整行文本
                        currentText = "河流说的没错 只要靠近那束光亮 \r\n我成功离开了";
                        textDisplay.text = currentText;
                        hasModified = true;
                        ToggleEditingMode(); // 自动退出编辑模式
                    }
                }
            }

            // 如果没有有效修改，恢复原始文本
            if (!hasModified)
            {
                Debug.Log("输入无效，恢复原始文本");
                currentText = storyLines[currentLineIndex]; // 恢复当前行的原始文本
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
                Debug.Log("当前行索引: " + currentLineIndex);
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
        UpdateButtonInteractable(); // 每次切换编辑模式时更新按钮状态
    }
    void UpdateButtonInteractable()
    {
        // 设置按钮交互状态
        foreach (Button button in buttons)
        {
            button.interactable = !isEditing; // 按钮在编辑模式下禁用
        }
    }
}

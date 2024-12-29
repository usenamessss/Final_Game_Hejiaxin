using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextEditor : MonoBehaviour
{
    public TMP_Text textDisplay;       // 用于显示初始文本的 TextMeshPro 组件
    public TMP_InputField inputField;  // 用于编辑文本的 InputField 组件
    public GameObject door;            // 场景中的 door 物体，初始时隐藏
    public TMP_Text hintText;          // 操作提示文本
    public TMP_Text hintText2;         // 第二个提示文本（当输入 "山" 或 "河流" 时显示）
    public Button[] buttons;           // 场景中所有需要控制的按钮

    private string[] storyLines = {   // 预设的三行文本
        "我不知道为什么山要那样生气 \r\n整个房子都在剧烈地震动",
        "传来咚咚咚的声音",
        "有一天夜晚 爆破声终于停止了 \r\n我计划离开这个地方"
    };

    private string initialText;        // 初始文本
    private string currentText;        // 当前的文本，用于存储编辑后的内容
    private int currentLineIndex = 0;  // 当前行的索引
    private bool isEditing = false;    // 标记当前是否正在编辑
    private bool hasFoundCorrectPosition = false;  // 用于标记是否已经成功修改了文本

    void Start()
    {
        initialText = storyLines[currentLineIndex];   // 使用第一行作为初始文本
        currentText = initialText;
        textDisplay.text = initialText; // 显示初始文本
        inputField.gameObject.SetActive(false); // 初始时不显示 InputField
        door.SetActive(false);           // 初始时隐藏 door 物体
        hintText.gameObject.SetActive(true); // 显示提示文本
        hintText2.gameObject.SetActive(false); // 隐藏 hintText2

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
            hintText.gameObject.SetActive(false); // 隐藏提示文本

            string newText = inputField.text; // 获取输入框中的文本

            // 检测是否输入了“山”或“河流”
            if (newText.Contains("“山”") || newText.Contains("“河流”"))
            {
                Debug.Log("检测到输入“山”或“河流”");
                hintText2.gameObject.SetActive(true); // 显示 hintText2
            }
            else
            {
                hintText2.gameObject.SetActive(false); // 如果未输入关键字，隐藏 hintText2
            }

            // 检测“生气”符号的位置和内容
            if (newText.Contains("“生气”"))
            {
                Debug.Log("检测到输入“生气”");
                int startIndex = newText.IndexOf("“生气”");
                currentText = "我不知道为什么山要那样“生气” \r\n像是要把整个天地翻转过来\r\n河流在哭泣\r\n"
                              + initialText.Substring(startIndex + 5);
                textDisplay.text = currentText; // 更新显示的文本

                // 自动退出编辑模式
                ToggleEditingMode();
                return; // 结束本次更新
            }

            // 判断是否有“？”符号输入，并进行位置判断
            if (newText.Contains("？") || newText.Contains("?"))
            {
                Debug.Log("检测到输入？");

                int doorIndex = newText.IndexOf("传来");
                Debug.Log("“传来”索引: " + doorIndex);

                int questionMarkIndex = newText.IndexOf("？");
                Debug.Log("“？”索引: " + questionMarkIndex);

                if (doorIndex != -1 && questionMarkIndex < doorIndex)
                {
                    Debug.Log("检测到在'传来'之前输入了'？'符号");

                    currentText = newText.Replace("？传来", "门外传来");
                    textDisplay.text = currentText;

                    hasFoundCorrectPosition = true;

                    // 自动退出编辑模式
                    ToggleEditingMode();
                    return; // 结束本次更新
                }
            }

            // 添加防止输入无效时恢复原文本
            if (!newText.Contains("“生气”") && !newText.Contains("？"))
            {
                Debug.Log("输入无效，恢复原始文本");
                currentText = storyLines[currentLineIndex]; // 恢复当前行初始文本
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
            inputField.gameObject.SetActive(true);        // 显示输入框
            inputField.text = textDisplay.text;           // 将当前文本赋值给输入框
            inputField.interactable = true;               // 激活输入框交互
            textDisplay.gameObject.SetActive(false);      // 隐藏显示的文本
            inputField.Select();                          // 自动选中输入框

        }
        else
        {
            // 退出编辑模式时，保存输入并展示修改后的文本
            textDisplay.text = currentText;               // 使用保存的修改过的文本
            textDisplay.gameObject.SetActive(true);       // 显示修改后的文本
            inputField.gameObject.SetActive(false);       // 隐藏输入框
            inputField.interactable = false;              // 禁用输入框

            if (hasFoundCorrectPosition)
            {
                door.SetActive(true);                     // 显示 door 物体
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

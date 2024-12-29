using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // 引入UI命名空间

public class TextEditor4 : MonoBehaviour
{
    public TMP_Text textDisplay;       // 用于显示初始文本的 TextMeshPro 组件
    public TMP_InputField inputField;  // 用于编辑文本的 InputField 组件
    public GameObject m1;              // 场景中的物体，初始时隐藏
    public Button[] buttons;           // 场景中所有需要控制的按钮

    public TMP_Text hintText;          // 操作提示文本
    public string sceneToLoad = "Scene3 3"; // 要加载的场景名

    private string[] storyLines = {   // 预设的文本
        "那时我就知道\r\n我只有在梦里才能见到那些人",
        "阿尔维斯结束了他的叙述 \r\n然而真的叙述才刚刚开始"
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

            // 检测并替换
            if (newText.Contains("“阿尔维斯”") || newText.Contains("\"阿尔维斯\""))
            {
                Debug.Log("检测到输入“阿尔维斯”");
                currentText = newText.Replace("“阿尔维斯”", "“山”");
                textDisplay.text = currentText;
                hasModified = true;
                m1.SetActive(true);
                Invoke("LoadScene", 2f);

                ShowRemainingStory(); // 显示后续故事
                ToggleEditingMode(); // 自动退出编辑模式
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

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad); // 加载指定的场景
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
            Debug.Log("显示后续故事...");
            // 按顺序显示后四行内容
            for (int i = currentLineIndex + 1; i < storyLines.Length; i++)
            {
                currentText += "\n\n" + storyLines[i];
            }

            textDisplay.text = currentText; // 更新显示的文本
        }
    }
   
}

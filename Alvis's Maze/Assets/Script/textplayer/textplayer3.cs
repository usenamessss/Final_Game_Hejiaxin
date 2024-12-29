using UnityEngine;
using TMPro;
using UnityEngine.UI; // 引入 UI 命名空间

public class textplayer3 : MonoBehaviour
{
    public TMP_Text textDisplay;   // TextMeshPro UI 对象
    public Button nextLineButton; // 下一行按钮
    public Button previousLineButton; // 上一行按钮
    public GameObject player;     // 玩家对象
    public GameObject train;       // 门对象

    private string[] storyLines = {
        "河流总是不相信我已经离开了",
        "她被邻居当成了疯子",
        "终于在一个清晨",
        "她也在一声巨大的轰鸣声中离开了",
        "她确信她找到了我"
    };
    private int currentLineIndex = 0;

    void Start()
    {
        // 初始化按钮点击事件
        nextLineButton.onClick.AddListener(ShowNextLine);
        previousLineButton.onClick.AddListener(ShowPreviousLine);

        // 初始化文本显示
        UpdateText();

        // 初始化按钮状态
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
        // 如果是第一行，禁用上一行按钮
        previousLineButton.interactable = currentLineIndex > 0;

        // 如果是最后一行，禁用下一行按钮
        nextLineButton.interactable = currentLineIndex < storyLines.Length - 1;
    }
}
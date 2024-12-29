using UnityEngine;
using TMPro;
using UnityEngine.UI; // 引入 UI 命名空间

public class textplayer1 : MonoBehaviour
{
    public TMP_Text textDisplay;   // TextMeshPro UI 对象
    public Button nextLineButton; // 下一行按钮
    public Button previousLineButton; // 上一行按钮
    public GameObject player;     // 玩家对象
    public GameObject door;       // 门对象

    private string[] storyLines = {
        "我不知道为什么山要那样生气 \r\n 整个房子都在剧烈地震动",
        "传来咚咚咚的声音",
        "有一天夜晚 爆破声终于停止了 \r\n我计划离开这个地方"
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

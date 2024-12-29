using UnityEngine;
using TMPro;
using UnityEngine.UI; // 引入 UI 命名空间

public class textplayer2 : MonoBehaviour
{
    public TMP_Text textDisplay;   // TextMeshPro UI 对象
    public Button nextLineButton; // 下一行按钮
    public Button previousLineButton; // 上一行按钮
    public GameObject player;     // 玩家对象
    public GameObject train;       // 门对象

    private string[] storyLines = {
        "听河流说山是驾驶巨蟒回家的",
        "每当山到家时 \r\n稻田外会传来一阵巨大的轰鸣声",
        "我猜想当我听到轰鸣声时\r\n就是我可以离开的时候",
        "河流说的没错\r\n我成功离开了"
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
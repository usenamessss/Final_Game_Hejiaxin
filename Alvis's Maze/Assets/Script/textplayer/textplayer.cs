using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class textplayer : MonoBehaviour
{
    public TMP_Text textDisplay; // TextMeshPro UI 对象
    private string[] storyLines = {
        "我到了退休的年纪，那天我接见了最后一位患者。\r\n他有些神智不清了，很难说出完整的话语，嘴里却一直念叨着关于“山”和“河流”的一些词汇。\r\n我接过他随身带来的一个本子，上面写满了一些混乱的字团，字体很幼稚，实在不像是他这个年龄的字迹，\r\n不过信纸发黄，应该是保存了很久了的老物件，看样子是他病情的症结。",
        "\r\n我询问他的名字。\r\n“阿尔……维斯”\r\n再往后我又让他讲述本子上所记录的符号。 \r\n他描述的故事很奇幻，\r\n拼凑中我听出一个关于山，河流之类的怪谈，\r\n还有一次离奇的出走经历。",
        "可惜长久的接诊经历让我不信任任何患者的叙事，\r\n那里面往往充满了痛苦的省略和混乱的人称 \r\n为了解开症结，总要引导他们说出正确的事实，\r\n就像是在一座叙事迷宫里摸索真相的出口",
        "试着在对话中插入\r\n“”（解锁人称）\r\n ……（解锁事件）\r\n ？（解锁叙事元素）\r\n还原患者的叙事\r\n 迷宫加载中……"
    };
    private int currentLineIndex = 0;

    void Start()
    {
        // 显示第一段内容
        UpdateText();
    }

    void Update()
    {
        // 检测鼠标点击或 Horizontal 键输入
        if (Input.GetMouseButtonDown(0))
        {
            ShowNextLine();
        }
    }

    void ShowNextLine()
    {
        if (currentLineIndex < storyLines.Length - 1)
        {
            currentLineIndex++;
            UpdateText();
        }
        else
        {
            Debug.Log("故事已结束！");
            // 可在这里添加其他逻辑，例如跳转场景或显示结束画面
            // 加载场景2
            LoadScene2();
        }
    }

    void UpdateText()
    {
        textDisplay.text = storyLines[currentLineIndex];
    }

    void LoadScene2()
    {
        // 使用 SceneManager.LoadScene 进行场景切换
        SceneManager.LoadScene("Scene2"); // 替换 "Scene2" 为你的实际场景名
    }
}

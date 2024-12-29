using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextPlayer5 : MonoBehaviour
{
    public TMP_Text textDisplay;        // TextMeshPro UI 对象
    public GameObject[] images;         // 用于存储图片的数组（8-14行对应的图片）
    private string[] storyLines = {
        "我思索良久，终于意识到他叙述中最大的省略。“‘山’，你能告诉我你自己的故事吗？”他看着我的眼神突然从浑浊变得清澈，然后整个人弓起身来，像是被突如其来的真相压得痛苦不堪",
        "良久他清醒过来，问我：“你是怎么发现的？”我于心不忍，但为了治疗我没有更好的方法：“你无法面对你自己，所以你从头到尾都没有讲过你自己——山的视角”",
        "他拿起阿尔维斯的笔记，开始以真正的第一人称来讲述：“阿尔维斯是我的孩子……”",
        "我二十岁就加入了军队，在军队里待了二十年。我们一家人两地分居了十年，每年寒暑假，他的母亲都会带他到山里去找我。",
        "长久的分离也许刺激了他的母亲，在第九个年头，她变得敏感多疑，半刻钟无法联系到我时就会朝我哭喊。我一开始会尽力解释，但久而久之，我也力不从心了。",
        "阿尔维斯一开始想过办法让我们和好，直到他的母亲询问他：“我和你的爸爸要分开，你是留在山里还是跟我去南方？”那之后他整日闭门不出，再也不见我们了。",
        "我听说这件事后和他的母亲大吵了一架，那晚我们吵得很凶，摔坏了很多东西。我看到阿尔维斯在门口冷冷地看着我们。",
        "那晚，阿尔维斯出逃了。我不知道他是怎么记得路的。",
        "他穿过一片军队的稻田",
        "爬过崎岖的树干",
        "来到了铁轨处等待",
        "他也许看到了火车刺眼的白灯，然后冲上了铁轨……",
        "在他死后，他的母亲开始折磨她自己。每日都在军队的稻田和铁轨处里游荡",
        "终于在某一天，她厌倦了折磨自己，于是也冲向了白灯。而我不敢死，我需要替他们记得这一切……",
        "真相是让人刺痛的。但为了治疗我们只能选择面对，因为还有未来的生活。我让他翻到日记的最后一页，并给他布置了任务：“请写作吧。写出阿尔维斯走失后的另一种结局，想象一种他在远方，离开山和河流后的人生。”他泣不成声，用力哭过后擦干眼泪，然后毫无留念地走了出去。",
        "我期待下次再见到他，或者不见到他。",
        "完"
    };
    private int currentLineIndex = 0;

    void Start()
    {
        // 确保所有图片隐藏
        HideAllImages();

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

            // 显示对应的图片
            UpdateImages();
        }
        else
        {
            Debug.Log("故事已结束！");
            QuitGame(); // 在最后一行退出游戏
        }
    }

    void UpdateText()
    {
        textDisplay.text = storyLines[currentLineIndex];
    }

    void UpdateImages()
    {
        // 确保所有图片隐藏
        HideAllImages();

        // 如果当前行在前 7 行范围内，显示第一张图片
        if (currentLineIndex >= 0 && currentLineIndex <= 6)
        {
            images[0].SetActive(true); // 假设第 0 个元素是前 7 行使用的图片
        }
        // 如果当前行在 8-14 行范围内，显示对应的图片
        else if (currentLineIndex >= 7 && currentLineIndex <= 13)
        {
            int imageIndex = currentLineIndex - 7 + 1; // 对应图片的索引（第 1 张图片对应第 8 行）
            if (imageIndex >= 1 && imageIndex < images.Length)
            {
                images[imageIndex].SetActive(true);
            }
        }
        else if (currentLineIndex >= 14)
        {
            images[0].SetActive(true); // 假设第 0 个元素是前 7 行使用的图片
        }
    }

    void HideAllImages()
    {
        // 隐藏所有图片
        foreach (GameObject img in images)
        {
            img.SetActive(false);
        }
    }

    void QuitGame()
    {
        Debug.Log("退出游戏！");
        Application.Quit(); // 退出游戏
    }
}

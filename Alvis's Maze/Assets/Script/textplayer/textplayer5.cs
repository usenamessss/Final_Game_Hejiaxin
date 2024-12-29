using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextPlayer5 : MonoBehaviour
{
    public TMP_Text textDisplay;        // TextMeshPro UI ����
    public GameObject[] images;         // ���ڴ洢ͼƬ�����飨8-14�ж�Ӧ��ͼƬ��
    private string[] storyLines = {
        "��˼�����ã�������ʶ��������������ʡ�ԡ�����ɽ�������ܸ��������Լ��Ĺ����𣿡��������ҵ�����ͻȻ�ӻ��Ǳ���峺��Ȼ�������˹������������Ǳ�ͻ������������ѹ��ʹ�಻��",
        "���������ѹ��������ң���������ô���ֵģ��������Ĳ��̣���Ϊ��������û�и��õķ����������޷�������Լ����������ͷ��β��û�н������Լ�����ɽ���ӽǡ�",
        "�����𰢶�ά˹�ıʼǣ���ʼ�������ĵ�һ�˳���������������ά˹���ҵĺ��ӡ�����",
        "�Ҷ�ʮ��ͼ����˾��ӣ��ھ�������˶�ʮ�ꡣ����һ�������ط־���ʮ�꣬ÿ�꺮��٣�����ĸ�׶��������ɽ��ȥ���ҡ�",
        "���õķ���Ҳ��̼�������ĸ�ף��ڵھŸ���ͷ����������ж��ɣ�������޷���ϵ����ʱ�ͻᳯ�ҿ޺�����һ��ʼ�ᾡ�����ͣ����ö���֮����Ҳ���������ˡ�",
        "����ά˹һ��ʼ����취�����Ǻͺã�ֱ������ĸ��ѯ���������Һ���İְ�Ҫ�ֿ�����������ɽ�ﻹ�Ǹ���ȥ�Ϸ�������֮�������ձ��Ų�������Ҳ���������ˡ�",
        "����˵����º������ĸ�״���һ�ܣ��������ǳ��ú��ף�ˤ���˺ܶණ�����ҿ�������ά˹���ſ�����ؿ������ǡ�",
        "��������ά˹�����ˡ��Ҳ�֪��������ô�ǵ�·�ġ�",
        "������һƬ���ӵĵ���",
        "������᫵�����",
        "���������촦�ȴ�",
        "��Ҳ�����˻𳵴��۵İ׵ƣ�Ȼ����������졭��",
        "������������ĸ�׿�ʼ��ĥ���Լ���ÿ�ն��ھ��ӵĵ�������촦���ε�",
        "������ĳһ�죬���������ĥ�Լ�������Ҳ�����˰׵ơ����Ҳ�����������Ҫ�����Ǽǵ���һ�С���",
        "���������˴�ʹ�ġ���Ϊ����������ֻ��ѡ����ԣ���Ϊ����δ������������������ռǵ����һҳ�����������������񣺡���д���ɡ�д������ά˹��ʧ�����һ�ֽ�֣�����һ������Զ�����뿪ɽ�ͺ�������������������������������޹���������ᣬȻ�������������˳�ȥ��",
        "���ڴ��´��ټ����������߲���������",
        "��"
    };
    private int currentLineIndex = 0;

    void Start()
    {
        // ȷ������ͼƬ����
        HideAllImages();

        // ��ʾ��һ������
        UpdateText();
    }

    void Update()
    {
        // ���������� Horizontal ������
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

            // ��ʾ��Ӧ��ͼƬ
            UpdateImages();
        }
        else
        {
            Debug.Log("�����ѽ�����");
            QuitGame(); // �����һ���˳���Ϸ
        }
    }

    void UpdateText()
    {
        textDisplay.text = storyLines[currentLineIndex];
    }

    void UpdateImages()
    {
        // ȷ������ͼƬ����
        HideAllImages();

        // �����ǰ����ǰ 7 �з�Χ�ڣ���ʾ��һ��ͼƬ
        if (currentLineIndex >= 0 && currentLineIndex <= 6)
        {
            images[0].SetActive(true); // ����� 0 ��Ԫ����ǰ 7 ��ʹ�õ�ͼƬ
        }
        // �����ǰ���� 8-14 �з�Χ�ڣ���ʾ��Ӧ��ͼƬ
        else if (currentLineIndex >= 7 && currentLineIndex <= 13)
        {
            int imageIndex = currentLineIndex - 7 + 1; // ��ӦͼƬ���������� 1 ��ͼƬ��Ӧ�� 8 �У�
            if (imageIndex >= 1 && imageIndex < images.Length)
            {
                images[imageIndex].SetActive(true);
            }
        }
        else if (currentLineIndex >= 14)
        {
            images[0].SetActive(true); // ����� 0 ��Ԫ����ǰ 7 ��ʹ�õ�ͼƬ
        }
    }

    void HideAllImages()
    {
        // ��������ͼƬ
        foreach (GameObject img in images)
        {
            img.SetActive(false);
        }
    }

    void QuitGame()
    {
        Debug.Log("�˳���Ϸ��");
        Application.Quit(); // �˳���Ϸ
    }
}

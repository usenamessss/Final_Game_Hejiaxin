using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextMazeCollision2 : MonoBehaviour
{
    // Reference to the TextMesh Pro objects
    public TextMeshPro text1;
    public TextMeshPro text2;
    public TextMeshPro text3;
    public TextMeshPro text4;

    // References to the objects in the scene (assign them in the Inspector)
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;

    // Start is called before the first frame update
    void Start()
    {
        // Initially hide all texts
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
        text4.gameObject.SetActive(false);
    }

    // Detect collision with the player and show corresponding text
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == object1)
        {
            text1.gameObject.SetActive(true);
        }
        else if (other.gameObject == object2)
        {
            text2.gameObject.SetActive(true);
        }
        else if (other.gameObject == object3)
        {
            text3.gameObject.SetActive(true);
        }
        else if (other.gameObject == object4)
        {
            text4.gameObject.SetActive(true);
            Debug.Log("切换场景！");
            Invoke("LoadScene5", 2f); // 延迟 2 秒调用 LoadScene7 方法
        }
    }
    void LoadScene5()
    {
        // 使用 SceneManager.LoadScene 进行场景切换
        SceneManager.LoadScene("Scene5");
    }
    // Optional: Hide all texts when player exits the trigger area
}
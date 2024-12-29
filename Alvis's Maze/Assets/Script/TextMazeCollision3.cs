using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextMazeCollision3 : MonoBehaviour
{
    // Reference to the TextMesh Pro objects
    public TextMeshPro text1;
    public TextMeshPro text2;
   

    // References to the objects in the scene (assign them in the Inspector)
    public GameObject object1;
    public GameObject object2;
   

    // Start is called before the first frame update
    void Start()
    {
        // Initially hide all texts
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        
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
            Debug.Log("切换场景！");
            Invoke("LoadScene6", 2f); // 延迟 2 秒调用 LoadScene7 方法
        }
        
    }
    void LoadScene6()
    {
        // 使用 SceneManager.LoadScene 进行场景切换
        SceneManager.LoadScene("Scene6");
    }
    // Optional: Hide all texts when player exits the trigger area

}
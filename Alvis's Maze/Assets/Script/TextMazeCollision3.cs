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
            Debug.Log("�л�������");
            Invoke("LoadScene6", 2f); // �ӳ� 2 ����� LoadScene7 ����
        }
        
    }
    void LoadScene6()
    {
        // ʹ�� SceneManager.LoadScene ���г����л�
        SceneManager.LoadScene("Scene6");
    }
    // Optional: Hide all texts when player exits the trigger area

}
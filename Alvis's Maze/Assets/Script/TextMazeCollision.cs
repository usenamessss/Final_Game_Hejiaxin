using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextMazeCollision : MonoBehaviour
{
    // Reference to the TextMesh Pro objects
    public TextMeshPro text1;
    public TextMeshPro text2;
    public TextMeshPro text3;

    // References to the objects in the scene (assign them in the Inspector)
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

    // Start is called before the first frame update
    void Start()
    {
        // Initially hide all texts
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
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
            Debug.Log("�л�������");
            
            Invoke("LoadScene4", 2f); // �ӳ� 2 ����� LoadScene7 ����
        }
    }
    void LoadScene4()
    {
        // ʹ�� SceneManager.LoadScene ���г����л�
        SceneManager.LoadScene("Scene4");
    }
    // Optional: Hide all texts when player exits the trigger area

}
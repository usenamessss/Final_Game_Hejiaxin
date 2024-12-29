using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal")*20, Input.GetAxis("Vertical")*20);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float SPEED = 5f;
    private Vector3 velocity = new Vector3(0, 0, 0);
    private float rotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            velocity = new Vector3(0, 0, SPEED);
            rotation = 0;
        } else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            velocity = new Vector3(0, 0, -SPEED);
            rotation = 180f;

        } else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            velocity = new Vector3(SPEED, 0, 0);
            rotation = 90f;

        } else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            velocity = new Vector3(-SPEED, 0, 0);
            rotation = 270f;

        } else
        {
            velocity = new Vector3(0, 0, 0);
        }
        transform.Translate(velocity * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.Euler(0, rotation, 0);
    }
}

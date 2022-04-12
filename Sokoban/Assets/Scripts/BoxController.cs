using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{

    LayerMask mask;
    // Start is called before the first frame update
    bool pushed;
    float playerRotationY;
    void Start()
    {
        mask = LayerMask.GetMask("Walls");
        pushed = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Push(other);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !pushed)
        {
            float actualPlayerPositionY = other.gameObject.transform.rotation.eulerAngles.y;

            if(Mathf.Abs(actualPlayerPositionY - playerRotationY) > 30) { 
                Push(other);        
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pushed = false;
        }
    }

    private void Push(Collider other)
    {
        playerRotationY = other.gameObject.transform.rotation.eulerAngles.y;
        if (playerRotationY >= 80 && playerRotationY <= 100)
        {
            RaycastHit hit;
            if (!Physics.Raycast(transform.position, new Vector3(1, 0, 0), out hit, 1f, mask))
            {
                transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                pushed = true;
            }
        }
        else if (playerRotationY >= 260 && playerRotationY <= 280)
        {
            RaycastHit hit;
            if (!Physics.Raycast(transform.position, new Vector3(-1, 0, 0), out hit, 1f, mask))
            {
                transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                pushed = true;
            }
        }
        else if (playerRotationY >= 350 && playerRotationY <= 370 || playerRotationY >= -10 && playerRotationY <= 10)
        {
            RaycastHit hit;
            if (!Physics.Raycast(transform.position, new Vector3(0, 0, 1), out hit, 1f, mask))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
                pushed = true;
            }
        }
        else if (playerRotationY >= 170 && playerRotationY <= 190)
        {
            RaycastHit hit;
            if (!Physics.Raycast(transform.position, new Vector3(0, 0, -1), out hit, 1f, mask))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
                pushed = true;
            }
        }
    }
}

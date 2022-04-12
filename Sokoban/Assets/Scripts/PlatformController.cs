using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    public bool pushed;
    
    private Color PushedColor = Color.yellow;
    private Color UnpushedColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        pushed = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MeshRenderer[] renderers = gameObject.GetComponents<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            if(pushed)
            {
                renderers[i].material.color = PushedColor;
            } else
            {
                renderers[i].material.color = UnpushedColor;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            pushed = true;
        } 
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            pushed = false;
        }
    }
}

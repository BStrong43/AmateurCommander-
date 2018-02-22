using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroTriggerScript : MonoBehaviour {

    // Use this for initialization
   
    
	void Start () {
        
	}
	
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Herder" || collision.tag == "Poacher")
        {
            GetComponentInParent<LionScript>().AggroStart();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Herder" || collision.tag == "Poacher")
        {
            GetComponentInParent<LionScript>().AggroStay(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Herder" || collision.tag == "Poacher")
        {
            GetComponentInParent<LionScript>().AggroEnd();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionScript : MonoBehaviour {

    // Use this for initialization
    SpriteRenderer sr;
    Rigidbody2D rb;
    Vector2 lastVeloc;
    Vector2 newDirec;

    bool isAggro = false;

    public float aggroSpeed;
    public float waitTime;
    float time = 0.0f;

    void Start () {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartUp()
    {
        lastVeloc = rb.velocity;
    }

    public void AggroStart()
    {
        StartUp();
        rb.velocity = Vector2.zero;
        sr.color = new Vector4(255, 0, 0, 255);
        isAggro = true;
        
    }

    public void AggroStay(GameObject target)
    {
        newDirec = target.transform.position;
        //Rotate Object
        time += Time.deltaTime;

        if(isAggro && time >= waitTime)
        {
            AggroAttack();
            time = 0.0f;
        }
    }

    public void AggroEnd()
    {
        sr.color = new Vector4(255, 255, 255, 255);
        rb.velocity = lastVeloc;
        isAggro = false;
        time = 0.0f;
    }

    void AggroAttack()
    {
        float x, y;
        x = transform.position.x - newDirec.x;
        y = transform.position.y - newDirec.y;

        Vector2 newVeloc = new Vector2(-x, -y);
        newVeloc = newVeloc.normalized;
        newVeloc *= aggroSpeed;
        rb.velocity = newVeloc;

        sr.color = new Vector4(255, 255, 255, 255);
        isAggro = false;
        time = 0.0f;
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityControl : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public bool isDragged;
	Vector2 objPos, 
			mousePos;

	public Color clicked,
				 unclicked;

	Rigidbody2D rb;
	SpriteRenderer sr;

	void Start () {
		isDragged = false;
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();

		randVeloc ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
        if (gameObject.tag != "Lion")
        {
            objPos = transform.position;
            isDragged = true;
            sr.color = clicked;
        }
	}

    private void OnMouseDrag()
    {
        if (isDragged) {
            transform.position = objPos;
        }
    }

    void OnMouseUp(){
		if (isDragged) {
			mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			float x, y;
			x = objPos.x - mousePos.x;
			y = objPos.y - mousePos.y;

			Vector2 newVelocity = new Vector2(-x,-y);
            newVelocity = newVelocity.normalized;

			newVelocity *= speed;
			rb.velocity = newVelocity;

			sr.color = unclicked;
		}
	}
	void randVeloc(){
		Vector3 pos = transform.position;
		int minX = 0, 
			maxX = 0,
			minY = 0, 
			maxY = 0;
		Vector2 newVeloc;

		if (pos.y == 0) {
			if (pos.x > 0) {
				minY = -3;
				maxY = 3;
				minX = -4;
				maxX = -4;
			}
			if (pos.x < 0) {
				minY = -3;
				maxY = 3;
				minX = 4;
				maxX = 4;
			}
		}
		if (pos.y == 3) {
			if (pos.x > 0) {
				minY = -3;
				maxY = 1;
				minX = -4;
                maxX = -4;
			}
			if (pos.x < 0) {
				minY = -3;
				maxY = 1;
				minX = 4;
				maxX = 4;
			}
		}
		if (pos.y == -3) {
			if (pos.x > 0) {
				minY = -3;
				maxY = 1;
				minX = -4;
				maxX = -4;
			}
			if (pos.x < 0) {
				minY = -3;
				maxY = 1;
				minX = 4;
				maxX = 4;
			}
		}
		newVeloc = new Vector2 (Random.Range (minX, maxX), Random.Range (minY, maxY));
		newVeloc = newVeloc.normalized;
		rb.velocity = newVeloc * speed;
	
	}

    private void OnTriggerEnter2D(Collider2D col){
		if (col.tag != "Destroyer") {
			if (col.tag != gameObject.tag && gameObject.tag != "Lion") {
				GameObject.Find ("Spawner").GetComponent<SpawnerScript> ().somebodyDied ();
			}
		}
    }
}

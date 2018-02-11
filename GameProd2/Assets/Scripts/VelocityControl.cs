using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityControl : MonoBehaviour {

	// Use this for initialization
	public float speed;
	bool isDragged;
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
		objPos = transform.position;
		isDragged = true;
		sr.color = clicked;

	}

	void OnMouseUp(){
		if (isDragged) {
			mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Debug.Log (objPos);
			Debug.Log (mousePos);

			float x, y;
			x = objPos.x - mousePos.x;
			y = objPos.y - mousePos.y;

			Vector2 newVelocity = new Vector2(-x,-y);
			newVelocity = newVelocity.normalized;
			Debug.Log (newVelocity);

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

		if (pos.x == 0) {
			if (pos.y > 0) {
				minX = -3;
				maxX = 3;
				minY = -3;
				maxY = -3;
				Debug.Log ("North Spawn");
			}

			if (pos.y < 0) {
				minX = -3;
				maxX = 3;
				minY = 3;
				maxY = 3;
				Debug.Log ("South Spawn");
			}
		} else if (pos.y == 0) {
			if (pos.x > 0) {
				minY = -3;
				maxY = 3;
				minX = -3;
				maxX = -3;
				Debug.Log ("West Spawn");
			}
			if (pos.x < 0) {
				minY = -3;
				maxY = 3;
				minX = 3;
				maxX = 3;
				Debug.Log ("East Spawn");
			}
		}

		newVeloc = new Vector2 (Random.Range (minX, maxX), Random.Range (minY, maxY));
		newVeloc = newVeloc.normalized;
		rb.velocity = newVeloc * speed;
	}
}

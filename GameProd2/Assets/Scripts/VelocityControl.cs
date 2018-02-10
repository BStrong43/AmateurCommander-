using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityControl : MonoBehaviour {

	// Use this for initialization
	public float speed;
	bool isDragged;
	Rigidbody2D rb;
	Vector2 objPos, 
			mousePos;

	void Start () {
		isDragged = false;
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		objPos = transform.position;
		isDragged = true;
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
		}
	}
}

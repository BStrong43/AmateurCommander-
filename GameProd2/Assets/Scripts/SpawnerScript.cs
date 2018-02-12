using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpawnerScript : MonoBehaviour {

    public int lives;
    public float waitTime;
    float timer = 0.0f;

	public GameObject obj1,
                      obj2,
                      obj3,
                      obj4;

	Vector3 eastSpawn,
            westSpawn, 
            northSpawn,
            southSpawn;

	void Start () {
		eastSpawn = new Vector3 (9, 0);
		westSpawn = new Vector3 (-9, 0);
		northSpawn = new Vector3 (0, 6);
		southSpawn = new Vector3 (0, -6);

		spawnUnit ();
        lives *= 2;
	}

	void Update () {
        timer += Time.deltaTime;
		if (Input.GetKeyDown (KeyCode.Space)) {
			spawnUnit ();
		}

        if (lives <= 0)
        {
            youLose();
        }

        if (timer >= waitTime)
        {
            spawnUnit();
            timer = 0.0f;
            if (waitTime >= 1.5f)
            {
                waitTime -= 0.3f;
            }
            Debug.Log("Wait Time = " + waitTime);
        }
	}

	void spawnUnit(){
		Vector3 spawnPos = randPos ();
		GameObject obj = randUnit ();
		GameObject.Instantiate (obj, spawnPos, Quaternion.identity);
	}

	GameObject randUnit(){
		int choice = Random.Range (1, 5);
        GameObject obj = obj1;

		switch (choice) {
		case 1:
			obj = obj1;
			break;
		case 2:
			obj = obj2;
			break;
		case 3:
			obj = obj3;
			break;
		case 4:
			obj = obj4;
			break;

		}
		return obj;
	}

	Vector3 randPos(){
		int choice = Random.Range (1, 5);

		Vector3 spawnPos = new Vector3();

		switch (choice) {
		case 1:
			spawnPos = eastSpawn;
			break;
		case 2:
			spawnPos = westSpawn;
			break;
		case 3:
			spawnPos = northSpawn;
			break;
		case 4:
			spawnPos = southSpawn;
			break;
		}
		return spawnPos;
	}

    void youLose()
    {
        SceneManager.LoadScene("LoseScreen", LoadSceneMode.Single);
    }

    public void somebodyDied()
    {
        lives--;
        Debug.Log("Somebody Died | " + lives / 2 + " remaining");
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpawnerScript : MonoBehaviour {

    public int lives;
    public float waitTime;
	public float waitTime2;
    public float waitTimeDecrease;
	public float waitTimeDecrease2;
    float timer1 = 0.0f;
	float timer2 = 0.0f;

    public bool willSpawn;

    public GameObject herder,
                      lion,
                      poacher;

    public Transform[] positions;


	void Start () {
        lives *= 2;
	}

	void Update () {
        
		if (Input.GetKeyDown (KeyCode.Space)) {
			spawnUnit ();
		}

        if (lives <= 0){
            youLose();
        }
        if (willSpawn)
        {
            runTimer();
        }
	}

	void runTimer(){
		timer1 += Time.deltaTime;

		if (timer1 >= waitTime){
			spawnUnit();
			timer1 = 0.0f;
			if (waitTime >= 1.5f)
			{
				waitTime -= waitTimeDecrease;
			}
		}

		timer2 += Time.deltaTime;

		if (timer2 >= waitTime2){
			spawnUnit();
			timer2 = 0.0f;
			if (waitTime2 >= 1.5f)
			{
				waitTime2 -= waitTimeDecrease2;
			}
		}

	}

	void spawnUnit(){
		Transform spawnPos = randPos ();
		GameObject obj = randUnit ();
		GameObject.Instantiate (obj, spawnPos.transform.position, spawnPos.transform.rotation);

    }

	GameObject randUnit(){
		int choice = Random.Range (1, 5);
        GameObject obj = herder;

		switch (choice) {
		case 1:
			obj = herder;
			break;
		case 2:
			obj = lion;
			break;
		case 3:
			obj = poacher;
			break;
		}
		return obj;
	}

	Transform randPos(){
		int choice = Random.Range (1, positions.Length);
        return positions[choice];
	}

    void youLose(){
        SceneManager.LoadScene("LoseScreen", LoadSceneMode.Single);
    }

    public void somebodyDied(){
        lives--;
        Debug.Log("Somebody Died | " + lives / 2 + " remaining");
    }
}
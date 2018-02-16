using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpawnerScript : MonoBehaviour {

    public int lives;
    public float waitTime;
    public float waitTimeDecrease;
    float timer = 0.0f;

    public GameObject herder,
                      lion,
                      poacher;

    public Transform[] positions;


	void Start () {
		spawnUnit ();
        lives *= 2;
	}

	void Update () {
        timer += Time.deltaTime;
		if (Input.GetKeyDown (KeyCode.Space)) {
			spawnUnit ();
		}

        if (lives <= 0){
            youLose();
        }

        if (timer >= waitTime){
            spawnUnit();
            timer = 0.0f;
            if (waitTime >= 1.5f)
            {
                waitTime -= waitTimeDecrease;
            }
            Debug.Log("Wait Time = " + waitTime);
        }
	}

	void spawnUnit(){
		Transform spawnPos = randPos ();
		GameObject obj = randUnit ();
		GameObject.Instantiate (obj, spawnPos.transform.position, spawnPos.transform.rotation);

        Transform spawnPos2 = randPos();
        GameObject obj2 = randUnit();

        while(spawnPos2 == spawnPos)
        {
            spawnPos2 = randPos();
        }
        while (obj2 == obj)
        {
            obj = randUnit();
        }

        GameObject.Instantiate(obj2, spawnPos.transform.position, spawnPos.transform.rotation);

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
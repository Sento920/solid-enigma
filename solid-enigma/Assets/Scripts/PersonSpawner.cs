using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner : MonoBehaviour {

	[SerializeField] private Transform[] spawnPositions;
	[SerializeField] private GameObject person;

	// Use this for initialization
	void Awake () {
        reshuffle(spawnPositions);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnPerson(int x) {
       // int index = Random.Range(0, spawnPositions.Length);
        for (int i = 0; i < x; i++) {
            Instantiate(person, spawnPositions[i].position, Quaternion.identity);
        }
	}

    public int GetSize()
    {
        return spawnPositions.Length;
    }

    void reshuffle(Transform[] spawnPositions)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < spawnPositions.Length; t++)
        {
            Transform tmp = spawnPositions[t];
            int r = Random.Range(t, spawnPositions.Length);
            spawnPositions[t] = spawnPositions[r];
            spawnPositions[r] = tmp;
        }
    }


}

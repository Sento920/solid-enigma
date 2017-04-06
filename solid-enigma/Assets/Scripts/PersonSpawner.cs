using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner : MonoBehaviour {

	[SerializeField] private Transform[] spawnPositions;
	[SerializeField] private GameObject person;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnPerson () {
		int index = Random.Range (0, spawnPositions.Length);

		Instantiate (person, spawnPositions[index].position, Quaternion.identity);
	}
}

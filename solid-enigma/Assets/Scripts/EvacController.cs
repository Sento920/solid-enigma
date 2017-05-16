using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvacController : MonoBehaviour
{

    [SerializeField]
    private RoundController rc;
    [SerializeField]
    private GameObject[] evacSlots;
    int numPeople = 0;
    [SerializeField]
    private Collider trigger;
    private Rigidbody rb;
    private List<GameObject> passengers;
	[SerializeField]
	private GameObject platform;

    // Use this for initialization
    void Start()
    {
        rc = GameObject.FindObjectOfType<RoundController>();
		passengers = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            PlayerController p = other.GetComponent<PlayerController>();
            while (p.GetNumPassengers() > 0)
            {
                GameObject person = p.RemovePerson();
                if (person)
                {
                    Debug.Log("Person evacuated!");
                    person.transform.SetParent(this.transform);
					Vector2 pos = Random.insideUnitCircle * 2.0f;
					person.transform.position = platform.transform.position + new Vector3 (pos.x, 0.5f, pos.y);
					passengers.Add (person);
                    numPeople++;
                    p.AddMoney(5);
                    rc.AddPoint();
                }
                else
                {
                    Debug.Log("NULL RETURNED");
                }
            }
        }
    }

    void OnBecameInvisible()
    {
        //Debug.Log("NOT VISIBLE Dumb Dumb");
        //destroy players on evac pad
		int numPeoples = passengers.Count;

        //for(int i = 0; i < numPeoples; i++)
        //{
        //Debug.Log("i: " + i + " Person Val: " + passengers[i].transform.position);
        //GameObject p = passengers [i];
        //passengers.RemoveAt (i);
        //Destroy(p);
        //numPeople--;
        //  }
        clearPeople();
    }

    private void clearPeople()
    {
        for(int i = 0; i < passengers.Count; i++)
        {
            GameObject p = passengers[i];
            if (p)
            {
                Debug.Log("cleared person");
                Destroy(p);
                passengers.RemoveAt(i);
            }
        }
    }
}



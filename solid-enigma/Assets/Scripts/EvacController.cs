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

    // Use this for initialization
    void Start()
    {
        rc = GameObject.FindObjectOfType<RoundController>();
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
                    person.transform.position = evacSlots[numPeople].transform.position;
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

    void OnBecameVisible()
    {
        Debug.Log("Im visible");
        rb.isKinematic = false;
        trigger.enabled = true;
    }

    void OnBecameInvisible()
    {
        Debug.Log("NOT VISIBLE");
        //destroy players on evac pad
        PlayerController p = GetComponent<PlayerController>();
        while (p.GetNumPassengers() > 0)
        {
            if (p)
            {
                Debug.Log("NOT VISIBLE");
                Destroy(p);
            }
            rb.isKinematic = true;
            trigger.enabled = false;
        }
    }
}



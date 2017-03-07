using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    
    public float maxSpeed = 10;
    public float accel = 150;
    public float drag = 10;
    private Rigidbody rb;
    private Vector3 heading;
	public Text fuelUI;

    public Text moneyUI;
    
	[SerializeField]
    private float fuelUsage = 1.0f;
    [SerializeField]
    private float fuel = 100.0f;
    [SerializeField]
    public float fuelCapacity = 100.0f;

    [SerializeField]
    public int money = 50;

	[SerializeField]
	private int numPeople;
	[SerializeField]
	private int peopleCapacity;
	private List<GameObject> passengers;

    [SerializeField]
    private int numRings;
    [SerializeField]
    private int ringCapacity;
    public GameObject Ring;
    [SerializeField]
    private List<GameObject> slots;


    // Use this for initialization
    void Start () {
		passengers = new List<GameObject> ();
        this.rb = GetComponent<Rigidbody>();
		fuelUI.text = "fuel: " + fuel;
        moneyUI.text = "money: " + money;
	}

    // Update is called once per frame
    void Update() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        heading = new Vector3(x, 0.0f, z);
        if (heading.magnitude > 1.0f)
            heading.Normalize();

		if(heading != Vector3.zero)
        	transform.LookAt(this.transform.position + heading);
		fuelUI.text = "fuel: " + fuel;
         moneyUI.text = "money: " + money;
        moneyUI.text = "money: " + money;
        //LifeRings
        if (numRings > 0 && Input.GetKeyDown("space")) {
            //Create a new ring
            GameObject temp = Instantiate<GameObject>(Ring,this.GetBow(),transform.rotation);
            temp.GetComponent<Rigidbody>().AddForce(Vector3.forward * accel);
            numRings--;
        }

    }

    void FixedUpdate() {
        rb.AddForce(-(rb.velocity * drag));

        if (fuel > 0.0f) {
            rb.AddForce(heading * accel);

            //check for max speeds X.
            if (rb.velocity.x > maxSpeed) {
                rb.velocity = new Vector3(maxSpeed, rb.velocity.y, rb.velocity.z);
            } else if (rb.velocity.x < -maxSpeed) {
                rb.velocity = new Vector3(-maxSpeed, rb.velocity.y, rb.velocity.z);
            }

            //check for max speeds Z.
            if (rb.velocity.z > maxSpeed) {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxSpeed);
            } else if (rb.velocity.z < -maxSpeed) {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -maxSpeed);
            }

            fuel -= (heading).magnitude * fuelUsage;
        }
    }

    public void AddFuel(float fuel) {
        this.fuel += fuel;
        if (this.fuel > fuelCapacity)
        {
            SetFuel(fuelCapacity);
        }
    }

    public float GetFuel()
    {
        return fuel;
    }
    public void SetFuel(float fuel)
    {
        this.fuel = fuel;
    }

    public float GetFuelCapacity()
    {
        return fuelCapacity;
    }

    public void AddMoney(int money)
    {
        this.money += money;
    }
    

	public void AddPerson(GameObject person){
		if (numPeople < peopleCapacity) {
			Debug.Log ("Passengers: " + passengers.Count + " Slots: " + slots.Count);
			person.transform.SetParent (this.transform);
			int loc = passengers.Count;
			numPeople++;
			passengers.Add (person);
			person.transform.position = slots [loc].transform.position;
		} else {
			//life ring capacity

		}
	}

	public void RemovePerson(){
        if (numPeople > 0) {
            numPeople--;
            Destroy(passengers[numPeople]);
            passengers.Remove(passengers[numPeople]);
        }
	}

	public bool HasCapacity(){
		return (peopleCapacity - numPeople) > 0;
	}

    public int GetNumPassengers() {
        return (numPeople);
    }

  public Vector3 GetBow() {
        return new Vector3(transform.localPosition.x, 0f, transform.localPosition.z + 1.5f);
    }

}

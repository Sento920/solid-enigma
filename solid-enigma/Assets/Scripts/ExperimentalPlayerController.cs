using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperimentalPlayerController : MonoBehaviour {
    
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
        transform.LookAt(this.transform.position + heading);
		fuelUI.text = "fuel: " + fuel;
         moneyUI.text = "money: " + money;
        moneyUI.text = "money: " + money;
        //LifeRings
        if (numRings > 0 && Input.GetKeyDown("space")) {
            //Create a new ring
            GameObject temp = Instantiate<GameObject>(Ring, this.transform);
            temp.transform.position = new Vector3(transform.position.x,transform.position.y+1, transform.position.z+3);
            //Set ring's rotation to what we are facing.
            temp.transform.LookAt(temp.transform.position + heading);
            //Add our velocity, plus the acceleration constant. This should feel explosive and need tweeking.
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
    }

    public void AddMoney(int money)
    {
        this.money += money;
    }
    

	public void AddPerson(GameObject person){
		numPeople++;
		passengers.Add (person);
        
        person.transform.SetParent (this.transform);
        //Set the Slot's position
        int loc = 0;
        //Go through the list of Slots backward, Setting position as we go.
        for(int i = slots.Count-1; i <= 0; i--) {
            Debug.Log("HI");
            if(passengers[loc] == null) {
                Debug.Log("Position found: " + i);
                loc = i;
                Debug.Log("FUCK");
            }
            Debug.Log("BYE");
        }
        person.transform.position = slots[loc].transform.position;
	}

	public void RemovePerson(){
		numPeople--;
	}

	public bool HasCapacity(){
		return (peopleCapacity - numPeople) > 0;
	}

  

}

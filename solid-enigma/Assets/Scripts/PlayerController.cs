using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 10;
    public float accel = 150;
    public float paddleAccel = 10;
    public float drag = 10;
    public float turnSpeed = 1.0f;

    private Rigidbody rb;

    private Vector3 desiredHeading;
    [SerializeField] private Vector3 heading;

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
	private bool activeTime;


    // Use this for initialization
    void Start () {
		passengers = new List<GameObject> ();
        this.rb = GetComponent<Rigidbody>();
		fuelUI.text = "fuel: " + fuel;
        moneyUI.text = "money: " + money;

        heading = Vector3.forward;
	}

    // Update is called once per frame
    void Update() {
		if (activeTime) {
            // get desired movement vector
            float x = Input.GetAxis ("Horizontal");
			float z = Input.GetAxis ("Vertical");

            desiredHeading = new Vector3(x, 0.0f, z);

            if (desiredHeading.magnitude > 1.0f)
                desiredHeading.Normalize();

            //LifeRings
            if (numRings > 0 && Input.GetKeyDown ("space")) {
				//Create a new ring
				GameObject temp = Instantiate<GameObject> (Ring, this.GetBow (), transform.rotation);
				temp.GetComponent<Rigidbody> ().AddForce (Vector3.forward * accel);
				numRings--;
			}
		}

		fuelUI.text = "fuel: " + fuel;
		moneyUI.text = "money: " + money;
    }

    private float getAngle(Vector3 vec) {
        float negative = 1.0f;

        if (vec.x < 0.0f)
            negative *= -1.0f;

        return Vector3.Angle(Vector3.forward, vec.normalized) * negative;
    }

    void FixedUpdate() {
        rb.AddForce(-(rb.velocity * drag));

        if (activeTime) {
            // normalize vector, compare angle between current and desired headings
            if (desiredHeading != Vector3.zero) {
                float deltangle = getAngle(desiredHeading) - getAngle(heading); // deltangle is the change in angle on this update

                // if deltangle is greater than 180 degrees, turn the other way, dingus
                if (deltangle >= 180.0f)
                    deltangle -= 360.0f;
                if (deltangle < -180.0f)
                    deltangle += 360.0f;

                deltangle = Mathf.Clamp(deltangle / turnSpeed, -1.0f, 1.0f) * turnSpeed;

                float curAngle = getAngle(heading);   // not to be confused with wwe superstar kurt angle

                heading = new Vector3(Mathf.Sin(Mathf.Deg2Rad * (curAngle + deltangle)), 0.0f, Mathf.Cos(Mathf.Deg2Rad * (curAngle + deltangle)));

                transform.LookAt(this.transform.position + heading);
            }

            Vector3 movement = heading * desiredHeading.magnitude;

            if (fuel > 0)
                rb.AddForce(movement * accel);
            else
                rb.AddForce(movement * paddleAccel);

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
				
			fuel = Mathf.Max(fuel - ((movement).magnitude * fuelUsage), 0.0f);
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
    
	public bool getActiveTime(){
		return activeTime;
	}

	public void setActiveTime(bool active){
		activeTime = active;
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

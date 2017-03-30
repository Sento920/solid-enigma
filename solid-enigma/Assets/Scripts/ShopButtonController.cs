using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonController : MonoBehaviour {
    [SerializeField]
    private GameObject PlayerBoat;
    [SerializeField]
    private Button FuelButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BuyFuel()
    {
        if (PlayerBoat.GetComponent<PlayerController>().money > 0){
            PlayerBoat.GetComponent<PlayerController>().AddFuel(100);
            PlayerBoat.GetComponent<PlayerController>().AddMoney(-5);

            if(PlayerBoat.GetComponent<PlayerController>().GetFuel() >= PlayerBoat.GetComponent<PlayerController>().GetFuelCapacity())
            {
                PlayerBoat.GetComponent<PlayerController>().SetFuel(PlayerBoat.GetComponent<PlayerController>().fuelCapacity);
                FuelButton.GetComponent<Button>().enabled = false;
            }
        }else {
            FuelButton.GetComponent<Button>().enabled = false;
        }
        //GameObject.Find("Fuel Button").GetComponent<Button>().enabled = false;
    }


    public void BuyFuelCapacityUpgrade()
    {
        PlayerBoat.GetComponent<PlayerController>().fuelCapacity += 100;
        PlayerBoat.GetComponent<PlayerController>().AddFuel(100);
        //FuelButton.enabled = true;
    }

    public void enableShopButtons()
    {
        FuelButton.enabled = true;
    }

    public void BuySpeedUpgrade()
    {
        PlayerBoat.GetComponent<PlayerController>().maxSpeed += 10;
        PlayerBoat.GetComponent<PlayerController>().accel += 50;
        PlayerBoat.GetComponent<PlayerController>().AddMoney(-5);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonController : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerBoat;
    [SerializeField]
    private Button FuelButton;
    [SerializeField]
    private Button SpeedButton;
    [SerializeField]
    private Button CapacityButton;

    private int SpeedCount;
    private int CapacityCount;

    // Use this for initialization
    void Start()
    {
        SpeedCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerBoat.GetComponent<PlayerController>().GetFuel() >= PlayerBoat.GetComponent<PlayerController>().GetFuelCapacity())
        {
            FuelButton.GetComponentInChildren<Text>().text = "Buy Fuel: FULL";
        }else
            FuelButton.GetComponentInChildren<Text>().text = "Buy Fuel: $" + 20;

        if (SpeedCount < 5)
        {
            SpeedButton.GetComponentInChildren<Text>().text = "Speed Capacity: $" + 50 * (SpeedCount + 1);
        }
        else
            SpeedButton.GetComponentInChildren<Text>().text = "Speed Capacity: MAX";

        if (CapacityCount < 5)
        {
            CapacityButton.GetComponentInChildren<Text>().text = "Fuel Capacity: $" + 50 * (CapacityCount + 1);
        }
        else
            CapacityButton.GetComponentInChildren<Text>().text = "Fuel Capacity: MAX";



    }

    public void BuyFuel()
    {
        if (PlayerBoat.GetComponent<PlayerController>().money > 20)
        {
            PlayerBoat.GetComponent<PlayerController>().AddFuel(100);
            PlayerBoat.GetComponent<PlayerController>().AddMoney(-20);

            if (PlayerBoat.GetComponent<PlayerController>().GetFuel() >= PlayerBoat.GetComponent<PlayerController>().GetFuelCapacity())
            {
                PlayerBoat.GetComponent<PlayerController>().SetFuel(PlayerBoat.GetComponent<PlayerController>().fuelCapacity);
                FuelButton.GetComponentInChildren<Text>().text = "Buy Fuel: FULL";
                FuelButton.GetComponent<Button>().enabled = false;
            }
        }
        else
        {
            FuelButton.GetComponentInChildren<Text>().text = "Buy Fuel: FULL";
            FuelButton.GetComponent<Button>().enabled = false;
        }
        //GameObject.Find("Fuel Button").GetComponent<Button>().enabled = false;
    }


    public void BuyFuelCapacityUpgrade()
    {
		if (PlayerBoat.GetComponent<PlayerController>().money > 50 * (CapacityCount+1))
        {
            PlayerBoat.GetComponent<PlayerController>().fuelCapacity += 100;
            PlayerBoat.GetComponent<PlayerController>().AddFuel(100);
			PlayerBoat.GetComponent<PlayerController>().AddMoney(-50 * (CapacityCount+1));
            CapacityCount++;
            if (CapacityCount >= 5)
            {
                CapacityButton.GetComponentInChildren<Text>().text = "Fuel Capacity: MAX";
                CapacityButton.enabled = false;
            }
        }
        //FuelButton.enabled = true;
    }

    public void enableShopButtons()
    {
        FuelButton.enabled = true;
        CapacityButton.enabled = true;
        SpeedButton.enabled = true;
    }

    public void BuySpeedUpgrade()
    {
		if (PlayerBoat.GetComponent<PlayerController>().money > 50 *  (SpeedCount+1))
        {
            PlayerBoat.GetComponent<PlayerController>().maxSpeed += .5f;
            PlayerBoat.GetComponent<PlayerController>().accel += 50;
			PlayerBoat.GetComponent<PlayerController>().AddMoney(-50 * (SpeedCount+1));
            SpeedCount++;
            if (SpeedCount >= 5)
            {
                SpeedButton.GetComponentInChildren<Text>().text = "Speed Capacity: MAX";
                SpeedButton.enabled = false;
            }
        }
    }
}

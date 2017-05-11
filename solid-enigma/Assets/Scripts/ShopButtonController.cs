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
                FuelButton.GetComponent<Button>().enabled = false;
            }
        }
        else
        {
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
                SpeedButton.enabled = false;
            }
        }
    }
}

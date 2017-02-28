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
        }else {
            FuelButton.GetComponent<Button>().enabled = false;
        }
        //GameObject.Find("Fuel Button").GetComponent<Button>().enabled = false;
    }
}

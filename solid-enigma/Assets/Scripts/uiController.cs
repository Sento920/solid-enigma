using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiController : MonoBehaviour {

    private GameObject camPrefab;
    [SerializeField]
    private GameObject uiCam;
    [SerializeField]
    private List<GameObject> uiObjects;
    private Camera camRef;
    [SerializeField]
    private Transform camLoc;

    // Use this for initialization
    void Start () {
        uiCam = Instantiate<GameObject>(camPrefab, camLoc);
        camRef = uiCam.GetComponent<Camera>();
        //Culling mask for Unity's UI Defaults to 5.
        camRef.cullingMask = 5;
        camRef.orthographic = true;
        camRef.clearFlags = CameraClearFlags.Depth;
        camRef.depth = 5;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

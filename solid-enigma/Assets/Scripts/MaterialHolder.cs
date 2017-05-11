using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialHolder : MonoBehaviour {

    public Material[] BodyColors;
    public Material[] HeadColors;

    public Material[] getA1() {
        return BodyColors;
    }

    public Material[] getA2(){
        return HeadColors;
    }
}

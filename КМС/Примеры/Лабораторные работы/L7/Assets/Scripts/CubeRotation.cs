using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour {


	void Update () {
        transform.Rotate(new Vector3(0,90,0), 90*Time.deltaTime);
    }
}

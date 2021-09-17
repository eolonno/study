using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Сube3Roration : MonoBehaviour {

    public int speedY = 90;
    public int speedZ = 90;
	void Update () {
        transform.Rotate(new Vector3(0, 90, 0), speedY * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, 90), speedZ * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringObs : MonoBehaviour {

    Rigidbody ringPy;

    [SerializeField]
    private float obsSpeed;

	void Start () {
        ringPy = GetComponent<Rigidbody>();
        ringPy.AddForce(Vector3.back * obsSpeed);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

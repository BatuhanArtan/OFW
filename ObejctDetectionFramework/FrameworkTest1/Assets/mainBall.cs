using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainBall : MonoBehaviour {

    public GameObject getRedBallTransform;
    Vector3 redFirstPos, redLastPos;
    public bool isGameOver;

	void Start () {
        redFirstPos = getRedBallTransform.transform.position - transform.position;
	}
	
	void FixedUpdate () {
        redBallPosControl();
	}

    void redBallPosControl()
    {
        
        /* if ((redLastPos - redFirstPos).magnitude <=  10f )
        {
            redLastPos = redFirstPos + transform.position;
            getRedBallTransform.transform.position = Vector3.Lerp(getRedBallTransform.transform.position, redLastPos, 0.5f);
        }*/
        
        if(isGameOver == false)
        {
            redLastPos = redFirstPos + transform.position;
            getRedBallTransform.transform.position = Vector3.Lerp(getRedBallTransform.transform.position, redLastPos, 0.1f);
        }
    }
}
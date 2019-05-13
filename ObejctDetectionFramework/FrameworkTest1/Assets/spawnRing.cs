using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRing : MonoBehaviour {

    [SerializeField]
    private GameObject ringPrefab;
    private GameObject ring;
    private float myTime;

    public bool isGameOver;

    Vector3 spawnPos;
    
	void Start () {
        spawnPos.z = transform.position.z;
	}
	
	void Update () {
        myTime += Time.deltaTime;
        createRing();
	}

    void createRing()
    {
        if (myTime > 4f)
        {
            myTime = 0;
            spawnPos.y = Random.Range(1f, 8f);
            spawnPos.x = Random.Range(-7f, 7f);
            ring =  Instantiate(ringPrefab, spawnPos, transform.rotation);
            ring.SetActive(true);
        }  
    }
}

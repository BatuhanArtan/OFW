using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class gameControl : MonoBehaviour {

    public bool isGameOver;
    public Button restartButton;  
    [SerializeField]
    private float cubeSize;
    [SerializeField]
    private float cubesInRow;
    [SerializeField]
    private float explosionForce;
    [SerializeField]
    private float explosionRadius;
    [SerializeField]
    private float explosionUpward;

    [SerializeField]
    private TextMeshProUGUI getReadyText;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI gameOverText;
    [SerializeField]
    private mainBall mainBallScript;


    private int score = 0;
    private float cubePivotDistance;
    private Vector3 cubesPivot;  

    void Start () {

      
        cubePivotDistance = cubeSize * cubesInRow / 2;
        cubesPivot = new Vector3(cubePivotDistance, cubePivotDistance, cubePivotDistance);

        Invoke("textEnableControl", 3f);
    }

    void textEnableControl()
    {
        getReadyText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "ring")
        {
            score += 1;
            scoreText.text = "SCORE: " + score.ToString(); 
            Destroy(other.gameObject, 2f);
        }

        if(other.gameObject.tag == "ringGameOver")
        {
            restartButton.gameObject.SetActive(true);
            mainBallScript.isGameOver = true;
            gameOverText.gameObject.SetActive(true);
            explode();
        }
    }

    void explode()
    {
        gameObject.SetActive(false);

        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    creatPiece(x, y, z);
                }
            }
        }

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, explosionPos, explosionRadius, explosionUpward);
            }
        }
        Destroy(gameObject, 6f);
    }

    void creatPiece(int x, int y, int z)
    {
        GameObject piece = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        piece.GetComponent<Renderer>().material.color = Color.red;

        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
   
    }
}
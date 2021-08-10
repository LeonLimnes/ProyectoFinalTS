using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GummyBears : MonoBehaviour
{
    Text gummybearsCount;
    int gummyBears = 0;
    int gummyBearsMax;
    // Start is called before the first frame update
    void Start()
    {
        gummyBearsMax = GameObject.FindGameObjectsWithTag("Gummy Bear").Length;
        gummybearsCount = transform.GetComponent<Text>();
    }

        // Update is called once per frame
    void Update()
    {
        gummybearsCount.text = "GUMMY BEARS: " + gummyBears + "/" + gummyBearsMax;
        if(gummyBears == gummyBearsMax)
        {
            GameFinished();
        }
    }

    public void IncrementCount()
    {
        gummyBears += 1;
    }

    void GameFinished()
    {
        EndGame gameEnd = GameObject.Find("Canvas").GetComponent<EndGame>();
        gameEnd.GameFinished();
        Destroy(gameObject);
    }
}

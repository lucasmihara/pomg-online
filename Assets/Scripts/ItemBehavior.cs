using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public GameObject mainBall;

    public GameObject tempBallPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.name == mainBall.name)
        {
            // Check for item type and perform its action
            spawnTempBalls(1);
            Destroy(this.gameObject);
        }
    }

    private void spawnTempBalls(int quantity)
    {
        for(int i=0; i < quantity; i++)
        {
            Instantiate(tempBallPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}

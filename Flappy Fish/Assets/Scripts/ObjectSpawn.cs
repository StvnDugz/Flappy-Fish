using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    private float timer = 0;        
    public float maxTime = 1;
    public GameObject item;     // the game object to spawn
    public float distance;      // the distance between objects

    void Start()
    {
        // spawn the object
        GameObject newItem = Instantiate(item);
        newItem.transform.position = transform.position + new Vector3(Random.Range(-distance, distance), 0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            GameObject newItem = Instantiate(item);
            newItem.transform.position = transform.position + new Vector3(Random.Range(-distance, distance), 0,0);
            Destroy(newItem, 20);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}

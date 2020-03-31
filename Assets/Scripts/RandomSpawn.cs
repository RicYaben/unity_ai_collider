using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
	public GameObject ground;
    public int max_range = 4;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = getSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getSpawn()
    {
    	var x = Random.Range(- max_range,  max_range);
    	var z = Random.Range(- max_range , max_range);

    	var randomSpawn = ground.transform.position + new Vector3(x, .2f, z);

    	return randomSpawn;
    }
}

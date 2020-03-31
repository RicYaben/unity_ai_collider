using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using MLAgents.Sensors;

public class Player : Agent
{

	public float moveSpeed = 4f;

	Rigidbody rBody;
	private Renderer rend;

    public GameObject Ground;
    public Transform Goal;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localPosition = getSpawn();
    	rBody = GetComponent<Rigidbody>();
    	rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update(){}   

    //change the color of the ball when it collides with the goal
    void OnCollisionEnter(Collision col)
    {
        this.rBody.velocity = Vector3.zero;
    	if(col.collider.name == "Goal")
    	{
    		this.rend.material.color = Color.green;
    	}
    }

    //function to get a random spawn
    public Vector3 getSpawn()
    {
        //coordinate x and z
        var x = Random.Range(- 4,  4);
        var z = Random.Range(- 4 , 4);

        // position relative to the ground it is on
        var randomSpawn = Ground.transform.localPosition + new Vector3(x, .2f, z);

        return randomSpawn;
    }

    public override void OnEpisodeBegin()
    {
        //restarts the position of the goal and the agent and change the color
        //to yellow
        this.transform.localPosition = getSpawn();
        this.rend.material.color = Color.blue;
        Goal.localPosition = getSpawn();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        //observe the position of the goal and itself
        sensor.AddObservation(Goal.localPosition);
        sensor.AddObservation(this.transform.localPosition);

        //observe the velocity at which the agent was
        sensor.AddObservation(rBody.velocity.x);
        sensor.AddObservation(rBody.velocity.z);
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        // Actions, size = 2
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = vectorAction[0];
        controlSignal.z = vectorAction[1];
        rBody.AddForce(controlSignal * moveSpeed);

        // calculate the distance to the goal
        float distanceToTarget = Vector3.Distance(this.transform.localPosition,
            Goal.localPosition);

        // reward the agent if it is close to the goal, and end the episode if it touches the ball
        if (this.rend.material.color == Color.green)
        {
            SetReward(2.0f);
            EndEpisode();
        }else if(distanceToTarget < 1.0f)
        {
            SetReward(1.0f);
        }
    }

    // add a control mode
    public override float[] Heuristic()
    {
        var action = new float[2];
        action[0] = Input.GetAxis("Horizontal");
        action[1] = Input.GetAxis("Vertical");
        return action;
    }
}

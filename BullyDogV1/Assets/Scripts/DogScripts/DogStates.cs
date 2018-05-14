using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum State {
	Idle, 
	Move, 
	Turn,
	Cowering,
	Bullied
}

public class DogStates : MonoBehaviour {
	
	public State currentState;

	private float stateChangeTimer = 3f;

	private bool checkIdle = true;
	private bool checkBackToIdle = true;
	private float checkMoveOrTurn;

	void Start () {
		currentState = State.Idle;
	}


	void Update () {
		CheckState();
	}


	void CheckState()
	{
		switch (currentState)
		{
		case State.Idle:
			if (checkIdle) {
				checkIdle = false;
				Invoke ("MoveOrTurn", stateChangeTimer + Random.Range (-.5f, .5f));
			}
			break;
		
		case State.Move:
			if (checkBackToIdle) {
				checkBackToIdle = false;
				Invoke ("BackToIdle", stateChangeTimer + Random.Range (-.5f, .5f));
			}
			break;
		
		case State.Turn:
			if (checkBackToIdle) {
				checkBackToIdle = false;
				Invoke ("BackToIdle", stateChangeTimer + Random.Range (-.5f, .5f));
			}			
			break;
		
		case State.Cowering:

			break;
		
		case State.Bullied:
			break;
		}
	}


	void MoveOrTurn(){
		checkMoveOrTurn = Random.Range (0f, 2f);

		if ((currentState != State.Cowering) || (currentState != State.Bullied)) {
			if (checkMoveOrTurn <= 1) {
				currentState = State.Turn;

			} else {
				currentState = State.Move;
			}
		}
		checkIdle = true;
	}

	void BackToIdle (){
		if ((currentState != State.Cowering) || (currentState != State.Bullied)) {
			currentState = State.Idle;
		}

		checkBackToIdle = true;
	}
}

/*{
	public GameObject prefab;

	// Instantiate the prefab somewhere between -10.0 and 10.0 on the x-z plane
	void Start()
	{
		Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
		Instantiate(prefab, position, Quaternion.identity);
	}
}
*/






	/* Handy for the Bully perhaps.

		//Sensing
		if (target == null)
		{
			distanceToTarget = float.MaxValue;
			Collider[] cols = Physics.OverlapSphere(transform.position, senseRange);
			foreach (Collider c in cols)
			{
				if (c.gameObject == gameObject) { continue; }
				Health hp = c.gameObject.GetComponent<Health>();
				if (hp != null)
				{
					Debug.Log("Health found!");
					float distToHealthScript = Vector3.Distance(transform.position, hp.transform.position);
					if (distToHealthScript < distanceToTarget)
					{
						target = hp;
						distanceToTarget = distToHealthScript;
					}
				}
			}
			if(target == null)
			{
				currentState = State.Idle;
			}

		}else{
			distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
			if(distanceToTarget > senseRange)
			{
				target = null;
			}
		}

		//States
		switch (currentState)
		{
		case State.Attack:
			//Action
			if (coolDown > 0)
			{
				coolDown -= Time.deltaTime;
			}

			//Do Damage
			if(distanceToTarget < attackRange && coolDown <= 0)
			{
				Debug.Log("Do attack!");
				target.DoDamage(gameObject, damage);
				coolDown = maxCooldown;
			}

			//Transition
			if(distanceToTarget > 2* attackRange)
			{
				currentState = State.Move;
			}

			break;
		case State.Idle:

			//if we are close pick a new position to walk to
			if(agent.remainingDistance > agent.stoppingDistance)
			{
				break;
			}
			else
			{
				agent.SetDestination(transform.position + new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)));
			}
			if(distanceToTarget < senseRange)
			{
				currentState = State.Move;
			}


			break;
		case State.Move:
			//Move to the target
			if(target != null)
			{
				agent.SetDestination(target.transform.position);
			}


			if(distanceToTarget < attackRange)
			{
				currentState = State.Attack;
			}

			break;

		}
		*/

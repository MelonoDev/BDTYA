using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum State {
	StopTime,
	Idle, 
	Move, 
	Turn,
	Cowering,
	Bullied,
	Peeing,
	Smug
}

public class DogStates : MonoBehaviour {
	
	public State currentState;
	public bool TheBullyDog = false;
	public AudioSource DogWhine;
	public AudioSource DogPeeSound;

	public WrongDogPicked wrongDogPicked; //Script for showing Crosses in UI
	public RightDogPicked rightDogPicked; //Script for winning
	public PeeLevel peeLevel;

	//material to change to according to State
	public Texture IdleDogMat;
	public Texture PeeingMat;
	public Texture SmugMat;
	public Texture BulliedMat;

	private bool checkIdle = true;
	private bool checkBackToIdle = true;
	private bool checkBullied = true;
	private float checkMoveOrTurn;

	//Timer numbers for standard actions
	private float timerAmount = 3f;
	private float timerPeeAmount = 4.632f;
	private float timerPeeBackToIdle; //action is peeing
	private float timerIdle; //idling
	private float timerBackToIdle; //actions like moving and turning

	//PseudoRandomise Peeing
	private int peeCounter = 0;

	//Timer winning
	private float timerWinAmount = 2.5f;
	private float timerWin;

	//Animator
	public Animator ThisAnimator;

	void Awake () {
		currentState = State.Idle;
		timerIdle = timerAmount + Random.Range(-.5f, .5f);
		timerBackToIdle = timerAmount + Random.Range(-.5f, .5f);
		timerPeeBackToIdle = timerPeeAmount;
		timerWin = timerWinAmount;

		ThisAnimator = gameObject.GetComponent<Animator> ();
	}

	void Start(){
		wrongDogPicked = GameObject.Find("WrongParent").GetComponent<WrongDogPicked>();
		rightDogPicked = GameObject.Find("WinParent").GetComponent<RightDogPicked>();
		peeLevel = GameObject.Find("PeeLevelParent").GetComponent<PeeLevel>();

	}


	void Update () {
		CheckState();
		if (currentState == State.Move) {
			ThisAnimator.SetBool ("MovingBool", true);
		} else {
			ThisAnimator.SetBool ("MovingBool", false);
		}
	}


	void CheckState()
	{


		switch (currentState)
		{
		case State.StopTime:
			//Gets refered to in other scripts



			break;		
		
		case State.Idle:
			if (checkIdle) {
				checkIdle = false;

			}
            
			timerIdle -= Time.deltaTime;
			if (timerIdle < 0) {
				MoveOrTurn ();
				timerIdle = timerAmount + Random.Range (-.5f, .5f);
			}

			GetComponent<Renderer> ().material.mainTexture = IdleDogMat;
        
			break;
		
		case State.Move:
			if (checkBackToIdle) {
				checkBackToIdle = false;
			}

			timerBackToIdle -= Time.deltaTime;
			if (timerBackToIdle < 0) {
				BackToIdle ();
				timerBackToIdle = timerAmount + Random.Range(-.5f, .5f);
			}
			
			break;
		
		case State.Turn:
			if (checkBackToIdle) {
				checkBackToIdle = false;

			}
			timerBackToIdle -= Time.deltaTime;
			if (timerBackToIdle < 0) {
				BackToIdle ();
				timerBackToIdle = timerAmount + Random.Range(-.5f, .5f);
			}
						
			break;
		
		case State.Cowering:

			break;
		
		case State.Bullied:
			if (checkBullied) {
				checkBullied = false;
				DogWhine.Play ();
				wrongDogPicked.ChosenWrong ();
			}

			GetComponent<Renderer> ().material.mainTexture = BulliedMat;

			break;

		case State.Peeing:

			if (checkBackToIdle) {
				checkBackToIdle = false;
				DogPeeSound.Play ();
				peeLevel.GainPee ();
			}
			timerPeeBackToIdle -= Time.deltaTime;
			if (timerPeeBackToIdle < 0) {
				BackToIdle ();
				timerPeeBackToIdle = timerPeeAmount;
			}

			peeCounter = 0;


			GetComponent<Renderer> ().material.mainTexture = PeeingMat;


			break;

		case State.Smug:
			timerWin -= Time.deltaTime;

			if (timerWin < 0) {
				rightDogPicked.DisplayWinMessage ();
				timerWin = timerWinAmount;
			}

			GetComponent<Renderer> ().material.mainTexture = SmugMat;


			break;

		}
	}



	void MoveOrTurn(){
		checkMoveOrTurn = Random.Range (0f, 2f);

		if ((currentState != State.Cowering) && (currentState != State.Bullied) && (currentState != State.StopTime)) {

			if (peeCounter < 3) {
				if (checkMoveOrTurn <= 1) {
					currentState = State.Turn;

				} else {
					if (!TheBullyDog) {
						currentState = State.Move;
					} else {
						if (checkMoveOrTurn > 1.4) {
							currentState = State.Move; 
						} else {
							currentState = State.Peeing;
						}
					}

				}
			} else {
				currentState = State.Peeing;
			}
			if (this.TheBullyDog) {
				peeCounter += 1;
			}
				
		}
		checkIdle = true;
	}

	void BackToIdle (){
		if ((currentState != State.Cowering) && (currentState != State.Bullied) && (currentState != State.StopTime)) {
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

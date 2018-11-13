using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatMovement : MonoBehaviour
{

	// this is for variables
	[Header("Variables")]
	[Space]

	// for movement
	[SerializeField] float moveSpeed;
	[SerializeField] float maxSpeed;
	[SerializeField] float maxReverseSpeed;
	[SerializeField] float deccelerationSpeed;
	[SerializeField] float currentSteerSpeed;
	[SerializeField] float rotationSpeed;
	[SerializeField] bool isInput;

	// this is for boost
	[SerializeField] float boost;
	[SerializeField] float boostUsageRate; // this is the rate of decrease of boost
	[SerializeField] bool isBoosting;

	// float on water
	public float heightAboveWater;

	//this is used so that the boat only moves when the player is at the steering wheel 
	public bool controllingBoat;
	Vector3 moveMentOutput;

	// This is for getting components
	[Header("Components")]
	[Space]
	[SerializeField] CharacterController chController;
	[SerializeField] BoatMovement theBoat;

	[Header("UI")]
	[Space]
	public Slider boostSlider;

	[Header("GameObjects")]
	[Space]
	public GameObject theWater;

	// Use this for initialization
	void Start()
	{

		// variables
		maxSpeed = 8f;
		moveSpeed = 0f;
		maxReverseSpeed = -5f;
		deccelerationSpeed = 2f;
		currentSteerSpeed = 0f;
		rotationSpeed = 180f;
		isInput = false;
		controllingBoat = false;
		boost = 100f;
		boostUsageRate = 20f;
		isBoosting = false;

		// components
		chController = GetComponent<CharacterController>();
		theBoat = FindObjectOfType<BoatMovement>();

		// For ui
		boostSlider.maxValue = boost;

	}

	// Update is called once per frame
	void Update()
	{

		if (controllingBoat) Movement();
		if (!isInput) StopBoat();

		Boost();

		BoostSlider();

		FloatOnWater();

	}


	// This part is for movement only
	void Boost()
	{
		if (boost < 0) boost = Mathf.CeilToInt(boost);

		isBoosting = (boost > 0f && Input.GetKey(KeyCode.Space) && theBoat.controllingBoat) ? isBoosting = true : isBoosting = false;
		maxSpeed = (isBoosting) ? 15f : 8f;
		moveSpeed = (isBoosting) ? maxSpeed : moveSpeed;
		if (!isBoosting && moveSpeed > maxSpeed) moveSpeed = 8f;

		boost = isBoosting ? boost -= boostUsageRate * Time.deltaTime : boost;

		if (boost > 100f) boost = 100f; 
	}

	void StopBoat()
	{
		moveMentOutput = transform.TransformDirection(Vector3.down * moveSpeed);
		if (moveSpeed >= 0) moveSpeed -= deccelerationSpeed * Time.deltaTime;
		if (moveSpeed <= 0) moveSpeed += deccelerationSpeed * Time.deltaTime;
	}

	// method that handles the boat movement
	void Movement()
	{

		if (moveSpeed > maxSpeed) moveSpeed = (Mathf.FloorToInt(moveSpeed));

		//Local Variables 

		float steerRate = 6f; // this is for the steering later


		float accelRate = 1.5f;

		if (Input.GetKey(KeyCode.W))
		{
			if (moveSpeed < maxSpeed) moveSpeed += accelRate * Time.deltaTime;
			isInput = true;
		}

		if (Input.GetKeyUp(KeyCode.W)) isInput = false;


		if (Input.GetKey(KeyCode.S))
		{
			if (moveSpeed > maxReverseSpeed) moveSpeed -= accelRate * Time.deltaTime;
			isInput = true;
		}

		else if (Input.GetKeyUp(KeyCode.S)) isInput = false;

		//for decceleration 
		if (!isInput)
		{
			if (moveSpeed >= 0) moveSpeed -= deccelerationSpeed * Time.deltaTime;
			if (moveSpeed <= 0) moveSpeed += deccelerationSpeed * Time.deltaTime;
		}

		// Handle the boat rotation.

		if (Input.GetKey(KeyCode.D))
		{

			if (moveSpeed > .5f || moveSpeed < -0.5) currentSteerSpeed += steerRate * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.A))
		{

			if (moveSpeed > .5f || moveSpeed < -0.5) currentSteerSpeed -= steerRate * Time.deltaTime;
		}

		if (moveSpeed < 0.1 && moveSpeed > -0.1f && !isInput) moveSpeed = 0f;

		//to move the character
		moveMentOutput = transform.TransformDirection(Vector3.down * moveSpeed);

		chController.Move(moveMentOutput * Time.deltaTime);

		// to rotate the boat
		transform.rotation = Quaternion.Euler(-90, currentSteerSpeed, 0);
	}

	void FloatOnWater()
	{
		transform.position = new Vector3(transform.position.x, theWater.transform.position.y + heightAboveWater, transform.position.z);
	}

	// this next part is for UI
	void BoostSlider()
	{
		if (controllingBoat)
		{
			boostSlider.gameObject.SetActive(true);
		}

		else
		{
			boostSlider.gameObject.SetActive(false);
		}

		boostSlider.value = boost;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boost")
		{
			boost += 100;
			Destroy(other.gameObject);

		}
	}

}

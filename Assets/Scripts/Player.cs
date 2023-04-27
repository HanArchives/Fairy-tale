using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{

	public float movementSpeed = 4f;
	public float boostSpeed;
	public float regularMovementSpeed;
	public float jumpingPower = 600f;
	public bool enableDoubleJump;

	public bool isSpeedBoosting;

	private Rigidbody2D rb;

	public float horizontalInput;
	public float verticalInput;
	private bool isGrounded;
	private bool doJump;
	private bool canDoubleJump;

	public Transform top_left;
	public Transform bottom_right;
	public LayerMask ground_layers;

	public float speedBoostTimer;
	public float speedBoostTime;

	public Animator anim;

	public Sprite[] bodySprites;
	public SpriteRenderer bodyRenderer;

	public SpriteRenderer glassesRenderer;
	public SpriteRenderer hairRenderer;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		regularMovementSpeed = movementSpeed;

		anim = GetComponent<Animator>();
	}

	void Update()
	{
		horizontalInput = Input.GetAxisRaw("Horizontal");       //Get player input for moving left or right [-1 (left), 0 (idle) or 1 (right)]
		verticalInput = Input.GetAxisRaw("Vertical");

		if (Input.GetButtonDown("Jump"))
		{   //If jump button is pressed,

			isSpeedBoosting = true;

			/*
			if (isGrounded)
			{               // and player is on ground
				doJump = true;              // player will jump (in FixedUpdate),
				canDoubleJump = true;       // and player can double jump.
			}
			else if (enableDoubleJump)
			{   //If jump button is pressed, player is not on ground, but double jump is enabled in inspector,
				if (canDoubleJump)
				{       // and player has not used double jump yet,
					doJump = true;          // player will jump again (in FixedUpdate),
					canDoubleJump = false;  // and cannot jump again until he touches ground.
				}
			} */
		}

		if(isSpeedBoosting == true)
        {
			speedBoostTimer += Time.deltaTime;
			movementSpeed = boostSpeed;

			if (speedBoostTimer >= speedBoostTime)
			{
				movementSpeed = regularMovementSpeed;
				speedBoostTimer = 0;
				isSpeedBoosting = false;
			}
		}

		if (horizontalInput >= 1 || horizontalInput >= -1 || verticalInput >= 1 || verticalInput >= -1)
        {
			GameManager.instance.isWalking = true;
		}
		if(horizontalInput == 0 && verticalInput == 0)
        {
			GameManager.instance.isWalking = false;
        }
	}

	void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapArea(top_left.position, bottom_right.position, ground_layers);

		//Variable speed
		if(horizontalInput == Input.GetAxisRaw("Horizontal") || verticalInput == Input.GetAxisRaw("Vertical"))
        {
			if (Mathf.Abs(rb.velocity.x) >= movementSpeed || (rb.velocity.y) >= movementSpeed)
			{                               //If sideways velocity is higher than or equal to set movement speed,
				rb.velocity = new Vector3(horizontalInput * movementSpeed, verticalInput * movementSpeed);  // set sideways velocity to movement speed.
			}
			else
			{
				rb.AddForce(new Vector3(horizontalInput * (movementSpeed * 10f), verticalInput * (movementSpeed * 10f), 1f));       //Else add sideways force to player
			}
		}

		//Fixed speed
		//rb.velocity = new Vector2 (horizontalInput * movementSpeed, rb.velocity.y);


		if (horizontalInput > 0)    //If player is moving towards right but is facing left,
		{       // or if player is moving towards left but is facing right,
			transform.localRotation = Quaternion.Euler(0, 0, 0); // Resets sprite direction
			anim.SetBool("IsRunning", true);

			bodyRenderer.sprite = bodySprites[2];
			bodyRenderer.size = new Vector2(2f, 2f);

			glassesRenderer.size = new Vector2(0.75f, 0.75f);
			hairRenderer.size = new Vector2(0.75f, 0.75f);
		}
		if (horizontalInput < 0)
		{
			transform.localRotation = Quaternion.Euler(0, 180, 0); // Swaps sprite direction
			anim.SetBool("IsRunning", true);
			bodyRenderer.sprite = bodySprites[2];
			bodyRenderer.size = new Vector2(2f, 2f);

			glassesRenderer.size = new Vector2(0.75f, 0.75f);
			hairRenderer.size = new Vector2(0.75f, 0.75f);
		}

		if (verticalInput > 0)
        {
			anim.SetBool("IsRunning", true);
			bodyRenderer.sprite = bodySprites[3];
			bodyRenderer.size = new Vector2(2.25f, 2.25f);

			glassesRenderer.size = new Vector2(0f, 0f);
			hairRenderer.size = new Vector2(0f, 0f);
		}

		if (verticalInput < 0)
        {
			anim.SetBool("IsRunning", true);
			bodyRenderer.sprite = bodySprites[0];
			bodyRenderer.size = new Vector2(2f, 2f);

			glassesRenderer.size = new Vector2(0.75f, 0.75f);
			hairRenderer.size = new Vector2(0.75f, 0.75f);
		}

		if (horizontalInput == 0 && verticalInput == 0)
        {
			anim.SetBool("IsRunning", false);
			bodyRenderer.sprite = bodySprites[0];
			bodyRenderer.size = new Vector2(2f, 2f);

			glassesRenderer.size = new Vector2(0.75f, 0.75f);
			hairRenderer.size = new Vector2(0.75f, 0.75f);
		}

		if (doJump)
		{
			rb.velocity = new Vector2(rb.velocity.x, 0);    //Set upwards velocity to 0 to prevent double jump from jumping very high
			rb.AddForce(new Vector2(0, jumpingPower));  //Apply upwards force to player (jump)
			doJump = false;
			isGrounded = false;
		}
	}

	void OnDrawGizmosSelected()
	{
		// Draw a semitransparent red cube at the transforms position
		Gizmos.color = new Color(1, 0, 0, 0.5f);
		//Vector3 gizmoPosition = new Vector3(bottom_right.position.x + top_left.position.x, top_left.position.y, top_left.position.z);
		Vector3 gizmoPosition = (bottom_right.position + top_left.position) / 2;
		Gizmos.DrawCube(gizmoPosition, new Vector3(Mathf.Abs(bottom_right.position.x - top_left.position.x), Mathf.Abs(top_left.position.y - bottom_right.position.y), 1));
	}



}

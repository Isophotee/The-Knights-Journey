using UnityEngine;

public class PlayerMovement: MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;
	public float crouchSpeed = 20f;

	float horizontalMove = 0f;
	float previousHorizontalMove = 0f; 
	bool jump = false;
	bool crouch = false;
	bool isTurningAround = false; //to detect turning around

	void Update () {
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		// Detect turning around
		if (Mathf.Sign(horizontalMove) != Mathf.Sign(previousHorizontalMove) && horizontalMove != 0)
		{
			isTurningAround = true;
		}
		else
		{
			isTurningAround = false;
		}

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		animator.SetBool("IsTurningAround", isTurningAround); // Set animator parameter

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
		previousHorizontalMove = horizontalMove;
	}

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
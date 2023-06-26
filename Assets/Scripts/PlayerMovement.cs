using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	PlayerHealth playerHealth;

	public CharacterController characterControler;
	public Transform playerBody;


	public float playerMovementSpeed = 9.0f;

	public float playerJumpHeight = 7.0f;

	public float playerCurrentJumpHeight = 0f;

	public float playerSprintSpeed = 7.0f;


	public float mouseVelocity = 3.0f;
	public float mouseUpDown = 0.0f;

	public float mouseUpDownScope = 90.0f;

	public float vaultHeight = 4.0f;


	public float fallHeight = 0f;

	public bool blockMovement = false;

	void Start()
	{
		characterControler = GetComponent<CharacterController>();
		playerHealth = GetComponent<PlayerHealth>();
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update()
	{
		Keyboard();
		Mouse();
		Fall();
	}


	private void Keyboard()
	{
		if(!blockMovement){
			float moveForwardBackward = Input.GetAxis("Vertical") * playerMovementSpeed;

			float moveLeftRight = Input.GetAxis("Horizontal") * playerMovementSpeed;

			if (characterControler.isGrounded && Input.GetButton("Jump"))
			{
				playerCurrentJumpHeight = playerJumpHeight;
				fallHeight -= 14;
			}
			else if (!characterControler.isGrounded)
			{
				playerCurrentJumpHeight += Physics.gravity.y * Time.deltaTime;
			}



			if (Input.GetKeyDown("left shift"))
			{
				playerMovementSpeed += playerSprintSpeed;
			}
			else if (Input.GetKeyUp("left shift"))
			{
				playerMovementSpeed -= playerSprintSpeed;
			}


			Vector3 move = new Vector3(moveLeftRight, playerCurrentJumpHeight, moveForwardBackward);

			move = transform.rotation * move;

			characterControler.Move(move * Time.deltaTime);
		}
	}


	private void Mouse()
	{
		if(!blockMovement){
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			float mouseLeftRight = Input.GetAxis("Mouse X") * mouseVelocity;
		
			transform.Rotate(0, mouseLeftRight, 0);

			mouseUpDown -= Input.GetAxis("Mouse Y") * mouseVelocity ;

			mouseUpDown = Mathf.Clamp(mouseUpDown, -mouseUpDownScope, mouseUpDownScope);
			
			Camera.main.transform.localRotation = Quaternion.Euler(mouseUpDown, 0, 0);
		}
		else{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		
		
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Vault")
		{
			playerCurrentJumpHeight = vaultHeight;
		}
	}
	private void Fall()
    {
		if (!characterControler.isGrounded)
		{
			fallHeight -= Physics.gravity.y * Time.deltaTime;
		}
		else if (characterControler.isGrounded && fallHeight >= 5)
		{
            if (fallHeight < 10)
            {
				playerHealth.TakeDamage((int)((fallHeight * fallHeight / Mathf.Sqrt(fallHeight) + fallHeight)/2) - 5);
			}
			else
            {
				playerHealth.TakeDamage((int)(fallHeight * fallHeight / Mathf.Sqrt(fallHeight) + 2 * fallHeight));
			}
				
			fallHeight = 0;
		}
		else
			fallHeight = 0;


    }
}

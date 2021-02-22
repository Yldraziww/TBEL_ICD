using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Player : MonoBehaviour
{

	public CharacterController characterController;
	public float speed = 6;

	void Update()
	{
		Move();
	}

	private void Move()
	{
		float horizontalMove = Input.GetAxis("Horizontal");
		float verticalMove = Input.GetAxis("Vertical");

		Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
		characterController.Move(speed * Time.deltaTime * move);
	}
}
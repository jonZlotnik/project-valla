using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valla : Human {

	private float lastHorizontalAxisValue = 0f;
	public bool canControl = true;

	// Use this for initialization
	protected new void Start () {
		base.Start();

	}

	// Update is called once per frame
	protected new void Update () {
		base.Update();
		checkControl();
		if(canControl)
		{
			userControlHorizontal();
			userControlVertical();
		}
		lastHorizontalAxisValue = Input.GetAxis("Horizontal");
	}
	protected new void FixedUpdate() {
		base.FixedUpdate();
	}

	private void userControlHorizontal()
	{
		//Move Left
		if(Input.GetAxis("Horizontal") < 0){
			if(this.getDirection() > 0){this.flip();}
			this.moveForward(5f);
		}
		//Move Right
		else if(Input.GetAxis("Horizontal") > 0){
			if(this.getDirection() < 0){this.flip();}
			this.moveForward(5f);
		}
		//Cut Movement
		else if(Input.GetAxis("Horizontal") == 0/* && lastHorizontalAxisValue != 0*/){
			this.moveForward(0f);
		}
	}

	bool canDoubleJump = false;
	private void userControlVertical()
	{
		if(Input.GetKeyDown(KeyCode.Space)){
			if(this.isGrounded())
			{
				this.jump(5f);
				canDoubleJump = true;
			}
			else if(canDoubleJump)
			{
				this.jump(5f);
				canDoubleJump = false;
			}
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			this.cancelJump();
		}
	}

	private void checkControl()
	{
		if(this.isKnockbacking)
		{
			this.canControl = false;
		}
		else 
		{ 
			this.canControl = true;
		}
	}
}

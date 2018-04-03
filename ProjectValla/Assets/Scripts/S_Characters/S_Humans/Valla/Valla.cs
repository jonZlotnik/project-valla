using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valla : Human {


 //----------------------------------------------------------------
//  Main Valla Loop
	private float lastHorizontalAxisValue = 0f;
	public bool canControl = true;

	protected new void Start () {
		base.Start();

	}
	protected new void Update () {
		base.Update();
		checkControl();
		if(canControl)
		{
			userControlHorizontal();
			userControlVertical();
			userMobilityAbilities ();
		}
		lastHorizontalAxisValue = Input.GetAxis("Horizontal");
	}
	protected new void FixedUpdate() {
		base.FixedUpdate();
	}



 //----------------------------------------------------------------
//  General User Control

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
		if(Input.GetAxis("Jump") > 0 && lastJumpAxisValue == 0)
		{
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
		if(Input.GetAxis("Jump") == 0)
		{
			this.cancelJump();
		}
		lastJumpAxisValue = Input.GetAxis ("Jump");
	}

	private void checkControl()
	{
		if(isKnockbacking || isAirdashing)
		{
			this.canControl = false;
		}
		else 
		{ 
			this.canControl = true;
		}
	}

	private float lastJumpAxisValue = 0;



 //----------------------------------------------------------------
//  Mobility Abilities

	private void userMobilityAbilities ()
	{
		if (Input.GetAxis ("AirDash") > 0 && this.isAirdashing == false)
		{
			this.airDash ();

		}
		if (Input.GetAxis ("Glide") > 0 && this.isGliding == false)
		{
			this.glide ();

		}
		if (Input.GetAxis ("Launch") > 0 && this.isLaunching == false)
		{
			this.launch ();

		}
	}

	
}

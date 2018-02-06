using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valla : Human {

	// Use this for initialization
	protected new void Start () {
		base.Start();

	}

	// Update is called once per frame
	protected new void Update () {
		base.Update();
		userControlHorizontal();
		userControlVertical();
	}

	private void userControlHorizontal()
	{
		if(Input.GetKey(KeyCode.A)){
			if(this.getDirection() > 0){this.flip();}
			this.moveForward(5f);
		}else if(Input.GetKey(KeyCode.D)){
			if(this.getDirection() < 0){this.flip();}
			this.moveForward(5f);
		}else{
			this.moveForward(0f);
		}
	}

	private void userControlVertical()
	{
		if(Input.GetKeyDown(KeyCode.Space)){
			if(this.isGrounded())
			{
				this.jump(5f);
			}
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			this.cancelJump();
		}
	}
}

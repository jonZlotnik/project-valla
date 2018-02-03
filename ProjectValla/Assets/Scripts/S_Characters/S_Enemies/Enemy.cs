using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

	//ProtoEnemy Properties
	private bool keepMoving;
	private RaycastHit2D atLedge;
	private RaycastHit2D atWall;

	// Use this for initialization
	protected void Start () {
		base.Start();
		this.keepMoving = true;
	}
	
	// Update is called once per frame
	protected void Update () {
		base.Update();
		if(this.keepMoving == true){
			movementAI();
		}
	}


	//ProtoEnemy Movement AI
	public void stopMoving()
	{
		this.keepMoving = false;
	}
	private void movementAI()
	{
		Vector2 wallPoint = new Vector2(
			this.getPosition().x+this.getDirection()*this.getSize().x,
			this.getPosition().y
		);
		this.atWall = Physics2D.Linecast(this.getPosition(), wallPoint);
		if (this.atWall.transform.gameObject.tag.Equals("Platform"))
		{
			this.flip();
		}else{
			this.moveForward(2f);
		}
	}
}

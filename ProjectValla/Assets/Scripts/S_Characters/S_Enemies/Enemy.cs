﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

	//ProtoEnemy Properties
	private bool keepMoving;
	private RaycastHit2D atLedge;
	private RaycastHit2D atWall;

	// Use this for initialization
	protected new void Start () {
		base.Start();
		this.keepMoving = true;
	}
	
	// Update is called once per frame
	protected new void Update () {
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
	public void resumeMoving()
	{
		this.keepMoving = true;
	}
	private void movementAI()
	{
		Vector2 facePoint = new Vector2(
			this.getPosition().x + this.getDirection()*(this.getSize().x),
			this.getPosition().y
		);
		Vector2 wallPoint = new Vector2(
			this.getPosition().x + this.getDirection()*(this.getSize().x+1f),
			this.getPosition().y
		);
		Vector2 floorPoint = new Vector2(
			this.getPosition().x + this.getDirection()*(this.getSize().x),
			this.getPosition().y - 0.33f
		);
		this.atWall = Physics2D.Linecast(facePoint, wallPoint, LayerMask.GetMask("Platforms"));
		this.atLedge = Physics2D.Linecast(facePoint, floorPoint, LayerMask.GetMask("Platforms"));

		//Debug.Log(this.getPosition().x+"  |  "+facePoint.x+"  |  "+wallPoint.x);

		if(this.atLedge.transform != null)
		{
			Debug.Log(facePoint.y +"  |  "+ floorPoint.y);
		}

		if (this.atWall.collider != null && this.atWall.collider.tag.Equals("Platform") ||
			this.atLedge.collider == null)
		{
			Debug.Log("Should flip");
			this.flip();
			this.moveForward(3f);
		}else{
			this.moveForward(3f);
		}
	}
}

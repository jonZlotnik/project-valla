using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	private int hp;
	private Rigidbody2D rb2d;

	//Position Getter
	public Vector2 getPosition(){
		return new Vector2(
			this.transform.position.x,
			this.transform.position.y
		);
	}
	//Direction Getter
	public int getDirection(){
		return (int)Mathf.Sign(this.transform.localScale.x);
	}
	//Size Getter
	public Vector2 getSize(){
		return new Vector2 (
			Mathf.Abs(this.transform.localScale.x),
			Mathf.Abs(this.transform.localScale.y)
		);
	}


	//Health Functions
	public void initHP(int hp)
	{
		this.hp = hp;
	}

	public void takeDamage(int damage)
	{
		this.hp -= damage;
	}
	public void takeDamage(int damage, Character attacker)
	{
		this.hp -= damage;
		Vector2 knockBack = attacker.getPosition() - this.getPosition();
		knockBack.Normalize();
		knockBack *= damage;
	}

	private void checkHealth()
	{
		if(this.hp <= 0)
		{
			this.die();
		}
	}

	private void die()
	{
		Destroy(this.gameObject);
	}


	//Horizotical Movement Functions
	public void moveForward(float speed)
	{
		this.rb2d.velocity = new Vector2(Mathf.Abs(speed)*this.getDirection(), this.rb2d.velocity.y);
	}
	public void flip()
	{
		this.transform.localScale = new Vector3(
			-(this.transform.localScale.x),
			this.transform.localScale.y,
			this.transform.localScale.z
		);
	}

	//Vertical Movement Properties
	private Vector2 groundCheckR;
	private Vector2 groundCheckL;
	private RaycastHit2D groundCastR;
	private RaycastHit2D groundCastL;
	//Vertical Movement Functions
	public bool isGrounded()
	{
		groundCheckR = new Vector2(
			this.getPosition().x+this.getSize().x/2,
			this.getPosition().y-this.getSize().y/2-0.01f
		);
		groundCheckL = new Vector2(
			this.getPosition().x-this.getSize().x/2,
			this.getPosition().y-this.getSize().y/2-0.01f
		);
		groundCastR = Physics2D.Linecast(this.getPosition(), groundCheckR, LayerMask.GetMask("Platforms"));
		groundCastL = Physics2D.Linecast(this.getPosition(), groundCheckL, LayerMask.GetMask("Platforms"));
		if(groundCastR.collider != null || groundCastL.collider != null)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	protected void jump(float jumpHeight)
	{
		Vector2 jumpVelocity = new Vector2(this.rb2d.velocity.x, Mathf.Sqrt(-2f* Physics2D.gravity.y*jumpHeight));
		this.rb2d.velocity = jumpVelocity;
	}
	protected void cancelJump()
	{
		this.rb2d.velocity = new Vector2(this.rb2d.velocity.x, 0f);
	}



	// Use this for initialization
	protected void Start () {
		//Initialize Components
		this.rb2d = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	protected void Update () {
		checkHealth();
	}
}

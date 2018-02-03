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


	//Movement Functions
	public void moveForward(float speed)
	{
		this.rb2d.velocity = new Vector2(Mathf.Abs(speed)*this.getDirection(), this.rb2d.velocity.y);
	}
	public void flip()
	{
		this.transform.localScale.Set(
			-(this.transform.localScale.x),
			this.transform.localScale.y,
			this.transform.localScale.z
		);
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

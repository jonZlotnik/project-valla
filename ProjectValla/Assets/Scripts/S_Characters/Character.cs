using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	private int hp;


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













	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		checkHealth();
		//this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(50,50));
	}
}

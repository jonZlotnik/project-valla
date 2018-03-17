using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {


	//General State Properties
	protected bool isIdle = false;
	protected bool isRunning = false;
	protected bool isDashing =false;
	protected bool isKnockbacking = false;
	protected bool isOnWall = false;
	protected bool isGliding = false;
	protected bool isFalling = false;
	protected bool isAttackStance = false;
	protected bool isHealthStance = false;
	protected bool isEnergyStance = false;
	protected bool isSpeedStance = false;

	//MonoBehaviour Properties
	private Rigidbody2D rb2d;
	protected Collider2D col2d;

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

	//General Movement Properties
	//General Movement Functions

	//Horizontical Movement Properties
	//Horizontical Movement Functions
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

	//Health/Combat Properties
	public int maxHealth;
	public int hp;

	//Health/Combat Functions
	public void initHP(int hp)
	{
		this.maxHealth = hp;
		this.hp = maxHealth;
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

	private void takeDamage(int damage)
	{
		this.hp -= damage;
	}
	public void receiveAttack(Attack attack)
	{
		this.takeDamage(attack.getDamageValue());

		Direction knockBackDir;
		knockBackDir = (attack.getAttackerTransform().position.x - this.getPosition().x) > 0 ? Direction.RIGHT : Direction.LEFT ;

		Vector2 knockBack = new Vector2(5f,5f)*attack.getKnockBackMultiplier();
		this.rb2d.velocity = knockBack;
		this.isKnockbacking = true;
	}

	//protected void attack(Attack attack, )





	// Use this for initialization
	protected void Start () {
		//Initialize Components
		this.rb2d = this.gameObject.GetComponent<Rigidbody2D>();
		this.col2d = this.gameObject.GetComponent<Collider2D>(); 
	}
	
	// Update is called once per frame
	protected void Update () {
		checkHealth();
	}


	//Timers
	private float knockBackTimer = 0f;
	private float KNOCKBACK_DURATION = 1.0f;

	// FixedUpdate is called every fixed framerate frame
	protected void FixedUpdate() {

		//KnockBack Timekeeping
		if(this.isKnockbacking && knockBackTimer < KNOCKBACK_DURATION)
		{
			this.knockBackTimer += Time.deltaTime;
		}
		else
		{
			this.knockBackTimer = 0;
			this.isKnockbacking = false;
		}
	}
}

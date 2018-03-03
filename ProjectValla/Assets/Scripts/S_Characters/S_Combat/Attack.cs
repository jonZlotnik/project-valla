using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack {

	private int damageValue;
	private float knockBackMultiplier;
	private float attackRepeatDelay;
	protected Transform attackerTransform;

	public Attack(){
		this.damageValue = 1;
		this.knockBackMultiplier = 1f;
		this.attackRepeatDelay = 0f;
	}

	public int getDamageValue()
	{
		return damageValue;
	}
	public float getKnockBackMultiplier()
	{
		return knockBackMultiplier;
	}
	public float getAttackRepeatDelay()
	{
		return attackRepeatDelay;
	}
	public Transform getAttackerTransform()
	{
		return this.attackerTransform;
	}

	protected void setDamageValue(int damageValue)
	{
		this.damageValue = damageValue;
	}
	protected void setKnockBackMultiplier(float knockBackMultiplier)
	{
		this.knockBackMultiplier = knockBackMultiplier;
	}
	protected void setAttackRepeatDelay(float attackRepeatDelay)
	{
		this.attackRepeatDelay = attackRepeatDelay;
	}
}

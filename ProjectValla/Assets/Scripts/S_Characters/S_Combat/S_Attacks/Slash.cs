using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : Attack {

	public const int SLASH_DAMAGE = 1;
	public const float SLASH_KNOCKBACK = 5f;
	public const float SLASH_REPEAT_DELAY = 1f;


	public Slash(GameObject attacker)
	{
		this.setDamageValue(SLASH_DAMAGE);
		this.setKnockBackMultiplier(SLASH_KNOCKBACK);
		this.setAttackRepeatDelay(SLASH_REPEAT_DELAY);
		this.attackerTransform = attacker.transform;
	}
	public Slash(Character attacker)
	{
		this.setDamageValue(SLASH_DAMAGE);
		this.setKnockBackMultiplier(SLASH_KNOCKBACK);
		this.setAttackRepeatDelay(SLASH_REPEAT_DELAY);
		this.attackerTransform = attacker.gameObject.transform;
	}
	public Slash(Transform attackerTransform)
	{
		this.setDamageValue(SLASH_DAMAGE);
		this.setKnockBackMultiplier(SLASH_KNOCKBACK);
		this.setAttackRepeatDelay(SLASH_REPEAT_DELAY);
		this.attackerTransform = attackerTransform;
	}
}

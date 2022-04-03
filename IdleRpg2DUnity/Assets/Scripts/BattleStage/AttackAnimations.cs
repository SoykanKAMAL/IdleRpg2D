using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimations : MonoBehaviour
{
    private Attacker attacker;
    public Animator animator;
    
    private void PlayAttackAnimation()
    {
        animator.SetTrigger("Attack");
    }
    
    private void PlayGetHitAnimation()
    {
        animator.SetTrigger("GetHit");
    }

    public void SetupAnimations(Attacker attacker)
    {
        this.attacker = attacker;
        attacker.OnAttack += PlayAttackAnimation;
        attacker.OnGetHit += PlayGetHitAnimation;
    }

    public void SetupAttackSpeed()
    {
        animator.SetFloat("AttackSpeed", Mathf.Clamp(1, 1f / this.attacker.stats.attackSpeed, int.MaxValue));
    }
    
    public void PerformBasicAttack()
    {
        this.attacker.enemy.TakeDamage(this.attacker.stats.attackDamage);
        Debug.Log("----------------------------------------------------");
        Debug.Log(this.attacker.stats.name + " attacked " + this.attacker.enemy.stats.name + " for " + Mathf.Clamp(this.attacker.stats.attackDamage - this.attacker.enemy.stats.armor, 1, int.MaxValue) + " damage, " + this.attacker.enemy.stats.name + " has " + this.attacker.enemy.stats.currentHealth + " health left.");
    }
}

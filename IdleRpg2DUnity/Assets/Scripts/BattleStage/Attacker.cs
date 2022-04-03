using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Attacker : MonoBehaviour
{
    public CharacterStats stats;
    public Attacker enemy;
    
    public Action OnAttack;
    public Action OnGetHit;
    public Action OnDeath;
    
    public Attacker Setup(CharacterStats stats, Attacker enemy)
    {
        this.stats = stats;
        this.enemy = enemy;
        if(TryGetComponent<AttackAnimations>(out var attackAnimations))  attackAnimations.SetupAttackSpeed();
        return this;
    }

    private void OnEnable()
    {
        // OnBattleEnd event destroy this
        BattleState.OnBattleEnd += Attacker_OnBattleEnd;
        if(TryGetComponent<AttackAnimations>(out var attackAnimations))  attackAnimations.SetupAnimations(this);
    }
    
    private void OnDisable()
    {
        BattleState.OnBattleEnd -= Attacker_OnBattleEnd;
    }

    public void StartAttacking()
    {
        StartCoroutine(BasicAttack());
        StartCoroutine(SpellAttack());
    }
    
    public void TakeDamage(int damage)
    {
        OnGetHit?.Invoke();
        stats.currentHealth -= Mathf.Clamp(damage - stats.armor, 1, int.MaxValue);
        if (stats.currentHealth <= 0)
        {
            Destroy(gameObject);
            BattleState.OnBattleEnd?.Invoke(enemy);
        }
    }
    
    public IEnumerator BasicAttack()
    {
        yield return new WaitForSeconds(stats.attackSpeed);
        if (enemy != null)
        {
            OnAttack?.Invoke();
            yield return BasicAttack();
        }
    }
    
    public IEnumerator SpellAttack()
    {
        yield return new WaitForSeconds(stats.spellSpeed);
        if (enemy != null)
        {
            enemy.TakeDamage(stats.spellDamage);
            Debug.Log("----------------------------------------------------");
            Debug.Log(this.stats.name + " casted a spell on " + enemy.stats.name + " for " + Mathf.Clamp(stats.spellDamage - enemy.stats.armor, 1, int.MaxValue) + " damage, " + enemy.stats.name + " has " + enemy.stats.currentHealth + " health left.");
            yield return SpellAttack();
        }
    }
    
    public void Attacker_OnBattleEnd(Attacker attacker)
    {
        StopAllCoroutines();
        //Destroy(this);
    }
}

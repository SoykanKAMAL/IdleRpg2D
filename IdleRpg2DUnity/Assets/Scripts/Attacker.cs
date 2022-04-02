using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public CharacterStats stats;
    public Attacker enemy;
    
    public Attacker Setup(CharacterStats stats, Attacker enemy)
    {
        this.stats = stats;
        this.enemy = enemy;
        return this;
    }
    
    public void StartAttacking()
    {
        StartCoroutine(BasicAttack());
        StartCoroutine(SpellAttack());
    }
    
    public void TakeDamage(int damage)
    {
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
            enemy.TakeDamage(stats.attackDamage);
            Debug.Log("----------------------------------------------------");
            Debug.Log(this.stats.name + " attacked " + enemy.stats.name + " for " + Mathf.Clamp(stats.attackDamage - enemy.stats.armor, 1, int.MaxValue) + " damage, " + enemy.stats.name + " has " + enemy.stats.currentHealth + " health left.");
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
}

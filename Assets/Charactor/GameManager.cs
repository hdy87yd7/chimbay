using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
public class Character
{
    public string name;
    protected int maxHp;
    protected int hp;
    protected int attack;

    public Character(string name, int hp, int attack)
    {
        this.name=name;
        this.hp=hp;
        this.maxHp=hp;
        this.attack=attack;
    }
    public int GetHp()
    {
        return hp;
    }
    public virtual void Attack(Character other)
    {
        Debug.Log(name + " attacks " + other.name);
        other.TakeDamage(attack);
    }
    public void TakeDamage(int damage)
    {
        hp-=damage;
        if (hp <= 0)
        {
            hp=0;
        }
        Debug.Log(name + " takes damage " + damage + ". HP: " + hp + "/" + maxHp );
        if (hp == 0)
        {
            Debug.Log(name + " has been defeated!");
        }
    }
}
public class Player : Character
{
    public Player(string name, int hp,int attack) : base(name,hp,attack){}
    public override void Attack(Character other)
    {
        Debug.Log(name + " performs an attack!");
        base.Attack(other);
    }
    
}
public class Enemy : Character
{
    public Enemy(String name, int hp, int attack) : base(name,hp,attack){}
    public override void Attack(Character other)
    {
        Debug.Log(name + " performs an attack!");
        base.Attack(other);
    }
}
public class GameManager : MonoBehaviour
{
    void Start()
    {
        Player player = new Player("Player",100,20);
        Enemy enemy= new Enemy("Enemy",50,40);
        Debug.Log("=== COMBAT START ===");
        while(player.GetHp()>0 && enemy.GetHp() > 0)
        {
            player.Attack(enemy);
            if (enemy.GetHp() > 0)
            {
                enemy.Attack(player);
            }
        }
        Debug.Log("=== COMBAT END ===");
        if (player.GetHp() > 0)
        {
            Debug.Log("Player wins!");
        }
        else
        {
            Debug.Log("Enemy wins!");
        }

    }
}

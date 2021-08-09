using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zapper : Hero
{
    [SerializeField] private int attack;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        float offsetX = GetComponent<SpriteRenderer>().bounds.size.x;
        float offsetY = GetComponent<SpriteRenderer>().bounds.size.y;
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    protected override void Attack(GameObject enemy)
    {//attack melee
        audioSource.PlayOneShot(attackSound, 1.0f);
        anim.SetTrigger("attack");
        enemy.GetComponent<Enemy>().GetHit(attack);
    }
}

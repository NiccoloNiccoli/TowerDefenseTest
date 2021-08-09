using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stormhead : Hero
{

    [SerializeField] private int attack;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        float offsetX = GetComponent<SpriteRenderer>().bounds.size.x;
        float offsetY = GetComponent<SpriteRenderer>().bounds.size.y;
        transform.position = new Vector2(transform.position.x - offsetX/15, transform.position.y);
    }

    protected override void Attack(GameObject enemy)
    {//attack melee
        audioSource.PlayOneShot(attackSound, 1.0f);
        anim.SetTrigger("attack");
        enemy.GetComponent<Enemy>().GetHit(attack);
        audioSource.PlayOneShot(attackSound, 1.0f);
    }
}

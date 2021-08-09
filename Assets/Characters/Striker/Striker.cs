using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Striker : Hero
{
    [SerializeField] private int attackMelee;
    [SerializeField] private int attackRanged;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        float offsetX = GetComponent<SpriteRenderer>().bounds.size.x;
        float offsetY = GetComponent<SpriteRenderer>().bounds.size.y;
        transform.position = new Vector2(transform.position.x - offsetX/5 + offsetX/9 , transform.position.y - offsetX / 8);
    }

    protected override void Attack(GameObject enemy)
    {//attack melee
        audioSource.PlayOneShot(attackSound, 0.5f);
        anim.SetTrigger("attack");
        audioSource.PlayOneShot(attackSound, 1.0f);
        enemy.GetComponent<Enemy>().GetHit(attackMelee);
        enemy.GetComponent<Enemy>().GetHit(attackRanged);
    }
}
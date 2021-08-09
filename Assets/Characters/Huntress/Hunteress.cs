using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunteress : Hero
{
    private Vector2 castingPoint;
    [SerializeField] private GameObject projectile;
    [SerializeField] private int attack;
    protected override void Start()
    {
        //TODO testare la posizione e vedere se funziona tutto perché al momento non lo so :)
        base.Start();
        float offsetX = GetComponent<SpriteRenderer>().bounds.size.x;
        float offsetY = GetComponent<SpriteRenderer>().bounds.size.y;
        transform.position = new Vector2(transform.position.x-offsetX/7, transform.position.y - offsetY/6);
        castingPoint = new Vector2(transform.position.x + offsetX / 5, transform.position.y + offsetY / 2);
    }

    protected override void Attack(GameObject enemy)
    {//attack melee
        audioSource.PlayOneShot(attackSound, 1.0f);
        anim.SetTrigger("attack");
        enemy.GetComponent<Enemy>().GetHit(attack);
        GameObject prj = Instantiate(projectile, castingPoint, Quaternion.identity);
        prj.GetComponent<BasicProjectile>().AssignEnemy(enemy);
    }
}

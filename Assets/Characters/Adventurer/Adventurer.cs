using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer : Hero
{
    [SerializeField] private AudioClip attack_m; //l'altra è attack_r
    [SerializeField] protected int meleeRange;
    [SerializeField] private GameObject projectile;
    [SerializeField] private int attackMelee;
    [SerializeField] private float cooldownRanged;
    private Vector2 castingPoint;
    protected override void Start()
    {
        //TODO testare la posizione e vedere se funziona tutto perché al momento non lo so :)
        base.Start();
        float offsetX = GetComponent<SpriteRenderer>().bounds.size.x;
        float offsetY = GetComponent<SpriteRenderer>().bounds.size.y;
        transform.position = new Vector2(transform.position.x - offsetX / 4, transform.position.y);
        castingPoint = new Vector2(transform.position.x + offsetX /2, transform.position.y+offsetY/2);
    }

    protected override void Update() {
        bool ranged = false;
        GameObject[] activeEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        int i = 0;
        bool isEnemyNear = false;
        while (i < activeEnemies.Length && !isEnemyNear) {
            if (Mathf.Abs(activeEnemies[i].transform.position.x - transform.position.x) < range && Mathf.Approximately(Mathf.Ceil(transform.position.y), Mathf.Ceil(activeEnemies[i].transform.position.y))) {
                isEnemyNear = true;
                if(Mathf.Abs(activeEnemies[i].transform.position.x - transform.position.x) < meleeRange) {
                    ranged = false;
                }
                else {
                    ranged = true;
                }
            }
            else {
                i++;
            }
        }
        if (isEnemyNear) {
            if (timeToNextAttack <= 0) {
                if (ranged) {
                    AttackRanged(activeEnemies[i]);
                    timeToNextAttack = cooldownRanged;
                }
                else {
                    Attack(activeEnemies[i]);
                    timeToNextAttack = cooldown;
                }
                
            }
        }
        timeToNextAttack -= Time.deltaTime;
    }


    protected override void Attack(GameObject enemy) {//attack melee
        audioSource.PlayOneShot(attack_m, 1.0f);
            anim.SetTrigger("attackM");
            enemy.GetComponent<Enemy>().GetHit(attackMelee);
    }
    protected void AttackRanged(GameObject enemy) {
        audioSource.PlayOneShot(attackSound, 1.0f);
        anim.SetTrigger("attackR");
        GameObject prj = Instantiate(projectile, castingPoint, Quaternion.identity);
        prj.GetComponent<BasicProjectile>().AssignEnemy(enemy);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blacksmith : Hero
{
    [SerializeField] private int attack;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        float offsetX = GetComponent<SpriteRenderer>().bounds.size.x;
        float offsetY = GetComponent<SpriteRenderer>().bounds.size.y;
        transform.position = new Vector2(transform.position.x - offsetX/32, transform.position.y+offsetY/3);
    }
    protected override void Update() {
        GameObject[] activeEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        int i = 0;
        bool isEnemyNear = false;
        while (i < activeEnemies.Length && !isEnemyNear) {
            if (Mathf.Abs(activeEnemies[i].transform.position.x - transform.position.x) < range && Mathf.Approximately(Mathf.Ceil(transform.position.y), Mathf.Ceil(activeEnemies[i].transform.position.y))) {
                isEnemyNear = true;
            }
            else {
                i++;
            }
        }
        if (isEnemyNear) {
            if (timeToNextAttack <= 0) {
                Attack(activeEnemies[i]);
                timeToNextAttack = cooldown;
            }
        }
        timeToNextAttack -= Time.deltaTime;
    }
    protected override void Attack(GameObject enemy) {//attack melee
        base.Attack(enemy);
        enemy.GetComponent<Enemy>().GetHit(attack);
    }
}

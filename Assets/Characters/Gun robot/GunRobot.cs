using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRobot : Hero
{
    [SerializeField] private float slowTime;
    [SerializeField] private float slowingFactor;
    [SerializeField] private GameObject slowShootingEffect;
    private Vector2 shootingPoint;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        float offsetX = GetComponent<SpriteRenderer>().bounds.size.x;
        float offsetY = GetComponent<SpriteRenderer>().bounds.size.y;
        shootingPoint = new Vector2(transform.position.x + offsetX / 12, transform.position.y + offsetY / 3*2 + offsetY/16);

    }

    // Update is called once per frame
    /* void Update()
     {

     }*/
    protected override void Attack(GameObject enemy) {//attack melee
        base.Attack(enemy);
        slowShootingEffect.GetComponent<SpriteRenderer>().sortingOrder = this.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
        Instantiate(slowShootingEffect, shootingPoint, Quaternion.identity);
        enemy.GetComponent<Enemy>().Slow(slowTime,slowingFactor);
    }
}

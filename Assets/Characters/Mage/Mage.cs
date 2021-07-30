using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Hero
{
    [SerializeField] private GameObject projectile;
    private Vector2 castingPoint;
    protected override void Start() {
        base.Start();
        float offsetX = GetComponent<SpriteRenderer>().bounds.size.x;
        float offsetY = GetComponent<SpriteRenderer>().bounds.size.y;
        transform.position = new Vector2(transform.position.x - offsetX / 6, transform.position.y);
        castingPoint = new Vector2(transform.position.x+offsetX/5, transform.position.y+offsetY/2+offsetY/10);

    }
    protected override void Attack(GameObject enemy) {
        base.Attack(enemy);
        GameObject prj = Instantiate(projectile, castingPoint, Quaternion.identity);
        prj.GetComponent<BasicProjectile>().AssignEnemy(enemy);
    }
}

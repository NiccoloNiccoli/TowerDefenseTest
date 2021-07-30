using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : BasicProjectile
{
    [SerializeField] protected GameObject explosion = null;

    protected override void OnTriggerEnter2D(Collider2D other) {
        anim.SetTrigger("Explode");
        StartCoroutine(Explode(anim.GetCurrentAnimatorStateInfo(0).length));
    }

    protected IEnumerator Explode(float waitTime) {
        GameObject ex = Instantiate(explosion, new Vector2(enemy.transform.position.x, Mathf.Floor(enemy.transform.position.y)), Quaternion.identity);
        SpriteRenderer exSprite = ex.GetComponent<SpriteRenderer>();
        exSprite.color = new Color(168, 0, 255);
        exSprite.sortingOrder = enemy.GetComponent<SpriteRenderer>().sortingOrder + 1;
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }
}

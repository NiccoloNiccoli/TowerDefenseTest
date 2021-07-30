using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Hero
{
    [SerializeField] private int finalHitMultiplier;
    [SerializeField] private int attack;
    protected Vector2 startingPos;
    private int hitsDone = 0;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        float offsetX = GetComponent<SpriteRenderer>().bounds.size.x;
        transform.position = new Vector2(transform.position.x - offsetX /3, transform.position.y);
        startingPos = transform.position;
    }

    // Update is called once per frame

    protected override void Attack(GameObject enemy) {
        audioSource.PlayOneShot(attackSound, 1.0f);
        //2 normal hit and then one stronger(x 2)
        if (hitsDone == 2) {
            anim.SetTrigger("attack2");
            enemy.GetComponent<Enemy>().GetHit(attack * finalHitMultiplier);
            //longer cooldown
            hitsDone = 0;
           // anim.ResetTrigger("attack2");
        }
        else {
            anim.SetTrigger("attack1");
            enemy.GetComponent<Enemy>().GetHit(attack);
            hitsDone++;
            //anim.ResetTrigger("attack1");
        }
    }
}

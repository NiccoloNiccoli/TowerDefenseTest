using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : Hero
{
    [SerializeField] private int moneyPerAttack;
    protected override void Start()
    {
        base.Start();
        float offsetX = GetComponent<SpriteRenderer>().bounds.size.x;
        transform.position = new Vector2(transform.position.x - offsetX /3 *2, transform.position.y);

    }

    // Update is called once per frame
    protected override void Update()
    {
        if (timeToNextAttack <= 0) {
            GiveMoney(moneyPerAttack);
            timeToNextAttack = cooldown;
        }
        timeToNextAttack -= Time.deltaTime;
    }

    protected void GiveMoney(int mpa) {
        anim.SetTrigger("attack");
        audioSource.PlayOneShot(attackSound, 1.0f);
        GameObject game = GameObject.FindGameObjectWithTag("GameController");
        game.GetComponent<GameData>().Earn(moneyPerAttack);
    }
}

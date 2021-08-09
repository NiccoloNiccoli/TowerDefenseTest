using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Hero
{

    [SerializeField] private int attack;
    [SerializeField] private GameObject explosion;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        float offsetX = GetComponent<SpriteRenderer>().bounds.size.x;
        float offsetY = GetComponent<SpriteRenderer>().bounds.size.y;
        transform.position = new Vector2(transform.position.x-offsetX/8, transform.position.y-offsetY/5);
    }

    protected virtual void Update()
    {
        GameObject[] activeEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        int i = 0;
        bool isEnemyNear = false;
        if(activeEnemies.Length > 0 && timeToNextAttack <= 0)
            {
                
                StartCoroutine(AttackEveryone(1.0f,activeEnemies));
                timeToNextAttack = cooldown;
            }
        timeToNextAttack -= Time.deltaTime;
    }
    private void playAttackAnim()
    {
        audioSource.PlayOneShot(attackSound, 1.0f);
        anim.SetTrigger("attack");
        GameObject e = Instantiate(explosion, transform.position, Quaternion.identity);
        e.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder;
    }
    IEnumerator AttackEveryone(float timeToWait, GameObject[] activeEnemies)
    {
        playAttackAnim();
        yield return new WaitForSeconds(timeToWait);
        for (int j = 0; j < activeEnemies.Length; j++)
        {
            activeEnemies[j].GetComponent<Enemy>().GetHit(attack);
        }
    }
}

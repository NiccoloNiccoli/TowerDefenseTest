using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
    [SerializeField] private GameObject laser;
    protected override void Update()
    {
        GameObject[] heroes = GameObject.FindGameObjectsWithTag("Hero");
        if (heroes.Length >= 0)
        {
            float minDistance = Mathf.Infinity;
            int minIndex = -1;
            for (int i = 0; i < heroes.Length; i++)
            {
                if (Mathf.Abs(heroes[i].transform.position.x - transform.position.x) < minDistance && Mathf.CeilToInt(heroes[i].transform.position.y) == Mathf.CeilToInt(transform.position.y))
                {
                    minDistance = Mathf.Abs(heroes[i].transform.position.x - transform.position.x);
                    minIndex = i;
                }
            }
            if (minDistance <= range && minIndex != -1)
            {
                if (timeToNextAttack <= 0)
                {
                    AttackOneRow(heroes[minIndex],heroes);
                    timeToNextAttack = cooldown;
                }

            }
            else if (IsAlive() && !anim.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
            {
                Move();
            }
        }
        timeToNextAttack -= Time.deltaTime;

        if (transform.position.x.Equals(trgPoint.x))
        {
            Debug.LogError("Hai perso!");
            Time.timeScale = 0.0f;
            //TODO
        }
    }

    void AttackOneRow(GameObject firstHero, GameObject[] heroes)
    {
        Attack();
        for (int i = 0; i < heroes.Length; i++)
        {
            if (Mathf.CeilToInt(heroes[i].transform.position.y) == Mathf.CeilToInt(firstHero.transform.position.y))
            {
                heroes[i].GetComponent<Hero>().GetHit(attack);
            }
        }
        //now changes position
        int newRow = 0;
        do
        {
            newRow = Random.Range(-1,2);
        } while (newRow == 0);
        transform.position = new Vector2(transform.position.x, transform.position.y + newRow);
        trgPoint = new Vector2(trgPoint.x, transform.position.y);
    }

    public override void Attack()
    {
        base.Attack();
        GameObject l = Instantiate(laser, transform.position, Quaternion.identity);
        l.GetComponent<laser>().SetOrder(GetComponent<SpriteRenderer>().sortingOrder);
    }
}

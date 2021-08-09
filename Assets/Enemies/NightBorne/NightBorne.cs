using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorne : Enemy
{
    private Vector2 startingPosition;
    int phase = 0;

    protected override void Start()
    {
        base.Start();
        startingPosition = transform.position;
    }

    protected override void Update()
    {
        //phase1: cerca nemico e lo uccide
        switch (phase)
        {
            case 0:
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
                            Attack(heroes[minIndex]);
                            timeToNextAttack = cooldown;
                            phase = 1;
                            _ = GetComponent<SpriteRenderer>().flipX;
                        }

                    }
                    else if (IsAlive() && !anim.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
                    {
                        Move();
                    }
                }
                break;
            case 1:
                if(transform.position.x < startingPosition.x)
                {
                    Return();
                }
                else
                {
                    phase = 0;
                    _ = GetComponent<SpriteRenderer>().flipX;
                    int newRow = 0;
                    do
                    {
                        newRow = Random.Range(-1, 2);
                    } while (newRow == 0);
                    transform.position = new Vector2(transform.position.x, transform.position.y + newRow);
                    trgPoint = new Vector2(trgPoint.x, transform.position.y);
                }
                break;
        }
        timeToNextAttack -= Time.deltaTime;
        if (transform.position.x.Equals(trgPoint.x))
        {
            Debug.LogError("Hai perso!");
            Time.timeScale = 0.0f;
            //TODO
        }
    }

    private void Return()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPosition, moveSpeed * Time.deltaTime);
    }
}

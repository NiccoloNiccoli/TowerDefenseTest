using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int health = 3;
    [SerializeField] protected int attack;
    [SerializeField] protected int range;
    [SerializeField] protected float cooldown;
    [SerializeField] protected int reward;
    [SerializeField] protected AudioClip attackSound;
    [SerializeField] protected AudioClip hitSound;
    [SerializeField] protected AudioClip deathSound;
    [SerializeField] protected Vector2 initialOffset;
    protected AudioSource audioSource;
    protected float timeToNextAttack = 0f;
    protected bool isSlowed = false;
    protected Animator anim;

    [SerializeField]
    protected float moveSpeed = 1f;

    protected Vector2 trgPoint;

    protected virtual void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.7f;
        transform.position = new Vector2(transform.position.x + initialOffset.x, transform.position.y + 0.49f + initialOffset.y);
        anim = GetComponent<Animator>();
        GameObject target = GameObject.FindGameObjectWithTag("Target");
        trgPoint = new Vector2(target.transform.position.x, transform.position.y);

    }

    // Update is called once per frame
    virtual protected void Update() {
        GameObject[] heroes = GameObject.FindGameObjectsWithTag("Hero");
        if (heroes.Length >= 0) {
            float minDistance = Mathf.Infinity;
            int minIndex = -1;
            for (int i = 0; i < heroes.Length; i++) {
                if (Mathf.Abs(heroes[i].transform.position.x - transform.position.x) < minDistance && Mathf.CeilToInt(heroes[i].transform.position.y) == Mathf.CeilToInt(transform.position.y )) {
                    minDistance = Mathf.Abs(heroes[i].transform.position.x - transform.position.x);
                    minIndex = i;
                }
           }
           if (minDistance <= range && minIndex != -1) {
                if(timeToNextAttack <= 0) {
                    Attack(heroes[minIndex]);
                    timeToNextAttack = cooldown;
                }
                
            } else if (IsAlive() && !anim.GetCurrentAnimatorStateInfo(0).IsTag("attack")) {
                Move();
            }
        }
        timeToNextAttack -= Time.deltaTime;

        if (transform.position.x.Equals(trgPoint.x)) {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameData>().Lose();
        }
        
    }

    protected void Move() {
            transform.position = Vector2.MoveTowards(transform.position, trgPoint, moveSpeed * Time.deltaTime);
    }

    virtual public void GetHit(int dmg) {
        health -= dmg;
        anim.SetTrigger("getHit");
        audioSource.PlayOneShot(hitSound, 1.0f);
        if (health <= 0)
            Die();
    }

    public void Die() {
        StartCoroutine(PlayDeathAnim(anim.GetCurrentAnimatorStateInfo(0).length));
        StartCoroutine(DestroyAfter(5.0f));
    }

    public bool IsAlive() {
        if (health > 0)
            return true;
        else
            return false;
    }

    virtual public void Attack() {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("attack")) {
            anim.SetTrigger("attack"); //0 -> idle, 1->run, 2->attack
            audioSource.PlayOneShot(attackSound, 1.0f);
        }
     }

    public void Attack(GameObject target) {
        Attack();
        target.GetComponent<Hero>().GetHit(attack);
        /*if (!target.GetComponent<Hero>().IsAlive()) {
            GetComponent<Movement>().isAttacking(false);
        }*/
    }


    private IEnumerator PlayDeathAnim(float waitTime) {
        anim.SetBool("isAlive", false);
        audioSource.PlayOneShot(deathSound, 1.0f);
        yield return new WaitForSeconds(waitTime);
        //il singleton me lo faccio da solo
        GameObject game = GameObject.FindGameObjectWithTag("GameController");
        game.GetComponent<GameData>().Earn(reward);
        game.GetComponent<GameData>().UpdateProgressBar();
        this.gameObject.SetActive(false);
    }

    private IEnumerator AttackHero(GameObject target, float waitTime) {
       
        yield return new WaitForSeconds(waitTime);
    }

    public void Slow(float time, float factor) {
        if (!isSlowed) {
            float oldSpeed = moveSpeed;
            moveSpeed *= factor;
            isSlowed = true;
            StartCoroutine(Slowed(time, oldSpeed));
        }
       
    }

    private IEnumerator Slowed(float time, float oldSpeed) {
        //TODO fare uno shader che renda blu/bianco il personaggio slowato
        yield return new WaitForSeconds(time);
        moveSpeed = oldSpeed;
        isSlowed = false;
    }

    IEnumerator DestroyAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);

    }

}

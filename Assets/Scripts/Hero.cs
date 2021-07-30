using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int defense;
    [SerializeField] protected int range;
    [SerializeField] protected float cooldown;
    [SerializeField] protected int cost;
    [SerializeField] protected AudioClip attackSound;
    [SerializeField] protected AudioClip summonSound;
    [SerializeField] protected AudioClip hitSound;
    [SerializeField] protected AudioClip deathSound;
    [SerializeField] protected GameObject shadow;
    protected AudioSource audioSource;
    protected Vector2 pos;
    protected Animator anim;
    protected float timeToNextAttack = 0f;
    [SerializeField] public Sprite iconSprite;
    public int iconAnimIndex;
    protected virtual void Start()
    {
        if(shadow != null)
            shadow.GetComponent<SpriteRenderer>().sortingOrder = this.GetComponent<SpriteRenderer>().sortingOrder;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.7f;
        audioSource.PlayOneShot(summonSound, 1.0f);
        anim = GetComponent<Animator>();
    }

    
    protected virtual void Update()
    {
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


    protected virtual void Attack(GameObject enemy) {
        audioSource.PlayOneShot(attackSound, 1.0f);
        anim.SetTrigger("attack");
    }

    //protected virtual void Attack() => anim.SetTrigger("attack");

    public virtual void GetHit(int dmg) {
        //FIXME
        StartCoroutine(PlayTakeHit(anim.GetCurrentAnimatorStateInfo(0).length));
        dmg -= defense;
        if (dmg > 1)
            health -= dmg;
        else if (dmg <= 1 && dmg >= 0)
            health -= 1;

        if (health <= 0)
            Die();
    }

    protected IEnumerator PlayTakeHit(float waitTime) {
        anim.SetTrigger("takeHit");
        audioSource.PlayOneShot(hitSound, 1.0f);
        yield return new WaitForSeconds(waitTime);
        //anim.ResetTrigger("takeHit");
    }

    protected void Die() {
        GameObject.FindGameObjectWithTag("Grid").GetComponent<GridController>().FreePos(pos);
        StartCoroutine(PlayDeathAnim());
    }
    protected IEnumerator PlayDeathAnim() {
        float waitTime = 0.0f;
        anim.SetBool("isAlive", false);
        //anim.SetTrigger("die");
        audioSource.PlayOneShot(deathSound, 1.0f);
        yield return new WaitForSeconds(0.4f);
        waitTime = anim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(waitTime-0.4f);
        this.gameObject.SetActive(false);
    }

    public bool IsAlive() {
        if (health > 0)
            return true;
        else
            return false;
    }

    public int GetCost() {
        return cost;
    }

    public void SetPos(Vector2 p) {
        pos = p;
    }
    public Vector2 GetPos() {
        return pos;
    }
}

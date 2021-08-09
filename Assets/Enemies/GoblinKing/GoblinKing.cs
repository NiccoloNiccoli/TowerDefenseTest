using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinKing : Enemy
{
    private GameObject camera;
    private void Awake()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    protected override void Update()
    {
        GameObject[] heroes = GameObject.FindGameObjectsWithTag("Hero");

        if (heroes.Length >= 0)
        {
                if (timeToNextAttack <= 0)
                {
                    AttackAllEnemies(heroes);
                    timeToNextAttack = cooldown;
                }

            }
            if (IsAlive() && !anim.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
            {
                Move();
            }
        timeToNextAttack -= Time.deltaTime;
        if (transform.position.x.Equals(trgPoint.x))
        {
            Debug.LogError("Hai perso!");
            Time.timeScale = 0.0f;
            //TODO
        }
    }


    public void AttackAllEnemies(GameObject[] heroes)
    {
              Attack();
    for(int i = 0; i < heroes.Length; i++)
        {
            heroes[i].GetComponent<Hero>().GetHit(attack);
        }
  
    }

    public override void Attack()
    {
        base.Attack();
        StartCoroutine(Shake(0.2f,1f));
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = camera.transform.position;
        float elapsed = 0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            camera.transform.position = new Vector3(x, y, originalPosition.z);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        camera.transform.position = originalPosition;
    }

}

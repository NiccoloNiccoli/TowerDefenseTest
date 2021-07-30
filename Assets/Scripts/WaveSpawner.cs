using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies = null;
    [SerializeField] private float timeBetweenSpanws = 2f;
    [SerializeField] private GameObject[] spawners = null;
    float cooldown = 0f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown <= 0f) {
            int i = Random.Range(0, spawners.Length);
            print(i);
            GameObject e = Instantiate(enemies[Random.Range(0, enemies.Length)], spawners[i].transform.position + Vector3.forward, Quaternion.identity);
            int j = 0;
            while (j < spawners.Length && Mathf.FloorToInt(e.transform.position.y) != Mathf.FloorToInt(spawners[j].transform.position.y)) {
                j++;
            }
            e.GetComponent<SpriteRenderer>().sortingOrder = j+1;
            cooldown = timeBetweenSpanws;
        }
        cooldown -= Time.deltaTime;
    }
}

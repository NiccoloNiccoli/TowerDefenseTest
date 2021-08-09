using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainExplosion : Explosion {
    [SerializeField] private GameObject[] explosions;
    protected override void Start()
    {
        base.Start();
        GameObject spawner = GameObject.FindGameObjectWithTag("Spawner");
        if(transform.position.x < spawner.transform.position.x)
        {
            GameObject e = Instantiate(explosions[Random.Range(0, explosions.Length)], new Vector2(transform.position.x + GetComponent<SpriteRenderer>().sprite.rect.width/3 * 2, transform.position.y), Quaternion.identity);
            e.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder;
        }
    }
}

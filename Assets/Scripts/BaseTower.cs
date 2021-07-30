using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    [SerializeField] GameObject projectile = null;
    [SerializeField] float projectilePerSecond = 0.5f;
    private float cooldown = 0f;
    Vector2 shootingPoint;
    // Start is called before the first frame update
    void Start()
    {
        float offsetX = GetComponent<SpriteRenderer>().bounds.size.x;
        float offsetY = GetComponent<SpriteRenderer>().bounds.size.y;
        shootingPoint = new Vector2(transform.position.x + offsetX / 2 , transform.position.y + offsetY / 2);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemiesInRange = GameObject.FindGameObjectsWithTag("Goblin");
        if (enemiesInRange.Length > 0 && cooldown <= 0f) {
            Shoot(enemiesInRange[0]);
            cooldown = 1 / projectilePerSecond;
        }
        else {
            cooldown -= Time.deltaTime;
        }
    }

   void Shoot(GameObject enemy) { 
        GameObject proj = Instantiate(projectile, shootingPoint, Quaternion.identity);
        proj.GetComponent<BasicProjectile>().AssignEnemy(enemy);
        
    }
}

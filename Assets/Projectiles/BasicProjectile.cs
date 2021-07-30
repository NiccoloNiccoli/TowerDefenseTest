using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour {
    protected GameObject enemy;
    [SerializeField] protected float speed = 3f;
    [SerializeField] protected int dmg = 1;
    protected Animator anim;
    protected virtual void Start() {
        anim = GetComponent<Animator>();
        GetComponent<SpriteRenderer>().sortingOrder = enemy.GetComponent<SpriteRenderer>().sortingOrder;
        Vector3 directionVector = transform.position - enemy.transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.Cross(directionVector, Vector3.down));
    }

    // Update is called once per frame
   protected virtual void Update() {
        Vector2 target = new Vector2(enemy.transform.position.x, enemy.transform.position.y + enemy.GetComponent<SpriteRenderer>().bounds.size.y / 2 +
            Random.Range(-enemy.GetComponent<SpriteRenderer>().bounds.size.y*0.25f, enemy.GetComponent<SpriteRenderer>().bounds.size.y*0.25f));
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (!enemy.activeInHierarchy) {
            Vector2 pos = new Vector2(transform.position.x, transform.position.y);
            if (pos == target) {
                Destroy(this.gameObject);
            }
        }
    }

    public void AssignEnemy(GameObject _enemy) {
        enemy = _enemy;
    }


    protected virtual void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            other.gameObject.GetComponent<Enemy>().GetHit(dmg);
            Destroy(this.gameObject);
        }
    }
}

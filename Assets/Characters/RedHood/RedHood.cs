using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedHood : Hero
{
    
    [SerializeField] private GameObject barrier = null;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        float offsetX = GetComponent<SpriteRenderer>().bounds.size.x;
        transform.position = new Vector2(transform.position.x - offsetX / 3, transform.position.y);
        anim.SetTrigger("attack");
        StartCoroutine(CreateBarrier(anim.GetCurrentAnimatorStateInfo(0).length));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected IEnumerator CreateBarrier(float wait) {
        yield return new WaitForSeconds(wait);
        Instantiate(barrier, transform.position + new Vector3(0.5f,0,0), Quaternion.identity);
    }
}

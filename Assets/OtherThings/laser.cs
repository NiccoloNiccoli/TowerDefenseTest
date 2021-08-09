using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfter(1f));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetOrder(int x)
    {
        GetComponent<SpriteRenderer>().sortingOrder = x;
    }
    private IEnumerator DestroyAfter(float seconds)
    {

        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }
}

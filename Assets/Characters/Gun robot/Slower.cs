using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slower : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(DestroyAfter(anim.GetCurrentAnimatorStateInfo(0).length));
    }

    private IEnumerator DestroyAfter(float length) {
        yield return new WaitForSeconds(length);
        Destroy(this.gameObject);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Animator anim;
    private float countdown;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.7f;
        anim = GetComponent<Animator>();
        countdown = anim.GetCurrentAnimatorStateInfo(0).length;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown<=0.0f) {
            Destroy(this.gameObject);
        }
        countdown -= Time.deltaTime;
    }
}

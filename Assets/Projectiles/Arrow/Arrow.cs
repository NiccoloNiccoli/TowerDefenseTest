using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : BasicProjectile
{
    [SerializeField] private GameObject trail;
    private TrailRenderer trailR;

    protected override void Start() {
        base.Start();
        trailR = trail.GetComponent<TrailRenderer>();
        trailR.sortingOrder = this.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
    }
}

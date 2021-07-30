using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Hero
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
    }

    public override void GetHit(int dmg) {
        dmg -= defense;
        if (dmg > 1)
            health -= dmg;
        else if (dmg <= 1 && dmg >= 0)
            health -= 1;

        if (health <= 0)
            Destroy(this.gameObject);
    }

}

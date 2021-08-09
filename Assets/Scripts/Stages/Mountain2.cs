using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain2 : Level
{
    override protected IEnumerator SpawnCR()
    {
        yield return new WaitForSeconds(3f);
        InstantiateEnemy(0, 0);
        yield return new WaitForSeconds(5f);
        InstantiateEnemy(0, 3);
        yield return new WaitForSeconds(5f);
        InstantiateEnemy(0, 0);
        yield return new WaitForSeconds(5f);
        InstantiateEnemy(0, 4);
        yield return new WaitForSeconds(5f);
        InstantiateEnemy(0, 0);
        yield return new WaitForSeconds(1f);
        InstantiateEnemy(0, 0);
        InstantiateEnemy(0, 2);
        InstantiateEnemy(0, 4);
        InstantiateEnemy(0, 3);
        yield return new WaitForSeconds(5f);

        InstantiateEnemy(0, 2);
        InstantiateEnemy(1, 1);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 2);
        InstantiateEnemy(0, 3);
        InstantiateEnemy(0, 0);
        InstantiateEnemy(0, 4);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 4);
        InstantiateEnemy(0, 1);
        InstantiateEnemy(0, 2);
        yield return new WaitForSeconds(1f);
        InstantiateEnemy(0, 4);
        InstantiateEnemy(1, 0);
        yield return new WaitForSeconds(0.5f);

        InstantiateEnemy(0, 0);
        InstantiateEnemy(1, 4);
        InstantiateEnemy(1, 3);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 3);
        InstantiateEnemy(0, 4);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 3);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 3);
        InstantiateEnemy(0, 4);
        yield return new WaitForSeconds(1f);
        InstantiateEnemy(1, 2);
        InstantiateEnemy(1, 1);
        yield return new WaitForSeconds(0.5f);

        InstantiateEnemy(1, 3);
        InstantiateEnemy(1, 4);
        InstantiateEnemy(1, 0);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 3);
        InstantiateEnemy(0, 1);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 1);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 4);
        InstantiateEnemy(0, 3);
        yield return new WaitForSeconds(1f);
        InstantiateEnemy(0, 4);
        InstantiateEnemy(0, 2);
        yield return new WaitForSeconds(0.5f);

        InstantiateEnemy(0, 0);
        InstantiateEnemy(0, 3);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 3);
        InstantiateEnemy(0, 2);
        InstantiateEnemy(0, 0);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 0);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 4);
        InstantiateEnemy(0, 0);
        yield return new WaitForSeconds(1f);
        InstantiateEnemy(0, 0);
        InstantiateEnemy(0, 2);
        yield return new WaitForSeconds(0.5f);

        InstantiateEnemy(0, 0);
        InstantiateEnemy(0, 1);
        InstantiateEnemy(0, 2);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 1);
        InstantiateEnemy(0, 2);
        InstantiateEnemy(1, 3);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 0);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 3);
        InstantiateEnemy(0, 0);
        InstantiateEnemy(1, 4);
        yield return new WaitForSeconds(0.5f);

        InstantiateEnemy(0, 4);
        InstantiateEnemy(0, 2);
        InstantiateEnemy(0, 1);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0,4);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 3);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 3);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 0);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 1);
        yield return new WaitForSeconds(1f);
        InstantiateEnemy(1, 1);
        InstantiateEnemy(1, 0);
        yield return new WaitForSeconds(0.5f);

        InstantiateEnemy(1, 3);
        InstantiateEnemy(1, 0);
        InstantiateEnemy(1, 1);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 4);
        InstantiateEnemy(0, 0);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 0);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 0);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 2);
        yield return new WaitForSeconds(1f);
        InstantiateEnemy(1, 1);
        InstantiateEnemy(1, 2);
        yield return new WaitForSeconds(0.5f);

    }
}
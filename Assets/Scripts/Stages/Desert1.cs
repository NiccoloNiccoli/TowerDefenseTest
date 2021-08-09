using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desert1 : Level
{
    override protected IEnumerator SpawnCR()
    {

        InstantiateEnemy(0, 4); //0
        yield return new WaitForSeconds(5f);
        InstantiateEnemy(0, 0); //1
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < 4; i++)
        {
            InstantiateEnemy(0, (1 + i * 2) % spawners.Length);
            yield return new WaitForSeconds(1f);
        }//5
        InstantiateEnemy(0, 0); //6
        yield return new WaitForSeconds(1f);
        InstantiateEnemy(1, 0); //7
        yield return new WaitForSeconds(2f);
        InstantiateEnemy(0, 2); //8
        yield return new WaitForSeconds(1f);
        InstantiateEnemy(0, 3); //9
        yield return new WaitForSeconds(1f);
        InstantiateEnemy(0, 0); //10
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 4; i++)
        {
            InstantiateEnemy(i % 2, 0);
            yield return new WaitForSeconds(2f);
        }//14
        InstantiateEnemy(0, 3);
        InstantiateEnemy(0, 1);
        yield return new WaitForSeconds(2f);
        InstantiateEnemy(0, 1);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 1);//18
        InstantiateEnemy(1, 4);
        yield return new WaitForSeconds(2f);
        InstantiateEnemy(0, 1);
        InstantiateEnemy(0, 2);
        InstantiateEnemy(0, 3);
        yield return new WaitForSeconds(5f);
        InstantiateEnemy(0, 1);
        InstantiateEnemy(0, 2);
        InstantiateEnemy(0, 3);
        InstantiateEnemy(0, 0);
        yield return new WaitForSeconds(2f);
        InstantiateEnemy(1, 1);//28
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 10; i++)
        {
            InstantiateEnemy(0, (i * 3) % spawners.Length);
            if (i % 3 == 0)
                InstantiateEnemy(1, (i * 3 + 1) % spawners.Length);
            yield return new WaitForSeconds(0.5f);
        }//41
        InstantiateEnemy(0, 0); //42
        yield return new WaitForSeconds(1f);
        InstantiateEnemy(1, 0); //43
        yield return new WaitForSeconds(2f);
        InstantiateEnemy(0, 2); //44
        yield return new WaitForSeconds(1f);
        InstantiateEnemy(0, 3); //45
        for (int i = 0; i < 2; i++)
        {
            InstantiateEnemy(1, i);
            InstantiateEnemy(1, spawners.Length - 1 - i);
            yield return new WaitForSeconds(2.5f);
        }
        InstantiateEnemy(1, 2);


    }
}

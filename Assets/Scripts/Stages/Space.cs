using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space : Level
{
    override protected IEnumerator SpawnCR()
    {
        //1
        yield return new WaitForSeconds(3f);
        InstantiateEnemy(0, 1);
        yield return new WaitForSeconds(10f);
        InstantiateEnemy(0, 3);
        yield return new WaitForSeconds(10f);
        InstantiateEnemy(1,3);
        yield return new WaitForSeconds(10f);
        InstantiateEnemy(0,4);
        yield return new WaitForSeconds(10f);
        InstantiateEnemy(1,4);
        yield return new WaitForSeconds(10f);
        InstantiateEnemy(0, 0);
        InstantiateEnemy(0, 4);
        InstantiateEnemy(0, 3);
        yield return new WaitForSeconds(1f);
        InstantiateEnemy(0, 0);
        InstantiateEnemy(0, 4);
        yield return new WaitForSeconds(1f);

        //2
        InstantiateEnemy(0, 1);
        InstantiateEnemy(0, 4);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 4);
        InstantiateEnemy(0, 2);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 2);
        InstantiateEnemy(0, 0);
        InstantiateEnemy(1, 1);
        yield return new WaitForSeconds(1f);
        InstantiateEnemy(0, 0);
        yield return new WaitForSeconds(1f);
        InstantiateEnemy(1, 0);
        InstantiateEnemy(1, 1);
        yield return new WaitForSeconds(1f);

        //3
        InstantiateEnemy(1, 2);
        InstantiateEnemy(1, 0);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 0);
        InstantiateEnemy(0, 3);
        InstantiateEnemy(1, 1);
        InstantiateEnemy(0, 2);
        yield return new WaitForSeconds(1f);
        InstantiateEnemy(1, 1);
        InstantiateEnemy(0, 2);
        InstantiateEnemy(1, 3);
        InstantiateEnemy(1, 4);
        yield return new WaitForSeconds(1f);

        //4
        InstantiateEnemy(1, 3);
        InstantiateEnemy(1, 1);
        InstantiateEnemy(0, 4);
        InstantiateEnemy(0, 2);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 1);
        InstantiateEnemy(0, 2);
        yield return new WaitForSeconds(1f);
        InstantiateEnemy(1, 2);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 2);
        InstantiateEnemy(1, 1);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 2);
        yield return new WaitForSeconds(1f);

        //5
        InstantiateEnemy(1, 3);
        InstantiateEnemy(1, 4);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 4);
        InstantiateEnemy(0, 0);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 3);
        InstantiateEnemy(0, 1);
        yield return new WaitForSeconds(1f);
        InstantiateEnemy(1, 3);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 3);
        InstantiateEnemy(1, 4);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 0);
        yield return new WaitForSeconds(1f);

        //6
        InstantiateEnemy(0, 0);
        InstantiateEnemy(1, 1);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 1);
        InstantiateEnemy(0, 3);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 0);
        InstantiateEnemy(0, 4);
        yield return new WaitForSeconds(1f);
        InstantiateEnemy(1, 1);
        InstantiateEnemy(0, 3);
        InstantiateEnemy(1, 4);
        InstantiateEnemy(0, 0);
        yield return new WaitForSeconds(1f);

        //7
        InstantiateEnemy(0, 4);
        InstantiateEnemy(1, 3);
        InstantiateEnemy(0, 0);
        InstantiateEnemy(0, 1);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 0);
        InstantiateEnemy(0, 3);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 0);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 2);
        InstantiateEnemy(1, 4);
        InstantiateEnemy(0, 0);
        yield return new WaitForSeconds(0.5f);

        //8
        InstantiateEnemy(0, 4);
        InstantiateEnemy(1, 3);
        InstantiateEnemy(0, 0);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 3);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 3);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 3);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 4);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 1);
        InstantiateEnemy(1, 4);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 1);
        yield return new WaitForSeconds(0.5f);

        //9
        InstantiateEnemy(0, 0);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 2);
        InstantiateEnemy(0, 0);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 0);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 4);
        InstantiateEnemy(0, 0);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 4);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 3);
        InstantiateEnemy(1, 2);
        InstantiateEnemy(0, 1);
        yield return new WaitForSeconds(0.5f);

        //10
        InstantiateEnemy(0, 2);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 2);
        InstantiateEnemy(0, 1);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 3);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 3);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 3);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 4);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 4);
        InstantiateEnemy(1, 0);
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 4);
        yield return new WaitForSeconds(10f);

        for (int j = 0; j < 20; j++)
        {
            for (int i = 0; i < spawners.Length; i++)
            {
                int r = Random.Range(0, enemies.Length);
                while(r == 2)
                    r = Random.Range(0, enemies.Length);
                InstantiateEnemy(r, i);
            }
            yield return new WaitForSeconds(0.5f + 1 / (j + 1));
        }//+100
        InstantiateEnemy(2, 2);//+1
        for (int j = 0; j < 20; j++)
        {
            for (int i = 0; i < spawners.Length; i++)
            {
                int r = Random.Range(0, enemies.Length);
                while (r == 2)
                    r = Random.Range(0, enemies.Length);
                InstantiateEnemy(r, i);
            }
            yield return new WaitForSeconds(0.5f + 1 / (j + 1));
        }//+100

    }
}
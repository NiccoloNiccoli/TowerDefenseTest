using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest1 : Level
{
    override protected IEnumerator SpawnCR()
    {
        yield return new WaitForSeconds(5);
        InstantiateEnemy(0, 2); //0
        yield return new WaitForSeconds(4);
        InstantiateEnemy(0, 2); //1
        yield return new WaitForSeconds(2);
        for (int i = 0; i < 3; i++)
        {
            InstantiateEnemy(0, 2); //4
            yield return new WaitForSeconds(0.5f);
        }
        InstantiateEnemy(0, 1); //5
        InstantiateEnemy(0, 3); //6
        yield return new WaitForSeconds(2);
        InstantiateEnemy(0, 0); //7
        InstantiateEnemy(0, 4); //8
        yield return new WaitForSeconds(2);
        InstantiateEnemy(1,2); //9
        yield return new WaitForSeconds(3);
        InstantiateEnemy(1, 3); //10
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 4); //11
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(0, 1); //12
        yield return new WaitForSeconds(0.3f);
        InstantiateEnemy(0, 2); //13
        yield return new WaitForSeconds(0.3f);
        InstantiateEnemy(0, 0); //14
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < spawners.Length; i++)
        {
            InstantiateEnemy(0, i); //19
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(2);
        for (int i = spawners.Length-1; i > 0; i--)
        {
            InstantiateEnemy(0, i); //24
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(2);
        InstantiateEnemy(1, 1); //25
        yield return new WaitForSeconds(0.5f);
        InstantiateEnemy(1, 0); //26
        yield return new WaitForSeconds(2);
        InstantiateEnemy(1, 2); //27
        for (int i = 1; i < 4; i++)
        {
            InstantiateEnemy(0, i); //30
        }
        
    }
}

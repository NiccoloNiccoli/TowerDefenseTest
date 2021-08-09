using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest2 : Level
{
    override protected IEnumerator SpawnCR()
    {
        for(int i = 0; i<4; i++)
        {
            InstantiateEnemy(0, 0);
            yield return new WaitForSeconds(1f);
            InstantiateEnemy(0, 4);
            yield return new WaitForSeconds(1f);
        }//7
        for (int i = 0; i < 2; i++)
        {
            InstantiateEnemy(1, 1+i);
            yield return new WaitForSeconds(1f);
            InstantiateEnemy(1, 3+i);
            yield return new WaitForSeconds(1f);
        }//11
        for(int i = 0; i < spawners.Length;i++)
        {
            InstantiateEnemy(0, i);
        }//16
        InstantiateEnemy(1, 0); //17
        yield return new WaitForSeconds(5);
        for (int i = 0; i < spawners.Length; i++)
        {
            InstantiateEnemy(1, i);
        }//22
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < spawners.Length; i++)
        {
            InstantiateEnemy(0, i);
        }//27
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < spawners.Length; i++)
        {
            InstantiateEnemy(0, i);
        }//32
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < spawners.Length; i++)
        {
            InstantiateEnemy(0, i);
        }//37
        yield return new WaitForSeconds(3f);
        InstantiateEnemy(0, 4); //38
        InstantiateEnemy(1, 1); // 39
        InstantiateEnemy(1, 2);//40
    }
}
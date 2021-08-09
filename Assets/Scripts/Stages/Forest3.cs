using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest3 : Level
{
    override protected IEnumerator SpawnCR()
    {
        InstantiateEnemy(1, 2); //0
        yield return new WaitForSeconds(10f);
        InstantiateEnemy(0, 4); //1
        yield return new WaitForSeconds(4f);
        for(int i = 0; i<3; i++)
        {
            InstantiateEnemy(0, 1);
            InstantiateEnemy(0, 3);
            yield return new WaitForSeconds(1f);
            InstantiateEnemy(1, 0);
            yield return new WaitForSeconds(1f);
        } //10
        for(int i = 0; i < 3; i++)
        {
            InstantiateEnemy(0, 2);
            yield return new WaitForSeconds(0.5f);
        }//13
        for (int i = 0; i < 3; i++)
        {
            InstantiateEnemy(0, 4);
            yield return new WaitForSeconds(0.5f);
        }//16
        for (int i = 0; i < 3; i++)
        {
            InstantiateEnemy(1, (i*2)%spawners.Length);
            yield return new WaitForSeconds(3f);
        }//19
        InstantiateEnemy(0, 1); //20
        InstantiateEnemy(0, 4); //21
        yield return new WaitForSeconds(1f);
        InstantiateEnemy(0, 0); //22
        InstantiateEnemy(0, 3); //23
        for(int i = 0; i < spawners.Length * 2; i++)
        {
            InstantiateEnemy(0, (i * 3) % spawners.Length);
            yield return new WaitForSeconds(0.5f);
        } //33
        for (int i = 0; i < spawners.Length; i++)
        {
            InstantiateEnemy(1, i);
            yield return new WaitForSeconds(2f);
        } //38
        for (int i = 0; i < spawners.Length; i++)
        {
            InstantiateEnemy(1, i);
        }//43
        yield return new WaitForSeconds(2.5f);
        for (int i = 0; i < spawners.Length; i++)
        {
            InstantiateEnemy(1, i);
        }//48
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < spawners.Length; i++)
        {
            InstantiateEnemy(1, i);
        }//53
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < spawners.Length; i++)
        {
            InstantiateEnemy(1, i);
        }//58
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < spawners.Length; i++)
        {
            InstantiateEnemy(1, i);
        }//63
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < spawners.Length; i++)
        {
            InstantiateEnemy(1, i);
        }//68
        yield return new WaitForSeconds(1f);
        InstantiateEnemy(0, 2); //69
        yield return new WaitForSeconds(10f);
        InstantiateEnemy(2, 2); //! 70 !
        for(int i = 0; i < spawners.Length; i++)
        {
            InstantiateEnemy(0, i);
        }//71
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < spawners.Length; i++)
        {
            InstantiateEnemy(0, i);
        }//76
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < spawners.Length; i++)
        {
            InstantiateEnemy(0, i);
        }//81
        yield return new WaitForSeconds(0.7f);
        for (int i = 0; i < spawners.Length; i++)
        {
            InstantiateEnemy(0, i);
        }//85
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < spawners.Length; i++)
        {
            InstantiateEnemy(0, i);
        }//90
        for (int i = 0; i < spawners.Length; i++)
        {
            if(i!= 2)
                InstantiateEnemy(1, i);
        }//94


    }
}

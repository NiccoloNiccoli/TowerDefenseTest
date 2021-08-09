using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level : MonoBehaviour
{
    [SerializeField] protected int maxEnemies;
    [SerializeField] protected GameObject[] enemies;
    [SerializeField] protected GameObject[] spawners = null;
    [SerializeField] protected int levelnumber;
    public int MaxEnemies { get => maxEnemies; set => maxEnemies = value; }
    public int Levelnumber { get => levelnumber; set => levelnumber = value; }

    abstract protected IEnumerator SpawnCR();
    public void Spawn()
    {
        StartCoroutine(SpawnCR());
    }

    public void StopSpawning()
    {
        StopCoroutine(SpawnCR());
    }

    protected void InstantiateEnemy(int index, int row)
    {
        int j = 0;
        GameObject e = Instantiate(enemies[index], spawners[row].transform.position + Vector3.forward, Quaternion.identity);
        while (j < spawners.Length && Mathf.FloorToInt(e.transform.position.y) != Mathf.FloorToInt(spawners[j].transform.position.y))
        {
            j++;
        }
        e.GetComponent<SpriteRenderer>().sortingOrder = j + 1;
    }
    
}

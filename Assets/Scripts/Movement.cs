using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //[SerializeField]
    //GameObject waypoint;
    [SerializeField]
    float moveSpeed = 1f;

    private Vector2 trgPoint;
    //int currentWaypointIndex = 0;

    //private Transform[] waypoints;
    private bool shouldRun = true;
    // Start is called before the first frame update
   // void Start()
    //{

        /* waypoints = new Transform[waypoint.transform.childCount];

         for (int i = 0; i < waypoint.transform.childCount; i++) {
             waypoints[i] = waypoint.transform.GetChild(i);
         }
         transform.position = waypoints[currentWaypointIndex].transform.position;*/
        /*GameObject target = GameObject.FindGameObjectWithTag("Target");
        trgPoint = new Vector2(target.transform.position.x, transform.position.y);*/

   // }

    // Update is called once per frame
  /*  void Update()
    {
        if(Mathf.Approximately(transform.position.x, trgPoint.x)){
            GetComponent<Enemy>().Attack();
        }
        else if(GetComponent<Enemy>().IsAlive()){
            Move();
        }
        
    }*/

   // private void Move() {
        /*if (GetComponent<Goblin>().IsAlive()) {
            if (currentWaypointIndex != waypoints.Length) {
                
                transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, moveSpeed * Time.deltaTime);

                if (transform.position == waypoints[currentWaypointIndex].transform.position)
                    currentWaypointIndex++;

            }
            else {
                
            }
        } */
       /* if (shouldRun) {
            GetComponent<Enemy>().Run();
            transform.position = Vector2.MoveTowards(transform.position, trgPoint, moveSpeed * Time.deltaTime);
        }
    }

    public void isAttacking(bool b) {
        shouldRun = !b;
    }*/
}

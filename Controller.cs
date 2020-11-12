using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    private NavMeshAgent meshAgent;
    private List<GameObject> alltarget = new List<GameObject>();
    private List<GameObject> TargetTypeslist = new List<GameObject>();
    private float distance;
    private int rand;
    private int TargetCount;
    private GameObject destination;
    private bool moveAgain = false;

    // Start is called before the first frame update
    void Start()
    {
        meshAgent = gameObject.GetComponent<NavMeshAgent>();
        PinkTarget();

    }
    void PinkTarget()
    {
        GameObject parentobject = GameObject.Find("Target");
        TargetCount = parentobject.transform.childCount;

        for (int i = 0; i < TargetCount; i++)
        {
            GameObject TargetType = parentobject.transform.GetChild(i).gameObject;
            TargetTypeslist.Add(TargetType);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (destination != null)
        {
            distance = Vector3.Distance(gameObject.transform.position, destination.transform.position);
        }

        if (distance < 5)
        {
            moveAgain = true;
        }

        if(moveAgain == true)
        { 
            rand = UnityEngine.Random.Range(0, TargetCount);
            destination = TargetTypeslist[rand];
            meshAgent.SetDestination(destination.transform.position);
            Debug.Log("Rand" + rand);
            moveAgain = false;
        }
    }
}

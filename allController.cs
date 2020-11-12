using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allController : MonoBehaviour
{
    private List<GameObject> SpawnLocationlist = new List<GameObject>();
    private List<GameObject> AgentTypeslist = new List<GameObject>();
    private int AgentTypesCount;
    public int AgentAllCount = 10;
    // Start is called before the first frame update
    void Start()
    {
        GetAgentType();
        GetSpawnLocation();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnAgents();
    }

    void GetAgentType()
    {
        GameObject parentobject = GameObject.Find("AgentTypes");
        AgentTypesCount = parentobject.transform.childCount;

        for (int i = 0; i < AgentTypesCount; i++)
        {
            GameObject AgentType = parentobject.transform.GetChild(i).gameObject;
            AgentTypeslist.Add(AgentType);
        }
    }
    void GetSpawnLocation()
    {
        GameObject parentobject = GameObject.Find("SpawnLocation");
        int SpawnLocationType = parentobject.transform.childCount;

        for (int i = 0; i< SpawnLocationType; i++)
        {
            GameObject SpawnLocation = parentobject.transform.GetChild(i).gameObject;
            SpawnLocationlist.Add(SpawnLocation);
        }
    }
    void SpawnAgents()
    {
        int i = Random.Range(0, AgentTypesCount);
        GameObject AgentSelected = AgentTypeslist[i];

        int m = Random.Range(0, AgentTypesCount);
        GameObject SpawnLocationSelected = SpawnLocationlist[m];

        if (AgentTypeslist.Count<= AgentAllCount)
        {
            GameObject AgenttoSpawn = Instantiate(AgentSelected, SpawnLocationSelected.transform.position, SpawnLocationSelected.transform.rotation);
            AgentTypeslist.Add(AgenttoSpawn);
        }
    }
}

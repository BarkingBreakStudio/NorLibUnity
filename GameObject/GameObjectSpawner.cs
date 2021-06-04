using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSpawner : MonoBehaviour
{

    public Transform MinimumPosition;
    public Transform MaximumPosition;

    private float counter;
    public float timeBetweenSpawn = 1f;

    public List<GameObject> objects2Spawn = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if(MinimumPosition && !MaximumPosition){
            MaximumPosition = MinimumPosition;
        }
        if (MaximumPosition && !MinimumPosition)
        {
            MinimumPosition = MaximumPosition;
        }


        SpawnRandomObject();
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if(counter >= timeBetweenSpawn)
        {
            counter -= timeBetweenSpawn;
            SpawnRandomObject();
        }
    }

    void SpawnRandomObject()
    {
        if (objects2Spawn.Count > 0)
        {
            Vector3 position = Vector3.Lerp(MinimumPosition.position, MaximumPosition.position, Random.value);
            GameObject gobj = objects2Spawn[Random.Range(0, objects2Spawn.Count)];
            Instantiate<GameObject>(gobj, position, MinimumPosition.rotation, transform);
        }
    }

    public void SpawnUpTo(int amount)
    {
        while(transform.childCount < amount)
        {
            SpawnRandomObject();
        }
    }
}

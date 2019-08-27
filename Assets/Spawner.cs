using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject projectile;
    public float minTime, maxTime;
    private float spawnTime;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = minTime;
        SetRandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventManager.instance.IsEventActivated(30))
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            //Counts up
            time += Time.deltaTime;

            //Check if its the right time to spawn the object
            if (time >= spawnTime)
            {
                SpawnObject();
                SetRandomTime();
            }
        }
    }
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

    void SpawnObject()
    {
        time = 0;
        Instantiate(projectile, transform.position, projectile.transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvManager : MonoBehaviour
{
    public GameObject[] envPrefabs;
    public float zSpawn;
    public float envLength;
    public int numberofEnvs;
    public Transform playerTransform;
    private List<GameObject> activeEnv = new List<GameObject>();
    private int envNumber;
    // Start is called before the first frame update
    void Start()
    {
        envLength = 1000;
        numberofEnvs = 2;
        zSpawn = 0;
        for (int i=0; i<numberofEnvs; i++){
            if(i==0){
                SpawnEnv(0);
            }
            else
            {
                SpawnEnv(Random.Range(0, envPrefabs.Length));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z -1000 > zSpawn-numberofEnvs * envLength){
            envNumber = Random.Range(0, envPrefabs.Length);
            SpawnEnv(envNumber);
            DeleteEnv();
        }
    }

    private void DeleteEnv(){
        Destroy(activeEnv[0]);
        activeEnv.RemoveAt(0);
    }

    public void SpawnEnv(int envIndex){
        GameObject go = Instantiate(envPrefabs[envIndex], transform.forward * zSpawn, transform.rotation);
        activeEnv.Add(go);
        zSpawn += envLength;
    }
}

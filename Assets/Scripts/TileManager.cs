using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn;
    public float tileLength;
    public int numberOfTiles;
    public Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();
    private int tileNumber;
    private int usedTileIndex;
    // Start is called before the first frame update
    void Start()
    {
        tileLength = 51;
        numberOfTiles = 9;
        zSpawn = 0;
        for (int i=0; i<numberOfTiles; i++){
            if(i==0){
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length-1));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z -53 > zSpawn-numberOfTiles * tileLength){
            tileNumber = Random.Range(0, tilePrefabs.Length);
            if(tileNumber == usedTileIndex){
                if(tileNumber > 0){
                    tileNumber = tileNumber - 1;
                }
                else{
                    tileNumber= tileNumber + 1;
                }
            }
            SpawnTile(tileNumber);
            DeleteTile();
        }
    }

    private void DeleteTile(){
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    public void SpawnTile(int tileIndex){
        usedTileIndex = tileIndex;
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }
}

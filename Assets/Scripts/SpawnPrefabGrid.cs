using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


/*
THINGS I WANT TO CHANGE / ADD
Spawn water in a more waterlike way
Water might make you slower
I want the game to be dimmed down so that the view distance is reduced to just around the player --- FIXED

i want the head of the player to turn towards an enemy before the enemy is visibla within the player light radious

Spawn Things in the yAxis to make obsticles randomly, ---Kinda done might wanna add to the hight abit

Add the Lightbulbman as player. ---
add monsters from blender maybe i dont knwo.

inception foldable world thing (Shader maybe)




-------------------ERRORS / PROBLEMS---------------------
look over movement script cube clips trough cube obsticles --- FIXED after 8 hours i figured out that i froze some axises in unity that i shouldnt freeze...............................
fix camera --- FIXED reason was that (Toggle tool handle position) was set to Center in unitym hours spent 5 
fix light over player---- FIXED when figureing out above problems


 */
public class SpawnPrefabGrid : MonoBehaviour
{

    //a array of prefabs to pick from when spawning the ground.
    public GameObject[] itemsToPickFrom;
    public int gridX;
    public int gridZ;
    public int gridY;
    //a offset that makes it so the blocks spawns next to eachother, not quite sure how this works (ReadUp)
    public float gridSpacingOffset = 1f;
    //gridOrigin will be the entrypoint of which its going to position the blocks relative to the entrypoint
    public Vector3 gridOrigin = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        SpawnGrid();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void SpawnGrid()
    {
       
        


        // looping out a groundbox at x and z as long as its less than the gridX and gridZ Size, of which the value is set in the unity editor
        for (int x = 0; x < gridX; x++)
        {

            for (int z = 0; z < gridZ; z++)
            {

                Vector3 spawnPosition = new Vector3(x * gridSpacingOffset, 0 * gridSpacingOffset, z * gridSpacingOffset) + gridOrigin;
                PickAndSpawn(spawnPosition, Quaternion.identity);

                //previous error was because i had the percent functioncall outside the forloop which set the percent to a set value and did not randomize the value

                if (Percentage() < 5)
                {
                        Vector3 SpawnYPosition = new Vector3(x, 1 * gridSpacingOffset,z) + gridOrigin;
                        PickAndSpawn(SpawnYPosition, Quaternion.identity);
                }
                
            }
        }

}
    // a random percentage generator
      public static int Percentage()
    {
        int randomPercentage = Random.Range(0, 100 +1);
        return randomPercentage;
        
    }


    //a function that picks random prefabs from the array (not used yet only one prefab)
    void PickAndSpawn(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        int randomIndex = Random.Range(0, itemsToPickFrom.Length);
        GameObject clone = Instantiate(itemsToPickFrom[randomIndex], positionToSpawn, rotationToSpawn);
    }
}

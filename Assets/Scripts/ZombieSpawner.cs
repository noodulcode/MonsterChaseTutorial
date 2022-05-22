using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] zombieReference;
    [SerializeField]
    private Transform leftPos, rightPos;
    private GameObject spawnedZombies;
    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnedZombies());
    }

    IEnumerator SpawnedZombies()
    {
        while (true) 
        {
            yield return new WaitForSeconds(Random.Range(1, 5)); // yield return waits for the timer before while loop restarts, will crash without

            randomIndex = Random.Range(0, zombieReference.Length); //give a random number between 0 and arrays length minus one randomizing enemies
            randomSide = Random.Range(0, 2);

            spawnedZombies = Instantiate(zombieReference[randomIndex]); // call a function that will create a copy of our monsters, either0, 1, or 2 foreach enemy

            // left side
            if (randomSide == 0) 
            {
            spawnedZombies.transform.position = leftPos.position;
            spawnedZombies.GetComponent<Zombies>().speed = Random.Range(4, 10);
            }
            // right side
            else 
            {
            spawnedZombies.transform.position = rightPos.position;
            spawnedZombies.GetComponent<Zombies>().speed = -Random.Range(4, 10);
            spawnedZombies.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }




} // class

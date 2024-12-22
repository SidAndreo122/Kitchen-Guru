using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] fruitsToSpawn;
    public Transform[] spawnPlaces;
    public float minWait = .3f;
    public float maxWait = 1f;
    public float minForce = 12;
    public float maxForce = 17;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }
    private IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

            GameObject go = null;
            float p = Random.Range(0, 100);
            if (p < 10)
            {
                go = fruitsToSpawn[0];
            }
            else
            {
                go = fruitsToSpawn[Random.Range(1, fruitsToSpawn.Length)];
            }

            GameObject item = Instantiate(go, t.position, t.rotation);

            item.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);

            Destroy(item, 5);
        }
    }
    
}

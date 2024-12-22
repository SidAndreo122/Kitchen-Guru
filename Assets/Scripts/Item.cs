using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject slicedItemPrefab;

    public void CreateSlicedItem()
    {
        GameObject inst = (GameObject)Instantiate(slicedItemPrefab, transform.position, transform.rotation);

        FindObjectOfType<GameManager>().PlayRandomCutSound();
        Rigidbody[] rbsOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody r in rbsOnSliced)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(500, 1000), transform.position, 5f);
        }
        FindObjectOfType<GameManager>().IncreaseScore(3);
        Destroy(inst.gameObject, 5);
        Destroy(gameObject);

    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();

        if (!b)
        {
            return;
        }
        CreateSlicedItem();
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class Cookbook : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();

        if (!b)
        {
            return;
        }

        FindObjectOfType<GameManager>().OnCookBookHit();
    }
    

    
    
}

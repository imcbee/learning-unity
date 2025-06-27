using System.Collections;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Projectile : MonoBehaviour
{
    // Goal:
    // check on trigger + enter for collison on layer mask
    // if yes, damage the thing if damageable then delete the object
    // there should be a life span for the projectile so they don't stay forever (co-routine)

    // Fields
    [SerializeField] private LayerMask damageableLayerMask; // Layer mask to check for damageable objects
    [SerializeField] private float lifespan = 5f; // Lifespan of the projectile in seconds

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(lifeSpan());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object is on the damageable layer
        if (((1 << collision.gameObject.layer) & damageableLayerMask) != 0)
        {
            // Attempt to get a Damageable component from the collided object
            //Damageable damageable = other.GetComponent<Damageable>();
            //if (damageable != null)
            //{
            //    // Apply damage to the damageable object
            //    damageable.TakeDamage(10); // Example damage value
            //}

            // Destroy the projectile after collision
            Destroy(gameObject);
        }
       
        
    }
    private IEnumerator lifeSpan()
    {
        //sr.sprite = sprites[1];
        yield return new WaitForSecondsRealtime(lifespan);
        Debug.Log("Projectile lifespan ended, destroying projectile.", gameObject);
        Destroy(gameObject);

        //sr.sprite = sprites[0];
    }
}

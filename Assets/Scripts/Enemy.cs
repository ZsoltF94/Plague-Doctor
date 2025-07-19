using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 10;


    PlayerCombat playerCombat;
    Rigidbody2D rb;
    void Awake()
    {
        playerCombat = FindAnyObjectByType<PlayerCombat>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    /* If time:
    * I have to pause EnemyAi Movement for a bit to apply PushBack
    
    public void ApplyPushBack(Vector2 direction, float force)
    {
        rb.AddForce(direction * force, ForceMode2D.Force);
    }
    */
    

}

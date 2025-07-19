using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float damageAmount = 0;

    void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void SetDamageAmount(float dmg)
    {
        damageAmount = dmg;
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {

            Vector2 pushDir = (collision.transform.position - player.position).normalized;
            Debug.Log(pushDir);
            collision.GetComponent<Enemy>()?.TakeDamage(damageAmount);
            //collision.GetComponent<Enemy>()?.ApplyPushBack(pushDir, 10f);
        }
    }
}

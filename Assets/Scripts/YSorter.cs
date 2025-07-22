using UnityEngine;

public class YSorter : MonoBehaviour
{
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    private CapsuleCollider2D cc;

    
    [SerializeField] private Transform player;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        cc = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Sort();
    }

    public void Sort()
    {
        if (bc != null)
        {
            Vector3 colliderWorldCenter = bc.transform.TransformPoint(bc.offset);

            if (player.position.y <= colliderWorldCenter.y)
            {
                sr.sortingOrder = -1;
            }
            else sr.sortingOrder = 1;
        }
        else
        {
            Vector3 colliderWorldCenter = cc.transform.TransformPoint(bc.offset);

            if (player.position.y <= colliderWorldCenter.y)
            {
                sr.sortingOrder = -1;
            }
            else sr.sortingOrder = 1; 
        }

    }
    
}

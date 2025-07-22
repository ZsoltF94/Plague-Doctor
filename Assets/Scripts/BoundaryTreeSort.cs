using UnityEngine;

public class BoundaryTreeSort : MonoBehaviour
{
    void Start()
    {
        BoundaryTree[] trees = GetComponentsInChildren<BoundaryTree>();

        foreach (BoundaryTree t in trees)
        {
            Collider2D col = t.GetComponent<Collider2D>();
            if (col != null)
            {
                float y = col.bounds.center.y;
                int order = Mathf.RoundToInt(y * -100);
                SpriteRenderer sr = t.GetComponent<SpriteRenderer>();
                if (sr != null) sr.sortingOrder = order;
            }     
        }
    }
}

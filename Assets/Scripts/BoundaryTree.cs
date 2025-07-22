using UnityEngine;

public class BoundaryTree : MonoBehaviour
{

    void Start()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y, 0f);

    }   
    void LateUpdate()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -100);
    }
}

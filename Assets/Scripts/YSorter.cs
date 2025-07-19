using UnityEngine;

public class YSorter : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private Transform player;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Sort();
    }

    public void Sort()
    {
        if (player.position.y <= transform.position.y)
        {
            sr.sortingOrder = -1;
        }
        else sr.sortingOrder = 1;
    }
    
}

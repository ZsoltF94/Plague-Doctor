using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteracter : MonoBehaviour
{
    [SerializeField] GameObject interactPanel;
    [SerializeField] GameObject interactSquare;
    [SerializeField] Vector2 boxSize = new Vector2(1.5f, 1.5f);

    [SerializeField] LayerMask interactableLayer;

    private Coroutine showRoutine;

    void Awake()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 center = transform.position;

            CheckInteractables(center);
        }

        CheckForInteractables();
    }


    void CheckInteractables(Vector3 position)
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(position, boxSize, 0f, interactableLayer);

        foreach (var hit in hits)
        {
            var interactable = hit.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
                break;
            }
        }
    }

    public void CheckForInteractables()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(interactSquare.transform.position, interactSquare.transform.localScale, 0f, interactableLayer);
        if (hits.Length > 0)
        {
            interactPanel.SetActive(true);
        }
        else interactPanel.SetActive(false);
    }


}

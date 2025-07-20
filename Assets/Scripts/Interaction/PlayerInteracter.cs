using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteracter : MonoBehaviour
{
    private IInteractable currentTarget;

    void Awake()
    {

    }


    void Update()
    {
        // check every frame for interactables
        CastRayToMouse();

        // if E was pressed
        if (Keyboard.current.eKey.wasPressedThisFrame && currentTarget != null)
        {
            Debug.Log("Key E pressed");
            currentTarget.Interact();
            currentTarget = null;
        }
    }


    // check if player in front of an interactable
    // if so, set that interactable to currentTarget
    public void CastRayToMouse()
    {

        // if mouse or camera not activ, return

        if (Mouse.current == null || Camera.current == null) return;


        // get mouse direction
        Vector3 mouseDir = (Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position).normalized;
        mouseDir.z = 0;

        // cast ray and 
        // only check object on Interactable layer
        int layerMask = LayerMask.GetMask("Interactable");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, mouseDir, 5f, layerMask);
        // Debug.DrawRay(transform.position, mouseDir * 5f, Color.red);



        // if ray hits an interactable, set that to currentTarget
        if (hit.collider != null)
        {
            IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>();
            currentTarget = interactable;

        }
        else currentTarget = null;

        if (currentTarget != null)
        {
            Debug.Log("target found");
        }
        else Debug.Log("nothing is here");
    }


}

using UnityEngine;

public class DirectionMan : MonoBehaviour, IInteractable
{

    [SerializeField] DialogData dialogData;

    void Update()
    {

    }

    public void Interact()
    {
        DialogManager.Instance.StartDialog(dialogData.GetLines());
    }
}

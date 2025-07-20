using UnityEngine;

public class Mentor : MonoBehaviour, IInteractable
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

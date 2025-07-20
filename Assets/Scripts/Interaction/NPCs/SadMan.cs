using UnityEngine;

public class SadMan : MonoBehaviour, IInteractable
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

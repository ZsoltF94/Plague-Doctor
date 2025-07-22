using System.Collections;
using UnityEngine;

public class King : MonoBehaviour, IInteractable
{

    [SerializeField] DialogData dialogData;
    [SerializeField] string targetScene;
    [SerializeField] GameObject dialogPanel;

    void Update()
    {

    }

    public void Interact()
    {
        DialogManager.Instance.StartDialog(dialogData.GetLines());
        StartCoroutine(WaitForDialogThenChangeScene());


    }

    private IEnumerator WaitForDialogThenChangeScene()
    {
        yield return new WaitUntil(() => !dialogPanel.activeInHierarchy);
        SceneTransitionManager.Instance.TransitionToScene(targetScene);
    }
    
    
}

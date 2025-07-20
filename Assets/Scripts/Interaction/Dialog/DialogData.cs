using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog", menuName = "Dialog/DialogData")]

public class DialogData : ScriptableObject
{
    [SerializeField] string[] dialog;

    public string[] GetLines()
    {
        return dialog;
    }
}

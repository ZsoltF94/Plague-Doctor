
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    [Header("UI References")]
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TMP_Text dialogText;
    [SerializeField] PlayerMovement player;


    
    private Queue<string> dialogLines = new Queue<string>(); // for dialog lines
    private bool isDialogActive = false;


    void Awake()
    {
        // singleton
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        // set dialogPanel off at the beginning
        dialogPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDialogActive && Input.GetKeyUp(KeyCode.Space))
        {
            ShowNextLine();
        }

    }

    public void StartDialog(string[] lines)
    {
        // clear queue
        dialogLines.Clear();

        // add given lines to queue
        foreach (string line in lines)
        {
            dialogLines.Enqueue(line);
        }

        dialogPanel.SetActive(true);
        isDialogActive = true;
        player.canMove = false;
        ShowNextLine();
    }

    private void ShowNextLine()
    {
        // is there is no more dialog
        if (dialogLines.Count == 0)
        {
            EndDialog();
            return;
        }

        string nextLine = dialogLines.Dequeue(); // take first line from queue
        dialogText.text = nextLine;
    }

    private void EndDialog()
    {
        // turn off panel
        isDialogActive = false;
        player.canMove = true;
        dialogPanel.SetActive(false);
    }
}

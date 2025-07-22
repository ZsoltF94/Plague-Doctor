using TMPro;
using UnityEngine;

public class Sea : MonoBehaviour, IInteractable
{
    [SerializeField] TextMeshProUGUI blutegelText;
    [SerializeField] PlayerHealth playerHealth;

    [SerializeField] int blutegelCountSea;
    void Start()
    {
        blutegelCountSea = 5;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact()
    {
        if (blutegelCountSea > 0)
        {
            blutegelCountSea--;
            playerHealth.AddBlutegel();
             
        }
       
    }
}

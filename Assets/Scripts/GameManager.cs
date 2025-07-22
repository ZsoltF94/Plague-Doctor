using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        InitGame();

    }

    public void InitGame()
    {
        GameState.savedInfection = 0f;
        GameState.savedHealth = 500f;
        GameState.spawnPosition = Vector3.zero;
    }
}

using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform player;

    void Start()
    {
        // set player position
        player.position = GameState.spawnPosition;

        // load saved stats
        PlayerHealth ph = player.GetComponent<PlayerHealth>();

        if (ph != null)
        {
            ph.SetValues(GameState.savedHealth, GameState.savedInfection);
        }
    }
}

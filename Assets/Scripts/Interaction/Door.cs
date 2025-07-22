using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] string targetScene;    // name of scene
    [SerializeField] Vector3 newSpawnPosition;

    public void Interact()
    {
        // Get Player Reference
        PlayerHealth player = GameObject.FindGameObjectWithTag("Player")?.GetComponent<PlayerHealth>();

        if (player == null) return; // dont interact if found no player

        GameState.savedHealth = player.GetCurrentHealth();
        GameState.savedInfection = player.GetCurrentInfection();
        GameState.savedBlutegel = player.GetCurrentBlutegel();
        GameState.spawnPosition = newSpawnPosition;

        // load new scene
        SceneTransitionManager.Instance.TransitionToScene(targetScene);
    }
}

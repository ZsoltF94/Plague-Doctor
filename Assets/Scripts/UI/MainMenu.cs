using UnityEngine;


public class MainMenu : MonoBehaviour
{
    [SerializeField] string targetScene;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {

        SceneTransitionManager.Instance.TransitionToScene(targetScene);
    }

    public void EndGame()
    {
        #if !UNITY_WEBGL
            Application.Quit();
        #endif

    }
}

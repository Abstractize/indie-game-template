using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public void Action() => Debug.Log("Action");
    public void LoadScene(int sceneIndex)
        => SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
}



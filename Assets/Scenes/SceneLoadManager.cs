using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField]
    Scenes scene = Scenes.GROUPS;
    public void LoadScene()
        => SceneManager.LoadScene((int)scene, LoadSceneMode.Single);
}

public enum Scenes
{
    STORY = 0,
    LOGIN = 1,
    GROUPS = 2,
    ROOM_INFO = 3,
    DANCE = 4,
}



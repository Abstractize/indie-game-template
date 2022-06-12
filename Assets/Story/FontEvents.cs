using System;
using UnityEngine;

public class FontEvents : MonoBehaviour
{
    [SerializeField] SceneLoadManager SceneLoader;
    public void LoadScene() => SceneLoader.LoadScene();
}


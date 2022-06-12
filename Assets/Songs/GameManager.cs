using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    [Header("Constants")]
    [SerializeField]
    int MaxFailures;

    public PlayerDanceController Player { get; set; }
    public int Failures { get; set; } = 0;
    public List<GameObject> Notes { get; set; } = new List<GameObject>();

    void Awake()
    {
        Instance = this;
    }

    void FixedUpdate()
    {
        if (Failures > MaxFailures)
            Player.OnLose();
    }

    public void NoteGenerated(GameObject newNote)
        => Notes.Add(newNote);

}

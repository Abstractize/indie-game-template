using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class NoteDisplayer : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField]
    TextMeshProUGUI FailureCounter;
    [Header("Render Prefabs")]
    [SerializeField]
    private GameObject Base;

    [Header("Constants")]
    [SerializeField]
    int MaxFailures;
    [Header("End Actions")]
    [SerializeField]
    UnityEvent LoseFunction;


    public List<GameObject> Notes { get; set; } = new List<GameObject>();
    public int Failures { get; set; } = 0;

    void Update()
    {
        if (FailureCounter != null)
            FailureCounter.text = $"Failures: {this.Failures}";
    }

    void FixedUpdate()
    {
        if (Failures > MaxFailures)
            LoseFunction.Invoke();

    }

    public void Tick(SongNote newNote)
    {
        float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        var temp = Instantiate(Base, spawnPosition, Quaternion.identity);
        Notes.Add(temp);
        temp.GetComponent<Note>().Initiate(newNote, this);
    }
}

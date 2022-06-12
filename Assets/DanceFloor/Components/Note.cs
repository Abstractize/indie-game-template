using System;
using UnityEngine;

public class Note : MonoBehaviour
{
    private bool Active = false;
    public SongNote NoteValue { get; set; }
    public Boolean Pressed { get; set; } = false;

    public void Initiate(SongNote newNote)
    {
        NoteValue = newNote;

        if (NoteValue.ToVector2() == Vector2.zero)
            Destroy(this.gameObject);

        Destroy(this.gameObject, 2f);
    }

    void OnDestroy()
    {
        if (!Pressed)
            ++GameManager.Instance.Failures;
        GameManager.Instance.Notes.Remove(this.gameObject);
    }
}

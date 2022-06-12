using System;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer Background;
    [SerializeField]
    SpriteRenderer Up;
    [SerializeField]
    SpriteRenderer Down;
    [SerializeField]
    SpriteRenderer Left;
    [SerializeField]
    SpriteRenderer Right;
    [SerializeField]
    public NoteDisplayer Displayer { get; set; }

    private bool Active = false;
    public SongNote NoteValue { get; set; }
    public Boolean Pressed { get; set; } = false;

    public void Initiate(SongNote newNote, NoteDisplayer noteDisplayer)
    {
        Displayer = noteDisplayer;
        NoteValue = newNote;
        Background.color = UnityEngine.Random.ColorHSV();
        if (newNote.Up != NoteType.NONE)
        {
            Up.gameObject.SetActive(true);
            Active = true;
        }

        if (newNote.Down != NoteType.NONE)
        {
            Down.gameObject.SetActive(true);
            Active = true;
        }

        if (newNote.Left != NoteType.NONE)
        {
            Left.gameObject.SetActive(true);
            Active = true;
        }

        if (newNote.Right != NoteType.NONE)
        {
            Right.gameObject.SetActive(true);
            Active = true;
        }

        if (!Active)
            Destroy(this.gameObject);

        Destroy(this.gameObject, 2f);
    }

    void OnDestroy()
    {
        if (!Pressed)
            ++this.Displayer.Failures;
        this.Displayer.Notes.Remove(this.gameObject);
    }
}

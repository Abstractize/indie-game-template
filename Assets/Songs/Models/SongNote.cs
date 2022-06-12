using UnityEngine;

[System.Serializable]
public class SongNote
{
    public NoteType Up;
    public NoteType Down;
    public NoteType Left;
    public NoteType Right;
    public static SongNote Empty
        => new SongNote
        {
            Up = NoteType.NONE,
            Down = NoteType.NONE,
            Left = NoteType.NONE,
            Right = NoteType.NONE,
        };

    internal Vector2 ToVector2()
    {
        int x = 0;
        int y = 0;

        if (Up != NoteType.NONE)
            y += 1;
        if (Down != NoteType.NONE)
            y -= 1;
        if (Left != NoteType.NONE)
            x -= 1;
        if (Right != NoteType.NONE)
            x += 1;

        return new Vector2(x, y);
    }

    public static SongNote RandomNote
        => new SongNote
        {
            Up = (NoteType)UnityEngine.Random.Range(0, 2),
            Down = (NoteType)UnityEngine.Random.Range(0, 2),
            Left = (NoteType)UnityEngine.Random.Range(0, 2),
            Right = (NoteType)UnityEngine.Random.Range(0, 2),
        };
}

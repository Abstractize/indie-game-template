using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoteDisplayer : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField]
    TextMeshProUGUI FailureCounter;
    [Header("Render Prefabs")]
    [SerializeField]
    private Sprite Up;
    [SerializeField]
    private Sprite Down;
    [SerializeField]
    private Sprite Left;
    [SerializeField]
    private Sprite Right;
    [SerializeField]
    private Sprite UpLeft;
    [SerializeField]
    private Sprite DownLeft;
    [SerializeField]
    private Sprite UpRight;
    [SerializeField]
    private Sprite DownRight;
    [Header("Spawn Point")]

    [SerializeField]
    RectTransform SpawnPoint;
    [SerializeField]
    Canvas Canvas;
    [SerializeField]
    GameObject Prefab;

    void Update()
    {
        if (FailureCounter != null)
            FailureCounter.text = $"Failures: {GameManager.Instance.Failures}";
    }


    public void Tick(SongNote newNote)
    {
        var go = Instantiate(Prefab, SpawnPoint.position, Quaternion.identity);
        var image = go.GetComponent<Image>();

        Vector2 noteValue = newNote.ToVector2();

        if (noteValue == new Vector2(0, 1))
            image.sprite = Up;
        else if (noteValue == new Vector2(0, -1))
            image.sprite = Down;
        else if (noteValue == new Vector2(-1, 0))
            image.sprite = Left;
        else if (noteValue == new Vector2(1, 0))
            image.sprite = Right;
        else if (noteValue == new Vector2(1, 1))
            image.sprite = UpRight;
        else if (noteValue == new Vector2(1, -1))
            image.sprite = DownRight;
        else if (noteValue == new Vector2(-1, 1))
            image.sprite = UpLeft;
        else if (noteValue == new Vector2(-1, -1))
            image.sprite = DownLeft;

        go.transform.SetParent(SpawnPoint);

        go.GetComponent<Note>().Initiate(newNote);
    }
}

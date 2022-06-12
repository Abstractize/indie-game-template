using TMPro;
using UnityEngine;


public class NoteDisplayer : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField]
    TextMeshProUGUI FailureCounter;
    [Header("Render Prefabs")]
    [SerializeField]
    private GameObject Base;

    void Update()
    {
        if (FailureCounter != null)
            FailureCounter.text = $"Failures: {GameManager.Instance.Failures}";
    }


    public void Tick(SongNote newNote)
    {
        float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        var temp = Instantiate(Base, spawnPosition, Quaternion.identity);
        GameManager.Instance.NoteGenerated(temp);
        temp.GetComponent<Note>().Initiate(newNote);
    }
}

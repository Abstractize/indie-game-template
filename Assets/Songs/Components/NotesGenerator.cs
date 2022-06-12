using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioProcessor))]
public class NotesGenerator : MonoBehaviour
{
    [Header("Sound Data")]
    [SerializeField]
    private TextAsset File;
    [SerializeField]
    private AudioSource MusicSource;
    [SerializeField]
    private AudioProcessor AudioProcessor;
    [Header("Note Action")]
    [SerializeField]
    private UnityEvent<SongNote> TickEvent;

    private SongData Data;

    void Awake()
    {
        if (MusicSource == null)
            MusicSource = GetComponent<AudioSource>();
        if (AudioProcessor == null)
            AudioProcessor = GetComponent<AudioProcessor>();

        AudioProcessor.onBeat.AddListener(OnBeatDetected);
        Data = JsonUtility.FromJson<SongData>(File.text);
    }

    void OnBeatDetected()
    {
        var number = UnityEngine.Random.Range(0, 10);
        if (number == 0)
            TickEvent.Invoke(SongNote.RandomNote);
    }
}

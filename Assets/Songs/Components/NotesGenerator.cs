using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioProcessor))]
public class NotesGenerator : MonoBehaviour
{
    [Header("Clips")]
    [SerializeField]
    Clip[] Clips;
    [Header("Sound Data")]
    [SerializeField]
    private AudioSource MusicSource;
    [SerializeField]
    private AudioProcessor AudioProcessor;
    [Header("Note Action")]
    [SerializeField]
    private UnityEvent<SongNote> TickEvent;

    private Queue<SongNote> Data;

    void Awake()
    {
        if (MusicSource == null)
            MusicSource = GetComponent<AudioSource>();
        if (AudioProcessor == null)
            AudioProcessor = GetComponent<AudioProcessor>();

        AudioProcessor.onBeat.AddListener(OnBeatDetected);

        Clip clip = Clips[UnityEngine.Random.Range(0, Clips.Length)];

        MusicSource.clip = clip.AudioClip;

        SongData json = JsonUtility.FromJson<SongData>(clip.DataFile.text);
        Data = new Queue<SongNote>(json.Notes);

        MusicSource.Play();
    }

    void OnBeatDetected()
    {
        var number = UnityEngine.Random.Range(0, 10);
        if (Data.Count <= 0)
            if (!(number == 0))
                return;
            else
                TickEvent.Invoke(SongNote.RandomNote);
        else
            TickEvent.Invoke(Data.Dequeue());
    }
}

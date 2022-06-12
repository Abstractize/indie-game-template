using System.Diagnostics;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class GameTimer : MonoBehaviour
{
    [Header("Time Settings")]
    [SerializeField]
    AudioSource MusicSource;
    [SerializeField]
    [Range(1, 59)]
    private int IntervalDisplay = 15;
    [SerializeField]
    [Range(1, 12)]
    private int StartHour = 5;
    [SerializeField]
    [Range(1, 12)]
    private int UserTimerDuration = 12;
    [Header("GUI Settings")]
    [SerializeField]
    TextMeshProUGUI Text;
    [Header("Stop Action")]
    [SerializeField]
    private UnityEvent TimerReadyAction;

    private Stopwatch Timer = new Stopwatch();
    private TimeSpan ClipDuration;
    private TimeSpan RemainingTime;

    void Awake()
    {
        if (MusicSource == null)
            MusicSource = GetComponent<AudioSource>();
        ClipDuration = TimeSpan.FromSeconds(MusicSource.clip.length);
        RemainingTime = ClipDuration;
    }

    void Start()
        => Timer.Start();

    void Update()
    {
        TimeSpan actualTime = (Timer.Elapsed * (new TimeSpan(0, UserTimerDuration, 0) / ClipDuration)) + new TimeSpan(0, StartHour, 0);
        if (actualTime.Seconds % IntervalDisplay == 0)
            if (Text != null)
                Text.text = (actualTime).ToString(@"mm\:ss");
    }


    void FixedUpdate()
    {
        if (Timer.Elapsed >= RemainingTime)
        {
            Timer.Stop();
            if (TimerReadyAction != null)
                TimerReadyAction.Invoke();
        }
    }
}

using System.Diagnostics;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameTimer : MonoBehaviour
{
    [Header("Time Settings")]
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
    TextMeshProUGUI text;
    [Header("Realtime")]
    [SerializeField]
    [Range(1, 5)]
    private int RealTimeMinutes = 1;
    [SerializeField]
    [Range(0, 59)]
    private int RealTimeSeconds = 0;
    [Header("Stop Action")]
    [SerializeField]
    private UnityEvent TimerReadyAction;

    private Stopwatch timer = new Stopwatch();
    private TimeSpan remainingTime;

    void Awake()
        => remainingTime = new TimeSpan(0, RealTimeMinutes, RealTimeSeconds);

    void Start()
        => timer.Start();

    void Update()
    {
        TimeSpan actualTime = (timer.Elapsed * (UserTimerDuration / RealTimeMinutes)) + new TimeSpan(0, StartHour, 0);
        if (actualTime.Seconds % IntervalDisplay == 0)
            text.text = (actualTime).ToString(@"mm\:ss");
    }


    void FixedUpdate()
    {
        if (timer.Elapsed >= remainingTime)
        {
            timer.Stop();
            TimerReadyAction.Invoke();
        }
    }
}

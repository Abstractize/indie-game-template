using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Photon.Pun;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    [Header("Constants")]
    [SerializeField]
    int MaxFailures;
    [Header("Actions")]
    [SerializeField]
    private UnityEvent NextScene;

    public PlayerDanceController Player { get; set; }
    public int Failures { get; set; } = 0;
    public GameObject Note { get; set; }

    public PlayerDanceController[] Players { get; set; } = new PlayerDanceController[4];

    public void Die(PlayerDanceController player)
        => Players[player.ActorNumber] = null;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (Failures > MaxFailures)
            Player.OnLose();
    }
    public void End(bool keepGoing = false)
    {
        List<PlayerDanceController> PlayersAlive = Players.Where(value => value != null).ToList();

        if (PlayersAlive.Count <= 1)
        {
            PhotonNetwork.AutomaticallySyncScene = false;
            if (PlayersAlive[0]?.ActorNumber == PhotonNetwork.LocalPlayer.ActorNumber)
                PhotonNetwork.LoadLevel((int)Scenes.WIN);
            else
                PhotonNetwork.LoadLevel((int)Scenes.LOSE);
        }
        else if (keepGoing)
            return;
        else
            NextScene.Invoke();
    }
    public void NoteGenerated(GameObject newNote)
        => Note = newNote;

}

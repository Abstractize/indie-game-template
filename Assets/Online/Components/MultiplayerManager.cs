using UnityEngine;
using System;
using Photon.Pun;

public class MultiplayerManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    SceneLoadManager SceneLoader = null;

    public static MultiplayerManager Instance { get; private set; }
    public String Username { get; set; } = String.Empty;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Instance.SceneLoader = this.SceneLoader;
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }
    }

    public void Login()
        => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster()
        => PhotonNetwork.JoinLobby();

    public override void OnJoinedLobby()
        => SceneLoader.LoadScene();
}

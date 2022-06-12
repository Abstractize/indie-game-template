using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RoomInfo : MonoBehaviour
{
    public String Roomname { get; set; } = String.Empty;
    private Room CurrentRoom;

    void Awake()
    {
        CurrentRoom = PhotonNetwork.CurrentRoom;
    }
    public void StartGame()
        => PhotonNetwork.LoadLevel((int)Scenes.DANCE);
}

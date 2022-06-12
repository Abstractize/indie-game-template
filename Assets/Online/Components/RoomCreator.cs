using System;
using Photon.Pun;
using UnityEngine;

public class RoomCreator : MonoBehaviourPunCallbacks
{
    public String Roomname { get; set; } = String.Empty;
    public void CreateRoom()
        => PhotonNetwork.CreateRoom(Roomname);

    public void JoinRoom()
        => PhotonNetwork.JoinRoom(Roomname);

    public override void OnJoinedRoom()
        => PhotonNetwork.LoadLevel((int)Scenes.DANCE);
}

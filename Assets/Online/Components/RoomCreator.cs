using System.Diagnostics;
using System;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;

public class RoomCreator : MonoBehaviourPunCallbacks
{
    public String Roomname { get; set; } = String.Empty;
    public void JoinOrCreateRoom()
        => PhotonNetwork.JoinOrCreateRoom(Roomname, new RoomOptions { MaxPlayers = 4 }, TypedLobby.Default);

    public override void OnRoomListUpdate(List<Photon.Realtime.RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
    }

    public override void OnJoinedRoom()
        => PhotonNetwork.LoadLevel((int)Scenes.ROOM_INFO);
}

using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviourPunCallbacks
{
    [SerializeField] ScrollRect ScrollView;
    [SerializeField] GameObject[] Rooms;

    public override void OnRoomListUpdate(List<Photon.Realtime.RoomInfo> roomList)
    {
        for (int i = 0; i < ScrollView.content.childCount; i++)
        {
            Photon.Realtime.RoomInfo info = roomList[i];
            var temp = ScrollView.content.GetChild(i).gameObject;
            if (info == null)
                temp.SetActive(false);
            else
            {
                temp.SetActive(true);
                temp.GetComponent<RoomData>().Initialize(info);
            }
        }
    }
}

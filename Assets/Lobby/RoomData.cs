using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomData : MonoBehaviour
{
    public string RoomName { get; set; }
    [SerializeField] TextMeshProUGUI RoomNameAsset;
    [SerializeField] TextMeshProUGUI RoomPlayerCount;
    [SerializeField] TextMeshProUGUI MaxPlayerQuantity;
    [SerializeField] TextMeshProUGUI RoomOpen;

    public void JoinRoom()
        => PhotonNetwork.JoinRoom(RoomName);

    public void Initialize(Photon.Realtime.RoomInfo roomInfo)
    {
        RoomName = roomInfo.Name;
        RoomNameAsset.text = "Room: " + roomInfo.Name;
        RoomPlayerCount.text = "Players: " + roomInfo.PlayerCount.ToString();
        MaxPlayerQuantity.text = "Max Players: " + (4).ToString();
        RoomOpen.text = roomInfo.IsOpen ? "Open" : "Closed";
    }
}

using System.Linq;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    [Header("Positions")]
    [SerializeField] Transform[] Positions;

    // Start is called before the first frame update
    void Start()
    {

        GameObject player = PhotonNetwork
            .Instantiate(playerPrefab.name, Positions[PhotonNetwork.LocalPlayer.ActorNumber].position, Quaternion.identity);
        GameManager.Instance.Player = player.GetComponent<PlayerDanceController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

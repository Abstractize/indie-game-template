using UnityEngine;
using Photon.Pun;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public partial class PlayerDanceController : MonoBehaviour
{
    [SerializeField]
    Animator Animations;
    [SerializeField]
    PhotonView View;
    [SerializeField]
    PlayerInput inputs;
    [SerializeField]
    TextMesh UsernameDisplay;

    public int ActorNumber { get; private set; }

    public Vector2 movement { get; set; } = Vector2.zero;
    private void Awake()
    {
        if (Animations == null)
            GetComponent<Animator>();
        if (View == null)
            GetComponent<PhotonView>();

        if (!View.IsMine)
            Destroy(inputs);

        Animations.SetFloat("X", 0);
        Animations.SetFloat("Y", 0);

        ActorNumber = View.Owner.ActorNumber;
        GameManager.Instance.Players[ActorNumber] = this;
        UsernameDisplay.text = View.Owner.NickName;
    }

    void LateUpdate()
    {
        Animations.SetFloat("X", movement.x);
        Animations.SetFloat("Y", movement.y);
    }

    public void OnLose()
    {
        Animations.SetTrigger("Lose");
        View.RPC("DeathRival", RpcTarget.All, this.ActorNumber);
    }

    public void OnWin()
    {
        Animations.SetTrigger("Win");
    }

    [PunRPC]
    void DeathRival(int actorNumber)
    {
        GameManager.Instance.Die(actorNumber);
        GameManager.Instance.End();
    }
}
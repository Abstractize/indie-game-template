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

    public Vector2 Movement { get; set; } = Vector2.zero;
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

        UsernameDisplay.text = View.Owner.NickName;
    }

    void LateUpdate()
    {
        Animations.SetFloat("X", Movement.x);
        Animations.SetFloat("Y", Movement.y);
    }

    public void OnLose() => Animations.SetTrigger("Lose");
}
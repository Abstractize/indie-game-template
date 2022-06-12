using UnityEngine;

[RequireComponent(typeof(Animator))]
public partial class PlayerDanceController : MonoBehaviour
{
    [SerializeField]
    NoteDisplayer Displayer;
    [SerializeField]
    Animator Animations;

    public Vector2 Movement { get; set; } = Vector2.zero;
    private void Awake()
    {
        if (Displayer == null)
            FindObjectOfType<NoteDisplayer>();
        if (Animations == null)
            GetComponent<Animator>();

        Animations.SetFloat("X", 0);
        Animations.SetFloat("Y", 0);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        Animations.SetFloat("X", Movement.x);
        Animations.SetFloat("Y", Movement.y);
    }

    public void OnLose() => Animations.SetTrigger("Lose");
}
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public partial class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Rigidbody2D rigidbody2d;


    void Awake()
    {
        if (rigidbody2d == null)
            this.rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {

    }

    void OnReset()
    {

    }

    void OnValidate()
    {

    }

    void Start()
    {

    }

    void OnApplicationPause()
    {

    }

    void FixedUpdate()
    {
        rigidbody2d.velocity = moveInput * (float)speed;
    }

    void Update()
    {

    }

    void LateUpdate()
    {

    }

    void OnApplicationQuit()
    {

    }

    void OnDisable()
    {

    }

}

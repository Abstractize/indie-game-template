using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerDanceController : MonoBehaviour
{
    [SerializeField]
    NoteDisplayer Displayer;
    private void Awake()
    {
        if (Displayer == null)
            FindObjectOfType<NoteDisplayer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

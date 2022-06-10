using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public partial class PlayerController : MonoBehaviour, IPlayerActions
{
    private Vector2 moveInput;

    public void OnMove(InputValue context)
        => moveInput = context.Get<Vector2>();

}

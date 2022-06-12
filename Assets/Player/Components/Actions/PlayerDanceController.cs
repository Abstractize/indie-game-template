using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerDanceController : MonoBehaviour, IPlayerDanceActions
{
    public void OnDance(InputValue context)
    {
        if (View.IsMine)
        {
            Movement = context.Get<Vector2>();
            Movement.Normalize();

            GameObject value = GameManager.Instance.Note;

            UnityEngine.Debug.Log(value);

            if (value == null)
                return;
            else if (value.GetComponent<Note>().NoteValue
                .ToVector2() == Movement)
            {
                value.GetComponent<Note>().Pressed = true;
                Destroy(value);
            }

        }
    }
}

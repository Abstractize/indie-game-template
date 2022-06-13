using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerDanceController : MonoBehaviour, IPlayerDanceActions
{
    public void OnDance(InputValue context)
    {
        if (View.IsMine)
        {
            GameManager.Instance.CanvasAnimator.SetTrigger("Press");

            movement = context.Get<Vector2>();
            movement.Normalize();

            GameObject value = GameManager.Instance.Note;

            if (value == null)
                return;

            Vector2 noteVector = value.GetComponent<Note>().NoteValue
                .ToVector2();
            noteVector.Normalize();
            if (noteVector == movement)
            {
                value.GetComponent<Note>().Pressed = true;
                Destroy(value);
            }

        }
    }
}

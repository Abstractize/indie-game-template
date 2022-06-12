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

            GameObject value = GameManager.Instance.Notes
                .Where(item => item.GetComponent<Note>()
                .NoteValue.ToVector2() == Movement).FirstOrDefault();

            UnityEngine.Debug.Log(value);

            if (value == null)
                return;

            value.GetComponent<Note>().Pressed = true;

            GameManager.Instance.Notes.Remove(value);
            Destroy(value);
        }
    }
}

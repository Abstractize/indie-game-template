using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerDanceController : MonoBehaviour, IPlayerDanceActions
{
    public void OnDance(InputValue context)
    {
        Movement = context.Get<Vector2>();
        Movement.Normalize();

        GameObject value = Displayer.Notes
            .Where(item => item.GetComponent<Note>()
            .NoteValue.ToVector2() == Movement).FirstOrDefault();

        if (value == null)
            return;

        value.GetComponent<Note>().Pressed = true;

        Displayer.Notes.Remove(value);
        Destroy(value);
    }
}

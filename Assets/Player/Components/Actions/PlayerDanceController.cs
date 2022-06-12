using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerDanceController : MonoBehaviour, IPlayerDanceActions
{
    public void OnDance(InputValue context)
    {
        Vector2 input = context.Get<Vector2>();
        input.Normalize();

        GameObject value = Displayer.Notes
            .Where(item => item.GetComponent<Note>()
            .NoteValue.ToVector2() == input).FirstOrDefault();

        if (value == null)
            return;

        value.GetComponent<Note>().Pressed = true;

        Displayer.Notes.Remove(value);
        Destroy(value);
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "Clip", menuName = "Audio/Clip")]
public class Clip : ScriptableObject
{
    public AudioClip AudioClip;
    public TextAsset DataFile;
}
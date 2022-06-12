using System.Collections.Generic;

[System.Serializable]
public class SongData
{
    public List<SongNote> Notes;
    public byte SignatureHi;
    public byte SignatureLo;
}

using System;

[Serializable]
public class ScoreFix
{
    public string name;
    public float score;

    public ScoreFix(string name, float score)
    {
        this.name = name;
        this.score = score;
    }
}

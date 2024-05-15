using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public static ScoreUI instance;

    public RowUI rowUI;
    public ScoreManager scoreManager;
    void Start()
    {
        scoreManager.AddScore(new ScoreFix("void", 0));

        var scores = scoreManager.GetHightScore().ToArray();
        for(int i = 0; i < scores.Length; i++)
        {
            if (i > 6)
                break;
            var row = Instantiate(rowUI,transform).GetComponent<RowUI>();
            row.NumText.text= (i+1).ToString();
            row.NameText.text= scores[i].name;
            row.ScoreText.text = scores[i].score.ToString();
        }
    }
}

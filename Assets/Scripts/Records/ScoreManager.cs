using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private ScroreData _scoreData;

    private void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        _scoreData = JsonUtility.FromJson<ScroreData>(json);
    }

    public IEnumerable<ScoreFix> GetHightScore()
    {
        return _scoreData.scores.OrderByDescending(x => x.score);
    }
    public void AddScore(ScoreFix score)
    {
        _scoreData.scores.Add(score);
    }

    private void OnDestroy()
    {
        SaveBaseScores();
    }
    public void SaveBaseScores()
    {
        var json = JsonUtility.ToJson(_scoreData);
        PlayerPrefs.SetString("scores", json);
    }
}

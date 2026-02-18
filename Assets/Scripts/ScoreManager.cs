using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text leftScoreText;
    public Text rightScoreText;
    
    void Start()
    {
        UpdateLeftScore(0);
        UpdateRightScore(0);
    }
    
    public void UpdateLeftScore(int score)
    {
        if (leftScoreText != null)
            leftScoreText.text = score.ToString();
    }
    
    public void UpdateRightScore(int score)
    {
        if (rightScoreText != null)
            rightScoreText.text = score.ToString();
    }
}

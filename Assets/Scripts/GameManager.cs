using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int leftScore = 0;
    public int rightScore = 0;
    public int maxScore = 5;
    
    public ScoreManager scoreManager;
    
    public void ScoreLeft()
    {
        leftScore++;
        scoreManager.UpdateLeftScore(leftScore);
        CheckWinner();
    }
    
    public void ScoreRight()
    {
        rightScore++;
        scoreManager.UpdateRightScore(rightScore);
        CheckWinner();
    }
    
    void CheckWinner()
    {
        if (leftScore >= maxScore)
        {
            Debug.Log("Left Player Wins!");
            EndGame();
        }
        else if (rightScore >= maxScore)
        {
            Debug.Log("Right Player Wins!");
            EndGame();
        }
    }
    
    void EndGame()
    {
        Time.timeScale = 0f;
        Debug.Log("Press R to restart");
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
    
    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

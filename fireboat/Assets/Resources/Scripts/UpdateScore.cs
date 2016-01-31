using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateScore : MonoBehaviour {

    public Text leftScoreText;
    public Text rightScoreText;

    private static int leftScore = 0;
    private static int rightScore = 0;
    
    void Update()
    {
        leftScoreText.text = "Score: " + leftScore;
        rightScoreText.text = "Score: " + rightScore;
        CheckWinCondition();
    }

    public static void ScoreUpdate(int type, int value)
    {
        switch (type)
        {
            case 1:
                leftScore += value;
                break;
            case 2:
                rightScore += value;
                break;
        }
    }

    void CheckWinCondition()
    {
        if (leftScore == 10)
        {
            Application.LoadLevel(2);
        }
        if (rightScore == 10)
        {
            Application.LoadLevel(3);
        }
    }
}

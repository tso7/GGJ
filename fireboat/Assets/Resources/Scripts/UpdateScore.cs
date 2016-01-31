using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateScore : MonoBehaviour {

    public Text leftScoreText;
    public Text rightScoreText;

    public int winScore = 5;

    public static int leftScore = 0;
    public static int rightScore = 0;
    
    void Update()
    {
        leftScoreText.text = "ALFHILD: " + leftScore;
        rightScoreText.text = "BRYNJAR: " + rightScore;
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
        if (leftScore == winScore)
        {
            Application.LoadLevel(2);
        }
        if (rightScore == winScore)
        {
            Application.LoadLevel(3);
        }
    }
}

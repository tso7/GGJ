using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateScore : MonoBehaviour {

    public Text leftScoreText;
    public Text rightScoreText;

    public RawImage leftImage, rightImage;

    public int winScore = 5;

    public static int leftScore = 0;
    public static int rightScore = 0;

    private int tempL = 0, tempR = 0;
    
    void Update()
    {
        leftScoreText.text = "ALFHILD: " + leftScore;
        rightScoreText.text = "BRYNJAR: " + rightScore;
        CheckWinCondition();
        CheckChangeInScore();
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
        if (leftScore >= winScore)
        {
            Application.LoadLevel(2);
        }
        if (rightScore >= winScore)
        {
            Application.LoadLevel(3);
        }
    }

    void CheckChangeInScore()
    {
        if (leftScore != tempL)
        {
            tempL = leftScore;
            StartCoroutine(InYourFace(leftImage));
        }
        if (rightScore != tempR)
        {
            tempR = rightScore;
            StartCoroutine(InYourFace(rightImage));
        }
    }

    IEnumerator InYourFace(RawImage img)
    {
        img.transform.localScale += new Vector3(0.2f, 0, 0);
        yield return new WaitForSeconds(0.5f);
        img.transform.localScale -= new Vector3(0.2F, 0, 0);
    }
}

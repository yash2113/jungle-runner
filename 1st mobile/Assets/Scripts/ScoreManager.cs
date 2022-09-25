using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public float pointsPerSecond;

    public Text scoreText;
    public Text highScoreText;

    public float score;
    private float highScore;

    public bool isScoreIncreasing;

    // Start is called before the first frame update
    void Start()
    {   isScoreIncreasing = true; 
        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {   if (isScoreIncreasing)

        {
            score += pointsPerSecond * Time.deltaTime;
        }
        if(score>highScore)
        {
            highScore=score;
            PlayerPrefs.SetFloat("HighScore",highScore);
        }

        scoreText.text=Mathf.Round(score).ToString();
        highScoreText.text = Mathf.Round(highScore).ToString();
    }
}

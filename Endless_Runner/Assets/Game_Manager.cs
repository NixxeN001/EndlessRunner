using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Game_Manager : MonoBehaviour
{
    private int m_score = 0;
    [SerializeField] private UnityEvent executeOnScore;
    [SerializeField] private Text scoreText;


    public int Score
    {
        get { return m_score; }
        set { m_score = value; OnScore(); }
    }

    private void OnScore()
    {
        executeOnScore.Invoke();
    }

    public void UpdateScoreUI()
    {
        scoreText.text = m_score.ToString();
    }

  
}

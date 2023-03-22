using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int teamOneScore;
    public int teamTwoScore;

    public Timer timer;

    private TextMeshProUGUI _teamOneUI;
    private TextMeshProUGUI _teamTwoUI;
    
    public static GameManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Trying to create another instance of PlayerConfigurationManager ");
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _teamOneUI = GameObject.Find("Team1Score").GetComponentInChildren<TextMeshProUGUI>();
        _teamTwoUI = GameObject.Find("Team2Score").GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!timer.TimerOn)
        {
            if (teamOneScore > teamTwoScore)
            {
                print("team 1 win");
            }
            else if (teamOneScore < teamTwoScore)
            {
                print("team 2 win");
            }
            else if(teamOneScore == teamTwoScore)
            {
                print("Draw !");
            }
            
        }
    }

    public void UpdateScore(int team)
    {
        switch (team)
        {
            case 1:
                teamOneScore += 50;
                _teamOneUI.text = teamOneScore.ToString();
                break;
            case 2:
                teamTwoScore += 50;
                _teamTwoUI.text = teamTwoScore.ToString();
                break;
        }
    }
}

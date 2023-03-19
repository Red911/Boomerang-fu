using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int teamOneScore;
    public int teamTwoScore;

    public Timer timer;
    void Start()
    {
        
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
}

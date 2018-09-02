using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    public float TimeControl;

    public void slowTime(){
        Time.timeScale = TimeControl;
    }

    public void normalTime()
    {
        Time.timeScale = 1f;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    public float TimeControl;

    public void slowTime(){
        Time.timeScale = TimeControl;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    public void normalTime()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }

}

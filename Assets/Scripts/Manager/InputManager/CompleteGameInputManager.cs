using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteGameInputManager : GameInputManager
{
    public override void Start()
    {
        base.Start();
        GameInitialize();
    }
    public void OnPauseAction()
    {
        if (Time.timeScale == 0f)
            GameResume();
        else
            GamePause();
    }
}

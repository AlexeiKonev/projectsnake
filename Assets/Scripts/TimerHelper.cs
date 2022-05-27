using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerHelper : MonoBehaviour
{
    [SerializeField]
   private Text _textBodyLeftTime;
    [SerializeField]
    private float _currentTimer;
    [SerializeField]
    bool timerAttached = false;
     
    void Awake()
    {
        //_textBodyLeftTime =GameObject.Find("counttime"). GetComponent<Text>();

        
    }


    void Update()
    {
       
        //_textBodyLeftTime.text = _currentTimer.ToString();
    }
     
}

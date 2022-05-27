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
    SnakeControll snake;
    void Awake()
    {
        snake = FindObjectOfType<SnakeControll>();
         _textBodyLeftTime =GameObject.Find("counttime"). GetComponent<Text>();

        
    }

    private void FixedUpdate()
    {

       _currentTimer= snake.NewBody.GetComponent<Body>().lifeTime;
    }
    void  Update()
    {
       
         _textBodyLeftTime.text = _currentTimer.ToString();
    }
     
}

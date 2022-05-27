using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour  ,IBodyAttachble
{
    public   int bodyBonus=0;
    public   int timeBonus=0;
    public   int speedBonus=0;

    private  SnakeControll _snakeControll;

    public bool _doubleBonusIsActive = false;
    public bool _timeBonusIsActive = false;
    public bool _speedBonusIsActive = false;

    [SerializeField] 
    Text textSpeedBonus;

    [SerializeField] 
    Text textTimeBonus;

    [SerializeField] 
    Text textBodyBonus;

    [SerializeField] 
    Text textBodyLeftTime;

    private void Awake()
    {
        _snakeControll = GameObject.Find("Head").GetComponent<SnakeControll>();
    }

    private void Update()
    {
        textSpeedBonus.text = speedBonus.ToString();
        textBodyBonus.text = bodyBonus.ToString();
         
        textTimeBonus.text = timeBonus.ToString();
        BonusCheck();

        if (Input.GetKey(KeyCode.E)&& bodyBonus > 0  )
        {
            Debug.Log("Speed bonus ");
            speedBonus--;
            _doubleBonusIsActive = true;
            ActivateBonus();
        }
        if (Input.GetKey(KeyCode.Q) && timeBonus > 0 && !_timeBonusIsActive)
        {
            Debug.Log("time bonus ");
            timeBonus--;
             _timeBonusIsActive = true;
            ActivateBonus() ;
        }
        if (Input.GetKey(KeyCode.Space) && bodyBonus > 0 && !_speedBonusIsActive)
        {
            Debug.Log("body bonus ");
            bodyBonus--;
           _speedBonusIsActive = true;
            ActivateBonus();
        }

         
    }
    void ActivateBonus()
    {
        if(_speedBonusIsActive)
        {

            _speedBonusIsActive = false;
        }

        if(_doubleBonusIsActive)
        {
            AddBody(2);
            _doubleBonusIsActive = false;
        }

        if(_timeBonusIsActive)
        {
            
            _timeBonusIsActive = false;
        }

       
    }

    public void AddBody(int countBody)
    {
        for(int i=0; i < countBody; i++)
        {
            _snakeControll.AddBody();
        }
       
    }

    public void AddBody()
    {
         
    }
   void BonusCheck()
    {
        if (bodyBonus < 0)
        {
            bodyBonus = 0;
        }
        if (speedBonus < 0)
        {
            speedBonus = 0;
        }
        if (timeBonus < 0)
        {
            timeBonus = 0;
        }
    }
}

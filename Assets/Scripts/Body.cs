using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{

    [SerializeField]
  private  bool _isAlive = true;  
    [SerializeField]
  private  bool _isActiveDeathTimer = false; 
  public  bool isActiveDeathTimer { get { return _isActiveDeathTimer; } }
    [SerializeField]
  private  bool _isActiveSlowTimeBonus = false;
    [SerializeField]
  private  bool _isActiveAddTimeBonus = false;
    [SerializeField]
  private float _lifeTime = 15;
  public float lifeTime { get { return _lifeTime; } }

    private void Awake()
    {
        _isActiveDeathTimer = true;
    }
    private void Update()
    {
        //LifeTimer();
        //AddTime();
        //DestroyBody();
    }

    private  void AddTime() 
    {
        if (_isActiveAddTimeBonus)
        {
            _lifeTime += 5;
            _isActiveAddTimeBonus = false;
        }
    }
  private void LifeTimer()
    {
        if (_isActiveDeathTimer)
        {
            while (_lifeTime > 0) 
            { 
                _lifeTime -= Time.deltaTime; 
            }
                 
             
        }
        if (lifeTime <= 0)
        {
            _isAlive = false;
        }

        if ( _isActiveSlowTimeBonus && _isActiveDeathTimer)
        {
            while (_lifeTime > 0)
            {
                _lifeTime -= Time.deltaTime / 2;
            }
        }
        
        
    }

   private void DestroyBody()
    {
        if (!_isAlive)
        {
            Destroy(this.gameObject);
        }
    }
}

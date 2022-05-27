using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{

    [SerializeField]
  private  bool _isAlive = true;  
    [SerializeField]
  private  bool _isActiveDeathTimer = false;
    [SerializeField]
    private bool _isActiveSlowTimeBonus = false;
    public bool isActiveDeathTimer
    {
        get { return _isActiveDeathTimer; }
        set { _isActiveDeathTimer = value; }
    }
 
    [SerializeField]
    private  bool _isActiveAddTimeBonus = false;
    public bool isActiveAddTimeBonus
    {
        get { return _isActiveAddTimeBonus; }
        set { _isActiveAddTimeBonus = value; }
    }
    
        [SerializeField]
  private float _lifeTime = 45;
  public float lifeTime { get { return _lifeTime; } }

    private void Awake()
    {
        _isActiveDeathTimer = true;
    }
    private void Update()
    {
        //LifeTimer();
        AddTime();
        DestroyBody();
    }
    private void FixedUpdate()
    {

        LifeTimer();
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

        _lifeTime -= 0.1f;

        if (_lifeTime <= 0)
        {
            _isActiveDeathTimer = false;

            _isAlive = false;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{ 
public   class Food : MonoBehaviour,IBodyAttachble  
{

        [SerializeField]
        private bool _isEated=false;

        [SerializeField]
         private   SnakeControll _snake;
        [SerializeField]
         private   Inventory _inventory;
        [SerializeField]
        private float   _delayTimeDestroyItem=2.5f;

        private void Awake()
        {
             
            _snake = GameObject.Find("Head").GetComponent<SnakeControll>();
            _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        }
        public   void AddBody()
        {
            if (_inventory._doubleBonusIsActive)
            {
                for(int i = 0; i < 2; i++) 
                {
                    _snake.AddBody(); 
                }
                 
               
                Debug.Log("Give Double Body");
                Destroy(this.gameObject);
            }
            _snake.AddBody();
            Debug.Log("Give Body");
            Destroy(this.gameObject);
        }

        public void Eat()
        {
            throw new System.NotImplementedException();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_isEated&&other.gameObject.tag=="snake")
            {
                _isEated = true;
                AddBody();
            }
        }

      
        
       
    }
}
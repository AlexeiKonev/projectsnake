using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{


public class SnakeControll : MonoBehaviour,IMovable,IBodyAttachble
{
        [SerializeField]
        private GameObject _prefabBody;

        [SerializeField]
        private float _speed = 120f;

        [SerializeField]
         private GameObject _head;
         
        private Stack<GameObject> _tails =new Stack<GameObject>();

        [SerializeField]
        private Rigidbody _rb;

        private GameObject _previousBody;
        public GameObject PreviousBody { get { return _previousBody; } }

        private GameObject _newBody;
        public GameObject NewBody { get { return _newBody; } }
 
        [SerializeField]
        private int _countBody = 1;
        private LevelManager levelManager;
        private void Awake()
        {

            levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        }
        void Start()
    {
            
            _tails.Push(_head );
            _rb = GetComponent<Rigidbody>();
        }
     
    void Update()
    {
            if (_countBody == 0)
            {
                levelManager.GameOver();
            }
        }
        private void FixedUpdate()
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                Move();
            }
            SnakeTurn();
        }
        public void SnakeTurn()
    {
        float angle = Input.GetAxis("Horizontal") * 4;
        transform.Rotate(0, angle, 0);
    }

        public void Move()
        {
           
            _rb.velocity = transform.forward * Time.deltaTime * _speed;

        }

        public void AddBody()
        {
            //save lasts in stack tail
            _previousBody= _tails.Peek();

            Quaternion newQuant = new Quaternion(
                   _previousBody.transform.rotation.x,
                   _previousBody.transform.rotation.y,
                   _previousBody.transform.rotation.z,
                   _previousBody.transform.rotation.w
                   );
            Vector3 newPos = new Vector3(
                           _previousBody.transform.localPosition.x,
                           _previousBody.transform.localPosition.y,
                           _previousBody.transform.localPosition.z 
                           );
             _newBody = Instantiate(
                    _prefabBody,
                    newPos,
                    newQuant
                    );


            HingeJoint hingeJoint =  _newBody.GetComponent<HingeJoint>();
            hingeJoint.connectedBody = _previousBody.GetComponent<Rigidbody>();

            _tails.Push(_newBody);


            //_countBody++;
            Debug.Log("Body Attached");
             
                
               

            }
        public void DeleteBody()
        {
            _tails.Pop();
            Debug.Log("Body Poped");
        }
          
    }
}
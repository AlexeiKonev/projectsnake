using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpawItem : MonoBehaviour
    {
        [SerializeField]
        private int _randomPosition; 
        [SerializeField]
        private int _randomItem;
        [SerializeField]
        private GameObject[] _arrayBonus;
        [SerializeField]
        private Transform[] _arraySpawnPositions;

         
        private void Awake()
        {
            StartCoroutine(Spawn());
        }


        private  IEnumerator Spawn ()
        {

            yield return new WaitForSeconds(2f);

            Instantiate(_arrayBonus[_randomItem], _arraySpawnPositions[_randomPosition]);
            StartCoroutine(DelaySpawn());
        }
        private IEnumerator DelaySpawn()
        {
            yield return new WaitForSeconds(2f);
            StartCoroutine(Spawn());
        }
     private   void Randomizer()
        {
            _randomItem = Random.RandomRange(0, _arrayBonus.Length);
            _randomPosition = Random.RandomRange(0, _arraySpawnPositions.Length);
        }
    }
    
}

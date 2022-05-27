using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
     [SerializeField]
    private GameObject[] _fruitsArray= new GameObject[3];
    [SerializeField]
    private Transform[] _pointsAray;

    private void Awake()
    {
        StartCoroutine(ItemSpawn());
    }
    void Update()
    {
       
    }

    private IEnumerator ItemSpawn()
    {
        yield return new WaitForSeconds(3f);
        int randomFruit = Random.Range(0, _fruitsArray.Length);
        int randomPoint = Random.Range(0, _pointsAray.Length);
        Instantiate(_fruitsArray[randomFruit],_pointsAray [ randomPoint]  );
        yield return new WaitForSeconds(3f);
        StartCoroutine(ItemSpawn());
    }
}

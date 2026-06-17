using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private int _minValue = 1;
    [SerializeField] private int _maxValue = 5;
    private int _gemValue;

    private void OnTriggerEnter(Collider other)
    {
        Hero hero = other.GetComponent<Hero>();
        if (hero != null)
        {
            _gemValue = Random.Range(_minValue, _maxValue + 1);
            hero.AddGem(_gemValue);
            gameObject.SetActive(false);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _delay = 3f;
    void Start()
    {
        Destroy(gameObject, _delay);
    }

}

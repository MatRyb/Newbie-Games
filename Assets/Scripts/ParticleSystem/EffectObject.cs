using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    public float time = 2.5f;

    void Start()
    {
        Destroy(gameObject, time);
    }


}

#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Light))]




public class lightingdarkness : MonoBehaviour {

    public float multiplier = 1;

    void Update()
    {
        var light = GetComponent<Light>();
        light.color = new Color(-1f,-1f,-1f,1) * multiplier;
    }
}
#endif
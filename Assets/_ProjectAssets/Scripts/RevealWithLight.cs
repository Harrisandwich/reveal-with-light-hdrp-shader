using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
public class RevealWithLight : MonoBehaviour
{
    [SerializeField] private Material _mat;
    [SerializeField] private Light _spotLight;

    public Light SpotLight
    {
        get => _spotLight;
        set => _spotLight = value;
    }
    // Update is called once per frame
    void Update()
    {
        if (_mat == null || _spotLight == null) return;

        _mat.SetVector("_LightPosition", _spotLight.transform.position);
        _mat.SetVector("_LightDirection", -_spotLight.transform.forward);
        _mat.SetFloat("_LightAngle", _spotLight.spotAngle);
    }
}

using UnityEngine;
using UnityEngine.Events;

public class RevealWithLight_Instanced : MonoBehaviour
{
    public UnityEvent OnRevealed;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Light _spotLight;

    private Material _material;

    public Light SpotLight
    {
        get => _spotLight;
        set => _spotLight = value;
    }

    // Update is called once per frame
    void Update()
    {
        if (_material == null || _spotLight == null) return;

        _material.SetVector("_LightPosition", _spotLight.transform.position);
        _material.SetVector("_LightDirection", -_spotLight.transform.forward);
        _material.SetFloat("_LightAngle", _spotLight.spotAngle);
        float alpha = CalculateDecalAlpha();
   
        if (alpha > 2.5 && gameObject.activeInHierarchy)
        {
            OnRevealed?.Invoke();
        }
        
    }

    private float CalculateDecalAlpha()
    {
        Vector3 position = (_spotLight.transform.position - transform.position).normalized;
        float scale = Vector3.Dot(position, -_spotLight.transform.forward);
        float strength = scale - Mathf.Cos((3.14f / 360f) * _spotLight.spotAngle);
        float scaledStrength = Mathf.Min(Mathf.Max(_material.GetFloat("_Strength") * strength, 0),1);
        return scaledStrength * _material.GetFloat("_AlphaMod");
    }
}

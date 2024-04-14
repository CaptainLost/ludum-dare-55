using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    private Light2D _light;

    private void Awake()
    {
        _light = GetComponent<Light2D>();
    }
}

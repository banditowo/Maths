using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectShakePerlin : MonoBehaviour
{
    [Header("Press spacebar to toggle effect on/off \n")]
    [SerializeField] private float shakeIntensity = 1.0f;
    [SerializeField] private float lerpSharpness = 1.0f;
    [SerializeField] private float noiseFrequency = 1.0f;
    [SerializeField] private float maximumDisplacement = 6.0f;
    [SerializeField] private Vector2 samplingOffset = new Vector2(1.0f, 1.0f);
    [SerializeField] private UnityEvent<bool> outerBoundResponse;

    private Vector3 startingPos;
    private bool effectEnabled = false;
    [HideInInspector] public bool outerBoundContact = false;

    private void Start()
    {
        startingPos = this.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            effectEnabled = !effectEnabled;
        }

        Vector3 shake;

        if (!effectEnabled)
        {
            float noiseValue1 = Mathf.PerlinNoise(Time.time * noiseFrequency, Time.time * noiseFrequency + samplingOffset.y);
            float noiseValue2 = Mathf.PerlinNoise(Time.time * noiseFrequency + samplingOffset.x, Time.time * noiseFrequency);
            shake = (new Vector3(1.0f - noiseValue2, noiseValue1, 0.5f * noiseValue2 + 0.5f * noiseValue1) * 2.0f - Vector3.one) * shakeIntensity;
        }
        else
        {
            shake = Vector3.zero;
        }

        Vector3 preClampVector = startingPos + shake;
        Vector3 finalDisplacement = preClampVector.normalized * maximumDisplacement;

        outerBoundContact = preClampVector.magnitude > maximumDisplacement * 0.85f;
        outerBoundResponse.Invoke(outerBoundContact);

        this.transform.position = Vector3.Lerp(this.transform.position, finalDisplacement, lerpSharpness * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetherController : MonoBehaviour
{
    [SerializeField] private Transform parentTransform;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private ParticleSystem particleEmitter;

    public void ToggleParticleSystem(bool value)
    {
        if(value)
        {
            if(particleEmitter.isEmitting)
            {
                return;
            }

            particleEmitter.Play();
        }
        else
        {
            particleEmitter.Stop();
        }

    }

    void Update()
    {
        Vector3 direction = targetTransform.position - parentTransform.position + Vector3.one * 0.0001f;
        this.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }
}

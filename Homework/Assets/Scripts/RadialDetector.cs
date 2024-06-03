using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialDetector : MonoBehaviour
{
    [SerializeField] private Transform detectionTarget;
    [SerializeField] private float detectorRadius;
    [SerializeField] private float targetRadius;


    void Update()
    {
        Vector3 referenceVector = detectionTarget.position - this.transform.position;

        float distance = referenceVector.magnitude;
        Vector3 targetScale = new Vector3(0, 0, 0);

        if (distance < detectorRadius + targetRadius)
        {
            targetScale = Vector3.one * 2.5f;
        }
        else
        {
            targetScale = Vector3.one;
        }

        detectionTarget.localScale = Vector3.Lerp(detectionTarget.localScale, targetScale, Time.deltaTime * 10);
    }
}

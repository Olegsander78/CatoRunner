using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingItem : MonoBehaviour
{
    public float ScaleFrequency = 2f;
    public float PositionFrequency = 500f;
    public float ScaleAmplitude = 0.5f;
    public float PositionAmplitude = 0.05f;
    public float Scale = 0.5f;

    private Vector3 _startScale;

    private void Start()
    {
        _startScale = transform.localScale;
    }

    private void Update()
    {
        StartCoroutine(MoveInWaves());
    }

    IEnumerator MoveInWaves()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, (Mathf.Sin(Time.time * PositionFrequency) * PositionAmplitude), transform.localPosition.z);
        transform.localScale = _startScale * Mathf.Clamp((Mathf.Sin(Time.time * ScaleFrequency) * ScaleAmplitude + Scale), 0.7f, 1.2f);
        
        yield return new WaitForSeconds(0.3f);
    }
}

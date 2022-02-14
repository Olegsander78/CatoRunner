using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    private const int NUM_BLINKS = 10;
    private const float DURATION_BLINK = 0.1f;
    
    public SpriteRenderer SpriteRenderer;

    private void Start()
    {
        if (gameObject.TryGetComponent(out SpriteRenderer SpriteRenderer))
        {
            return;
        }
    }
    public void StartBlink()
    {
        StartCoroutine(BlinkEffect(SpriteRenderer, NUM_BLINKS, DURATION_BLINK));
    }

    public IEnumerator BlinkEffect(SpriteRenderer spriteRenderer,int numBlink, float seconds)
    {
        for (int i = 0; i < numBlink*2; i++)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(seconds);
        }
        spriteRenderer.enabled = true;
    }
}

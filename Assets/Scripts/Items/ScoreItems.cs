using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItems : GameItems
{
    private void Update()
    {
        StartCoroutine(MoveInWaves());
    }

    IEnumerator MoveInWaves()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * 2f) * 0.15f + 0.5f, transform.position.z);
        yield return new WaitForSeconds(0.5f);
    }
}

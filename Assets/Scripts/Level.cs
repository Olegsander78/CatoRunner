using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private const float LENGHT_SEGMENT = 30.7f;
    [SerializeField] private List<LevelSegment> _levelSegments = new List<LevelSegment>();
    [SerializeField] private float _speedLevel = 1f;
    [SerializeField] private float _minCoordLevelSegX;
    [SerializeField] private float _maxCoordLevelSegX;
    

    private void Start()
    {
        for (int i = 0; i < _levelSegments.Count; i++)
        {
            
            //todo  
            // Реализовать мин и макс иксовые координаты , вначале. стартовые коорд.
        }
    }
    private void Update()
    {
        float displacement = _speedLevel * Time.deltaTime;
        foreach (var segment in _levelSegments)
        {
            var pos = segment.transform.position;
            pos.x -= displacement;
            if (pos.x < _minCoordLevelSegX)
            {
                pos.x = _maxCoordLevelSegX - (_minCoordLevelSegX - pos.x) + LENGHT_SEGMENT;
                segment.RollVariant();
            }
            segment.transform.position = pos;
        }
        //

    }
}

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
        _minCoordLevelSegX = _levelSegments[0].transform.position.x;
        _maxCoordLevelSegX = _levelSegments[0].transform.position.x;

        for (int i = 1; i < _levelSegments.Count; i++)
        {
            if (_minCoordLevelSegX > _levelSegments[i].transform.position.x) _minCoordLevelSegX = _levelSegments[i].transform.position.x;
            if (_maxCoordLevelSegX < _levelSegments[i].transform.position.x) _maxCoordLevelSegX = _levelSegments[i].transform.position.x;
        }
    }
    private void FixedUpdate()
    {
        float displacement = _speedLevel * Time.deltaTime;

        foreach (var segment in _levelSegments)
        {
            var pos = segment.transform.position;
            pos.x -= displacement;
            if (pos.x < _minCoordLevelSegX)
            {
                pos.x = _maxCoordLevelSegX - (_minCoordLevelSegX - pos.x) + LENGHT_SEGMENT;
                segment.RollVariantLevelSegment();
            }
            segment.Rigidbody.MovePosition(pos);
        }
    }
}

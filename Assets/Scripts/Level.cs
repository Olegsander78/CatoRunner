using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private const float LENGHT_SEGMENT = 30.7f;
    [SerializeField] private List<LevelSegment> _levelSegments = new List<LevelSegment>();
    [SerializeField] private float _speedLevel = 3f;
    [SerializeField] private float _minCoordLevelSegX;
    [SerializeField] private float _maxCoordLevelSegX;

    public float MinCoordLevelSegX { get => _minCoordLevelSegX; set => _minCoordLevelSegX = value; }

    public float MaxCoordLevelSegX { get => _maxCoordLevelSegX; set => _maxCoordLevelSegX = value; }
    public float SpeedLevel => _speedLevel;

    [SerializeField] private PlayerCharacter _playerCharacter;
    public PlayerCharacter PlayerCharacter => _playerCharacter;

    private void Awake()
    {
        MinCoordLevelSegX = _levelSegments[0].transform.position.x;
        MaxCoordLevelSegX = _levelSegments[0].transform.position.x;

        for (int i = 1; i < _levelSegments.Count; i++)
        {
            if (MinCoordLevelSegX > _levelSegments[i].transform.position.x) MinCoordLevelSegX = _levelSegments[i].transform.position.x;
            if (MaxCoordLevelSegX < _levelSegments[i].transform.position.x) MaxCoordLevelSegX = _levelSegments[i].transform.position.x;
        }

        GameController.Instance.LevelController.SetLevel(this);
    }
    private void FixedUpdate()
    {
        float displacement = SpeedLevel * Time.deltaTime;

        foreach (var segment in _levelSegments)
        {
            var pos = segment.transform.position;
            pos.x -= displacement;
            if (pos.x < MinCoordLevelSegX)
            {
                pos.x = MaxCoordLevelSegX - (MinCoordLevelSegX - pos.x) + LENGHT_SEGMENT;
                //segment.Clear();
                segment.RollVariantLevelSegment();
            }
            segment.Rigidbody.MovePosition(pos);
        }
    }

    
}

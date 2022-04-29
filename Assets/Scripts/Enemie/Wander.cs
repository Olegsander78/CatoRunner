using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    public enum Directions
	{
		Up,
		Right,
		Down,
		Left,
	}

	public Rigidbody2D Rigidbody2D;

	[Header("Movement")]
	public float Speed = 1f;
	public float DirectionChangeInterval = 3f;
	public bool KeepNearStartingPoint = true;

	[Header("Orientation")]
	public bool OrientToDirection = false;
	// The direction that the GameObject will be oriented to
	public Directions LookAxis = Directions.Up;

	private Vector2 _direction;
	private Vector3 _startingPoint;


	private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

	private void Start()
	{
		//we don't want directionChangeInterval to be 0, so we force it to a minimum value ;)
		if (DirectionChangeInterval < 0.1f)
		{
			DirectionChangeInterval = 0.1f;
		}

		// we note down the initial position of the GameObject in case it has to hover around that (see keepNearStartingPoint)
		_startingPoint = transform.position;

		StartCoroutine(ChangeDirection());
    }

	// FixedUpdate is called every frame when the physics are calculated
	private void FixedUpdate()
	{
		Rigidbody2D.AddForce(_direction * Speed);
	}

	public void SetAxisTowards(Directions axis, Transform t, Vector2 direction)
	{
		switch (axis)
		{
			case Directions.Up:
				t.up = direction;
				break;
			case Directions.Down:
				t.up = -direction;
				break;
            case Directions.Right:
				t.right = direction;
				break;
			case Directions.Left:
				t.right = -direction;
				break;
		}
	}


	// Calculates a new direction
	private IEnumerator ChangeDirection()
	{
		while (true)
		{
			_direction = Random.insideUnitCircle; //change the direction the player is going

			// if we need to keep near the starting point...
			if (KeepNearStartingPoint)
			{
				// we measure the distance from it...
				float distanceFromStart = Vector2.Distance(_startingPoint, transform.position);
				if (distanceFromStart > 1f + (Speed * 0.1f)) // and if it's too much...
				{
					//... we get a direction that points back to the starting point
					_direction = (_startingPoint - transform.position).normalized;
				}
			}

			//if the object has to look in the direction of movement
			if (OrientToDirection)
			{
				SetAxisTowards(LookAxis, transform, _direction);
			}

			// this will make Unity wait for some time before continuing the execution of the code
			yield return new WaitForSeconds(DirectionChangeInterval);
		}
    }
}

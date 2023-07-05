using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy
{
	[CreateAssetMenu(fileName = "newMoveStateData", menuName = "Data/State Data/Move State")]

	public class D_MoveState : ScriptableObject
	{
		public float movementSpeed = 3f;

	}

}
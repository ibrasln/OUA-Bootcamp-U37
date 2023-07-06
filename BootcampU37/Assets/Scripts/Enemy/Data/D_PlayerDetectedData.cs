using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
	[CreateAssetMenu(fileName = "newPlayerDetectedStateData", menuName = "Data/State Data/Player Detected State")]

	public class D_PlayerDetectedData : ScriptableObject
	{
		public float longRangeActionTime = 1.5f;

	}
}
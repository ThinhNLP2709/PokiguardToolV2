/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 24: Unity.2D.SpriteShape.Runtime.dll - Assembly: Unity.2D.SpriteShape.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13957-14022

namespace UnityEngine.U2D
{
	public class SplineUtility // TypeDefIndex: 13988
	{
		// Constructors
		public SplineUtility(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public static float SlopeAngle(Vector2 start, Vector2 end); // 0x0000000181C46C00-0x0000000181C46D50
		public static void CalculateTangents(Vector3 point, Vector3 prevPoint, Vector3 nextPoint, Vector3 forward, float scale, out Vector3 rightTangent, out Vector3 leftTangent); // 0x0000000181C46760-0x0000000181C46BA0
		internal static int NextIndex(int index, int pointCount); // 0x0000000181C46BC0-0x0000000181C46BE0
		internal static int PreviousIndex(int index, int pointCount); // 0x0000000181C46BE0-0x0000000181C46C00
		private static int Mod(int x, int m); // 0x0000000181C46BA0-0x0000000181C46BC0
	}
}

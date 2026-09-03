/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening.Core
{
	public static class DOTweenUtils // TypeDefIndex: 13521
	{
		// Fields
		private static Assembly[] _loadedAssemblies; // 0x00
		private static readonly string[] _defAssembliesToQuery; // 0x08
	
		// Constructors
		static DOTweenUtils(); // 0x00000001807300E0-0x00000001807301E0
	
		// Methods
		internal static Vector3 Vector3FromAngle(float degrees, float magnitude); // 0x0000000180730080-0x00000001807300E0
		internal static float Angle2D(Vector3 from, Vector3 to); // 0x000000018072F9F0-0x000000018072FBC0
		internal static Vector3 RotateAroundPivot(Vector3 point, Vector3 pivot, Quaternion rotation); // 0x000000018072FF10-0x000000018072FFD0
		public static Vector2 GetPointOnCircle(Vector2 center, float radius, float degrees); // 0x000000018072FE90-0x000000018072FF10
		internal static bool Vector3AreApproximatelyEqual(Vector3 a, Vector3 b); // 0x000000018072FFD0-0x0000000180730080
		internal static Type GetLooseScriptType(string typeName); // 0x000000018072FBC0-0x000000018072FE90
	}
}

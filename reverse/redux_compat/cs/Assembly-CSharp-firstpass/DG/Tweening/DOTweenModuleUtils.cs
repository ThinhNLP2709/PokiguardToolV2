/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Scripting;

// Image 40: Assembly-CSharp-firstpass.dll - Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15099-15191

namespace DG.Tweening
{
	public static class DOTweenModuleUtils // TypeDefIndex: 15190
	{
		// Fields
		private static bool _initialized; // 0x00
	
		// Nested types
		public static class Physics // TypeDefIndex: 15191
		{
			// Methods
			public static void SetOrientationOnPath(PathOptions options, Tween t, Quaternion newRot, Transform trans); // 0x00000001802E47F0-0x00000001802E4900
			public static bool HasRigidbody2D(Component target); // 0x00000001802E46F0-0x00000001802E4770
			[Preserve]
			public static bool HasRigidbody(Component target); // 0x00000001802E4770-0x00000001802E47F0
			[Preserve]
			public static TweenerCore<Vector3, Path, PathOptions> CreateDOTweenPathTween(MonoBehaviour target, bool tweenRigidbody, bool isLocal, Path path, float duration, PathMode pathMode); // 0x00000001802E3FD0-0x00000001802E46F0
		}
	
		// Methods
		[Preserve]
		public static void Init(); // 0x00000001802E3EA0-0x00000001802E3F40
		[Preserve]
		private static void Preserver(); // 0x00000001802E3F40-0x00000001802E3FD0
	}
}

/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DG.Tweening;
using DG.Tweening.Plugins.Options;
using UnityEngine;

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening.Core
{
	public static class DOTweenExternalCommand // TypeDefIndex: 13514
	{
		// Fields
		[CompilerGenerated]
		private static Action<PathOptions, Tween, Quaternion, Transform> SetOrientationOnPath; // 0x00
	
		// Events
		public static event Action<PathOptions, Tween, Quaternion, Transform> SetOrientationOnPath {
			add; // 0x000000018072F760-0x000000018072F830
			remove; // 0x000000018072F830-0x000000018072F900
		}
	
		// Methods
		internal static void Dispatch_SetOrientationOnPath(PathOptions options, Tween t, Quaternion newRot, Transform trans); // 0x000000018072F670-0x000000018072F760
	}
}

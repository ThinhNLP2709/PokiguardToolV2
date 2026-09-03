/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DG.Tweening.Plugins.Options;
using UnityEngine;

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening.Plugins
{
	public struct CircleOptions : IPlugOptions // TypeDefIndex: 13452
	{
		// Fields
		public float endValueDegrees; // 0x00
		public bool relativeCenter; // 0x04
		public bool snapping; // 0x05
		internal Vector2 center; // 0x08
		internal float radius; // 0x10
		internal float startValueDegrees; // 0x14
		internal bool initialized; // 0x18
	
		// Methods
		public void Reset(); // 0x0000000180700310-0x0000000180700320
		public void Initialize(Vector2 startValue, Vector2 endValue); // 0x00000001807001E0-0x0000000180700310
	}
}

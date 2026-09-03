/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening.Plugins
{
	public class Vector4Plugin : ABSTweenPlugin<Vector4, Vector4, VectorOptions> // TypeDefIndex: 13467
	{
		// Constructors
		public Vector4Plugin(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void Reset(TweenerCore<Vector4, Vector4, VectorOptions> t); // 0x00000001802E76C0-0x00000001802E76D0
		public override void SetFrom(TweenerCore<Vector4, Vector4, VectorOptions> t, bool isRelative); // 0x000000018072ED70-0x000000018072F000
		public override void SetFrom(TweenerCore<Vector4, Vector4, VectorOptions> t, Vector4 fromValue, bool setImmediately, bool isRelative); // 0x000000018072F000-0x000000018072F3A0
		public override Vector4 ConvertToStartValue(TweenerCore<Vector4, Vector4, VectorOptions> t, Vector4 value); // 0x000000018071CA60-0x000000018071CA70
		public override void SetRelativeEndValue(TweenerCore<Vector4, Vector4, VectorOptions> t); // 0x000000018071D190-0x000000018071D210
		public override void SetChangeValue(TweenerCore<Vector4, Vector4, VectorOptions> t); // 0x000000018072EBD0-0x000000018072ED70
		public override float GetSpeedBasedDuration(VectorOptions options, float unitsXSecond, Vector4 changeValue); // 0x000000018072EB20-0x000000018072EBD0
		public override void EvaluateAndApply(VectorOptions options, Tween t, bool isRelative, DOGetter<Vector4> getter, DOSetter<Vector4> setter, float elapsed, Vector4 startValue, Vector4 changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice); // 0x000000018072E5B0-0x000000018072EB20
	}
}

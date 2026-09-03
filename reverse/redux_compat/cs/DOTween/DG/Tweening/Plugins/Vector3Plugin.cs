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
	public class Vector3Plugin : ABSTweenPlugin<Vector3, Vector3, VectorOptions> // TypeDefIndex: 13471
	{
		// Constructors
		public Vector3Plugin(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void Reset(TweenerCore<Vector3, Vector3, VectorOptions> t); // 0x00000001802E76C0-0x00000001802E76D0
		public override void SetFrom(TweenerCore<Vector3, Vector3, VectorOptions> t, bool isRelative); // 0x000000018072E080-0x000000018072E2B0
		public override void SetFrom(TweenerCore<Vector3, Vector3, VectorOptions> t, Vector3 fromValue, bool setImmediately, bool isRelative); // 0x000000018072E2B0-0x000000018072E5B0
		public override Vector3 ConvertToStartValue(TweenerCore<Vector3, Vector3, VectorOptions> t, Vector3 value); // 0x000000018072DAF0-0x000000018072DB10
		public override void SetRelativeEndValue(TweenerCore<Vector3, Vector3, VectorOptions> t); // 0x00000001807281A0-0x0000000180728200
		public override void SetChangeValue(TweenerCore<Vector3, Vector3, VectorOptions> t); // 0x000000018072DFA0-0x000000018072E080
		public override float GetSpeedBasedDuration(VectorOptions options, float unitsXSecond, Vector3 changeValue); // 0x0000000180727460-0x0000000180727490
		public override void EvaluateAndApply(VectorOptions options, Tween t, bool isRelative, DOGetter<Vector3> getter, DOSetter<Vector3> setter, float elapsed, Vector3 startValue, Vector3 changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice); // 0x000000018072DB10-0x000000018072DFA0
	}
}

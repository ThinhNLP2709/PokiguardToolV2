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
	public class Vector2Plugin : ABSTweenPlugin<Vector2, Vector2, VectorOptions> // TypeDefIndex: 13466
	{
		// Constructors
		public Vector2Plugin(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void Reset(TweenerCore<Vector2, Vector2, VectorOptions> t); // 0x00000001802E76C0-0x00000001802E76D0
		public override void SetFrom(TweenerCore<Vector2, Vector2, VectorOptions> t, bool isRelative); // 0x000000018072CD10-0x000000018072CE80
		public override void SetFrom(TweenerCore<Vector2, Vector2, VectorOptions> t, Vector2 fromValue, bool setImmediately, bool isRelative); // 0x000000018072CB50-0x000000018072CD10
		public override Vector2 ConvertToStartValue(TweenerCore<Vector2, Vector2, VectorOptions> t, Vector2 value); // 0x0000000180700320-0x0000000180700330
		public override void SetRelativeEndValue(TweenerCore<Vector2, Vector2, VectorOptions> t); // 0x000000018072CE80-0x000000018072CED0
		public override void SetChangeValue(TweenerCore<Vector2, Vector2, VectorOptions> t); // 0x000000018072CAA0-0x000000018072CB50
		public override float GetSpeedBasedDuration(VectorOptions options, float unitsXSecond, Vector2 changeValue); // 0x000000018072CA10-0x000000018072CAA0
		public override void EvaluateAndApply(VectorOptions options, Tween t, bool isRelative, DOGetter<Vector2> getter, DOSetter<Vector2> setter, float elapsed, Vector2 startValue, Vector2 changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice); // 0x000000018072C680-0x000000018072CA10
	}
}

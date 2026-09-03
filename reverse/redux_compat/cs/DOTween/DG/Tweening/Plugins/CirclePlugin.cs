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
using UnityEngine;

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening.Plugins
{
	public class CirclePlugin : ABSTweenPlugin<Vector2, Vector2, CircleOptions> // TypeDefIndex: 13453
	{
		// Constructors
		public CirclePlugin(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void Reset(TweenerCore<Vector2, Vector2, CircleOptions> t); // 0x00000001802E76C0-0x00000001802E76D0
		public override void SetFrom(TweenerCore<Vector2, Vector2, CircleOptions> t, bool isRelative); // 0x0000000180700800-0x0000000180700960
		public override void SetFrom(TweenerCore<Vector2, Vector2, CircleOptions> t, Vector2 fromValue, bool setImmediately, bool isRelative); // 0x0000000180700690-0x0000000180700800
		public static ABSTweenPlugin<Vector2, Vector2, CircleOptions> Get(); // 0x00000001807005D0-0x0000000180700600
		public override Vector2 ConvertToStartValue(TweenerCore<Vector2, Vector2, CircleOptions> t, Vector2 value); // 0x0000000180700320-0x0000000180700330
		public override void SetRelativeEndValue(TweenerCore<Vector2, Vector2, CircleOptions> t); // 0x0000000180700960-0x00000001807009E0
		public override void SetChangeValue(TweenerCore<Vector2, Vector2, CircleOptions> t); // 0x0000000180700600-0x0000000180700690
		public override float GetSpeedBasedDuration(CircleOptions options, float unitsXSecond, Vector2 changeValue); // 0x00000001807005B0-0x00000001807005D0
		public override void EvaluateAndApply(CircleOptions options, Tween t, bool isRelative, DOGetter<Vector2> getter, DOSetter<Vector2> setter, float elapsed, Vector2 startValue, Vector2 changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice); // 0x0000000180700330-0x00000001807004D0
		public Vector2 GetPositionOnCircle(CircleOptions options, float degrees); // 0x00000001807004D0-0x00000001807005B0
	}
}

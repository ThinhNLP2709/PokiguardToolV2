/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening
{
	public sealed class Sequence : Tween // TypeDefIndex: 13367
	{
		// Fields
		internal readonly List<Tween> sequencedTweens; // 0x120
		private readonly List<ABSSequentiable> _sequencedObjs; // 0x128
		internal float lastTweenInsertTime; // 0x130
	
		// Constructors
		internal Sequence(); // 0x0000000180708E30-0x0000000180708F40
	
		// Methods
		internal static Sequence DoPrepend(Sequence inSequence, Tween t); // 0x0000000180708480-0x00000001807085B0
		internal static Sequence DoInsert(Sequence inSequence, Tween t, float atPosition); // 0x0000000180708170-0x00000001807083D0
		internal static Sequence DoAppendInterval(Sequence inSequence, float interval); // 0x0000000180707BD0-0x0000000180707C10
		internal static Sequence DoPrependInterval(Sequence inSequence, float interval); // 0x00000001807083D0-0x0000000180708480
		internal static Sequence DoInsertCallback(Sequence inSequence, TweenCallback callback, float atPosition); // 0x0000000180708050-0x0000000180708170
		internal override float UpdateDelay(float elapsed); // 0x0000000180708D60-0x0000000180708D90
		internal override void Reset(); // 0x0000000180708970-0x0000000180708B70
		internal override bool Validate(); // 0x0000000180708D90-0x0000000180708E30
		internal override bool Startup(); // 0x0000000180708D50-0x0000000180708D60
		internal override bool ApplyTween(float prevPosition, int prevCompletedLoops, int newCompletedSteps, bool useInversePosition, UpdateMode updateMode, UpdateNotice updateNotice); // 0x0000000180707BB0-0x0000000180707BD0
		internal static void Setup(Sequence s); // 0x0000000180708B70-0x0000000180708C70
		internal static bool DoStartup(Sequence s); // 0x00000001807085B0-0x0000000180708910
		internal static bool DoApplyTween(Sequence s, float prevPosition, int prevCompletedLoops, int newCompletedSteps, bool useInversePosition, UpdateMode updateMode); // 0x0000000180707C10-0x0000000180708050
		private static bool ApplyInternalCycle(Sequence s, float fromPos, float toPos, UpdateMode updateMode, bool useInverse, bool prevPosIsInverse, bool multiCycleStep = false /* Metadata: 0x006A79D0 */); // 0x0000000180707370-0x0000000180707BB0
		private static void StableSortSequencedObjs(List<ABSSequentiable> list); // 0x0000000180708C70-0x0000000180708D50
		private static bool IsAnyCallbackSet(Sequence s); // 0x0000000180708910-0x0000000180708970
	}
}

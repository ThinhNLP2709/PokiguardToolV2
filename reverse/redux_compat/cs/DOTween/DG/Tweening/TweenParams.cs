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

namespace DG.Tweening
{
	public class TweenParams // TypeDefIndex: 13445
	{
		// Fields
		public static readonly TweenParams Params; // 0x00
		internal object id; // 0x10
		internal string stringId; // 0x18
		internal int intId; // 0x20
		internal object target; // 0x28
		internal UpdateType updateType; // 0x30
		internal bool isIndependentUpdate; // 0x34
		internal TweenCallback onStart; // 0x38
		internal TweenCallback onPlay; // 0x40
		internal TweenCallback onRewind; // 0x48
		internal TweenCallback onUpdate; // 0x50
		internal TweenCallback onStepComplete; // 0x58
		internal TweenCallback onComplete; // 0x60
		internal TweenCallback onKill; // 0x68
		internal TweenCallback<int> onWaypointChange; // 0x70
		internal bool isRecyclable; // 0x78
		internal bool isSpeedBased; // 0x79
		internal bool autoKill; // 0x7A
		internal int loops; // 0x7C
		internal LoopType loopType; // 0x80
		internal float delay; // 0x84
		internal bool isRelative; // 0x88
		internal Ease easeType; // 0x8C
		internal EaseFunction customEase; // 0x90
		internal float easeOvershootOrAmplitude; // 0x98
		internal float easePeriod; // 0x9C
	
		// Constructors
		public TweenParams(); // 0x0000000180716A40-0x0000000180716C20
		static TweenParams(); // 0x0000000180716810-0x0000000180716A40
	
		// Methods
		public TweenParams Clear(); // 0x0000000180716210-0x00000001807163E0
		public TweenParams SetAutoKill(bool autoKillOnCompletion = true /* Metadata: 0x006A7A66 */); // 0x00000001807164A0-0x00000001807164B0
		public TweenParams SetId(object objectId); // 0x00000001807166C0-0x00000001807166E0
		public TweenParams SetId(string stringId); // 0x00000001806CFB10-0x00000001806CFB30
		public TweenParams SetId(int intId); // 0x00000001807166E0-0x00000001807166F0
		public TweenParams SetTarget(object target); // 0x0000000180716770-0x0000000180716790
		public TweenParams SetLoops(int loops, LoopType? loopType = default); // 0x00000001807166F0-0x0000000180716740
		public TweenParams SetEase(Ease ease, float? overshootOrAmplitude = default, float? period = default); // 0x0000000180716580-0x0000000180716690
		public TweenParams SetEase(AnimationCurve animCurve); // 0x00000001807164C0-0x0000000180716580
		public TweenParams SetEase(EaseFunction customEase); // 0x0000000180716690-0x00000001807166C0
		public TweenParams SetRecyclable(bool recyclable = true /* Metadata: 0x006A7A67 */); // 0x0000000180716740-0x0000000180716750
		public TweenParams SetUpdate(bool isIndependentUpdate); // 0x00000001807167A0-0x0000000180716810
		public TweenParams SetUpdate(UpdateType updateType, bool isIndependentUpdate = false /* Metadata: 0x006A7A68 */); // 0x0000000180716790-0x00000001807167A0
		public TweenParams OnStart(TweenCallback action); // 0x0000000180716440-0x0000000180716460
		public TweenParams OnPlay(TweenCallback action); // 0x0000000180716400-0x0000000180716420
		public TweenParams OnRewind(TweenCallback action); // 0x0000000180716420-0x0000000180716440
		public TweenParams OnUpdate(TweenCallback action); // 0x00000001806F7540-0x00000001806F7560
		public TweenParams OnStepComplete(TweenCallback action); // 0x0000000180716460-0x0000000180716480
		public TweenParams OnComplete(TweenCallback action); // 0x00000001806F7570-0x00000001806F7590
		public TweenParams OnKill(TweenCallback action); // 0x00000001807163E0-0x0000000180716400
		public TweenParams OnWaypointChange(TweenCallback<int> action); // 0x0000000180716480-0x00000001807164A0
		public TweenParams SetDelay(float delay); // 0x00000001807164B0-0x00000001807164C0
		public TweenParams SetRelative(bool isRelative = true /* Metadata: 0x006A7A69 */); // 0x0000000180716750-0x0000000180716760
		public TweenParams SetSpeedBased(bool isSpeedBased = true /* Metadata: 0x006A7A6A */); // 0x0000000180716760-0x0000000180716770
	}
}

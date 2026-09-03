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
	public static class TweenExtensions // TypeDefIndex: 13365
	{
		// Methods
		private static void DoGoto(Tween t, float to, bool andPlay, bool withCallbacks); // 0x0000000180713E80-0x0000000180714020
	
		// Extension methods
		public static void Complete(this Tween t); // 0x0000000180713B10-0x0000000180713C50
		public static void Complete(this Tween t, bool withCallbacks); // 0x0000000180713C50-0x0000000180713DA0
		public static T Done<T>(this T t)
			where T : Tween;
		public static void Flip(this Tween t); // 0x0000000180714390-0x00000001807144C0
		public static void ForceInit(this Tween t); // 0x00000001807144C0-0x00000001807145F0
		public static void Goto(this Tween t, float to, bool andPlay = false /* Metadata: 0x006A79BF */); // 0x0000000180714980-0x00000001807149A0
		public static void GotoWithCallbacks(this Tween t, float to, bool andPlay = false /* Metadata: 0x006A79C0 */); // 0x0000000180714960-0x0000000180714980
		public static void Kill(this Tween t, bool complete = false /* Metadata: 0x006A79C1 */); // 0x0000000180714C30-0x0000000180714D70
		public static void ManualUpdate(this Tween t, float deltaTime, float unscaledDeltaTime); // 0x0000000180714DE0-0x0000000180714F50
		public static T Pause<T>(this T t)
			where T : Tween;
		public static T Play<T>(this T t)
			where T : Tween;
		public static void PlayBackwards(this Tween t); // 0x0000000180715530-0x0000000180715660
		public static void PlayForward(this Tween t); // 0x0000000180715660-0x0000000180715790
		public static void Restart(this Tween t, bool includeDelay = true /* Metadata: 0x006A79C2 */, float changeDelayTo = -1f /* Metadata: 0x006A79C3 */); // 0x0000000180715790-0x0000000180715900
		public static void Rewind(this Tween t, bool includeDelay = true /* Metadata: 0x006A79C7 */); // 0x0000000180715900-0x0000000180715A50
		public static void SmoothRewind(this Tween t); // 0x0000000180715A50-0x0000000180715B80
		public static void TogglePause(this Tween t); // 0x0000000180715B80-0x0000000180715CB0
		public static void GotoWaypoint(this Tween t, int waypointIndex, bool andPlay = false /* Metadata: 0x006A79C8 */); // 0x00000001807145F0-0x0000000180714960
		public static YieldInstruction WaitForCompletion(this Tween t); // 0x0000000180715CB0-0x0000000180715D90
		public static YieldInstruction WaitForRewind(this Tween t); // 0x0000000180716050-0x0000000180716130
		public static YieldInstruction WaitForKill(this Tween t); // 0x0000000180715E80-0x0000000180715F60
		public static YieldInstruction WaitForElapsedLoops(this Tween t, int elapsedLoops); // 0x0000000180715D90-0x0000000180715E80
		public static YieldInstruction WaitForPosition(this Tween t, float position); // 0x0000000180715F60-0x0000000180716050
		public static Coroutine WaitForStart(this Tween t); // 0x0000000180716130-0x0000000180716210
		public static int CompletedLoops(this Tween t); // 0x0000000180713DA0-0x0000000180713E10
		public static float Delay(this Tween t); // 0x0000000180713E10-0x0000000180713E80
		public static float ElapsedDelay(this Tween t); // 0x00000001807140D0-0x0000000180714140
		public static float Duration(this Tween t, bool includeLoops = true /* Metadata: 0x006A79C9 */); // 0x0000000180714020-0x00000001807140D0
		public static float Elapsed(this Tween t, bool includeLoops = true /* Metadata: 0x006A79CA */); // 0x00000001807142F0-0x0000000180714390
		public static float ElapsedPercentage(this Tween t, bool includeLoops = true /* Metadata: 0x006A79CB */); // 0x0000000180714210-0x00000001807142F0
		public static float ElapsedDirectionalPercentage(this Tween t); // 0x0000000180714140-0x0000000180714210
		public static bool IsActive(this Tween t); // 0x00000001807149A0-0x00000001807149B0
		public static bool IsBackwards(this Tween t); // 0x00000001807149B0-0x0000000180714A20
		public static bool IsLoopingOrExecutingBackwards(this Tween t); // 0x0000000180714B00-0x0000000180714BC0
		public static bool IsComplete(this Tween t); // 0x0000000180714A20-0x0000000180714A90
		public static bool IsInitialized(this Tween t); // 0x0000000180714A90-0x0000000180714B00
		public static bool IsPlaying(this Tween t); // 0x0000000180714BC0-0x0000000180714C30
		public static int Loops(this Tween t); // 0x0000000180714D70-0x0000000180714DE0
		public static Vector3 PathGetPoint(this Tween t, float pathPercentage); // 0x0000000180715140-0x0000000180715350
		public static Vector3[] PathGetDrawPoints(this Tween t, int subdivisionsXSegment = 10 /* Metadata: 0x006A79CC */); // 0x0000000180714F50-0x0000000180715140
		public static float PathLength(this Tween t); // 0x0000000180715350-0x0000000180715530
	}
}

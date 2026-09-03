/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DG.Tweening;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening.Core
{
	internal static class TweenManager // TypeDefIndex: 13519
	{
		// Fields
		private const int _DefaultMaxTweeners = 200; // Metadata: 0x006A7B07
		private const int _DefaultMaxSequences = 50; // Metadata: 0x006A7B09
		private const string _MaxTweensReached = "Max Tweens reached: capacity has automatically been increased from #0 to #1. Use DOTween.SetTweensCapacity to set it manually at startup"; // Metadata: 0x006A7B0A
		private const float _EpsilonVsTimeCheck = 1E-06f; // Metadata: 0x006A7B94
		internal static bool isUnityEditor; // 0x00
		internal static bool isDebugBuild; // 0x01
		internal static int maxActive; // 0x04
		internal static int maxTweeners; // 0x08
		internal static int maxSequences; // 0x0C
		internal static bool hasActiveTweens; // 0x10
		internal static bool hasActiveDefaultTweens; // 0x11
		internal static bool hasActiveLateTweens; // 0x12
		internal static bool hasActiveFixedTweens; // 0x13
		internal static bool hasActiveManualTweens; // 0x14
		internal static int totActiveTweens; // 0x18
		internal static int totActiveDefaultTweens; // 0x1C
		internal static int totActiveLateTweens; // 0x20
		internal static int totActiveFixedTweens; // 0x24
		internal static int totActiveManualTweens; // 0x28
		internal static int totActiveTweeners; // 0x2C
		internal static int totActiveSequences; // 0x30
		internal static int totPooledTweeners; // 0x34
		internal static int totPooledSequences; // 0x38
		internal static int totTweeners; // 0x3C
		internal static int totSequences; // 0x40
		internal static bool isUpdateLoop; // 0x44
		internal static Tween[] _activeTweens; // 0x48
		private static Tween[] _pooledTweeners; // 0x50
		private static readonly Stack<Tween> _PooledSequences; // 0x58
		private static readonly List<Tween> _KillList; // 0x60
		private static readonly Dictionary<Tween, TweenLink> _TweenLinks; // 0x68
		private static int _totTweenLinks; // 0x70
		private static int _maxActiveLookupId; // 0x74
		private static bool _requiresActiveReorganization; // 0x78
		private static int _reorganizeFromId; // 0x7C
		private static int _minPooledTweenerId; // 0x80
		private static int _maxPooledTweenerId; // 0x84
		private static bool _despawnAllCalledFromUpdateLoopCallback; // 0x88
	
		// Nested types
		internal enum CapacityIncreaseMode // TypeDefIndex: 13520
		{
			TweenersAndSequences = 0,
			TweenersOnly = 1,
			SequencesOnly = 2
		}
	
		// Constructors
		static TweenManager(); // 0x0000000180738390-0x0000000180738640
	
		// Methods
		internal static TweenerCore<T1, T2, TPlugOptions> GetTweener<T1, T2, TPlugOptions>()
			where TPlugOptions : struct, IPlugOptions;
		internal static Sequence GetSequence(); // 0x0000000180735410-0x00000001807356A0
		internal static void SetUpdateType(Tween t, UpdateType updateType, bool isIndependentUpdate); // 0x00000001807375F0-0x0000000180737860
		internal static void AddActiveTweenToSequence(Tween t); // 0x0000000180732E30-0x0000000180732E80
		internal static int DespawnAll(); // 0x0000000180733550-0x00000001807337F0
		internal static void Despawn(Tween t, bool modifyActiveLists = true /* Metadata: 0x006A7AFA */); // 0x00000001807337F0-0x0000000180733E60
		internal static void PurgeAll(bool isApplicationQuitting); // 0x0000000180736310-0x0000000180736840
		internal static void PurgePools(); // 0x0000000180736840-0x00000001807369C0
		internal static void AddTweenLink(Tween t, TweenLink tweenLink); // 0x0000000180733110-0x00000001807332E0
		private static void RemoveTweenLink(Tween t); // 0x0000000180736DB0-0x0000000180736E80
		internal static void ResetCapacities(); // 0x00000001807370F0-0x0000000180737230
		internal static void SetCapacities(int tweenersCapacity, int sequencesCapacity); // 0x00000001807374D0-0x00000001807375F0
		internal static int Validate(); // 0x00000001807381C0-0x0000000180738390
		internal static void Update(UpdateType updateType, float deltaTime, float independentTime); // 0x0000000180737CD0-0x0000000180737F40
		internal static bool Update(Tween t, float deltaTime, float independentTime, bool isSingleTweenManualUpdate); // 0x0000000180737F40-0x00000001807381C0
		internal static int FilteredOperation(OperationType operationType, FilterType filterType, object id, bool optionalBool, float optionalFloat, object optionalObj = null, object[] optionalArray = null); // 0x00000001807343E0-0x00000001807351A0
		internal static bool Complete(Tween t, bool modifyActiveLists = true /* Metadata: 0x006A7AFB */, UpdateMode updateMode = UpdateMode.Goto /* Metadata: 0x006A7AFC */); // 0x0000000180733380-0x00000001807334A0
		internal static bool Flip(Tween t); // 0x00000001807351A0-0x00000001807351C0
		internal static void ForceInit(Tween t, bool isSequenced = false /* Metadata: 0x006A7AFD */); // 0x00000001807351C0-0x0000000180735280
		internal static bool Goto(Tween t, float to, bool andPlay = false /* Metadata: 0x006A7AFE */, UpdateMode updateMode = UpdateMode.Goto /* Metadata: 0x006A7AFF */); // 0x0000000180735980-0x0000000180735B00
		internal static bool Pause(Tween t); // 0x0000000180735EA0-0x0000000180735EF0
		internal static bool Play(Tween t); // 0x0000000180736280-0x0000000180736310
		internal static bool PlayBackwards(Tween t); // 0x0000000180735EF0-0x0000000180736100
		internal static bool PlayForward(Tween t); // 0x0000000180736100-0x0000000180736280
		internal static bool Restart(Tween t, bool includeDelay = true /* Metadata: 0x006A7B00 */, float changeDelayTo = -1f /* Metadata: 0x006A7B01 */); // 0x0000000180737230-0x0000000180737320
		internal static bool Rewind(Tween t, bool includeDelay = true /* Metadata: 0x006A7B05 */); // 0x0000000180737320-0x00000001807374D0
		internal static bool SmoothRewind(Tween t); // 0x0000000180737860-0x00000001807379E0
		internal static bool TogglePause(Tween t); // 0x00000001807379E0-0x0000000180737AF0
		internal static int TotalPooledTweens(); // 0x0000000180737BC0-0x0000000180737C20
		internal static int TotalPlayingTweens(); // 0x0000000180737AF0-0x0000000180737BC0
		internal static int TotalTweensById(object id, bool playingOnly); // 0x0000000180737C20-0x0000000180737CD0
		internal static List<Tween> GetActiveTweens(bool playing, List<Tween> fillableList = null); // 0x0000000180735280-0x0000000180735410
		internal static List<Tween> GetTweensById(object id, bool playingOnly, List<Tween> fillableList = null); // 0x00000001807356A0-0x00000001807357C0
		private static int DoGetTweensById(object id, bool playingOnly, bool addToList, List<Tween> fillableList); // 0x0000000180733E60-0x0000000180734090
		internal static List<Tween> GetTweensByTarget(object target, bool playingOnly, List<Tween> fillableList = null); // 0x00000001807357C0-0x0000000180735980
		private static void MarkForKilling(Tween t, bool isSingleTweenManualUpdate = false /* Metadata: 0x006A7B06 */); // 0x0000000180735D60-0x0000000180735EA0
		private static void EvaluateTweenLink(Tween t); // 0x0000000180734090-0x00000001807343E0
		private static void AddActiveTween(Tween t); // 0x0000000180732E80-0x0000000180733110
		private static void ReorganizeActiveTweens(); // 0x0000000180736E80-0x00000001807370F0
		private static void DespawnActiveTweens(List<Tween> tweens); // 0x00000001807334A0-0x0000000180733550
		private static void RemoveActiveTween(Tween t); // 0x00000001807369C0-0x0000000180736DB0
		private static void ClearTweenArray(Tween[] tweens); // 0x00000001807332E0-0x0000000180733380
		private static void IncreaseCapacities(CapacityIncreaseMode increaseMode); // 0x0000000180735B00-0x0000000180735CA0
		private static void ManageOnRewindCallbackWhenAlreadyRewinded(Tween t, bool isPlayBackwardsOrSmoothRewind); // 0x0000000180735CA0-0x0000000180735D60
	}
}

/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening
{
	public abstract class Tween : ABSSequentiable // TypeDefIndex: 13448
	{
		// Fields
		public float timeScale; // 0x28
		public bool isBackwards; // 0x2C
		internal bool isInverted; // 0x2D
		public object id; // 0x30
		public string stringId; // 0x38
		public int intId; // 0x40
		public object target; // 0x48
		internal UpdateType updateType; // 0x50
		internal bool isIndependentUpdate; // 0x54
		public TweenCallback onPlay; // 0x58
		public TweenCallback onPause; // 0x60
		public TweenCallback onRewind; // 0x68
		public TweenCallback onUpdate; // 0x70
		public TweenCallback onStepComplete; // 0x78
		public TweenCallback onComplete; // 0x80
		public TweenCallback onKill; // 0x88
		public TweenCallback<int> onWaypointChange; // 0x90
		internal bool isFrom; // 0x98
		internal bool isBlendable; // 0x99
		internal bool isRecyclable; // 0x9A
		internal bool isSpeedBased; // 0x9B
		internal bool autoKill; // 0x9C
		internal float duration; // 0xA0
		internal int loops; // 0xA4
		internal LoopType loopType; // 0xA8
		internal float delay; // 0xAC
		[CompilerGenerated]
		private bool _isRelative_k__BackingField; // 0xB0
		internal Ease easeType; // 0xB4
		internal EaseFunction customEase; // 0xB8
		public float easeOvershootOrAmplitude; // 0xC0
		public float easePeriod; // 0xC4
		public string debugTargetId; // 0xC8
		internal Type typeofT1; // 0xD0
		internal Type typeofT2; // 0xD8
		internal Type typeofTPlugOptions; // 0xE0
		[CompilerGenerated]
		private bool _active_k__BackingField; // 0xE8
		internal bool isSequenced; // 0xE9
		internal Sequence sequenceParent; // 0xF0
		internal int activeId; // 0xF8
		internal SpecialStartupMode specialStartupMode; // 0xFC
		internal bool creationLocked; // 0x100
		internal bool startupDone; // 0x101
		[CompilerGenerated]
		private bool _playedOnce_k__BackingField; // 0x102
		[CompilerGenerated]
		private float _position_k__BackingField; // 0x104
		internal float fullDuration; // 0x108
		internal int completedLoops; // 0x10C
		internal bool isPlaying; // 0x110
		internal bool isComplete; // 0x111
		internal float elapsedDelay; // 0x114
		internal bool delayComplete; // 0x118
		internal int miscInt; // 0x11C
	
		// Properties
		public bool isRelative { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x00000001807186D0-0x00000001807186E0 0x0000000180718740-0x0000000180718750
		public bool active { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000180718600-0x0000000180718610 0x0000000180718700-0x0000000180718710
		public float fullPosition { get; set; } // 0x0000000180718610-0x00000001807186B0 0x0000000180718710-0x0000000180718740
		public bool hasLoops { get; } // 0x00000001807186B0-0x00000001807186D0 
		public bool playedOnce { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001807186E0-0x00000001807186F0 0x0000000180718750-0x0000000180718760
		public float position { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x00000001807186F0-0x0000000180718700 0x0000000180718760-0x0000000180718770
	
		// Constructors
		protected Tween(); // 0x00000001807185D0-0x0000000180718600
	
		// Methods
		internal virtual void Reset(); // 0x0000000180718420-0x00000001807185C0
		internal abstract bool Validate();
		internal virtual float UpdateDelay(float elapsed); // 0x00000001807185C0-0x00000001807185D0
		internal abstract bool Startup();
		internal abstract bool ApplyTween(float prevPosition, int prevCompletedLoops, int newCompletedSteps, bool useInversePosition, UpdateMode updateMode, UpdateNotice updateNotice);
		internal static bool DoGoto(Tween t, float toPosition, int toCompletedLoops, UpdateMode updateMode); // 0x0000000180717EC0-0x0000000180718280
		internal static bool OnTweenCallback(TweenCallback callback, Tween t); // 0x0000000180718280-0x0000000180718420
		internal static bool OnTweenCallback<T>(TweenCallback<T> callback, Tween t, T param);
	}
}

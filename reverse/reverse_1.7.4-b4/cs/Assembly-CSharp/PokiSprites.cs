/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class PokiSprites // TypeDefIndex: 1445
{
	// Fields
	private static readonly string[] OTA_PREFIXES; // 0x00
	private static readonly Dictionary<string, Sprite> _remote; // 0x08
	private static readonly HashSet<string> _missing; // 0x10
	private static readonly HashSet<string> _inFlight; // 0x18
	private static readonly Dictionary<string, int> _loadFailures; // 0x20
	private static readonly HashSet<string> _failedHard; // 0x28
	private static bool _warmed; // 0x30
	private static bool _warming; // 0x31
	private static readonly HashSet<string> _available; // 0x38
	private static bool _availableKnown; // 0x40
	private static readonly Dictionary<string, Sprite> _placeholders; // 0x48
	private static readonly Dictionary<Sprite, string> _placeholderPath; // 0x50
	private static readonly HashSet<string> _handedOut; // 0x58
	private static Texture2D _blankTex; // 0x60
	private static float _nextWarmRetry; // 0x68

	// Nested types
	private class Runner : MonoBehaviour // TypeDefIndex: 1446
	{
		// Fields
		private static Runner _instance; // 0x00

		// Constructors
		public Runner(); // 0x000000018028A560-0x000000018028A5B0

		// Methods
		public static void Run(IEnumerator routine); // 0x00000001807DC080-0x00000001807DC2A0
	}

	[CompilerGenerated]
	private sealed class _ApplyWhenReady_d__28 : IEnumerator<object> // TypeDefIndex: 1447
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string resourcePath; // 0x20
		public Image target; // 0x28
		public Sprite handed; // 0x30
		private float _deadline_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ApplyWhenReady_d__28(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001807DC2A0-0x00000001807DC850
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807DC850-0x00000001807DC890
	}

	[CompilerGenerated]
	private sealed class _LoadRoutine_d__36 : IEnumerator<object> // TypeDefIndex: 1448
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string resourcePath; // 0x20
		private string[] __7__wrap1; // 0x28
		private int __7__wrap2; // 0x30
		private string _address_5__4; // 0x38
		private AsyncOperationHandle<IList<IResourceLocation>> _locHandle_5__5; // 0x40
		private AsyncOperationHandle<Sprite> _h_5__6; // 0x58

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadRoutine_d__36(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001807DC890-0x00000001807DC9D0
		private bool MoveNext(); // 0x00000001807DC9D0-0x00000001807DDC00
		private void __m__Finally1(); // 0x00000001807DDC00-0x00000001807DDC90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807DDC90-0x00000001807DDCD0
	}

	[CompilerGenerated]
	private sealed class _WarmAsync_d__29 : IEnumerator<object> // TypeDefIndex: 1449
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public bool force; // 0x20
		private AsyncOperationHandle<IList<IResourceLocation>> _locHandle_5__2; // 0x28
		private int _loaded_5__3; // 0x40
		private List<string> _arrived_5__4; // 0x48
		private IEnumerator<IResourceLocation> __7__wrap4; // 0x50
		private IResourceLocation _loc_5__6; // 0x58
		private string _key_5__7; // 0x60
		private AsyncOperationHandle<Sprite> _h_5__8; // 0x68

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WarmAsync_d__29(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001807DDCD0-0x00000001807DDF60
		private bool MoveNext(); // 0x00000001807DDF60-0x00000001807DF510
		private void __m__Finally1(); // 0x00000001807DF510-0x00000001807DF570
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807DF570-0x00000001807DF5B0
	}

	// Constructors
	static PokiSprites(); // 0x00000001807DB560-0x00000001807DC080

	// Methods
	public static Sprite Load(string resourcePath); // 0x00000001807D8B90-0x00000001807D8F70
	public static bool IsPlaceholder(Sprite sprite); // 0x00000001807D8F70-0x00000001807D90D0
	public static bool IsKnownMissing(string resourcePath); // 0x00000001807D90D0-0x00000001807D91C0
	private static Sprite Placeholder(string resourcePath); // 0x00000001807D91C0-0x00000001807D9840
	private static void Reconcile(ICollection<string> paths); // 0x00000001807D9840-0x00000001807DA330
	private static void Reconcile(string path); // 0x00000001807DA330-0x00000001807DA3D0
	private static void EnsureWarm(); // 0x00000001807DA3D0-0x00000001807DA4A0
	public static void Apply(Image target, string resourcePath, Sprite fallback = null); // 0x00000001807DA4A0-0x00000001807DA8C0
	[IteratorStateMachine(typeof(_ApplyWhenReady_d__28))]
	private static IEnumerator ApplyWhenReady(Image target, string resourcePath, Sprite handed); // 0x00000001807DA8C0-0x00000001807DAA20
	[IteratorStateMachine(typeof(_WarmAsync_d__29))]
	public static IEnumerator WarmAsync(bool force = false /* Metadata: 0x005F0F69 */); // 0x00000001807DAA20-0x00000001807DAA70
	public static void WarmInBackground(); // 0x00000001807DAA70-0x00000001807DAB00
	public static void Invalidate(); // 0x00000001807DAB00-0x00000001807DAF00
	private static bool IsOtaPath(string resourcePath); // 0x00000001807DAF00-0x00000001807DB0D0
	private static string ResourceKeyOf(string address); // 0x00000001807DB0D0-0x00000001807DB2A0
	private static string[] AddressCandidates(string resourcePath); // 0x00000001807DB2A0-0x00000001807DB390
	private static void StartLoad(string resourcePath); // 0x00000001807DB390-0x00000001807DB4C0
	[IteratorStateMachine(typeof(_LoadRoutine_d__36))]
	private static IEnumerator LoadRoutine(string resourcePath); // 0x00000001807DB4C0-0x00000001807DB560
}


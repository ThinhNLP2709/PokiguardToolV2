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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class PokiSprites // TypeDefIndex: 1443
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
	private class Runner : MonoBehaviour // TypeDefIndex: 1444
	{
		// Fields
		private static Runner _instance; // 0x00

		// Constructors
		public Runner(); // 0x000000018028A560-0x000000018028A5B0

		// Methods
		public static void Run(IEnumerator routine); // 0x00000001807DA010-0x00000001807DA230
	}

	[CompilerGenerated]
	private sealed class _ApplyWhenReady_d__28 : IEnumerator<object> // TypeDefIndex: 1445
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001807DA230-0x00000001807DA7E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807DA7E0-0x00000001807DA820
	}

	[CompilerGenerated]
	private sealed class _LoadRoutine_d__36 : IEnumerator<object> // TypeDefIndex: 1446
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
		void IDisposable.Dispose(); // 0x00000001807DA820-0x00000001807DA960
		private bool MoveNext(); // 0x00000001807DA960-0x00000001807DBB90
		private void __m__Finally1(); // 0x00000001807DBB90-0x00000001807DBC20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807DBC20-0x00000001807DBC60
	}

	[CompilerGenerated]
	private sealed class _WarmAsync_d__29 : IEnumerator<object> // TypeDefIndex: 1447
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
		void IDisposable.Dispose(); // 0x00000001807DBC60-0x00000001807DBEF0
		private bool MoveNext(); // 0x00000001807DBEF0-0x00000001807DD4A0
		private void __m__Finally1(); // 0x00000001807DD4A0-0x00000001807DD500
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001807DD500-0x00000001807DD540
	}

	// Constructors
	static PokiSprites(); // 0x00000001807D94F0-0x00000001807DA010

	// Methods
	public static Sprite Load(string resourcePath); // 0x00000001807D6B20-0x00000001807D6F00
	public static bool IsPlaceholder(Sprite sprite); // 0x00000001807D6F00-0x00000001807D7060
	public static bool IsKnownMissing(string resourcePath); // 0x00000001807D7060-0x00000001807D7150
	private static Sprite Placeholder(string resourcePath); // 0x00000001807D7150-0x00000001807D77D0
	private static void Reconcile(ICollection<string> paths); // 0x00000001807D77D0-0x00000001807D82C0
	private static void Reconcile(string path); // 0x00000001807D82C0-0x00000001807D8360
	private static void EnsureWarm(); // 0x00000001807D8360-0x00000001807D8430
	public static void Apply(Image target, string resourcePath, Sprite fallback = null); // 0x00000001807D8430-0x00000001807D8850
	[IteratorStateMachine(typeof(_ApplyWhenReady_d__28))]
	private static IEnumerator ApplyWhenReady(Image target, string resourcePath, Sprite handed); // 0x00000001807D8850-0x00000001807D89B0
	[IteratorStateMachine(typeof(_WarmAsync_d__29))]
	public static IEnumerator WarmAsync(bool force = false /* Metadata: 0x005EFB9C */); // 0x00000001807D89B0-0x00000001807D8A00
	public static void WarmInBackground(); // 0x00000001807D8A00-0x00000001807D8A90
	public static void Invalidate(); // 0x00000001807D8A90-0x00000001807D8E90
	private static bool IsOtaPath(string resourcePath); // 0x00000001807D8E90-0x00000001807D9060
	private static string ResourceKeyOf(string address); // 0x00000001807D9060-0x00000001807D9230
	private static string[] AddressCandidates(string resourcePath); // 0x00000001807D9230-0x00000001807D9320
	private static void StartLoad(string resourcePath); // 0x00000001807D9320-0x00000001807D9450
	[IteratorStateMachine(typeof(_LoadRoutine_d__36))]
	private static IEnumerator LoadRoutine(string resourcePath); // 0x00000001807D9450-0x00000001807D94F0
}


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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class PokiSprites // TypeDefIndex: 1064
{
	// Fields
	public const string LABEL = "sprites"; // Metadata: 0x0068C39A
	public const string REMOTE_ROOT = "Assets/RemoteContent/"; // Metadata: 0x0068C3A2
	private static readonly string[] OTA_PREFIXES; // 0x00
	private static readonly Dictionary<string, Sprite> _remote; // 0x08
	private static readonly HashSet<string> _missing; // 0x10
	private static readonly HashSet<string> _inFlight; // 0x18
	private static readonly Dictionary<string, int> _loadFailures; // 0x20
	private static readonly HashSet<string> _failedHard; // 0x28
	private const int MAX_REMOTE_LOAD_FAILURES = 3; // Metadata: 0x0068C3B8
	private static bool _warmed; // 0x30
	private static bool _warming; // 0x31
	private static readonly HashSet<string> _available; // 0x38
	private static bool _availableKnown; // 0x40
	private static readonly Dictionary<string, Sprite> _placeholders; // 0x48
	private static readonly Dictionary<Sprite, string> _placeholderPath; // 0x50
	private static readonly HashSet<string> _handedOut; // 0x58
	private static Texture2D _blankTex; // 0x60
	private static float _nextWarmRetry; // 0x68

	// Properties
	public static int RemoteCount { get; } // 0x0000000180514B70-0x0000000180514BD0 

	// Nested types
	private class Runner : MonoBehaviour // TypeDefIndex: 1065
	{
		// Fields
		private static Runner _instance; // 0x00

		// Constructors
		public Runner(); // 0x00000001802EBA70-0x00000001802EBAF0

		// Methods
		public static void Run(IEnumerator routine); // 0x000000018051EAB0-0x000000018051EBF0
	}

	[CompilerGenerated]
	private sealed class _ApplyWhenReady_d__28 : IEnumerator<object> // TypeDefIndex: 1066
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string resourcePath; // 0x20
		public Image target; // 0x28
		public Sprite handed; // 0x30
		private float _deadline_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ApplyWhenReady_d__28(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018051EBF0-0x000000018051EEC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018051EEC0-0x000000018051EF00
	}

	[CompilerGenerated]
	private sealed class _LoadRoutine_d__36 : IEnumerator<object> // TypeDefIndex: 1067
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadRoutine_d__36(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180520C80-0x0000000180520D30
		private bool MoveNext(); // 0x000000018051FE10-0x0000000180520C40
		private void __m__Finally1(); // 0x0000000180520D30-0x0000000180520DC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180520C40-0x0000000180520C80
	}

	[CompilerGenerated]
	private sealed class _WarmAsync_d__29 : IEnumerator<object> // TypeDefIndex: 1068
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WarmAsync_d__29(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805221E0-0x0000000180522340
		private bool MoveNext(); // 0x0000000180521180-0x00000001805221A0
		private void __m__Finally1(); // 0x0000000180522340-0x0000000180522390
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805221A0-0x00000001805221E0
	}

	// Constructors
	static PokiSprites(); // 0x0000000180514470-0x0000000180514B70

	// Methods
	public static Sprite Load(string resourcePath); // 0x00000001805132E0-0x00000001805135E0
	public static bool IsPlaceholder(Sprite sprite); // 0x00000001805131B0-0x0000000180513270
	public static bool IsKnownMissing(string resourcePath); // 0x0000000180512FD0-0x00000001805130B0
	private static Sprite Placeholder(string resourcePath); // 0x00000001805135E0-0x0000000180513960
	private static void Reconcile(ICollection<string> paths); // 0x0000000180513960-0x0000000180514110
	private static void Reconcile(string path); // 0x0000000180514110-0x00000001805141B0
	private static void EnsureWarm(); // 0x0000000180512BB0-0x0000000180512CD0
	public static void Apply(Image target, string resourcePath, Sprite fallback = null); // 0x00000001805129B0-0x0000000180512BB0
	[IteratorStateMachine(typeof(_ApplyWhenReady_d__28))]
	private static IEnumerator ApplyWhenReady(Image target, string resourcePath, Sprite handed); // 0x0000000180512900-0x00000001805129B0
	[IteratorStateMachine(typeof(_WarmAsync_d__29))]
	public static IEnumerator WarmAsync(bool force = false /* Metadata: 0x0068C399 */); // 0x0000000180514380-0x00000001805143E0
	public static void WarmInBackground(); // 0x00000001805143E0-0x0000000180514470
	public static void Invalidate(); // 0x0000000180512CD0-0x0000000180512FD0
	private static bool IsOtaPath(string resourcePath); // 0x00000001805130B0-0x00000001805131B0
	private static string ResourceKeyOf(string address); // 0x00000001805141B0-0x00000001805142A0
	private static string[] AddressCandidates(string resourcePath); // 0x0000000180512820-0x0000000180512900
	private static void StartLoad(string resourcePath); // 0x00000001805142A0-0x0000000180514380
	[IteratorStateMachine(typeof(_LoadRoutine_d__36))]
	private static IEnumerator LoadRoutine(string resourcePath); // 0x0000000180513270-0x00000001805132E0
}


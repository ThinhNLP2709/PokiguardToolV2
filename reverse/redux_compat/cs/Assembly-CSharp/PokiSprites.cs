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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class PokiSprites // TypeDefIndex: 863
{
	// Fields
	public const string LABEL = "sprites"; // Metadata: 0x0064CBFD
	public const string REMOTE_ROOT = "Assets/RemoteContent/"; // Metadata: 0x0064CC05
	private static readonly string[] OTA_PREFIXES; // 0x00
	private static readonly Dictionary<string, Sprite> _remote; // 0x08
	private static readonly HashSet<string> _missing; // 0x10
	private static readonly HashSet<string> _inFlight; // 0x18
	private static bool _warmed; // 0x20
	private static bool _warming; // 0x21
	private static readonly HashSet<string> _available; // 0x28
	private static bool _availableKnown; // 0x30
	private static readonly Dictionary<string, Sprite> _placeholders; // 0x38
	private static readonly Dictionary<Sprite, string> _placeholderPath; // 0x40
	private static readonly HashSet<string> _handedOut; // 0x48
	private static Texture2D _blankTex; // 0x50
	private static float _nextWarmRetry; // 0x58

	// Properties
	public static int RemoteCount { get; } // 0x000000018043FEA0-0x000000018043FF00 

	// Nested types
	private class Runner : MonoBehaviour // TypeDefIndex: 864
	{
		// Fields
		private static Runner _instance; // 0x00

		// Constructors
		public Runner(); // 0x00000001802E7A70-0x00000001802E7BC0

		// Methods
		public static void Run(IEnumerator routine); // 0x0000000180447C30-0x0000000180447D70
	}

	[CompilerGenerated]
	private sealed class _ApplyWhenReady_d__25 : IEnumerator<object> // TypeDefIndex: 865
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string resourcePath; // 0x20
		public Image target; // 0x28
		private float _deadline_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ApplyWhenReady_d__25(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180447D70-0x0000000180447F70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180447F70-0x0000000180447FB0
	}

	[CompilerGenerated]
	private sealed class _LoadRoutine_d__33 : IEnumerator<object> // TypeDefIndex: 866
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadRoutine_d__33(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180449E20-0x0000000180449ED0
		private bool MoveNext(); // 0x00000001804490C0-0x0000000180449DE0
		private void __m__Finally1(); // 0x0000000180449ED0-0x0000000180449F60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180449DE0-0x0000000180449E20
	}

	[CompilerGenerated]
	private sealed class _WarmAsync_d__26 : IEnumerator<object> // TypeDefIndex: 867
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WarmAsync_d__26(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018044B230-0x000000018044B390
		private bool MoveNext(); // 0x000000018044A1D0-0x000000018044B1F0
		private void __m__Finally1(); // 0x000000018044B390-0x000000018044B3E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018044B1F0-0x000000018044B230
	}

	// Constructors
	static PokiSprites(); // 0x000000018043F9D0-0x000000018043FEA0

	// Methods
	public static Sprite Load(string resourcePath); // 0x000000018043E870-0x000000018043EB40
	public static bool IsPlaceholder(Sprite sprite); // 0x000000018043E740-0x000000018043E800
	public static bool IsKnownMissing(string resourcePath); // 0x000000018043E560-0x000000018043E640
	private static Sprite Placeholder(string resourcePath); // 0x000000018043EB40-0x000000018043EEC0
	private static void Reconcile(ICollection<string> paths); // 0x000000018043EEC0-0x000000018043F670
	private static void Reconcile(string path); // 0x000000018043F670-0x000000018043F710
	private static void EnsureWarm(); // 0x000000018043E180-0x000000018043E2A0
	public static void Apply(Image target, string resourcePath, Sprite fallback = null); // 0x000000018043DFA0-0x000000018043E180
	[IteratorStateMachine(typeof(_ApplyWhenReady_d__25))]
	private static IEnumerator ApplyWhenReady(Image target, string resourcePath); // 0x000000018043DF10-0x000000018043DFA0
	[IteratorStateMachine(typeof(_WarmAsync_d__26))]
	public static IEnumerator WarmAsync(bool force = false /* Metadata: 0x0064CBFC */); // 0x000000018043F8E0-0x000000018043F940
	public static void WarmInBackground(); // 0x000000018043F940-0x000000018043F9D0
	public static void Invalidate(); // 0x000000018043E2A0-0x000000018043E560
	private static bool IsOtaPath(string resourcePath); // 0x000000018043E640-0x000000018043E740
	private static string ResourceKeyOf(string address); // 0x000000018043F710-0x000000018043F800
	private static string[] AddressCandidates(string resourcePath); // 0x000000018043DE30-0x000000018043DF10
	private static void StartLoad(string resourcePath); // 0x000000018043F800-0x000000018043F8E0
	[IteratorStateMachine(typeof(_LoadRoutine_d__33))]
	private static IEnumerator LoadRoutine(string resourcePath); // 0x000000018043E800-0x000000018043E870
}


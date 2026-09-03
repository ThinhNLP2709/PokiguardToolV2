/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ImageLoader : MonoBehaviour // TypeDefIndex: 1687
{
	// Fields
	public RawImage rawImage; // 0x20
	public float jumpHeight; // 0x28
	public float jumpSpeed; // 0x2C
	private Vector3 initialPosition; // 0x30
	private bool isImageLoaded; // 0x3C
	private static readonly Dictionary<string, Texture2D> _textureCache; // 0x00
	private const int CACHE_LIMIT = 64; // Metadata: 0x0064D985
	private static readonly List<string> _cacheOrder; // 0x08

	// Nested types
	[CompilerGenerated]
	private sealed class _LoadImageFromURL_d__15 : IEnumerator<object> // TypeDefIndex: 1688
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ImageLoader __4__this; // 0x20
		public string url; // 0x28
		public RawImage r; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadImageFromURL_d__15(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805E5680-0x00000001805E56F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E56F0-0x00000001805E5730
	}

	[CompilerGenerated]
	private sealed class _LoadImageFromURL_d__16 : IEnumerator<object> // TypeDefIndex: 1689
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ImageLoader __4__this; // 0x20
		public string url; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadImageFromURL_d__16(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805E5730-0x00000001805E57A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E57A0-0x00000001805E57E0
	}

	[CompilerGenerated]
	private sealed class _LoadInto_d__17 : IEnumerator<object> // TypeDefIndex: 1690
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RawImage target; // 0x20
		public string url; // 0x28
		public ImageLoader __4__this; // 0x30
		private UnityWebRequest _www_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadInto_d__17(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805E6020-0x00000001805E6100
		private bool MoveNext(); // 0x00000001805E5BB0-0x00000001805E5FE0
		private void __m__Finally1(); // 0x00000001805E6100-0x00000001805E6150
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E5FE0-0x00000001805E6020
	}

	// Constructors
	public ImageLoader(); // 0x00000001805DDF00-0x00000001805DDF20
	static ImageLoader(); // 0x00000001805DDE10-0x00000001805DDF00

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetCacheOnPlay(); // 0x00000001805DD9A0-0x00000001805DDA40
	private static bool TryGetCached(string url, out Texture2D tex); // 0x00000001805DDC00-0x00000001805DDD60
	private static void Cache(string url, Texture2D tex); // 0x00000001805DD3D0-0x00000001805DD670
	private void Start(); // 0x00000001805DDB60-0x00000001805DDC00
	private void Update(); // 0x00000001805DDD60-0x00000001805DDE10
	public void StartLoadingImage(string url); // 0x00000001805DDA40-0x00000001805DDB60
	public RawImage LoadingImage(string url, RawImage r); // 0x00000001805DD860-0x00000001805DD9A0
	[IteratorStateMachine(typeof(_LoadImageFromURL_d__15))]
	public IEnumerator LoadImageFromURL(string url, RawImage r); // 0x00000001805DD670-0x00000001805DD720
	[IteratorStateMachine(typeof(_LoadImageFromURL_d__16))]
	public IEnumerator LoadImageFromURL(string url); // 0x00000001805DD720-0x00000001805DD7B0
	[IteratorStateMachine(typeof(_LoadInto_d__17))]
	private IEnumerator LoadInto(string url, RawImage target); // 0x00000001805DD7B0-0x00000001805DD860
}


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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ImageLoader : MonoBehaviour // TypeDefIndex: 1960
{
	// Fields
	public RawImage rawImage; // 0x20
	public float jumpHeight; // 0x28
	public float jumpSpeed; // 0x2C
	private Vector3 initialPosition; // 0x30
	private bool isImageLoaded; // 0x3C
	private static readonly Dictionary<string, Texture2D> _textureCache; // 0x00
	private const int CACHE_LIMIT = 64; // Metadata: 0x0068DDB4
	private static readonly List<string> _cacheOrder; // 0x08

	// Nested types
	[CompilerGenerated]
	private sealed class _LoadImageFromURL_d__15 : IEnumerator<object> // TypeDefIndex: 1961
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ImageLoader __4__this; // 0x20
		public string url; // 0x28
		public RawImage r; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadImageFromURL_d__15(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018070CF20-0x000000018070CF90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018070CF90-0x000000018070CFD0
	}

	[CompilerGenerated]
	private sealed class _LoadImageFromURL_d__16 : IEnumerator<object> // TypeDefIndex: 1962
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ImageLoader __4__this; // 0x20
		public string url; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadImageFromURL_d__16(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018070CFD0-0x000000018070D040
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018070D040-0x000000018070D080
	}

	[CompilerGenerated]
	private sealed class _LoadInto_d__17 : IEnumerator<object> // TypeDefIndex: 1963
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RawImage target; // 0x20
		public string url; // 0x28
		public ImageLoader __4__this; // 0x30
		private UnityWebRequest _www_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadInto_d__17(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018070D8C0-0x000000018070D9A0
		private bool MoveNext(); // 0x000000018070D450-0x000000018070D880
		private void __m__Finally1(); // 0x000000018070D9A0-0x000000018070D9F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018070D880-0x000000018070D8C0
	}

	// Constructors
	public ImageLoader(); // 0x0000000180707E10-0x0000000180707E30
	static ImageLoader(); // 0x0000000180707D20-0x0000000180707E10

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetCacheOnPlay(); // 0x00000001807078B0-0x0000000180707950
	private static bool TryGetCached(string url, out Texture2D tex); // 0x0000000180707B10-0x0000000180707C70
	private static void Cache(string url, Texture2D tex); // 0x00000001807072E0-0x0000000180707580
	private void Start(); // 0x0000000180707A70-0x0000000180707B10
	private void Update(); // 0x0000000180707C70-0x0000000180707D20
	public void StartLoadingImage(string url); // 0x0000000180707950-0x0000000180707A70
	public RawImage LoadingImage(string url, RawImage r); // 0x0000000180707770-0x00000001807078B0
	[IteratorStateMachine(typeof(_LoadImageFromURL_d__15))]
	public IEnumerator LoadImageFromURL(string url, RawImage r); // 0x0000000180707580-0x0000000180707630
	[IteratorStateMachine(typeof(_LoadImageFromURL_d__16))]
	public IEnumerator LoadImageFromURL(string url); // 0x0000000180707630-0x00000001807076C0
	[IteratorStateMachine(typeof(_LoadInto_d__17))]
	private IEnumerator LoadInto(string url, RawImage target); // 0x00000001807076C0-0x0000000180707770
}


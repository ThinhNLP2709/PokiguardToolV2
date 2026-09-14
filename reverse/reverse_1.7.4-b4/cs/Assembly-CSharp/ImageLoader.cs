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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ImageLoader : MonoBehaviour // TypeDefIndex: 2349
{
	// Fields
	public RawImage rawImage; // 0x20
	public float jumpHeight; // 0x28
	public float jumpSpeed; // 0x2C
	private Vector3 initialPosition; // 0x30
	private bool isImageLoaded; // 0x3C
	private static readonly Dictionary<string, Texture2D> _textureCache; // 0x00
	private const int CACHE_LIMIT = 64; // Metadata: 0x005F1F46
	private static readonly List<string> _cacheOrder; // 0x08

	// Nested types
	[CompilerGenerated]
	private sealed class _LoadImageFromURL_d__15 : IEnumerator<object> // TypeDefIndex: 2350
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ImageLoader __4__this; // 0x20
		public string url; // 0x28
		public RawImage r; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadImageFromURL_d__15(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180B4ABF0-0x0000000180B4ACA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B4ACA0-0x0000000180B4ACE0
	}

	[CompilerGenerated]
	private sealed class _LoadImageFromURL_d__16 : IEnumerator<object> // TypeDefIndex: 2351
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ImageLoader __4__this; // 0x20
		public string url; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadImageFromURL_d__16(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180B4ACE0-0x0000000180B4AD90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B4AD90-0x0000000180B4ADD0
	}

	[CompilerGenerated]
	private sealed class _LoadInto_d__17 : IEnumerator<object> // TypeDefIndex: 2352
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RawImage target; // 0x20
		public string url; // 0x28
		public ImageLoader __4__this; // 0x30
		private UnityWebRequest _www_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadInto_d__17(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180B4ADD0-0x0000000180B4AF00
		private bool MoveNext(); // 0x0000000180B4AF00-0x0000000180B4B640
		private void __m__Finally1(); // 0x0000000180B4B640-0x0000000180B4B6A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B4B6A0-0x0000000180B4B6E0
	}

	// Constructors
	public ImageLoader(); // 0x0000000180B4A900-0x0000000180B4A960
	static ImageLoader(); // 0x0000000180B4A960-0x0000000180B4ABF0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetCacheOnPlay(); // 0x0000000180B496A0-0x0000000180B49750
	private static bool TryGetCached(string url, out Texture2D tex); // 0x0000000180B49750-0x0000000180B49990
	private static void Cache(string url, Texture2D tex); // 0x0000000180B49990-0x0000000180B49DB0
	private void Start(); // 0x0000000180B49DB0-0x0000000180B49F20
	private void Update(); // 0x0000000180B49F20-0x0000000180B4A060
	public void StartLoadingImage(string url); // 0x0000000180B4A060-0x0000000180B4A2A0
	public RawImage LoadingImage(string url, RawImage r); // 0x0000000180B4A2A0-0x0000000180B4A530
	[IteratorStateMachine(typeof(_LoadImageFromURL_d__15))]
	public IEnumerator LoadImageFromURL(string url, RawImage r); // 0x0000000180B4A530-0x0000000180B4A690
	[IteratorStateMachine(typeof(_LoadImageFromURL_d__16))]
	public IEnumerator LoadImageFromURL(string url); // 0x0000000180B4A690-0x0000000180B4A7A0
	[IteratorStateMachine(typeof(_LoadInto_d__17))]
	private IEnumerator LoadInto(string url, RawImage target); // 0x0000000180B4A7A0-0x0000000180B4A900
}


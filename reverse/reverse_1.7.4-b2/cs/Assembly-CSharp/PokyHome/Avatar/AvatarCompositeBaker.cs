/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.Avatar
{
	[DisallowMultipleComponent]
	public sealed class AvatarCompositeBaker : MonoBehaviour // TypeDefIndex: 2447
	{
		// Fields
		private const int MAX_PARALLEL_LOADS = 4; // Metadata: 0x0068F522
		private static AvatarCompositeBaker _instance; // 0x00
		private static bool _quitting; // 0x08
		private readonly Queue<Job> _queue; // 0x20
		private int _loading; // 0x28
		private readonly Queue<Job> _ready; // 0x30
		private readonly Dictionary<string, Job> _pending; // 0x38
		[CompilerGenerated]
		private static RectInt _LastCrop_k__BackingField; // 0x0C
		private static Material _spritesMat; // 0x20
		private static bool _orientationChecked; // 0x28
		private static bool _flipRows; // 0x29
		private static float[] _toLinear; // 0x30
		private static byte[] _toSrgb; // 0x38
		private const int SRGB_TABLE = 4096; // Metadata: 0x0068F523
		private static readonly Dictionary<Sprite, Rect> _contentBounds; // 0x40
	
		// Properties
		public static AvatarCompositeBaker Instance { get; } // 0x00000001807F9CF0-0x00000001807F9E80 
		public static RectInt LastCrop { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001807F9E80-0x00000001807F9EE0 0x00000001807FA090-0x00000001807FA0F0
		private static Material SpritesMaterial { get; } // 0x00000001807F9EE0-0x00000001807FA090 
		public static bool? FlipDetected { get; } // 0x00000001807F9C70-0x00000001807F9CF0 
	
		// Nested types
		private sealed class Job // TypeDefIndex: 2448
		{
			// Fields
			public string cacheKey; // 0x10
			public AvatarLayerSpec spec; // 0x18
			public AvatarCompositeOptions options; // 0x20
			public List<Action<Sprite>> callbacks; // 0x28
			public AvatarLayerResult[] results; // 0x30
	
			// Constructors
			public Job(); // 0x0000000180804AD0-0x0000000180804B50
		}
	
		[CompilerGenerated]
		private sealed class _LoadJob_d__14 : IEnumerator<object> // TypeDefIndex: 2449
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public Job job; // 0x20
			public AvatarCompositeBaker __4__this; // 0x28
			private AvatarLayerResult[] _results_5__2; // 0x30
			private float _deadline_5__3; // 0x38
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _LoadJob_d__14(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
			private bool MoveNext(); // 0x000000018080B670-0x000000018080B980
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018080B980-0x000000018080B9C0
		}
	
		[CompilerGenerated]
		private sealed class _Pump_d__13 : IEnumerator<object> // TypeDefIndex: 2450
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public AvatarCompositeBaker __4__this; // 0x20
			private WaitForSecondsRealtime _idle_5__2; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _Pump_d__13(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
			private bool MoveNext(); // 0x000000018080C4B0-0x000000018080C6D0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018080C6D0-0x000000018080C710
		}
	
		// Constructors
		public AvatarCompositeBaker(); // 0x00000001807F9B00-0x00000001807F9C70
		static AvatarCompositeBaker(); // 0x00000001807F9A70-0x00000001807F9B00
	
		// Methods
		private void Awake(); // 0x00000001807F6930-0x00000001807F6A00
		private void OnApplicationQuit(); // 0x00000001807F8D40-0x00000001807F8D90
		public void Enqueue(string cacheKey, AvatarLayerSpec spec, AvatarCompositeOptions options, Action<Sprite> onReady); // 0x00000001807F7CE0-0x00000001807F7EE0
		[IteratorStateMachine(typeof(_Pump_d__13))]
		private IEnumerator Pump(); // 0x00000001807F8D90-0x00000001807F8E00
		[IteratorStateMachine(typeof(_LoadJob_d__14))]
		private IEnumerator LoadJob(Job job); // 0x00000001807F88B0-0x00000001807F8940
		private void BakeJob(Job job); // 0x00000001807F7210-0x00000001807F7880
		public static AvatarLayerFit FitOf(string resourcePath); // 0x00000001807F8700-0x00000001807F87C0
		public static Sprite BakeFromSprites(IList<Sprite> ordered, AvatarCompositeOptions options, string logKey, out Texture2D texture, bool keepReadable = false /* Metadata: 0x0068F520 */, IList<AvatarLayerFit> fits = null); // 0x00000001807F6A00-0x00000001807F7210
		private static Color32[] Render(IList<Sprite> ordered, int size, Material mat, IList<AvatarLayerFit> fits = null); // 0x00000001807F9200-0x00000001807F9750
		private static void EnsureOrientation(Material mat); // 0x00000001807F7EE0-0x00000001807F8440
		private static void DrawLayer(Sprite sp, Material mat, AvatarLayerFit fit = AvatarLayerFit.Frame /* Metadata: 0x0068F521 */); // 0x00000001807F7920-0x00000001807F7CE0
		private static void EnsureTables(); // 0x00000001807F8440-0x00000001807F8700
		private static byte UnpremulChannel(byte c, byte a); // 0x00000001807F9830-0x00000001807F9900
		private static bool Unpremultiply(Color32[] px, int size); // 0x00000001807F9900-0x00000001807F9A70
		private static Texture2D MakeTexture(Color32[] px, int size, bool keepReadable); // 0x00000001807F8AC0-0x00000001807F8BD0
		public static bool TryGetContentBounds(Sprite sprite, out Rect normalized); // 0x00000001807F9750-0x00000001807F9830
		private static Rect MeasureContent(Color32[] px, int size); // 0x00000001807F8BD0-0x00000001807F8D40
		private static void RememberContent(Sprite sprite, Rect content); // 0x00000001807F8E00-0x00000001807F9200
		private static Sprite MakeSprite(Texture2D tex, RectInt crop, AvatarCompositeOptions options); // 0x00000001807F8940-0x00000001807F8AC0
		private static void FlipRows(Color32[] px, int size); // 0x00000001807F87C0-0x00000001807F88B0
		private static void DestroyNow(UnityEngine.Object o); // 0x00000001807F7880-0x00000001807F7920
	}
}

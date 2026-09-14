/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.Avatar
{
	[DisallowMultipleComponent]
	public sealed class AvatarCompositeBaker : MonoBehaviour // TypeDefIndex: 2894
	{
		// Fields
		private const int MAX_PARALLEL_LOADS = 4; // Metadata: 0x005F226E
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
		private const int SRGB_TABLE = 4096; // Metadata: 0x005F226F
		private static readonly Dictionary<Sprite, Rect> _contentBounds; // 0x40
	
		// Properties
		public static AvatarCompositeBaker Instance { get; } // 0x0000000180D34B50-0x0000000180D34DD0 
		public static RectInt LastCrop { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180D35D30-0x0000000180D35DA0 0x0000000180D35DA0-0x0000000180D35E00
		private static Material SpritesMaterial { get; } // 0x0000000180D35E00-0x0000000180D36100 
		public static bool? FlipDetected { get; } // 0x0000000180D378B0-0x0000000180D37920 
	
		// Nested types
		private sealed class Job // TypeDefIndex: 2895
		{
			// Fields
			public string cacheKey; // 0x10
			public AvatarLayerSpec spec; // 0x18
			public AvatarCompositeOptions options; // 0x20
			public List<Action<Sprite>> callbacks; // 0x28
			public AvatarLayerResult[] results; // 0x30
	
			// Constructors
			public Job(); // 0x0000000180D39F60-0x0000000180D3A090
		}
	
		[CompilerGenerated]
		private sealed class _LoadJob_d__14 : IEnumerator<object> // TypeDefIndex: 2896
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public Job job; // 0x20
			public AvatarCompositeBaker __4__this; // 0x28
			private AvatarLayerResult[] _results_5__2; // 0x30
			private float _deadline_5__3; // 0x38
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _LoadJob_d__14(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018028E170-0x000000018028E1E0
			private bool MoveNext(); // 0x0000000180D3A090-0x0000000180D3A6A0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180D3A6A0-0x0000000180D3A6E0
		}
	
		[CompilerGenerated]
		private sealed class _Pump_d__13 : IEnumerator<object> // TypeDefIndex: 2897
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public AvatarCompositeBaker __4__this; // 0x20
			private WaitForSecondsRealtime _idle_5__2; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _Pump_d__13(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
			private bool MoveNext(); // 0x0000000180D3A6E0-0x0000000180D3AB50
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180D3AB50-0x0000000180D3AB90
		}
	
		// Constructors
		public AvatarCompositeBaker(); // 0x0000000180D39C20-0x0000000180D39E80
		static AvatarCompositeBaker(); // 0x0000000180D39E80-0x0000000180D39F60
	
		// Methods
		private void Awake(); // 0x0000000180D34DD0-0x0000000180D34F40
		private void OnApplicationQuit(); // 0x0000000180D34F40-0x0000000180D34FA0
		public void Enqueue(string cacheKey, AvatarLayerSpec spec, AvatarCompositeOptions options, Action<Sprite> onReady); // 0x0000000180D34FA0-0x0000000180D35260
		[IteratorStateMachine(typeof(_Pump_d__13))]
		private IEnumerator Pump(); // 0x0000000180D35260-0x0000000180D35300
		[IteratorStateMachine(typeof(_LoadJob_d__14))]
		private IEnumerator LoadJob(Job job); // 0x0000000180D35300-0x0000000180D35410
		private void BakeJob(Job job); // 0x0000000180D35410-0x0000000180D35D30
		public static AvatarLayerFit FitOf(string resourcePath); // 0x0000000180D36100-0x0000000180D36320
		public static Sprite BakeFromSprites(IList<Sprite> ordered, AvatarCompositeOptions options, string logKey, out Texture2D texture, bool keepReadable = false /* Metadata: 0x005F226C */, IList<AvatarLayerFit> fits = null); // 0x0000000180D36320-0x0000000180D36F10
		private static Color32[] Render(IList<Sprite> ordered, int size, Material mat, IList<AvatarLayerFit> fits = null); // 0x0000000180D36F10-0x0000000180D378B0
		private static void EnsureOrientation(Material mat); // 0x0000000180D37920-0x0000000180D38020
		private static void DrawLayer(Sprite sp, Material mat, AvatarLayerFit fit = AvatarLayerFit.Frame /* Metadata: 0x005F226D */); // 0x0000000180D38020-0x0000000180D38720
		private static void EnsureTables(); // 0x0000000180D38720-0x0000000180D38A80
		private static byte UnpremulChannel(byte c, byte a); // 0x0000000180D38A80-0x0000000180D38B60
		private static bool Unpremultiply(Color32[] px, int size); // 0x0000000180D38B60-0x0000000180D38CD0
		private static Texture2D MakeTexture(Color32[] px, int size, bool keepReadable); // 0x0000000180D38CD0-0x0000000180D38EC0
		public static bool TryGetContentBounds(Sprite sprite, out Rect normalized); // 0x0000000180D38EC0-0x0000000180D39030
		private static Rect MeasureContent(Color32[] px, int size); // 0x0000000180D39030-0x0000000180D391A0
		private static void RememberContent(Sprite sprite, Rect content); // 0x0000000180D391A0-0x0000000180D397F0
		private static Sprite MakeSprite(Texture2D tex, RectInt crop, AvatarCompositeOptions options); // 0x0000000180D397F0-0x0000000180D399C0
		private static void FlipRows(Color32[] px, int size); // 0x0000000180D399C0-0x0000000180D39AC0
		private static void DestroyNow(UnityEngine.Object o); // 0x0000000180D39AC0-0x0000000180D39C20
	}
}

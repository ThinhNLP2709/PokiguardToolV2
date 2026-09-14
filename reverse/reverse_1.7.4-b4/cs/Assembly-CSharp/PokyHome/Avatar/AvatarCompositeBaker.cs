/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.Avatar
{
	[DisallowMultipleComponent]
	public sealed class AvatarCompositeBaker : MonoBehaviour // TypeDefIndex: 2901
	{
		// Fields
		private const int MAX_PARALLEL_LOADS = 4; // Metadata: 0x005F3685
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
		private const int SRGB_TABLE = 4096; // Metadata: 0x005F3686
		private static readonly Dictionary<Sprite, Rect> _contentBounds; // 0x40
	
		// Properties
		public static AvatarCompositeBaker Instance { get; } // 0x0000000180D42910-0x0000000180D42B90 
		public static RectInt LastCrop { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180D43AF0-0x0000000180D43B60 0x0000000180D43B60-0x0000000180D43BC0
		private static Material SpritesMaterial { get; } // 0x0000000180D43BC0-0x0000000180D43EC0 
		public static bool? FlipDetected { get; } // 0x0000000180D45670-0x0000000180D456E0 
	
		// Nested types
		private sealed class Job // TypeDefIndex: 2902
		{
			// Fields
			public string cacheKey; // 0x10
			public AvatarLayerSpec spec; // 0x18
			public AvatarCompositeOptions options; // 0x20
			public List<Action<Sprite>> callbacks; // 0x28
			public AvatarLayerResult[] results; // 0x30
	
			// Constructors
			public Job(); // 0x0000000180D47D20-0x0000000180D47E50
		}
	
		[CompilerGenerated]
		private sealed class _LoadJob_d__14 : IEnumerator<object> // TypeDefIndex: 2903
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
			private bool MoveNext(); // 0x0000000180D47E50-0x0000000180D48460
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180D48460-0x0000000180D484A0
		}
	
		[CompilerGenerated]
		private sealed class _Pump_d__13 : IEnumerator<object> // TypeDefIndex: 2904
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
			private bool MoveNext(); // 0x0000000180D484A0-0x0000000180D48910
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180D48910-0x0000000180D48950
		}
	
		// Constructors
		public AvatarCompositeBaker(); // 0x0000000180D479E0-0x0000000180D47C40
		static AvatarCompositeBaker(); // 0x0000000180D47C40-0x0000000180D47D20
	
		// Methods
		private void Awake(); // 0x0000000180D42B90-0x0000000180D42D00
		private void OnApplicationQuit(); // 0x0000000180D42D00-0x0000000180D42D60
		public void Enqueue(string cacheKey, AvatarLayerSpec spec, AvatarCompositeOptions options, Action<Sprite> onReady); // 0x0000000180D42D60-0x0000000180D43020
		[IteratorStateMachine(typeof(_Pump_d__13))]
		private IEnumerator Pump(); // 0x0000000180D43020-0x0000000180D430C0
		[IteratorStateMachine(typeof(_LoadJob_d__14))]
		private IEnumerator LoadJob(Job job); // 0x0000000180D430C0-0x0000000180D431D0
		private void BakeJob(Job job); // 0x0000000180D431D0-0x0000000180D43AF0
		public static AvatarLayerFit FitOf(string resourcePath); // 0x0000000180D43EC0-0x0000000180D440E0
		public static Sprite BakeFromSprites(IList<Sprite> ordered, AvatarCompositeOptions options, string logKey, out Texture2D texture, bool keepReadable = false /* Metadata: 0x005F3683 */, IList<AvatarLayerFit> fits = null); // 0x0000000180D440E0-0x0000000180D44CD0
		private static Color32[] Render(IList<Sprite> ordered, int size, Material mat, IList<AvatarLayerFit> fits = null); // 0x0000000180D44CD0-0x0000000180D45670
		private static void EnsureOrientation(Material mat); // 0x0000000180D456E0-0x0000000180D45DE0
		private static void DrawLayer(Sprite sp, Material mat, AvatarLayerFit fit = AvatarLayerFit.Frame /* Metadata: 0x005F3684 */); // 0x0000000180D45DE0-0x0000000180D464E0
		private static void EnsureTables(); // 0x0000000180D464E0-0x0000000180D46840
		private static byte UnpremulChannel(byte c, byte a); // 0x0000000180D46840-0x0000000180D46920
		private static bool Unpremultiply(Color32[] px, int size); // 0x0000000180D46920-0x0000000180D46A90
		private static Texture2D MakeTexture(Color32[] px, int size, bool keepReadable); // 0x0000000180D46A90-0x0000000180D46C80
		public static bool TryGetContentBounds(Sprite sprite, out Rect normalized); // 0x0000000180D46C80-0x0000000180D46DF0
		private static Rect MeasureContent(Color32[] px, int size); // 0x0000000180D46DF0-0x0000000180D46F60
		private static void RememberContent(Sprite sprite, Rect content); // 0x0000000180D46F60-0x0000000180D475B0
		private static Sprite MakeSprite(Texture2D tex, RectInt crop, AvatarCompositeOptions options); // 0x0000000180D475B0-0x0000000180D47780
		private static void FlipRows(Color32[] px, int size); // 0x0000000180D47780-0x0000000180D47880
		private static void DestroyNow(UnityEngine.Object o); // 0x0000000180D47880-0x0000000180D479E0
	}
}

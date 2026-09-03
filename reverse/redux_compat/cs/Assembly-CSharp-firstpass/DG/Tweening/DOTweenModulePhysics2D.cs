/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

// Image 40: Assembly-CSharp-firstpass.dll - Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15099-15191

namespace DG.Tweening
{
	public static class DOTweenModulePhysics2D // TypeDefIndex: 15117
	{
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass0_0 // TypeDefIndex: 15118
		{
			// Fields
			public Rigidbody2D target; // 0x10
	
			// Constructors
			public __c__DisplayClass0_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Vector2 _DOMove_b__0(); // 0x00000001802E5C50-0x00000001802E5C70
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass1_0 // TypeDefIndex: 15119
		{
			// Fields
			public Rigidbody2D target; // 0x10
	
			// Constructors
			public __c__DisplayClass1_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Vector2 _DOMoveX_b__0(); // 0x00000001802E5C50-0x00000001802E5C70
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass2_0 // TypeDefIndex: 15120
		{
			// Fields
			public Rigidbody2D target; // 0x10
	
			// Constructors
			public __c__DisplayClass2_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Vector2 _DOMoveY_b__0(); // 0x00000001802E5C50-0x00000001802E5C70
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass3_0 // TypeDefIndex: 15121
		{
			// Fields
			public Rigidbody2D target; // 0x10
	
			// Constructors
			public __c__DisplayClass3_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal float _DORotate_b__0(); // 0x00000001802E67F0-0x00000001802E6810
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass4_0 // TypeDefIndex: 15122
		{
			// Fields
			public Rigidbody2D target; // 0x10
			public float startPosY; // 0x18
			public bool offsetYSet; // 0x1C
			public float offsetY; // 0x20
			public Sequence s; // 0x28
			public Vector2 endValue; // 0x30
			public Tween yTween; // 0x38
	
			// Constructors
			public __c__DisplayClass4_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Vector2 _DOJump_b__0(); // 0x00000001802E5C50-0x00000001802E5C70
			internal void _DOJump_b__1(Vector2 x); // 0x00000001802E6810-0x00000001802E6830
			internal void _DOJump_b__2(); // 0x00000001802E6830-0x00000001802E6870
			internal Vector2 _DOJump_b__3(); // 0x00000001802E5C50-0x00000001802E5C70
			internal void _DOJump_b__4(Vector2 x); // 0x00000001802E6810-0x00000001802E6830
			internal void _DOJump_b__5(); // 0x00000001802E6870-0x00000001802E6930
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass5_0 // TypeDefIndex: 15123
		{
			// Fields
			public Rigidbody2D target; // 0x10
	
			// Constructors
			public __c__DisplayClass5_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Vector3 _DOPath_b__0(); // 0x00000001802E69B0-0x00000001802E6A00
			internal void _DOPath_b__1(Vector3 x); // 0x00000001802E6A00-0x00000001802E6A40
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass6_0 // TypeDefIndex: 15124
		{
			// Fields
			public Transform trans; // 0x10
			public Rigidbody2D target; // 0x18
	
			// Constructors
			public __c__DisplayClass6_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Vector3 _DOLocalPath_b__0(); // 0x00000001802E5D20-0x00000001802E5D60
			internal void _DOLocalPath_b__1(Vector3 x); // 0x00000001802E6B70-0x00000001802E6C70
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass7_0 // TypeDefIndex: 15125
		{
			// Fields
			public Rigidbody2D target; // 0x10
	
			// Constructors
			public __c__DisplayClass7_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Vector3 _DOPath_b__0(); // 0x00000001802E69B0-0x00000001802E6A00
			internal void _DOPath_b__1(Vector3 x); // 0x00000001802E6A00-0x00000001802E6A40
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass8_0 // TypeDefIndex: 15126
		{
			// Fields
			public Transform trans; // 0x10
			public Rigidbody2D target; // 0x18
	
			// Constructors
			public __c__DisplayClass8_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Vector3 _DOLocalPath_b__0(); // 0x00000001802E5D20-0x00000001802E5D60
			internal void _DOLocalPath_b__1(Vector3 x); // 0x00000001802E6D40-0x00000001802E6E40
		}
	
		// Extension methods
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOMove(this Rigidbody2D target, Vector2 endValue, float duration, bool snapping = false /* Metadata: 0x006A9E95 */); // 0x00000001802DC460-0x00000001802DC5F0
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOMoveX(this Rigidbody2D target, float endValue, float duration, bool snapping = false /* Metadata: 0x006A9E96 */); // 0x00000001802DC130-0x00000001802DC2D0
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOMoveY(this Rigidbody2D target, float endValue, float duration, bool snapping = false /* Metadata: 0x006A9E97 */); // 0x00000001802DC2D0-0x00000001802DC460
		public static TweenerCore<float, float, FloatOptions> DORotate(this Rigidbody2D target, float endValue, float duration); // 0x00000001802DCA40-0x00000001802DCBB0
		public static Sequence DOJump(this Rigidbody2D target, Vector2 endValue, float jumpPower, int numJumps, float duration, bool snapping = false /* Metadata: 0x006A9E98 */); // 0x00000001802DB8C0-0x00000001802DBC80
		public static TweenerCore<Vector3, Path, PathOptions> DOPath(this Rigidbody2D target, Vector2[] path, float duration, PathType pathType = PathType.Linear /* Metadata: 0x006A9E99 */, PathMode pathMode = PathMode.Full3D /* Metadata: 0x006A9E9A */, int resolution = 10 /* Metadata: 0x006A9E9B */, Color? gizmoColor = default); // 0x00000001802DC5F0-0x00000001802DC8B0
		public static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(this Rigidbody2D target, Vector2[] path, float duration, PathType pathType = PathType.Linear /* Metadata: 0x006A9E9C */, PathMode pathMode = PathMode.Full3D /* Metadata: 0x006A9E9D */, int resolution = 10 /* Metadata: 0x006A9E9E */, Color? gizmoColor = default); // 0x00000001802DBE40-0x00000001802DC130
		internal static TweenerCore<Vector3, Path, PathOptions> DOPath(this Rigidbody2D target, Path path, float duration, PathMode pathMode = PathMode.Full3D /* Metadata: 0x006A9E9F */); // 0x00000001802DC8B0-0x00000001802DCA40
		internal static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(this Rigidbody2D target, Path path, float duration, PathMode pathMode = PathMode.Full3D /* Metadata: 0x006A9EA0 */); // 0x00000001802DBC80-0x00000001802DBE40
	}
}

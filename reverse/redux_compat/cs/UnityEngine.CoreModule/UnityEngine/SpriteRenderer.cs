/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Events;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeClass("SpriteRenderer", PersistentTypeId = 212)]
	[NativeHeader("Runtime/Graphics/Mesh/SpriteRenderer.h")]
	[RequireComponent(typeof(Transform))]
	public sealed class SpriteRenderer : Renderer // TypeDefIndex: 7464
	{
		// Fields
		private UnityEvent<SpriteRenderer> m_SpriteChangeEvent; // 0x18
	
		// Properties
		internal bool shouldSupportTiling { [NativeMethod("ShouldSupportTiling")] get; } // 0x00000001821953A0-0x0000000182195400 
		internal bool hasSpriteChangeEvents { get; set; } // 0x0000000182195260-0x00000001821952C0 0x0000000182195A90-0x0000000182195AF0
		public Sprite sprite { get; set; } // 0x00000001821955A0-0x0000000182195630 0x0000000182195D30-0x0000000182195DB0
		public SpriteDrawMode drawMode { get; set; } // 0x0000000182195080-0x00000001821950E0 0x0000000182195880-0x00000001821958E0
		public Vector2 size { get; set; } // 0x0000000182195450-0x00000001821954C0 0x0000000182195BE0-0x0000000182195C40
		public float adaptiveModeThreshold { get; set; } // 0x0000000182194F20-0x0000000182194F80 0x0000000182195720-0x0000000182195790
		public SpriteTileMode tileMode { get; set; } // 0x0000000182195670-0x00000001821956D0 0x0000000182195DF0-0x0000000182195E50
		public Color color { get; set; } // 0x0000000182194FD0-0x0000000182195040 0x00000001821957E0-0x0000000182195840
		public SpriteMaskInteraction maskInteraction { get; set; } // 0x0000000182195300-0x0000000182195360 0x0000000182195B30-0x0000000182195B90
		public bool flipX { get; set; } // 0x0000000182195120-0x0000000182195180 0x0000000182195930-0x0000000182195990
		public bool flipY { get; set; } // 0x00000001821951C0-0x0000000182195220 0x00000001821959E0-0x0000000182195A40
		public SpriteSortPoint spriteSortPoint { get; set; } // 0x0000000182195500-0x0000000182195560 0x0000000182195C80-0x0000000182195CE0
	
		// Constructors
		public SpriteRenderer(); // 0x00000001820502E0-0x00000001820502F0
	
		// Methods
		public void RegisterSpriteChangeCallback(UnityAction<SpriteRenderer> callback); // 0x0000000182194CC0-0x0000000182194DA0
		public void UnregisterSpriteChangeCallback(UnityAction<SpriteRenderer> callback); // 0x0000000182194E60-0x0000000182194EE0
		[RequiredByNativeCode]
		private void InvokeSpriteChanged(); // 0x0000000182194BA0-0x0000000182194C20
		public float GetBlendShapeWeight(int index); // 0x0000000182194730-0x0000000182194790
		public void SetBlendShapeWeight(int index, float value); // 0x0000000182194DF0-0x0000000182194E60
		internal int GetBlendShapeChannelCount(); // 0x0000000182194690-0x00000001821946F0
		internal bool IsSkinned(); // 0x0000000182194C60-0x0000000182194CC0
		private IntPtr GetCurrentMeshDataPtr(); // 0x00000001821947D0-0x0000000182194830
		internal Mesh.MeshDataArray GetCurrentMeshData(); // 0x0000000182194830-0x00000001821948E0
		[NativeMethod(Name = "GetSpriteBounds")]
		internal Bounds Internal_GetSpriteBounds(SpriteDrawMode mode); // 0x0000000182194B20-0x0000000182194BA0
		internal void GetSecondaryTextureProperties([NotNull] MaterialPropertyBlock mbp); // 0x0000000182194930-0x00000001821949F0
		internal Bounds GetSpriteBounds(); // 0x00000001821949F0-0x0000000182194AD0
		private static bool get_shouldSupportTiling_Injected(IntPtr _unity_self); // 0x0000000182195360-0x00000001821953A0
		private static bool get_hasSpriteChangeEvents_Injected(IntPtr _unity_self); // 0x0000000182195220-0x0000000182195260
		private static void set_hasSpriteChangeEvents_Injected(IntPtr _unity_self, bool value); // 0x0000000182195A40-0x0000000182195A90
		private static IntPtr get_sprite_Injected(IntPtr _unity_self); // 0x0000000182195560-0x00000001821955A0
		private static void set_sprite_Injected(IntPtr _unity_self, IntPtr value); // 0x0000000182195CE0-0x0000000182195D30
		private static SpriteDrawMode get_drawMode_Injected(IntPtr _unity_self); // 0x0000000182195040-0x0000000182195080
		private static void set_drawMode_Injected(IntPtr _unity_self, SpriteDrawMode value); // 0x0000000182195840-0x0000000182195880
		private static void get_size_Injected(IntPtr _unity_self, ); // 0x0000000182195400-0x0000000182195450
		private static void set_size_Injected(IntPtr _unity_self, in Vector2 value); // 0x0000000182195B90-0x0000000182195BE0
		private static float get_adaptiveModeThreshold_Injected(IntPtr _unity_self); // 0x0000000182194EE0-0x0000000182194F20
		private static void set_adaptiveModeThreshold_Injected(IntPtr _unity_self, float value); // 0x00000001821956D0-0x0000000182195720
		private static SpriteTileMode get_tileMode_Injected(IntPtr _unity_self); // 0x0000000182195630-0x0000000182195670
		private static void set_tileMode_Injected(IntPtr _unity_self, SpriteTileMode value); // 0x0000000182195DB0-0x0000000182195DF0
		private static void get_color_Injected(IntPtr _unity_self, ); // 0x0000000182194F80-0x0000000182194FD0
		private static void set_color_Injected(IntPtr _unity_self, in Color value); // 0x0000000182195790-0x00000001821957E0
		private static SpriteMaskInteraction get_maskInteraction_Injected(IntPtr _unity_self); // 0x00000001821952C0-0x0000000182195300
		private static void set_maskInteraction_Injected(IntPtr _unity_self, SpriteMaskInteraction value); // 0x0000000182195AF0-0x0000000182195B30
		private static bool get_flipX_Injected(IntPtr _unity_self); // 0x00000001821950E0-0x0000000182195120
		private static void set_flipX_Injected(IntPtr _unity_self, bool value); // 0x00000001821958E0-0x0000000182195930
		private static bool get_flipY_Injected(IntPtr _unity_self); // 0x0000000182195180-0x00000001821951C0
		private static void set_flipY_Injected(IntPtr _unity_self, bool value); // 0x0000000182195990-0x00000001821959E0
		private static SpriteSortPoint get_spriteSortPoint_Injected(IntPtr _unity_self); // 0x00000001821954C0-0x0000000182195500
		private static void set_spriteSortPoint_Injected(IntPtr _unity_self, SpriteSortPoint value); // 0x0000000182195C40-0x0000000182195C80
		private static float GetBlendShapeWeight_Injected(IntPtr _unity_self, int index); // 0x00000001821946F0-0x0000000182194730
		private static void SetBlendShapeWeight_Injected(IntPtr _unity_self, int index, float value); // 0x0000000182194DA0-0x0000000182194DF0
		private static int GetBlendShapeChannelCount_Injected(IntPtr _unity_self); // 0x0000000182194650-0x0000000182194690
		private static bool IsSkinned_Injected(IntPtr _unity_self); // 0x0000000182194C20-0x0000000182194C60
		private static IntPtr GetCurrentMeshDataPtr_Injected(IntPtr _unity_self); // 0x0000000182194790-0x00000001821947D0
		private static void Internal_GetSpriteBounds_Injected(IntPtr _unity_self, SpriteDrawMode mode, ); // 0x0000000182194AD0-0x0000000182194B20
		private static void GetSecondaryTextureProperties_Injected(IntPtr _unity_self, IntPtr mbp); // 0x00000001821948E0-0x0000000182194930
	}
}

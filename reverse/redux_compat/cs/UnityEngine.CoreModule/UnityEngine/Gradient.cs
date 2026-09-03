/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Export/Math/Gradient.bindings.h")]
	[RequiredByNativeCode]
	public class Gradient : IEquatable<UnityEngine.Gradient> // TypeDefIndex: 7661
	{
		// Fields
		[VisibleToOtherModules(new string[1] {"UnityEngine.ParticleSystemModule" })]
		internal IntPtr m_Ptr; // 0x10
		private bool m_RequiresNativeCleanup; // 0x18
	
		// Properties
		public GradientColorKey[] colorKeys { [FreeFunction("Gradient_Bindings::GetColorKeysArray", IsThreadSafe = true, HasExplicitThis = true)] get; } // 0x00000001821CC690-0x00000001821CC7A0 
		public GradientAlphaKey[] alphaKeys { [FreeFunction("Gradient_Bindings::GetAlphaKeysArray", IsThreadSafe = true, HasExplicitThis = true)] get; } // 0x00000001821CC530-0x00000001821CC640 
		[NativeProperty(IsThreadSafe = true)]
		public GradientMode mode { get; set; } // 0x00000001821CC880-0x00000001821CC8E0 0x00000001821CC9C0-0x00000001821CCA20
		[NativeProperty(IsThreadSafe = true)]
		public ColorSpace colorSpace { get; set; } // 0x00000001821CC7E0-0x00000001821CC840 0x00000001821CC920-0x00000001821CC980
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 7662
		{
			// Methods
			public static IntPtr ConvertToNative(Gradient graident); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		[RequiredByNativeCode]
		public Gradient(); // 0x00000001821CC4A0-0x00000001821CC4E0
	
		// Methods
		[FreeFunction(Name = "Gradient_Bindings::Init", IsThreadSafe = true)]
		private static IntPtr Init(); // 0x00000001821CC120-0x00000001821CC150
		[FreeFunction(Name = "Gradient_Bindings::Cleanup", IsThreadSafe = true, HasExplicitThis = true)]
		private void Cleanup(); // 0x00000001821CBD40-0x00000001821CBDA0
		[FreeFunction("Gradient_Bindings::Internal_Equals", IsThreadSafe = true, HasExplicitThis = true)]
		private bool Internal_Equals(IntPtr other); // 0x00000001821CC1A0-0x00000001821CC200
		~Gradient(); // 0x00000001821CC070-0x00000001821CC110
		[FreeFunction(Name = "Gradient_Bindings::Evaluate", IsThreadSafe = true, HasExplicitThis = true)]
		public Color Evaluate(float time); // 0x00000001821CBFF0-0x00000001821CC070
		public void SetKeys(GradientColorKey[] colorKeys, GradientAlphaKey[] alphaKeys); // 0x00000001821CC340-0x00000001821CC4A0
		[FreeFunction(Name = "Gradient_Bindings::SetKeysWithSpans", HasExplicitThis = true, IsThreadSafe = true)]
		public void SetKeys(ReadOnlySpan<GradientColorKey> colorKeys, ReadOnlySpan<GradientAlphaKey> alphaKeys); // 0x00000001821CC260-0x00000001821CC340
		public override bool Equals(object o); // 0x00000001821CBDA0-0x00000001821CBEC0
		public bool Equals(Gradient other); // 0x00000001821CBEC0-0x00000001821CBF90
		public override int GetHashCode(); // 0x00000001821CC110-0x00000001821CC120
		private static void Cleanup_Injected(IntPtr _unity_self); // 0x00000001821CBD00-0x00000001821CBD40
		private static bool Internal_Equals_Injected(IntPtr _unity_self, IntPtr other); // 0x00000001821CC150-0x00000001821CC1A0
		private static void Evaluate_Injected(IntPtr _unity_self, float time, ); // 0x00000001821CBF90-0x00000001821CBFF0
		private static void get_colorKeys_Injected(IntPtr _unity_self, ); // 0x00000001821CC640-0x00000001821CC690
		private static void get_alphaKeys_Injected(IntPtr _unity_self, ); // 0x00000001821CC4E0-0x00000001821CC530
		private static GradientMode get_mode_Injected(IntPtr _unity_self); // 0x00000001821CC840-0x00000001821CC880
		private static void set_mode_Injected(IntPtr _unity_self, GradientMode value); // 0x00000001821CC980-0x00000001821CC9C0
		private static ColorSpace get_colorSpace_Injected(IntPtr _unity_self); // 0x00000001821CC7A0-0x00000001821CC7E0
		private static void set_colorSpace_Injected(IntPtr _unity_self, ColorSpace value); // 0x00000001821CC8E0-0x00000001821CC920
		private static void SetKeys_Injected(IntPtr _unity_self, ref ManagedSpanWrapper colorKeys, ref ManagedSpanWrapper alphaKeys); // 0x00000001821CC200-0x00000001821CC260
	}
}

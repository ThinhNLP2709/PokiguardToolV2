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

// Image 57: UnityEngine.VFXModule.dll - Assembly: UnityEngine.VFXModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15667-15684

namespace UnityEngine.VFX
{
	[NativeHeader("Modules/VFX/Public/VFXEventAttribute.h")]
	[RequiredByNativeCode]
	public sealed class VFXEventAttribute : IDisposable // TypeDefIndex: 15671
	{
		// Fields
		private IntPtr m_Ptr; // 0x10
		private bool m_Owner; // 0x18
		private VisualEffectAsset m_VfxAsset; // 0x20
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 15672
		{
			// Methods
			public static IntPtr ConvertToNative(VFXEventAttribute eventAttibute); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		private VFXEventAttribute(IntPtr ptr, bool owner, VisualEffectAsset vfxAsset); // 0x00000001825D1F30-0x00000001825D1F90
	
		// Methods
		internal static VFXEventAttribute CreateEventAttributeWrapper(); // 0x00000001825D1A70-0x00000001825D1AD0
		internal void SetWrapValue(IntPtr ptrToEventAttribute); // 0x00000001825D1ED0-0x00000001825D1F30
		internal static IntPtr Internal_Create(); // 0x00000001825D1C30-0x00000001825D1C60
		internal static VFXEventAttribute Internal_InstanciateVFXEventAttribute(VisualEffectAsset vfxAsset); // 0x00000001825D1D70-0x00000001825D1E60
		internal void Internal_InitFromAsset(VisualEffectAsset vfxAsset); // 0x00000001825D1CF0-0x00000001825D1D70
		private void Release(); // 0x00000001825D1E60-0x00000001825D1ED0
		~VFXEventAttribute(); // 0x00000001825D1B70-0x00000001825D1C30
		public void Dispose(); // 0x00000001825D1AD0-0x00000001825D1B70
		[NativeMethod(IsThreadSafe = true)]
		internal static void Internal_Destroy(IntPtr ptr); // 0x00000001825D1C60-0x00000001825D1CA0
		private static void Internal_InitFromAsset_Injected(IntPtr _unity_self, IntPtr vfxAsset); // 0x00000001825D1CA0-0x00000001825D1CF0
	}
}

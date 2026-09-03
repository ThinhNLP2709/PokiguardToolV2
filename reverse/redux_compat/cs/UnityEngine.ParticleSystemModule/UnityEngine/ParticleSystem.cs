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

// Image 67: UnityEngine.ParticleSystemModule.dll - Assembly: UnityEngine.ParticleSystemModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15828-15838

namespace UnityEngine
{
	[NativeClass("ParticleSystem", PersistentTypeId = 198)]
	[NativeHeader("Modules/ParticleSystem/ScriptBindings/ParticleSystemScriptBindings.h")]
	[NativeHeader("Modules/ParticleSystem/ParticleSystem.h")]
	[NativeHeader("ParticleSystemScriptingClasses.h")]
	[NativeHeader("ParticleSystemScriptingClasses.h")]
	[NativeHeader("Modules/ParticleSystem/ParticleSystem.h")]
	[NativeHeader("Modules/ParticleSystem/ScriptBindings/ParticleSystemScriptBindings.h")]
	[NativeHeader("Modules/ParticleSystem/ParticleSystemGeometryJob.h")]
	[NativeHeader("Modules/ParticleSystem/ScriptBindings/ParticleSystemModulesScriptBindings.h")]
	[RequireComponent(typeof(Transform))]
	[UsedByNativeCode]
	public sealed class ParticleSystem : Component // TypeDefIndex: 15831
	{
		// Properties
		public MainModule main { get; } // 0x0000000180E10430-0x0000000180E10450 
	
		// Nested types
		public struct MainModule // TypeDefIndex: 15832
		{
			// Fields
			internal ParticleSystem m_ParticleSystem; // 0x00
	
			// Properties
			public int maxParticles { get; [NativeMethod(ThrowsException = true)] set; } // 0x00000001822C0420-0x00000001822C0460 0x00000001822C0460-0x00000001822C04A0
	
			// Constructors
			internal MainModule(ParticleSystem particleSystem); // 0x0000000180E02C90-0x0000000180E02CA0
		}
	
		[Serializable]
		[NativeHeader("Runtime/Scripting/ScriptingCommonStructDefinitions.h")]
		[NativeType(CodegenOptions.Custom, "MonoMinMaxCurve")]
		[RequiredByNativeCode]
		internal struct MinMaxCurveBlittable // TypeDefIndex: 15833
		{
			// Fields
			private ParticleSystemCurveMode m_Mode; // 0x00
			private float m_CurveMultiplier; // 0x04
			private IntPtr m_CurveMin; // 0x08
			private IntPtr m_CurveMax; // 0x10
			internal float m_ConstantMin; // 0x18
			internal float m_ConstantMax; // 0x1C
		}
	
		[Serializable]
		[NativeHeader("Runtime/Scripting/ScriptingCommonStructDefinitions.h")]
		[NativeType(CodegenOptions.Custom, "MonoMinMaxGradient")]
		[RequiredByNativeCode]
		internal struct MinMaxGradientBlittable // TypeDefIndex: 15834
		{
			// Fields
			private ParticleSystemGradientMode m_Mode; // 0x00
			private IntPtr m_GradientMin; // 0x08
			private IntPtr m_GradientMax; // 0x10
			private Color m_ColorMin; // 0x18
			private Color m_ColorMax; // 0x28
		}
	
		// Constructors
		public ParticleSystem(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		[FreeFunction(Name = "ParticleSystemScriptBindings::Play", HasExplicitThis = true)]
		public void Play([DefaultValue("true")] bool withChildren); // 0x00000001822C0680-0x00000001822C06E0
		public void Play(); // 0x00000001822C06E0-0x00000001822C0740
		[FreeFunction(Name = "ParticleSystemScriptBindings::Stop", HasExplicitThis = true)]
		public void Stop([DefaultValue("true")] bool withChildren, [DefaultValue("ParticleSystemStopBehavior.StopEmitting")] ParticleSystemStopBehavior stopBehavior); // 0x00000001822C0870-0x00000001822C09E0
		public void Stop([DefaultValue("true")] bool withChildren); // 0x00000001822C0800-0x00000001822C0870
		public void Stop(); // 0x00000001822C07A0-0x00000001822C0800
		[RequiredByNativeCode]
		public void Emit(int count); // 0x00000001822C05D0-0x00000001822C0630
		[NativeName("SyncJobs()->Emit")]
		private void Emit_Internal(int count); // 0x00000001822C05D0-0x00000001822C0630
		private static void Play_Injected(IntPtr _unity_self, [DefaultValue("true")] bool withChildren); // 0x00000001822C0630-0x00000001822C0680
		private static void Stop_Injected(IntPtr _unity_self, [DefaultValue("true")] bool withChildren, [DefaultValue("ParticleSystemStopBehavior.StopEmitting")] ParticleSystemStopBehavior stopBehavior); // 0x00000001822C0740-0x00000001822C07A0
		private static void Emit_Internal_Injected(IntPtr _unity_self, int count); // 0x00000001822C0590-0x00000001822C05D0
	}
}

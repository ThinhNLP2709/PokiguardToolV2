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

// Image 32: UnityEngine.AnimationModule.dll - Assembly: UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14715-14764

namespace UnityEngine
{
	[Serializable]
	[NativeAsStruct]
	[NativeHeader("Modules/Animation/AnimationEvent.h")]
	[RequiredByNativeCode]
	public sealed class AnimationEvent // TypeDefIndex: 14723
	{
		// Fields
		[NativeName("time")]
		internal float m_Time; // 0x10
		[NativeName("functionName")]
		internal string m_FunctionName; // 0x18
		[NativeName("stringParameter")]
		internal string m_StringParameter; // 0x20
		[NativeName("objectReferenceParameter")]
		internal Object m_ObjectReferenceParameter; // 0x28
		[NativeName("floatParameter")]
		internal float m_FloatParameter; // 0x30
		[NativeName("intParameter")]
		internal int m_IntParameter; // 0x34
		[NativeName("messageOptions")]
		internal int m_MessageOptions; // 0x38
		[NativeName("source")]
		internal AnimationEventSource m_Source; // 0x3C
		[NativeName("stateSender")]
		[UnityMarshalAs(NativeType.ScriptingObjectPtr)]
		internal AnimationState m_StateSender; // 0x40
		[NativeName("animatorStateInfo")]
		internal AnimatorStateInfo m_AnimatorStateInfo; // 0x48
		[NativeName("animatorClipInfo")]
		internal AnimatorClipInfo m_AnimatorClipInfo; // 0x70
	
		// Constructors
		public AnimationEvent(); // 0x0000000182157110-0x00000001821571B0
	
		// Methods
		[RequiredByNativeCode]
		internal static AnimationEvent CreateAnimationEvent(float time, string functionName, string stringParameter, Object objectReferenceParameter, float floatParameter, int intParameter, int messageOptions, AnimationEventSource source, AnimationState stateSender, AnimatorStateInfo animatorStateInfo, AnimatorClipInfo animatorClipInfo); // 0x0000000182156F70-0x0000000182157110
	}
}

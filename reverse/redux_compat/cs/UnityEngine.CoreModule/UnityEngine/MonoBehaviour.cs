/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[ExtensionOfNativeClass]
	[NativeClass("MonoBehaviour", PersistentTypeId = 114)]
	[NativeHeader("Runtime/Mono/MonoBehaviour.h")]
	[NativeHeader("Runtime/Scripting/DelayedCallUtility.h")]
	[RequiredByNativeCode]
	public class MonoBehaviour : Behaviour // TypeDefIndex: 7760
	{
		// Fields
		private CancellationTokenSource m_CancellationTokenSource; // 0x18
	
		// Properties
		public CancellationToken destroyCancellationToken { get; } // 0x00000001821EEE90-0x00000001821EF030 
		public bool useGUILayout { get; set; } // 0x00000001821EF1B0-0x00000001821EF210 0x00000001821EF2B0-0x00000001821EF310
		public bool didStart { get; } // 0x00000001821EF110-0x00000001821EF170 
		public bool didAwake { get; } // 0x00000001821EF070-0x00000001821EF0D0 
	
		// Constructors
		public MonoBehaviour(); // 0x00000001821E4560-0x00000001821E45B0
	
		// Methods
		[RequiredByNativeCode]
		private void RaiseCancellation(); // 0x00000001821EE090-0x00000001821EE0B0
		public bool IsInvoking(); // 0x00000001821ED970-0x00000001821EDA00
		public void CancelInvoke(); // 0x00000001821ED550-0x00000001821ED5E0
		public void Invoke(string methodName, float time); // 0x00000001821EDCD0-0x00000001821EDCF0
		public void InvokeRepeating(string methodName, float time, float repeatRate); // 0x00000001821EDC50-0x00000001821EDCD0
		public void CancelInvoke(string methodName); // 0x00000001821ED5E0-0x00000001821ED5F0
		public bool IsInvoking(string methodName); // 0x00000001821EDF10-0x00000001821EDF20
		[ExcludeFromDocs]
		public Coroutine StartCoroutine(string methodName); // 0x00000001821EE4D0-0x00000001821EE630
		public Coroutine StartCoroutine(string methodName, [DefaultValue("null")] object value); // 0x00000001821EE630-0x00000001821EE7A0
		public Coroutine StartCoroutine(IEnumerator routine); // 0x00000001821EE350-0x00000001821EE4D0
		[Obsolete("StartCoroutine_Auto has been deprecated. Use StartCoroutine instead (UnityUpgradable) -> StartCoroutine([mscorlib] System.Collections.IEnumerator)", false)]
		public Coroutine StartCoroutine_Auto(IEnumerator routine); // 0x00000001821EE350-0x00000001821EE4D0
		public void StopCoroutine(IEnumerator routine); // 0x00000001821EED10-0x00000001821EEE90
		public void StopCoroutine(Coroutine routine); // 0x00000001821EEB80-0x00000001821EED10
		public void StopCoroutine(string methodName); // 0x00000001821EEA10-0x00000001821EEB80
		public void StopAllCoroutines(); // 0x00000001821EE7E0-0x00000001821EE840
		public static void print(object message); // 0x00000001821EF210-0x00000001821EF260
		[FreeFunction("CancelInvoke")]
		private static void Internal_CancelInvokeAll([NotNull] MonoBehaviour self); // 0x00000001821ED550-0x00000001821ED5E0
		[FreeFunction("IsInvoking")]
		private static bool Internal_IsInvokingAll([NotNull] MonoBehaviour self); // 0x00000001821ED970-0x00000001821EDA00
		[FreeFunction]
		private static void InvokeDelayed([NotNull] MonoBehaviour self, string methodName, float time, float repeatRate); // 0x00000001821EDA70-0x00000001821EDC50
		[FreeFunction]
		private static void CancelInvoke([NotNull] MonoBehaviour self, string methodName); // 0x00000001821ED5F0-0x00000001821ED7B0
		[FreeFunction]
		private static bool IsInvoking([NotNull] MonoBehaviour self, string methodName); // 0x00000001821EDD40-0x00000001821EDF10
		[FreeFunction]
		private static bool IsObjectMonoBehaviour([NotNull] Object obj); // 0x00000001821EDF60-0x00000001821EDFF0
		private Coroutine StartCoroutineManaged(string methodName, object value); // 0x00000001821EE1C0-0x00000001821EE350
		private Coroutine StartCoroutineManaged2(IEnumerator enumerator); // 0x00000001821EE100-0x00000001821EE160
		private void StopCoroutineManaged(Coroutine routine); // 0x00000001821EE940-0x00000001821EE9C0
		private void StopCoroutineFromEnumeratorManaged(IEnumerator routine); // 0x00000001821EE890-0x00000001821EE8F0
		internal string GetScriptClassName(); // 0x00000001821ED800-0x00000001821ED8F0
		private void OnCancellationTokenCreated(); // 0x00000001821EE030-0x00000001821EE090
		private static void StopCoroutine_Injected(IntPtr _unity_self, ref ManagedSpanWrapper methodName); // 0x00000001821EE9C0-0x00000001821EEA10
		private static void StopAllCoroutines_Injected(IntPtr _unity_self); // 0x00000001821EE7A0-0x00000001821EE7E0
		private static bool get_useGUILayout_Injected(IntPtr _unity_self); // 0x00000001821EF170-0x00000001821EF1B0
		private static void set_useGUILayout_Injected(IntPtr _unity_self, bool value); // 0x00000001821EF260-0x00000001821EF2B0
		private static bool get_didStart_Injected(IntPtr _unity_self); // 0x00000001821EF0D0-0x00000001821EF110
		private static bool get_didAwake_Injected(IntPtr _unity_self); // 0x00000001821EF030-0x00000001821EF070
		private static void Internal_CancelInvokeAll_Injected(IntPtr self); // 0x00000001821ED8F0-0x00000001821ED930
		private static bool Internal_IsInvokingAll_Injected(IntPtr self); // 0x00000001821ED930-0x00000001821ED970
		private static void InvokeDelayed_Injected(IntPtr self, ref ManagedSpanWrapper methodName, float time, float repeatRate); // 0x00000001821EDA00-0x00000001821EDA70
		private static void CancelInvoke_Injected(IntPtr self, ref ManagedSpanWrapper methodName); // 0x00000001821ED500-0x00000001821ED550
		private static bool IsInvoking_Injected(IntPtr self, ref ManagedSpanWrapper methodName); // 0x00000001821EDCF0-0x00000001821EDD40
		private static bool IsObjectMonoBehaviour_Injected(IntPtr obj); // 0x00000001821EDF20-0x00000001821EDF60
		private static Coroutine StartCoroutineManaged_Injected(IntPtr _unity_self, ref ManagedSpanWrapper methodName, object value); // 0x00000001821EE160-0x00000001821EE1C0
		private static Coroutine StartCoroutineManaged2_Injected(IntPtr _unity_self, IEnumerator enumerator); // 0x00000001821EE0B0-0x00000001821EE100
		private static void StopCoroutineManaged_Injected(IntPtr _unity_self, IntPtr routine); // 0x00000001821EE8F0-0x00000001821EE940
		private static void StopCoroutineFromEnumeratorManaged_Injected(IntPtr _unity_self, IEnumerator routine); // 0x00000001821EE840-0x00000001821EE890
		private static void GetScriptClassName_Injected(IntPtr _unity_self, ); // 0x00000001821ED7B0-0x00000001821ED800
		private static void OnCancellationTokenCreated_Injected(IntPtr _unity_self); // 0x00000001821EDFF0-0x00000001821EE030
	}
}

namespace UnityEngine;

[ExtensionOfNativeClass]
[NativeHeader("Runtime/Scripting/DelayedCallUtility.h")]
[NativeHeader("Runtime/Mono/MonoBehaviour.h")]
[RequiredByNativeCode]
public class MonoBehaviour : Behaviour
{
	private CancellationTokenSource m_CancellationTokenSource; //Field offset: 0x18

	public CancellationToken destroyCancellationToken
	{
		 get { } //Length: 331
	}

	public bool didAwake
	{
		 get { } //Length: 118
	}

	public bool didStart
	{
		 get { } //Length: 118
	}

	public bool useGUILayout
	{
		 get { } //Length: 118
		 set { } //Length: 134
	}

	public MonoBehaviour() { }

	public void CancelInvoke() { }

	[FreeFunction]
	private static void CancelInvoke(MonoBehaviour self, string methodName) { }

	public void CancelInvoke(string methodName) { }

	private static void CancelInvoke_Injected(IntPtr self, ref ManagedSpanWrapper methodName) { }

	public CancellationToken get_destroyCancellationToken() { }

	public bool get_didAwake() { }

	private static bool get_didAwake_Injected(IntPtr _unity_self) { }

	public bool get_didStart() { }

	private static bool get_didStart_Injected(IntPtr _unity_self) { }

	public bool get_useGUILayout() { }

	private static bool get_useGUILayout_Injected(IntPtr _unity_self) { }

	internal string GetScriptClassName() { }

	private static void GetScriptClassName_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret) { }

	[FreeFunction("CancelInvoke")]
	private static void Internal_CancelInvokeAll(MonoBehaviour self) { }

	private static void Internal_CancelInvokeAll_Injected(IntPtr self) { }

	[FreeFunction("IsInvoking")]
	private static bool Internal_IsInvokingAll(MonoBehaviour self) { }

	private static bool Internal_IsInvokingAll_Injected(IntPtr self) { }

	public void Invoke(string methodName, float time) { }

	[FreeFunction]
	private static void InvokeDelayed(MonoBehaviour self, string methodName, float time, float repeatRate) { }

	private static void InvokeDelayed_Injected(IntPtr self, ref ManagedSpanWrapper methodName, float time, float repeatRate) { }

	public void InvokeRepeating(string methodName, float time, float repeatRate) { }

	[FreeFunction]
	private static bool IsInvoking(MonoBehaviour self, string methodName) { }

	public bool IsInvoking() { }

	public bool IsInvoking(string methodName) { }

	private static bool IsInvoking_Injected(IntPtr self, ref ManagedSpanWrapper methodName) { }

	[FreeFunction]
	private static bool IsObjectMonoBehaviour(object obj) { }

	private static bool IsObjectMonoBehaviour_Injected(IntPtr obj) { }

	private void OnCancellationTokenCreated() { }

	private static void OnCancellationTokenCreated_Injected(IntPtr _unity_self) { }

	public static void print(object message) { }

	[RequiredByNativeCode]
	private void RaiseCancellation() { }

	public void set_useGUILayout(bool value) { }

	private static void set_useGUILayout_Injected(IntPtr _unity_self, bool value) { }

	[ExcludeFromDocs]
	public Coroutine StartCoroutine(string methodName) { }

	public Coroutine StartCoroutine(IEnumerator routine) { }

	public Coroutine StartCoroutine(string methodName, object value) { }

	[Obsolete("StartCoroutine_Auto has been deprecated. Use StartCoroutine instead (UnityUpgradable) -> StartCoroutine([mscorlib] System.Collections.IEnumerator)", False)]
	public Coroutine StartCoroutine_Auto(IEnumerator routine) { }

	private Coroutine StartCoroutineManaged(string methodName, object value) { }

	private static Coroutine StartCoroutineManaged_Injected(IntPtr _unity_self, ref ManagedSpanWrapper methodName, object value) { }

	private Coroutine StartCoroutineManaged2(IEnumerator enumerator) { }

	private static Coroutine StartCoroutineManaged2_Injected(IntPtr _unity_self, IEnumerator enumerator) { }

	public void StopAllCoroutines() { }

	private static void StopAllCoroutines_Injected(IntPtr _unity_self) { }

	public void StopCoroutine(Coroutine routine) { }

	public void StopCoroutine(string methodName) { }

	public void StopCoroutine(IEnumerator routine) { }

	private static void StopCoroutine_Injected(IntPtr _unity_self, ref ManagedSpanWrapper methodName) { }

	private void StopCoroutineFromEnumeratorManaged(IEnumerator routine) { }

	private static void StopCoroutineFromEnumeratorManaged_Injected(IntPtr _unity_self, IEnumerator routine) { }

	private void StopCoroutineManaged(Coroutine routine) { }

	private static void StopCoroutineManaged_Injected(IntPtr _unity_self, IntPtr routine) { }

}


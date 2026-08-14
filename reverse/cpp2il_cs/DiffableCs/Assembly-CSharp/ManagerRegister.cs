//Type is in global namespace

public class ManagerRegister : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <CloseAfterDelay>d__18 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float delay; //Field offset: 0x20
		public ManagerRegister <>4__this; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <CloseAfterDelay>d__18(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <RegisterCoroutine>d__15 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerRegister <>4__this; //Field offset: 0x20
		private RegisterRequest <registerData>5__2; //Field offset: 0x28
		private UnityWebRequest <request>5__3; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <RegisterCoroutine>d__15(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[Header("UI References")]
	public GameObject registerPanel; //Field offset: 0x20
	public InputField nameInput; //Field offset: 0x28
	public InputField usernameInput; //Field offset: 0x30
	public InputField passwordInput; //Field offset: 0x38
	public InputField confirmPasswordInput; //Field offset: 0x40
	public Button registerButton; //Field offset: 0x48
	public Button closeButton; //Field offset: 0x50
	public Text errorMessageText; //Field offset: 0x58
	public GameObject loadingPanel; //Field offset: 0x60
	[Header("Debug")]
	public bool enableDebugLogs; //Field offset: 0x68

	public ManagerRegister() { }

	private void AutoFillLoginUsername(string username) { }

	private void ClearAllInputs() { }

	[IteratorStateMachine(typeof(<CloseAfterDelay>d__18))]
	private IEnumerator CloseAfterDelay(float delay) { }

	public void ClosePanel() { }

	private string GetOrCreateDeviceId() { }

	private void HandleErrorResponse(long responseCode, string responseText) { }

	private void HandleSuccessResponse(string responseText, string username) { }

	private void HideErrorMessage() { }

	private void OnRegisterClicked() { }

	public void OpenRegisterPanel() { }

	[IteratorStateMachine(typeof(<RegisterCoroutine>d__15))]
	private IEnumerator RegisterCoroutine() { }

	private void ShowError(string message) { }

	private void ShowSuccess(string message) { }

	private void Start() { }

	private bool ValidateInputs() { }

}


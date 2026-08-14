namespace UnityEngine.Rendering;

internal class DebugUpdater : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <DoAfterInputModuleUpdated>d__9 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Action action; //Field offset: 0x20

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
		public <DoAfterInputModuleUpdated>d__9(int <>1__state) { }

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
	private sealed class <RefreshRuntimeUINextFrame>d__15 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18

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
		public <RefreshRuntimeUINextFrame>d__15(int <>1__state) { }

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

	private static DebugUpdater s_Instance; //Field offset: 0x0
	private ScreenOrientation m_Orientation; //Field offset: 0x20
	private bool m_RuntimeUiWasVisibleLastFrame; //Field offset: 0x24

	public DebugUpdater() { }

	private void AssignDefaultActions() { }

	private void CheckInputModuleExists() { }

	private void CreateDebugEventSystem() { }

	private void DestroyDebugEventSystem() { }

	private static void DisableRuntime() { }

	[IteratorStateMachine(typeof(<DoAfterInputModuleUpdated>d__9))]
	private IEnumerator DoAfterInputModuleUpdated(Action action) { }

	private static void EnableRuntime() { }

	private void EnsureExactlyOneEventSystem() { }

	internal static void HandleInternalEventSystemComponents(bool uiEnabled) { }

	[IteratorStateMachine(typeof(<RefreshRuntimeUINextFrame>d__15))]
	private static IEnumerator RefreshRuntimeUINextFrame() { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::AfterSceneLoad (0))]
	private static void RuntimeInit() { }

	internal static void SetEnabled(bool enabled) { }

	private void Update() { }

}


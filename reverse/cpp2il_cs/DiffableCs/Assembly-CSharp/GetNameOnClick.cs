//Type is in global namespace

public class GetNameOnClick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerExitHandler
{
	[CompilerGenerated]
	private sealed class <CallRoomWaitAPI>d__6 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public int userId; //Field offset: 0x20
		public int petId; //Field offset: 0x24

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
		public <CallRoomWaitAPI>d__6(int <>1__state) { }

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

	private BoardController boardController; //Field offset: 0x20
	private LoadRoom loadRoom; //Field offset: 0x28
	private bool isPointerInside; //Field offset: 0x30

	public GetNameOnClick() { }

	[IteratorStateMachine(typeof(<CallRoomWaitAPI>d__6))]
	private IEnumerator CallRoomWaitAPI(int userId, int petId) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	public override void OnPointerExit(PointerEventData eventData) { }

	public override void OnPointerUp(PointerEventData eventData) { }

}


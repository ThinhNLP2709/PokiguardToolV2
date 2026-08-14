namespace UnityEngine.UIElements;

public class RadioButtonGroup : BaseField<Int32>, IGroupBox
{
	[CompilerGenerated]
	private sealed class <get_choices>d__9 : IEnumerable<String>, IEnumerable, IEnumerator<String>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private string <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		public RadioButtonGroup <>4__this; //Field offset: 0x28
		private Enumerator<RadioButton> <>s__1; //Field offset: 0x30
		private RadioButton <radioButton>5__2; //Field offset: 0x48

		private override string System.Collections.Generic.IEnumerator<System.String>.Current
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
		public <get_choices>d__9(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<String> System.Collections.Generic.IEnumerable<System.String>.GetEnumerator() { }

		[DebuggerHidden]
		private override string System.Collections.Generic.IEnumerator<System.String>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<RadioButtonGroup, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : BaseFieldTraits<Int32, UxmlIntAttributeDescription>
	{
		private UxmlStringAttributeDescription m_Choices; //Field offset: 0xA0

		public UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	internal static readonly BindingId choicesProperty; //Field offset: 0x0
	public static readonly string ussClassName; //Field offset: 0x98
	public static readonly string containerUssClassName; //Field offset: 0xA0
	private List<RadioButton> m_RadioButtons; //Field offset: 0x528
	private EventCallback<ChangeEvent`1<Boolean>> m_RadioButtonValueChangedCallback; //Field offset: 0x530
	private VisualElement m_RadioButtonContainer; //Field offset: 0x538

	[CreateProperty]
	public IEnumerable<String> choices
	{
		[IteratorStateMachine(typeof(<get_choices>d__9))]
		 get { } //Length: 113
		 set { } //Length: 1409
	}

	public virtual VisualElement contentContainer
	{
		 get { } //Length: 18
	}

	private static RadioButtonGroup() { }

	public RadioButtonGroup() { }

	public RadioButtonGroup(string label, List<String> radioButtonChoices = null) { }

	[IteratorStateMachine(typeof(<get_choices>d__9))]
	public IEnumerable<String> get_choices() { }

	public virtual VisualElement get_contentContainer() { }

	private void RadioButtonValueChangedCallback(ChangeEvent<Boolean> evt) { }

	public void set_choices(IEnumerable<String> value) { }

	public virtual void SetValueWithoutNotify(int newValue) { }

	private override void UnityEngine.UIElements.IGroupBox.OnOptionAdded(IGroupBoxOption option) { }

	private override void UnityEngine.UIElements.IGroupBox.OnOptionRemoved(IGroupBoxOption option) { }

	private void UpdateRadioButtons() { }

}


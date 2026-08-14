namespace UnityEngine.Playables;

[NativeHeader("Modules/Director/ScriptBindings/PlayableSystems.bindings.h")]
[StaticAccessor("PlayableSystemsBindings", StaticAccessorType::DoubleColon (2))]
internal static class PlayableSystems
{
	[DefaultMember("Item")]
	private class DataPlayableOutputList : IReadOnlyList<DataPlayableOutput>, IEnumerable<DataPlayableOutput>, IEnumerable, IReadOnlyCollection<DataPlayableOutput>
	{
		private class DataPlayableOutputEnumerator : IEnumerator<DataPlayableOutput>, IEnumerator, IDisposable
		{
			private DataPlayableOutputList m_List; //Field offset: 0x10
			private int m_Index; //Field offset: 0x18

			public override DataPlayableOutput Current
			{
				 get { } //Length: 437
			}

			private override object System.Collections.IEnumerator.Current
			{
				private get { } //Length: 84
			}

			public DataPlayableOutputEnumerator(DataPlayableOutputList list) { }

			public override void Dispose() { }

			public override DataPlayableOutput get_Current() { }

			public override bool MoveNext() { }

			public override void Reset() { }

			private override object System.Collections.IEnumerator.get_Current() { }

		}

		private PlayableOutputHandle* m_Outputs; //Field offset: 0x10
		private int m_Count; //Field offset: 0x18

		public override int Count
		{
			 get { } //Length: 4
		}

		public override DataPlayableOutput Item
		{
			 get { } //Length: 329
		}

		public DataPlayableOutputList(PlayableOutputHandle* outputs, int count) { }

		public override int get_Count() { }

		public override DataPlayableOutput get_Item(int index) { }

		public override IEnumerator<DataPlayableOutput> GetEnumerator() { }

		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	}

	internal sealed class PlayableSystemDelegate : MulticastDelegate
	{

		public PlayableSystemDelegate(object object, IntPtr method) { }

		public override void Invoke(IReadOnlyList<DataPlayableOutput> outputs) { }

	}

	internal enum PlayableSystemStage
	{
		FixedUpdate = 0,
		FixedUpdatePostPhysics = 1,
		Update = 2,
		AnimationBegin = 3,
		AnimationEnd = 4,
		LateUpdate = 5,
		Render = 6,
	}

	private static Dictionary<Int32, Type> s_SystemTypes; //Field offset: 0x0
	private static Dictionary<Int32, PlayableSystemDelegate> s_Delegates; //Field offset: 0x8
	private static ReaderWriterLockSlim s_RWLock; //Field offset: 0x10

	private static PlayableSystems() { }

	private static int CombineTypeAndIndex(int typeIndex, PlayableSystemStage stage) { }

	[RequiredByNativeCode]
	private static bool Internal_CallSystemDelegate(int systemIndex, PlayableSystemStage stage, IntPtr outputsPtr, int numOutputs) { }

}


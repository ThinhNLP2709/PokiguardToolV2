//Type is in global namespace

public class ManagerKhoPet : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<String> <>9__107_1; //Field offset: 0x8
		public static Func<StoneDTO, Int32> <>9__136_0; //Field offset: 0x10
		public static Predicate<StoneDTO> <>9__139_0; //Field offset: 0x18
		public static Func<StoneDTO, Boolean> <>9__144_0; //Field offset: 0x20
		public static Func<StoneDTO, Boolean> <>9__149_0; //Field offset: 0x28
		public static Func<StoneDTO, Boolean> <>9__149_2; //Field offset: 0x30
		public static Func<StoneDTO, Int64> <>9__149_3; //Field offset: 0x38
		public static Predicate<StoneDTO> <>9__198_0; //Field offset: 0x40
		public static Func<StoneDTO, Boolean> <>9__206_0; //Field offset: 0x48
		public static Func<StoneDTO, Boolean> <>9__206_1; //Field offset: 0x50
		public static Func<StoneDTO, Int64> <>9__206_2; //Field offset: 0x58

		private static <>c() { }

		public <>c() { }

		internal bool <CalculateStoneUpgradePercent>b__144_0(StoneDTO s) { }

		internal void <LoadPetStars>b__107_1(string err) { }

		internal int <LoadStonesForUpgrade>b__136_0(StoneDTO s) { }

		internal bool <OnStoneClicked>b__198_0(StoneDTO s) { }

		internal bool <OnStoneUpgradeClicked>b__139_0(StoneDTO s) { }

		internal bool <OnUpgradeButtonClicked>b__206_0(StoneDTO s) { }

		internal bool <OnUpgradeButtonClicked>b__206_1(StoneDTO s) { }

		internal long <OnUpgradeButtonClicked>b__206_2(StoneDTO s) { }

		internal bool <UpgradeThreeStones>b__149_0(StoneDTO s) { }

		internal bool <UpgradeThreeStones>b__149_2(StoneDTO s) { }

		internal long <UpgradeThreeStones>b__149_3(StoneDTO s) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass128_0
	{
		public Button button; //Field offset: 0x10

		public <>c__DisplayClass128_0() { }

		internal void <AnimateButtonClick>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass130_0
	{
		public Text textComponent; //Field offset: 0x10

		public <>c__DisplayClass130_0() { }

		internal void <AnimateStatUpdate>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass138_0
	{
		public ManagerKhoPet <>4__this; //Field offset: 0x10
		public Button btnStone; //Field offset: 0x18
		public StoneDTO stone; //Field offset: 0x20
		public Text txtCount; //Field offset: 0x28

		public <>c__DisplayClass138_0() { }

		internal void <SetupStoneUpgradeUI>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass140_0
	{
		public Button btn; //Field offset: 0x10
		public int slotIndex; //Field offset: 0x18
		public ManagerKhoPet <>4__this; //Field offset: 0x20

		public <>c__DisplayClass140_0() { }

		internal void <UpdateStoneUpgradeSlotsUI>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass144_0
	{
		public int firstLevel; //Field offset: 0x10

		public <>c__DisplayClass144_0() { }

		internal bool <CalculateStoneUpgradePercent>b__1(StoneDTO s) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass148_0
	{
		public bool apiSuccess; //Field offset: 0x10
		public StoneBatchUpgradeResponseDTO response; //Field offset: 0x18

		public <>c__DisplayClass148_0() { }

		internal void <UpgradeSelectedStoneSequence>b__0(StoneBatchUpgradeResponseDTO res) { }

		internal void <UpgradeSelectedStoneSequence>b__1(string error) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass149_0
	{
		public int firstLevel; //Field offset: 0x10

		public <>c__DisplayClass149_0() { }

		internal bool <UpgradeThreeStones>b__1(StoneDTO s) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass168_0
	{
		public ManagerKhoPet <>4__this; //Field offset: 0x10
		public PetUserDTO pet; //Field offset: 0x18

		public <>c__DisplayClass168_0() { }

		internal void <SetupPetUISimple>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass190_0
	{
		public ManagerKhoPet <>4__this; //Field offset: 0x10
		public PetUserDTO pet; //Field offset: 0x18

		public <>c__DisplayClass190_0() { }

		internal void <SetupPetInfo>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass196_0
	{
		public ManagerKhoPet <>4__this; //Field offset: 0x10
		public Button btnStone; //Field offset: 0x18
		public StoneDTO stone; //Field offset: 0x20
		public Text txtCount; //Field offset: 0x28

		public <>c__DisplayClass196_0() { }

		internal void <SetupStoneUI>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass199_0
	{
		public Button btn; //Field offset: 0x10
		public int slotIndex; //Field offset: 0x18
		public ManagerKhoPet <>4__this; //Field offset: 0x20

		public <>c__DisplayClass199_0() { }

		internal void <UpdateSelectedStonesUI>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <AnimateTextFlyUp>d__224 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Text textComponent; //Field offset: 0x20
		public float moveDistance; //Field offset: 0x28
		public float duration; //Field offset: 0x2C
		private Vector3 <startPos>5__2; //Field offset: 0x30
		private Vector3 <targetPos>5__3; //Field offset: 0x3C
		private float <elapsed>5__4; //Field offset: 0x48
		private Color <originalColor>5__5; //Field offset: 0x4C

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
		public <AnimateTextFlyUp>d__224(int <>1__state) { }

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
	private sealed class <DeductGoldAndUpgradeSelectedStone>d__147 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerKhoPet <>4__this; //Field offset: 0x20
		public StoneDTO selectedStone; //Field offset: 0x28
		public int totalGroups; //Field offset: 0x30

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
		public <DeductGoldAndUpgradeSelectedStone>d__147(int <>1__state) { }

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
	private sealed class <HideMessageAfterDelay>d__162 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float delay; //Field offset: 0x20
		public ManagerKhoPet <>4__this; //Field offset: 0x28

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
		public <HideMessageAfterDelay>d__162(int <>1__state) { }

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
	private sealed class <HideResultAfterDelay>d__213 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float delay; //Field offset: 0x20
		public ManagerKhoPet <>4__this; //Field offset: 0x28

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
		public <HideResultAfterDelay>d__213(int <>1__state) { }

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
	private sealed class <HideStoneMessageAfterDelay>d__132 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float delay; //Field offset: 0x20
		public ManagerKhoPet <>4__this; //Field offset: 0x28

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
		public <HideStoneMessageAfterDelay>d__132(int <>1__state) { }

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
	private sealed class <HideStoneResultAfterDelay>d__157 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float delay; //Field offset: 0x20
		public ManagerKhoPet <>4__this; //Field offset: 0x28

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
		public <HideStoneResultAfterDelay>d__157(int <>1__state) { }

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
	private sealed class <LoadPage>d__175 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerKhoPet <>4__this; //Field offset: 0x20
		public int userId; //Field offset: 0x28
		public int page; //Field offset: 0x2C

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
		public <LoadPage>d__175(int <>1__state) { }

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
	private sealed class <LoadPetsPage>d__165 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public int userId; //Field offset: 0x20
		public int page; //Field offset: 0x24
		public ManagerKhoPet <>4__this; //Field offset: 0x28

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
		public <LoadPetsPage>d__165(int <>1__state) { }

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
	private sealed class <LoadPetStars>d__107 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public int userId; //Field offset: 0x20
		public ManagerKhoPet <>4__this; //Field offset: 0x28

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
		public <LoadPetStars>d__107(int <>1__state) { }

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
	private sealed class <LoadSceneAfterDelay>d__163 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerKhoPet <>4__this; //Field offset: 0x20
		private int <userId>5__2; //Field offset: 0x28
		private IEnumerator <stonesRequest>5__3; //Field offset: 0x30

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
		public <LoadSceneAfterDelay>d__163(int <>1__state) { }

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
	private sealed class <ReloadAllStonesAfterUpgrade>d__154 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerKhoPet <>4__this; //Field offset: 0x20

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
		public <ReloadAllStonesAfterUpgrade>d__154(int <>1__state) { }

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
	private sealed class <ReloadDataAfterUpgrade>d__214 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerKhoPet <>4__this; //Field offset: 0x20
		private int <userId>5__2; //Field offset: 0x28
		private IEnumerator <userRequest>5__3; //Field offset: 0x30

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
		public <ReloadDataAfterUpgrade>d__214(int <>1__state) { }

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
	private sealed class <UpgradePetAPI>d__208 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public EncryptedBody payload; //Field offset: 0x20
		public ManagerKhoPet <>4__this; //Field offset: 0x28

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
		public <UpgradePetAPI>d__208(int <>1__state) { }

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
	private sealed class <UpgradeSelectedStoneSequence>d__148 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public int totalGroups; //Field offset: 0x20
		public StoneDTO selectedStone; //Field offset: 0x28
		public ManagerKhoPet <>4__this; //Field offset: 0x30
		private <>c__DisplayClass148_0 <>8__1; //Field offset: 0x38

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
		public <UpgradeSelectedStoneSequence>d__148(int <>1__state) { }

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
	private sealed class <UpgradeStoneAPI>d__150 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public EncryptedBody payload; //Field offset: 0x20
		public ManagerKhoPet <>4__this; //Field offset: 0x28

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
		public <UpgradeStoneAPI>d__150(int <>1__state) { }

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
	private sealed class <WaitForAnimationThenReload>d__210 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerKhoPet <>4__this; //Field offset: 0x20
		public PetUpgradeResponseDTO response; //Field offset: 0x28

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
		public <WaitForAnimationThenReload>d__210(int <>1__state) { }

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
	private sealed class <WaitForStoneAnimationThenReload>d__152 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerKhoPet <>4__this; //Field offset: 0x20
		public StoneUpgradeResponseDTO response; //Field offset: 0x28

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
		public <WaitForStoneAnimationThenReload>d__152(int <>1__state) { }

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

	internal class DeductGoldRequestDTO
	{
		public int userId; //Field offset: 0x10
		public int amount; //Field offset: 0x14
		public string reason; //Field offset: 0x18

		public DeductGoldRequestDTO() { }

	}

	internal class DeductGoldResponseDTO
	{
		public bool success; //Field offset: 0x10
		public string message; //Field offset: 0x18
		public int remainingGold; //Field offset: 0x20

		public DeductGoldResponseDTO() { }

	}

	internal class PetPageResponse
	{
		public PetUserDTO[] content; //Field offset: 0x10
		public int totalPages; //Field offset: 0x18
		public int totalElements; //Field offset: 0x1C
		public int number; //Field offset: 0x20
		public int size; //Field offset: 0x24
		public bool first; //Field offset: 0x28
		public bool last; //Field offset: 0x29
		public int numberOfElements; //Field offset: 0x2C

		public PetPageResponse() { }

	}

	internal class PetUpgradeRequestDTO
	{
		public long userId; //Field offset: 0x10
		public long userPetId; //Field offset: 0x18
		public Int64[] stoneIds; //Field offset: 0x20
		public bool preventDowngrade; //Field offset: 0x28
		public bool boost15Percent; //Field offset: 0x29

		public PetUpgradeRequestDTO() { }

	}

	internal class PetUpgradeResponseDTO
	{
		public bool success; //Field offset: 0x10
		public string message; //Field offset: 0x18
		public PetUserDTO updatedPet; //Field offset: 0x20

		public PetUpgradeResponseDTO() { }

	}

	internal class StoneBatchUpgradeRequestDTO
	{
		public int userId; //Field offset: 0x10
		public StoneGroupDTO[] stoneGroups; //Field offset: 0x18

		public StoneBatchUpgradeRequestDTO() { }

	}

	internal class StoneBatchUpgradeResponseDTO
	{
		public bool success; //Field offset: 0x10
		public string message; //Field offset: 0x18
		public int successCount; //Field offset: 0x20
		public int failCount; //Field offset: 0x24
		public String[] details; //Field offset: 0x28
		public int remainingGold; //Field offset: 0x30

		public StoneBatchUpgradeResponseDTO() { }

	}

	internal class StoneGroupDTO
	{
		public long stoneId; //Field offset: 0x10
		public int quantity; //Field offset: 0x18

		public StoneGroupDTO() { }

	}

	internal class StoneUpgradeRequestDTO
	{
		public int userId; //Field offset: 0x10
		public Int64[] stoneIds; //Field offset: 0x18
		public bool upgradeAll; //Field offset: 0x20

		public StoneUpgradeRequestDTO() { }

	}

	internal class StoneUpgradeResponseDTO
	{
		public bool success; //Field offset: 0x10
		public string message; //Field offset: 0x18

		public StoneUpgradeResponseDTO() { }

	}

	private const int POOL_SIZE = 15; //Field offset: 0x0
	public const string PANEL_KEY = "PanelKhoPet"; //Field offset: 0x0
	private const int PETS_PER_PAGE = 7; //Field offset: 0x0
	[Header("Pet UI")]
	public GameObject petUIPrefab; //Field offset: 0x20
	public Transform petListContainer; //Field offset: 0x28
	public GameObject LoadingPanel; //Field offset: 0x30
	public Text txtVang; //Field offset: 0x38
	public Text txtCt; //Field offset: 0x40
	public Text txtNl; //Field offset: 0x48
	public Animator animator; //Field offset: 0x50
	public Text namePet; //Field offset: 0x58
	public Text txtHp; //Field offset: 0x60
	public Text txtMana; //Field offset: 0x68
	public Text txtDame; //Field offset: 0x70
	public Text txtWee; //Field offset: 0x78
	public Text txtLv; //Field offset: 0x80
	public Text des; //Field offset: 0x88
	public Image imgAtribute; //Field offset: 0x90
	public Image imgAtributeOther; //Field offset: 0x98
	public Animator imgPetAnimator; //Field offset: 0xA0
	[Header("Stone Upgrade UI")]
	public GameObject panelStone; //Field offset: 0xA8
	public Transform stoneListContainer; //Field offset: 0xB0
	public GameObject stonePrefab; //Field offset: 0xB8
	public GameObject panelUpdate; //Field offset: 0xC0
	public Transform updateSlotsContainer; //Field offset: 0xC8
	public Text txtUpgradePercent; //Field offset: 0xD0
	public Button btnUpdate; //Field offset: 0xD8
	[Header("Stone Sprites")]
	public List<Sprite> fireStoneSprites; //Field offset: 0xE0
	public List<Sprite> waterStoneSprites; //Field offset: 0xE8
	public List<Sprite> earthStoneSprites; //Field offset: 0xF0
	public List<Sprite> electricStoneSprites; //Field offset: 0xF8
	public List<Sprite> woodStoneSprites; //Field offset: 0x100
	private PetUserDTO firstPet; //Field offset: 0x108
	private PetUserDTO currentSelectedPet; //Field offset: 0x110
	private StoneResponse allStones; //Field offset: 0x118
	private StoneDTO[] selectedStones; //Field offset: 0x120
	private Dictionary<Int32, Int32> tempStoneCount; //Field offset: 0x128
	[Header("Upgrade Animation")]
	public GameObject anmtUpdatePet; //Field offset: 0x130
	public Text txtResultUpdate; //Field offset: 0x138
	private Color originalResultColor; //Field offset: 0x140
	public Toggle toggleProtection; //Field offset: 0x150
	public Toggle toggle15Percent; //Field offset: 0x158
	public Text messageText; //Field offset: 0x160
	private UserDTO currentUser; //Field offset: 0x168
	[Header("Skill Card UI")]
	public GameObject PanelCardPet; //Field offset: 0x170
	public Image imgCard; //Field offset: 0x178
	public Text txtDescription; //Field offset: 0x180
	[Header("Stone Upgrade System")]
	public GameObject PanelUpdateStone; //Field offset: 0x188
	public Button btnOpenStoneUpgrade; //Field offset: 0x190
	public Button btnCloseStoneUpgrade; //Field offset: 0x198
	public GameObject PanelHe; //Field offset: 0x1A0
	public Button btnHeFire; //Field offset: 0x1A8
	public Button btnHeWater; //Field offset: 0x1B0
	public Button btnHeEarth; //Field offset: 0x1B8
	public Button btnHeMetal; //Field offset: 0x1C0
	public Button btnHeWood; //Field offset: 0x1C8
	public GameObject PanelStoneUpgrade; //Field offset: 0x1D0
	public Transform stoneUpgradeListContainer; //Field offset: 0x1D8
	public GameObject PanelUpdateStone2; //Field offset: 0x1E0
	public Transform stoneUpgradeSlotsContainer; //Field offset: 0x1E8
	public GameObject StoneMain; //Field offset: 0x1F0
	public Image imgStoneMain; //Field offset: 0x1F8
	public Text txtStoneMainLevel; //Field offset: 0x200
	public Text txtUpgradePercentStone; //Field offset: 0x208
	public Button btnUpgradeStone; //Field offset: 0x210
	public Text txtResultUpdateStone; //Field offset: 0x218
	public GameObject anmtUpdateStone; //Field offset: 0x220
	public Toggle toggleUpgradeAll; //Field offset: 0x228
	public Text messageTextStone; //Field offset: 0x230
	private string currentSelectedElement; //Field offset: 0x238
	private StoneDTO[] selectedStonesForUpgrade; //Field offset: 0x240
	private Dictionary<Int32, Int32> tempStoneCountUpgrade; //Field offset: 0x248
	private Color originalResultColorStone; //Field offset: 0x250
	[Header("LeanTween Settings - ĐÃ TỐI ƯU")]
	public float panelAnimDuration; //Field offset: 0x260
	public float itemAnimDelay; //Field offset: 0x264
	public LeanTweenType easeType; //Field offset: 0x268
	private CanvasGroup panelStoneCanvasGroup; //Field offset: 0x270
	private CanvasGroup panelUpdateCanvasGroup; //Field offset: 0x278
	private CanvasGroup panelUpdateStoneCanvasGroup; //Field offset: 0x280
	private CanvasGroup panelCardPetCanvasGroup; //Field offset: 0x288
	[Header("Background Music")]
	public AudioSource bgmAudioSource; //Field offset: 0x290
	public AudioClip bgmClip; //Field offset: 0x298
	[Range(0, 1)]
	public float bgmVolume; //Field offset: 0x2A0
	public bool loopBGM; //Field offset: 0x2A4
	[Header("Sound Effects")]
	public AudioClip clickSound; //Field offset: 0x2A8
	[Range(0, 1)]
	public float clickVolume; //Field offset: 0x2B0
	private List<Coroutine> activeCoroutines; //Field offset: 0x2B8
	private bool isProcessingUpgrade; //Field offset: 0x2C0
	[Header("Pet Pagination - BACKEND API")]
	public Button btnPrevPage; //Field offset: 0x2C8
	public Button btnNextPage; //Field offset: 0x2D0
	public Text txtPageInfo; //Field offset: 0x2D8
	[Header("Nâng sao pet (mảnh pet)")]
	[Tooltip("Nút mở panel nâng sao cho pet đang chọn.")]
	public Button btnPetStar; //Field offset: 0x2E0
	[Tooltip("Panel nâng sao — dựng bởi Tools/Pokiguard/PetStar/2.")]
	public PetStarPanelController petStarPanel; //Field offset: 0x2E8
	private readonly Dictionary<Int64, Int32> _petStars; //Field offset: 0x2F0
	private int _petStarMax; //Field offset: 0x2F8
	private readonly HashSet<Int64> _upgradablePets; //Field offset: 0x300
	private bool _upgradableLoaded; //Field offset: 0x308
	private PetPageResponse currentPageData; //Field offset: 0x310
	private int currentPage; //Field offset: 0x318
	private bool _wired; //Field offset: 0x31C
	private bool _openHandled; //Field offset: 0x31D
	private bool _loadingVisible; //Field offset: 0x31E
	private AudioClip _prevGlobalClickSound; //Field offset: 0x320
	[Header("Mobile Optimization")]
	public bool enableMobileOptimization; //Field offset: 0x328
	private bool isLoadingPage; //Field offset: 0x329
	[Header("Object Pooling - OPTIMIZED")]
	private Queue<GameObject> petUIPool; //Field offset: 0x330

	public ManagerKhoPet() { }

	[CompilerGenerated]
	private void <LoadPage>b__175_0(PetPageResponse response) { }

	[CompilerGenerated]
	private void <LoadPetsPage>b__165_0(PetPageResponse response) { }

	[CompilerGenerated]
	private void <LoadPetStars>b__107_0(PetStarListResponse resp) { }

	[CompilerGenerated]
	private bool <ReloadDataAfterUpgrade>b__214_0(PetUserDTO p) { }

	[CompilerGenerated]
	private void <SetupButtons>b__114_0() { }

	[CompilerGenerated]
	private void <SetupButtons>b__114_1() { }

	[CompilerGenerated]
	private void <SetupButtons>b__114_2() { }

	[CompilerGenerated]
	private void <SetupButtons>b__114_3() { }

	[CompilerGenerated]
	private void <SetupButtons>b__114_4() { }

	private void AnimateButtonClick(Button button) { }

	private void AnimateClosePanel(GameObject panel, CanvasGroup canvasGroup) { }

	private void AnimateItemAppear(GameObject item, int index, float baseDelay = 0) { }

	private void AnimateOpenPanel(GameObject panel, CanvasGroup canvasGroup) { }

	private void AnimateStatUpdate(Text textComponent, int oldValue, int newValue, float delay = 0) { }

	[IteratorStateMachine(typeof(<AnimateTextFlyUp>d__224))]
	private IEnumerator AnimateTextFlyUp(Text textComponent, float duration = 1, float moveDistance = 50) { }

	private void ApplyGlobalClickSound() { }

	private void Awake() { }

	public void BackScene() { }

	private float CalculateStoneRate(int petLevel, int stoneLevel) { }

	private void CalculateStoneUpgradePercent() { }

	private void CalculateUpgradePercent() { }

	private bool CanUpgradeStar(long petId) { }

	private void CleanupPetUIComplete(GameObject petUI) { }

	private void ClearContainer(Transform container) { }

	private void ClearContainerSafe(Transform container) { }

	private void ClearPetListNoPool() { }

	private void ClearPetListSimple() { }

	private void CloseStoneUpgradePanel() { }

	[IteratorStateMachine(typeof(<DeductGoldAndUpgradeSelectedStone>d__147))]
	private IEnumerator DeductGoldAndUpgradeSelectedStone(StoneDTO selectedStone, int totalGroups) { }

	private void DisplayCurrentPage() { }

	private void DisplayCurrentPageNoPool() { }

	private void EnsurePreviewCamera() { }

	public static string FormatVND(long amount) { }

	private CanvasGroup GetOrAddCanvasGroup(GameObject obj) { }

	private int GetPetStar(long petId) { }

	private GameObject GetPetUIFromPool() { }

	private StoneDTO[] GetStonesForElement(string element) { }

	private Sprite GetStoneSpriteByElement(string elementType, int level) { }

	private float GetUpgradeSuccessRate() { }

	private float GetUpgradeSuccessRateWithBoost() { }

	private void HandleStoneUpgradeResult(StoneUpgradeResponseDTO response) { }

	private void HandleUpgradeResult(PetUpgradeResponseDTO response) { }

	[IteratorStateMachine(typeof(<HideMessageAfterDelay>d__162))]
	private IEnumerator HideMessageAfterDelay(float delay) { }

	[IteratorStateMachine(typeof(<HideResultAfterDelay>d__213))]
	private IEnumerator HideResultAfterDelay(float delay) { }

	[IteratorStateMachine(typeof(<HideStoneMessageAfterDelay>d__132))]
	private IEnumerator HideStoneMessageAfterDelay(float delay) { }

	[IteratorStateMachine(typeof(<HideStoneResultAfterDelay>d__157))]
	private IEnumerator HideStoneResultAfterDelay(float delay) { }

	private bool IsCurrentPetOnPage() { }

	private void LoadAttributeImage(Image imageComponent, string attributeName) { }

	private void LoadAudioSettings() { }

	[IteratorStateMachine(typeof(<LoadPage>d__175))]
	private IEnumerator LoadPage(int userId, int page) { }

	private void LoadPetSkillCard(int skillCardId, string description) { }

	[IteratorStateMachine(typeof(<LoadPetsPage>d__165))]
	private IEnumerator LoadPetsPage(int userId, int page) { }

	[IteratorStateMachine(typeof(<LoadPetStars>d__107))]
	private IEnumerator LoadPetStars(int userId) { }

	[IteratorStateMachine(typeof(<LoadSceneAfterDelay>d__163))]
	private IEnumerator LoadSceneAfterDelay() { }

	private void LoadStonesForElement(string elementType) { }

	private void LoadStonesForUpgrade(string elementType) { }

	private void LockStoneInteraction() { }

	private void OnAllStonesReloadedAfterUpgrade(StoneResponse stones) { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnError(string error) { }

	private void OnPageLoadError(string error) { }

	private void OnPetClicked(string petId, string name, int attack, int hp, int mana, int maxLevel, string elementType, string elementOther, double weaknessValue, string txtDes, PetUserDTO pet, int skillCardId) { }

	private void OnPetsPageReceived(PetPageResponse response) { }

	public void OnPetStarChanged(long petId, int newStar) { }

	private void OnStoneClicked(StoneDTO stone, Text txtCount) { }

	private void OnStonesReceived(StoneResponse stones) { }

	private void OnStonesReloaded(StoneResponse stones) { }

	private void OnStoneUpgradeClicked(StoneDTO stone, Text txtCount) { }

	private void OnStoneUpgradeError(string error) { }

	private void OnStoneUpgradeSuccess(StoneUpgradeResponseDTO response) { }

	private void OnToggle15PercentChanged(bool isOn) { }

	private void OnToggleProtectionChanged(bool isOn) { }

	private void OnToggleUpgradeAllChanged(bool isOn) { }

	private void OnUpgradeButtonClicked() { }

	private void OnUpgradeError(string error) { }

	private void OnUpgradeStoneClicked() { }

	private void OnUpgradeSuccess(PetUpgradeResponseDTO response) { }

	private void OnUserReceived(UserDTO user) { }

	public void Open() { }

	private void OpenPetStarPanel() { }

	private void OpenStoneUpgradePanel() { }

	private void PlayBackgroundMusic() { }

	private void RefreshPetStarButton() { }

	private void RefreshVisibleStarRows() { }

	[IteratorStateMachine(typeof(<ReloadAllStonesAfterUpgrade>d__154))]
	private IEnumerator ReloadAllStonesAfterUpgrade() { }

	[IteratorStateMachine(typeof(<ReloadDataAfterUpgrade>d__214))]
	private IEnumerator ReloadDataAfterUpgrade() { }

	private void RemoveStoneFromSlot(int slotIndex) { }

	private void RemoveStoneFromUpgradeSlot(int slotIndex) { }

	private void ResetStoneUpgradeUI() { }

	private void RestoreGlobalClickSound() { }

	private void ReturnPetUIToPoolSimple(GameObject obj) { }

	private void SelectElement(string element) { }

	private void SelectPet(PetUserDTO pet) { }

	public void SetBGMVolume(float volume) { }

	private void SetPaginationButtonsState(bool interactable) { }

	private void SetTextIfNotNull(Text textComponent, string value) { }

	private void SetupButtons() { }

	private void SetupButtonSoundsOptimized() { }

	private void SetupCanvasGroups() { }

	private void SetupFallbackImage(Image petIcon, string petID, Animator petAnimator) { }

	private void SetupInitialStates() { }

	private void SetupPetInfo(GameObject petUIObject, PetUserDTO pet, string petID) { }

	private void SetupPetUI(GameObject petUIObject, PetUserDTO pet) { }

	private void SetupPetUISimple(GameObject petUIObject, PetUserDTO pet) { }

	private void SetupStoneUI(GameObject stoneObj, StoneDTO stone, int index) { }

	private void SetupStoneUpgradeUI(GameObject stoneObj, StoneDTO stone, int index) { }

	private void SetupToggles() { }

	private void ShowErrorMessage(string message) { }

	private void ShowLocalLoading(bool show) { }

	private void ShowNextPage() { }

	private void ShowPreviousPage() { }

	private void ShowStoneErrorMessage(string message) { }

	private void Start() { }

	private Coroutine StartCoroutineTracked(IEnumerator routine) { }

	private bool TrySetupPetAnimation(Animator petAnimator, string petID) { }

	private void UnlockStoneInteraction() { }

	private void UpdatePaginationButtons() { }

	private void UpdateSelectedStonesUI() { }

	private void UpdateStoneListUI() { }

	private void UpdateStoneMainDisplay() { }

	private void UpdateStoneUpgradeListUI() { }

	private void UpdateStoneUpgradeSlotsUI() { }

	private void UpgradeAllStonesOfSelectedType() { }

	[IteratorStateMachine(typeof(<UpgradePetAPI>d__208))]
	private IEnumerator UpgradePetAPI(EncryptedBody payload) { }

	[IteratorStateMachine(typeof(<UpgradeSelectedStoneSequence>d__148))]
	private IEnumerator UpgradeSelectedStoneSequence(StoneDTO selectedStone, int totalGroups) { }

	[IteratorStateMachine(typeof(<UpgradeStoneAPI>d__150))]
	private IEnumerator UpgradeStoneAPI(EncryptedBody payload) { }

	private void UpgradeThreeStones() { }

	[IteratorStateMachine(typeof(<WaitForAnimationThenReload>d__210))]
	private IEnumerator WaitForAnimationThenReload(PetUpgradeResponseDTO response) { }

	[IteratorStateMachine(typeof(<WaitForStoneAnimationThenReload>d__152))]
	private IEnumerator WaitForStoneAnimationThenReload(StoneUpgradeResponseDTO response) { }

	private void WireOnce() { }

}


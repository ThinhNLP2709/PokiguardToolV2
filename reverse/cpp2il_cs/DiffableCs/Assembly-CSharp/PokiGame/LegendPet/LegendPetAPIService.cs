namespace PokiGame.LegendPet;

public class LegendPetAPIService : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public Action<LegendPetData> onSuccess; //Field offset: 0x10
		public Action<String> onError; //Field offset: 0x18

		public <>c__DisplayClass7_0() { }

		internal void <GetLegendPetInfo>b__0(LegendPetData response) { }

		internal void <GetLegendPetInfo>b__1(string error) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public Action<InlayStarResponse> onSuccess; //Field offset: 0x10
		public Action<String> onError; //Field offset: 0x18

		public <>c__DisplayClass8_0() { }

		internal void <InlayStar>b__0(InlayStarResponse response) { }

		internal void <InlayStar>b__1(string error) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public Action<UnlockPetResponse> onSuccess; //Field offset: 0x10
		public Action<String> onError; //Field offset: 0x18

		public <>c__DisplayClass9_0() { }

		internal void <UnlockLegendPet>b__0(UnlockPetResponse response) { }

		internal void <UnlockLegendPet>b__1(string error) { }

	}

	[CompilerGenerated]
	private sealed class <GetAllLegendPetsWithRawResponse>d__6 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string url; //Field offset: 0x20
		public Action<String> onError; //Field offset: 0x28
		public Action<LegendPetListResponse> onSuccess; //Field offset: 0x30
		private UnityWebRequest <request>5__2; //Field offset: 0x38

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
		public <GetAllLegendPetsWithRawResponse>d__6(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <GetUserPetInfoWithRawResponse>d__11 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string url; //Field offset: 0x20
		public Action<String> onError; //Field offset: 0x28
		public Action<PetUserDTO> onSuccess; //Field offset: 0x30
		private UnityWebRequest <request>5__2; //Field offset: 0x38

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
		public <GetUserPetInfoWithRawResponse>d__11(int <>1__state) { }

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

	private static LegendPetAPIService instance; //Field offset: 0x0

	public static LegendPetAPIService Instance
	{
		 get { } //Length: 288
	}

	public LegendPetAPIService() { }

	private static void AttachAuth(UnityWebRequest request) { }

	public static LegendPetAPIService get_Instance() { }

	public void GetAllLegendPets(Action<LegendPetListResponse> onSuccess, Action<String> onError) { }

	[IteratorStateMachine(typeof(<GetAllLegendPetsWithRawResponse>d__6))]
	private IEnumerator GetAllLegendPetsWithRawResponse(string url, Action<LegendPetListResponse> onSuccess, Action<String> onError) { }

	private static string GetAuthToken() { }

	public void GetLegendPetInfo(long userId, long petId, Action<LegendPetData> onSuccess, Action<String> onError) { }

	public void GetUserPetInfo(int userId, int petId, Action<PetUserDTO> onSuccess, Action<String> onError) { }

	[IteratorStateMachine(typeof(<GetUserPetInfoWithRawResponse>d__11))]
	private IEnumerator GetUserPetInfoWithRawResponse(string url, Action<PetUserDTO> onSuccess, Action<String> onError) { }

	public void InlayStar(InlayStarRequest requestData, Action<InlayStarResponse> onSuccess, Action<String> onError) { }

	public void UnlockLegendPet(long userId, long petId, Action<UnlockPetResponse> onSuccess, Action<String> onError) { }

}


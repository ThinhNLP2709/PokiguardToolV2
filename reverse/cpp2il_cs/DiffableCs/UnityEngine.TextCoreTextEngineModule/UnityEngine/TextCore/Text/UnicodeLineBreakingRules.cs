namespace UnityEngine.TextCore.Text;

public class UnicodeLineBreakingRules
{
	[SerializeField]
	private TextAsset m_UnicodeLineBreakingRules; //Field offset: 0x10
	[SerializeField]
	private TextAsset m_LeadingCharacters; //Field offset: 0x18
	[SerializeField]
	private TextAsset m_FollowingCharacters; //Field offset: 0x20
	[SerializeField]
	private bool m_UseModernHangulLineBreakingRules; //Field offset: 0x28
	private HashSet<UInt32> m_LeadingCharactersLookup; //Field offset: 0x30
	private HashSet<UInt32> m_FollowingCharactersLookup; //Field offset: 0x38

	internal HashSet<UInt32> followingCharactersLookup
	{
		internal get { } //Length: 43
	}

	internal HashSet<UInt32> leadingCharactersLookup
	{
		internal get { } //Length: 43
	}

	public bool useModernHangulLineBreakingRules
	{
		 get { } //Length: 5
	}

	public UnicodeLineBreakingRules() { }

	internal HashSet<UInt32> get_followingCharactersLookup() { }

	internal HashSet<UInt32> get_leadingCharactersLookup() { }

	public bool get_useModernHangulLineBreakingRules() { }

	private static HashSet<UInt32> GetCharacters(TextAsset file) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal void LoadLineBreakingRules() { }

}


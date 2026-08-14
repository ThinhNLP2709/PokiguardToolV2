namespace Unity.VisualScripting;

public class ProfiledSegmentCollection : KeyedCollection<String, ProfiledSegment>
{

	public ProfiledSegmentCollection() { }

	protected virtual string GetKeyForItem(ProfiledSegment item) { }

}


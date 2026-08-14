//Type is in global namespace

public static class UpgradeRequestBuilder
{

	public static EncryptedBody BuildBatchStoneUpgrade(long userId, StoneGroupPayload[] groups) { }

	public static EncryptedBody BuildPetUpgrade(long userId, long userPetId, Int64[] stoneIds, bool preventDowngrade, bool boost15Percent) { }

	public static EncryptedBody BuildStoneUpgrade(long userId, Int64[] stoneIds, bool upgradeAll) { }

	private static EncryptedBody Encrypt(string plainJson) { }

	private static string SerializeLongArray(Int64[] arr) { }

}


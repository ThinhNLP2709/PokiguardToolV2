//Type is in global namespace

public static class PvpRankingRequest
{

	public static EncryptedBody BuildHistoryRequest(int userId, int page = 0, int size = 20) { }

	public static EncryptedBody BuildTopRequest(int limit) { }

	public static EncryptedBody BuildUserRequest(int userId) { }

	private static EncryptedBody Encrypt(string plainJson) { }

}


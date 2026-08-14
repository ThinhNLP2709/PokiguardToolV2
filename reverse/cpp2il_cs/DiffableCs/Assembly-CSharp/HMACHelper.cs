//Type is in global namespace

public static class HMACHelper
{
	private const string LEGACY_KEY = "YourSecretKey_ChangeThis_2025"; //Field offset: 0x0
	private const string PREF_KEY = "SessionKey"; //Field offset: 0x0
	private static string _sessionKey; //Field offset: 0x0
	private static readonly string _aesKey; //Field offset: 0x8
	private static long _timeOffset; //Field offset: 0x10

	private static HMACHelper() { }

	public static string EncryptAES(string plainText) { }

	public static string GenerateCoopSignature(string encryptedData, long timestamp) { }

	public static string GenerateSignature(long userId, long petId, long timestamp) { }

	public static string GenerateSpinSignature(long userId, int multiplier, long timestamp) { }

	public static string GenerateWheelSignature(long userId, string spinType, long timestamp) { }

	public static long GetTimestamp() { }

	public static void SetSessionKey(string key) { }

	public static void SetTimeOffset(long offset) { }

}


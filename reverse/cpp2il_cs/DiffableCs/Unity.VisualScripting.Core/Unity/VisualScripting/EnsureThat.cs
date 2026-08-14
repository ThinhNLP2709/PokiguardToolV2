namespace Unity.VisualScripting;

public class EnsureThat
{
	internal string paramName; //Field offset: 0x10

	public EnsureThat() { }

	public void Any(ICollection<T> value, Func<T, Boolean> predicate) { }

	public void Any(IList<T> value, Func<T, Boolean> predicate) { }

	public void Any(T[] value, Func<T, Boolean> predicate) { }

	public void HasAttribute(Type param, Type attributeType) { }

	public void HasAttribute(Type param) { }

	private void HasConstructorAccepting(Type param, Type[] parameterTypes, bool nonPublic) { }

	public void HasConstructorAccepting(Type param, Type[] parameterTypes) { }

	public void HasItems(T value) { }

	public void HasItems(ICollection<T> value) { }

	public void HasItems(T[] value) { }

	public void HasItems(IList<T> value) { }

	public void HasItems(IDictionary<TKey, TValue> value) { }

	public void HasLengthBetween(string value, int minLength, int maxLength) { }

	public void HasNoNullItem(T value) { }

	public void HasPublicConstructorAccepting(Type param, Type[] parameterTypes) { }

	public void Is(T param, T expected) { }

	public void IsEqualTo(string value, string expected) { }

	public void IsEqualTo(string value, string expected, StringComparison comparison) { }

	public void IsFalse(bool value) { }

	public void IsGt(T param, T limit) { }

	public void IsGte(T param, T limit) { }

	public void IsGuid(string value) { }

	public void IsInRange(T param, T min, T max) { }

	public void IsKeyOf(IDictionary<TKey, TValue> value, TKey expectedKey, string keyLabel = null) { }

	public void IsLt(T param, T limit) { }

	public void IsLte(T param, T limit) { }

	public void IsNot(T param, T expected) { }

	public void IsNotDefault(T param) { }

	public void IsNotEmpty(Guid value) { }

	public void IsNotEmpty(string value) { }

	public void IsNotEqualTo(string value, string expected, StringComparison comparison) { }

	public void IsNotEqualTo(string value, string expected) { }

	public void IsNotNull(string value) { }

	public void IsNotNull(T value) { }

	public void IsNotNull(Nullable<T> value) { }

	public void IsNotNullOrEmpty(string value) { }

	public void IsNotNullOrWhiteSpace(string value) { }

	public void IsNull(T value) { }

	public void IsOfType(Type param) { }

	public void IsOfType(object param) { }

	public void IsOfType(Type param, Type expectedType) { }

	public void IsOfType(T param, Type expectedType) { }

	public void IsTrue(bool value) { }

	public void Matches(string value, string match) { }

	public void Matches(string value, Regex match) { }

	public void SizeIs(T[] value, int expected) { }

	public void SizeIs(IDictionary<TKey, TValue> value, long expected) { }

	public void SizeIs(string value, int expected) { }

	public void SizeIs(T value, int expected) { }

	public void SizeIs(IDictionary<TKey, TValue> value, int expected) { }

	public void SizeIs(T value, long expected) { }

	public void SizeIs(ICollection<T> value, int expected) { }

	public void SizeIs(ICollection<T> value, long expected) { }

	public void SizeIs(IList<T> value, int expected) { }

	public void SizeIs(T[] value, long expected) { }

	public void SizeIs(IList<T> value, long expected) { }

	private bool StringEquals(string x, string y, Nullable<StringComparison> comparison = null) { }

}


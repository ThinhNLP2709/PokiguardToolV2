namespace UnityEngine.UIElements;

[Obsolete("BaseFieldTraits<TValueType, TValueUxmlAttributeType> is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
public class BaseFieldTraits : UxmlTraits<TValueType>
{
	private TValueUxmlAttributeType m_Value; //Field offset: 0x0

	public BaseFieldTraits`2() { }

	public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

}


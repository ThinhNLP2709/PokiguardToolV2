namespace Unity.Properties;

public abstract class ConcreteTypeVisitor : IPropertyBagVisitor
{

	protected ConcreteTypeVisitor() { }

	private override void Unity.Properties.IPropertyBagVisitor.Visit(IPropertyBag<TContainer> properties, ref TContainer container) { }

	protected abstract void VisitContainer(ref TContainer container) { }

}


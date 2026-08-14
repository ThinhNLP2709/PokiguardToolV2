namespace System.Linq.Expressions;

public class Expression : LambdaExpression
{

	internal virtual Type PublicType
	{
		internal get { } //Length: 57
	}

	internal virtual Type TypeCore
	{
		internal get { } //Length: 56
	}

	internal Expression`1(Expression body) { }

	protected private virtual Expression Accept(ExpressionVisitor visitor) { }

	public TDelegate Compile() { }

	public TDelegate Compile(bool preferInterpretation) { }

	internal virtual Type get_PublicType() { }

	internal virtual Type get_TypeCore() { }

	[ExcludeFromCodeCoverage]
	internal override Expression<TDelegate> Rewrite(Expression body, ParameterExpression[] parameters) { }

}


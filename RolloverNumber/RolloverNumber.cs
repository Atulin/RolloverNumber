using System.Numerics;

namespace RolloverNumber;

public readonly partial record struct RolloverNumber<T> :
	IIncrementOperators<RolloverNumber<T>>,
	IDecrementOperators<RolloverNumber<T>>,
	IAdditionOperators<RolloverNumber<T>, RolloverNumber<T>, RolloverNumber<T>>,
	ISubtractionOperators<RolloverNumber<T>, RolloverNumber<T>, RolloverNumber<T>>
	where T : struct, IBinaryInteger<T>, IMinMaxValue<T>
{
	public T MinValue { get; }
	public T MaxValue { get; }
	public T Value { get; private init; }

	public override string? ToString() => Value.ToString();

	public string ToFullString() => $$"""{ {{nameof(Value)}} = {{Value}}, {{nameof(MinValue)}} = {{MinValue}}, {{nameof(MaxValue)}} = {{MaxValue}} }""";

	public static explicit operator T(RolloverNumber<T> num)
	{
		return num.Value;
	}

	public static RolloverNumber<T> operator --(RolloverNumber<T> num)
	{
		var newValue = num.Value - T.One;

		return num with
		{
			Value = newValue < num.MinValue 
				? num.MaxValue 
				: newValue
		};
	}
	
	public static RolloverNumber<T> operator ++(RolloverNumber<T> num)
	{
		var newValue = num.Value + T.One;

		return num with
		{
			Value = newValue > num.MaxValue
				? num.MinValue
				: newValue
		};
	}
	
	public static RolloverNumber<T> operator +(RolloverNumber<T> left, RolloverNumber<T> right)
	{
		var newValue = left.Value + right.Value;

		return left with
		{
			Value = newValue > left.MaxValue
				? newValue - left.MaxValue
				: newValue
		};
	}
	
	public static RolloverNumber<T> operator +(RolloverNumber<T> left, T right)
	{
		var newValue = left.Value + right;

		return left with
		{
			Value = newValue > left.MaxValue
				? newValue - left.MaxValue
				: newValue
		};
	}
	
	public static RolloverNumber<T> operator -(RolloverNumber<T> left, RolloverNumber<T> right)
	{
		var newValue = left.Value - right.Value;

		return left with
		{
			Value = newValue < left.MinValue
				? newValue + left.MinValue
				: newValue
		};
	}
	
	public static RolloverNumber<T> operator -(RolloverNumber<T> left, T right)
	{
		var newValue = left.Value - right;

		return left with
		{
			Value = newValue < left.MinValue
				? newValue + left.MinValue
				: newValue
		};
	}
}
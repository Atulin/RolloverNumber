namespace RolloverNumber;

public readonly partial record struct RolloverNumber<T>
{
	public RolloverNumber(T value, T minValue, T maxValue)
	{
		Value = value;
		MinValue = minValue;
		MaxValue = maxValue;
	}
	public RolloverNumber(T minValue, T maxValue)
	{
		Value = default;
		MinValue = minValue;
		MaxValue = maxValue;
	}
	public RolloverNumber(T value)
	{
		Value = value;
		MinValue = T.MinValue;
		MaxValue = T.MaxValue;
	}
	public RolloverNumber()
	{
		Value = default;
		MinValue = T.MinValue;
		MaxValue = T.MaxValue;
	}
}
namespace Main;

internal interface IRateAndCopy
{
    double Rating { get; }
    object DeepCopy();
}


namespace Lab1;

/// <summary>
/// Manipulator can be used to process any type of data with any result.
/// </summary>
interface IManipulator
{
    void FillWithRandomValues();

    void PrintResult();

    void ProcessData();
}
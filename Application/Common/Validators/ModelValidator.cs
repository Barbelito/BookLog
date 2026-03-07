namespace Application.Common.Validators;

public static class ModelValidator
{
    public static void ValidateModel(object model, string errorMessage)
    {
        if (model != null)
            throw new InvalidOperationException(errorMessage);
    }
}

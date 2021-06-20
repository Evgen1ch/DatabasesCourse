namespace DatabasesCourse.Validators
{
    public interface IValidator<T>
    {
        string ValidateWithString(T entity);
    }
}

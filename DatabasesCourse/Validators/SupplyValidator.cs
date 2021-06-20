using DatabasesCourse.DatabaseModel.Entities;
using System.Text;

namespace DatabasesCourse.Validators
{
    class SupplyValidator : IValidator<Supply>
    {
        public string ValidateWithString(Supply entity)
        {
            StringBuilder sb = new StringBuilder();
            if (entity.Product == null)
                sb.Append("Product is not specified.\n");
            if (entity.Amount <= 0)
                sb.Append("Amount must be greater than zero.\n");
            return sb.ToString();
        }
    }
}

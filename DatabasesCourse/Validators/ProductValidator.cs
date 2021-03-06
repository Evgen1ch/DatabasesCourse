using DatabasesCourse.DatabaseModel.Entities;
using System.Text;

namespace DatabasesCourse.Validators
{
    public class ProductValidator : IValidator<Product>
    {
        public string ValidateWithString(Product entity)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(entity.BarCode))
                sb.Append("Barcode is reqiured. Please fill the field 'Barcode'.\n");
            if (entity.BarCode?.Length < 13)
                sb.Append("Barcode must contain only 13 numbers. Please edit your input.\n");
            if (entity.Manufacturer == null)
                sb.Append("Manufacturer is reqiured. Please select 'Manufacturer'.\n");
            if (string.IsNullOrEmpty(entity.Name))
                sb.Append("Name is reqiured. Please fill the field 'Name'.\n");
            if (entity.Category == null)
                sb.Append("Category is reqiured. Please select 'Category'.\n");
            if (entity.Price == 0)
                sb.Append("Price can not be 0. Please fill the field 'Price'.\n");
            return sb.ToString();
        }
    }
}

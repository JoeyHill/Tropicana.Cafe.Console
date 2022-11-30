using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tropicana.Cafe.Main;

namespace Tropicana.Cafe.Main.Validators
{
    /// <summary>
    /// An object produced after testing an EntryMeal for validity. 
    /// </summary>
    public class ValidationResponse
    {
        public Validation Status;
        public object ValidatedObject;
        public Type ValidatedType
        {
            get
            {
                return ValidatedObject == null ? null : ValidatedObject.GetType();
            }
        }
        public string ValidationMessage;

        public ValidationResponse()
        {
            ValidationMessage = "Uninitiated Validation Response.";
            Status = Validation.Invalid;
            ValidatedObject = null;
        }

        public ValidationResponse(bool Success, string Message = "Success", object Object = null)
        {
            Status = (Success) ? Validation.Valid : Validation.Invalid;
            ValidationMessage = Message;
            ValidatedObject = Object;
        }

        public ValidationResponse(bool Success, object Object = null, string Message = "Success")
        {
            Status = Validation.Valid;
            ValidationMessage = Message;
            ValidatedObject = Object;
        }

    }
}

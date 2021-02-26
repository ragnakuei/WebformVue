using System.Collections.Generic;
using System.Linq;
using WebformVue.Models;

namespace WebformVue.Validators
{
    public abstract class ViewModelValidator<T>
    {
        public Dictionary<string, List<string>> ValidateResult { get; } = new Dictionary<string, List<string>>();

        public bool IsValid
        {
            get
            {
                var errorMessagesCount = ValidateResult.SelectMany(v => v.Value)
                                                       .Count();

                return errorMessagesCount == 0;
            }
        }

        /// <summary>
        /// 驗証
        /// </summary>
        /// <param name="validateVm"></param>
        /// <returns>true：代表輸入的資料有效</returns>
        public abstract bool Validate(ValidateViewModel<T> validateVm);

        protected void AddError(string propertyName, string errorMessage)
        {
            if (ValidateResult.TryGetValue(propertyName, out var errorMessages))
            {
                errorMessages.Add(errorMessage);
                return;
            }

            ValidateResult.Add(propertyName, new List<string> { errorMessage });
        }
    }
}

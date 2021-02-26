using WebformVue.Models;
using WebformVue.Parameters;

namespace WebformVue.Validators
{
    public class TestViewModelValidator : ViewModelValidator<TestViewModel>
    {
        public override bool Validate(ValidateViewModel<TestViewModel> validateVm)
        {
            ValidateName(validateVm);
            ValidatePassword(validateVm);
            ValidateAge(validateVm);
            ValidateGendor(validateVm);
            ValidateSchoolType(validateVm);

            return IsValid;
        }

        private void ValidateName(ValidateViewModel<TestViewModel> validateVm)
        {
            var propertyName  = nameof(TestViewModel.Name);
            var propertyValue = validateVm.ViewModel.Name;

            if (validateVm.ValidateProperties.Contains(propertyName) == false)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(propertyValue))
            {
                AddError(propertyName, "姓名未填寫");
            }
        }

        private void ValidatePassword(ValidateViewModel<TestViewModel> validateVm)
        {
            var propertyName  = nameof(TestViewModel.Password);
            var propertyValue = validateVm.ViewModel.Password;

            if (validateVm.ValidateProperties.Contains(propertyName) == false)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(propertyValue))
            {
                AddError(propertyName, "密碼未填寫");
            }

            if (propertyValue != validateVm.ViewModel.RePassword)
            {
                AddError(propertyName,                     "密碼輸入不一致");
                AddError(nameof(TestViewModel.RePassword), "密碼輸入不一致");
            }
        }

        private void ValidateAge(ValidateViewModel<TestViewModel> validateVm)
        {
            var propertyName  = nameof(TestViewModel.Age);
            var propertyValue = validateVm.ViewModel.Age;

            if (validateVm.ValidateProperties.Contains(propertyName) == false)
            {
                return;
            }

            if (propertyValue == null)
            {
                AddError(propertyName, "年齡未填寫");
                return;
            }

            if (propertyValue < 18
             || propertyValue > 100)
            {
                AddError(propertyName, "年齡要介於 18 至 100 之間");
            }
        }

        private void ValidateGendor(ValidateViewModel<TestViewModel> validateVm)
        {
            var propertyName  = nameof(TestViewModel.Gendor);
            var propertyValue = validateVm.ViewModel.Gendor;

            if (validateVm.ValidateProperties.Contains(propertyName) == false)
            {
                return;
            }

            if (propertyValue == null)
            {
                AddError(propertyName, "性別未填寫");
            }
        }

        private void ValidateSchoolType(ValidateViewModel<TestViewModel> validateVm)
        {
            var propertyName  = nameof(TestViewModel.SchoolType);
            var propertyValue = validateVm.ViewModel.SchoolType;

            if (validateVm.ValidateProperties.Contains(propertyName) == false)
            {
                return;
            }

            if (propertyValue == null)
            {
                AddError(propertyName, "就讀學校未填寫");
                return;
            }

            if (propertyValue == SchoolType.Option)
            {
                if (validateVm.ViewModel.SchoolOptionGuid == null)
                {
                    AddError(propertyName, "就讀學校未填寫");
                    return;
                }
            }
            else if (propertyValue == SchoolType.Custom)
            {
                if (validateVm.ViewModel.CustomSchoolName == null)
                {
                    AddError(propertyName, "就讀學校未填寫");
                    return;
                }
            }
        }
    }
}

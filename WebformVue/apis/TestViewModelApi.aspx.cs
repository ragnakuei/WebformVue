using System;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using WebformVue.Helpers;
using WebformVue.Models;
using WebformVue.Validators;

namespace WebformVue.apis
{
    public partial class TestViewModelApi : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static ValidateResponse Validate(List<string> ValidateProperties, TestViewModel ViewModel)
        {
            var vm = new ValidateViewModel<TestViewModel>
                     {
                         ValidateProperties = ValidateProperties,
                         ViewModel          = ViewModel
                     };

            var testViewModelValidator = new TestViewModelValidator();

            if (testViewModelValidator.Validate(vm))
            {
                return new ValidateResponse(200);
            }

            return new ValidateResponse(400, testViewModelValidator.ValidateResult);
        }

        [WebMethod]
        public static ValidateResponse Submit(List<string> ValidateProperties, TestViewModel ViewModel)
        {
            var vm = new ValidateViewModel<TestViewModel>
                     {
                         ValidateProperties = ValidateProperties,
                         ViewModel          = ViewModel
                     };

            var testViewModelValidator = new TestViewModelValidator();

            if (testViewModelValidator.Validate(vm))
            {
                return new ValidateResponse(200)
                       {
                           Model = ViewModel
                       };
            }
            else
            {
                return new ValidateResponse(400, testViewModelValidator.ValidateResult);
            }
        }
    }
}

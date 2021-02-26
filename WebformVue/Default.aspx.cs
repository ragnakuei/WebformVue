using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebformVue.Helpers;
using WebformVue.Models;
using WebformVue.Services;
using WebformVue.Validators;

namespace WebformVue
{
    public partial class Default : Page
    {
        private readonly TestViewModelValidator _testViewModelValidator;
        private readonly StoreService _storeService;

        public Default()
        {
            _testViewModelValidator = new TestViewModelValidator();
            _storeService = new StoreService();
        }

        public string GendorsJson { get; set; }

        public string SchoolOptionsJson { get; set; }

        public string InterestsJson { get; set; }

        public string ModelJson { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            GendorsJson = _storeService.GetGendors().ToJson();
            SchoolOptionsJson = _storeService.GetSchools().ToJson();
            InterestsJson = _storeService.GetInterests().ToJson();
            ModelJson = new TestViewModel().ToJson();
        }
    }

}
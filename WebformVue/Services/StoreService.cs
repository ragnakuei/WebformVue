using System;
using System.Collections.Generic;
using System.Linq;
using WebformVue.Helpers;
using WebformVue.Models;
using WebformVue.Parameters;

namespace WebformVue.Services
{
    public class StoreService
    {
        private static readonly Dictionary<int, TestViewModel> _vms;

        private readonly string _listKey = "test-list";

        private static CustomOptionItem<Guid>[] _schools
            = new CustomOptionItem<Guid>[]
              {
                  new CustomOptionItem<Guid> { Text = "學校 A", Value = Guid.NewGuid() },
                  new CustomOptionItem<Guid> { Text = "學校 B", Value = Guid.NewGuid() },
                  new CustomOptionItem<Guid> { Text = "學校 C", Value = Guid.NewGuid() },
                  new CustomOptionItem<Guid> { Text = "學校 D", Value = Guid.NewGuid() },
                  new CustomOptionItem<Guid> { Text = "學校 E", Value = Guid.NewGuid() },
              };

        private static CustomOptionItem<int>[] _interests
            = new CustomOptionItem<int>[]
              {
                  new CustomOptionItem<int> { Text = "跑步", Value  = 1 },
                  new CustomOptionItem<int> { Text = "打羽球", Value = 2 },
                  new CustomOptionItem<int> { Text = "上網", Value  = 3 },
                  new CustomOptionItem<int> { Text = "看書", Value  = 4 },
                  new CustomOptionItem<int> { Text = "追劇", Value  = 5 },
              };

        public Dictionary<int, TestViewModel> GetVms()
        {
            return _vms;
        }

        public void Add(ValidateViewModel<TestViewModel> vm)
        {
            var vms = GetVms();

            ApplyName(vm.ViewModel);

            vm.ViewModel.Id = vms.Count;
            _vms.Add(vm.ViewModel.Id.GetValueOrDefault(), vm.ViewModel);
        }

        public void Edit(ValidateViewModel<TestViewModel> vm)
        {
            ApplyName(vm.ViewModel);

            _vms[vm.ViewModel.Id.GetValueOrDefault()] = vm.ViewModel;
        }

        private void ApplyName(TestViewModel vm)
        {
            vm.GendorName = GetGendors().FirstOrDefault(g => (Gendor)g.Value == vm.Gendor)?.Text;

            if (vm.SchoolType == SchoolType.Custom)
            {
                vm.SchoolName = vm.CustomSchoolName;
            }
            else if (vm.SchoolType == SchoolType.Option)
            {
                vm.SchoolName = GetSchools().FirstOrDefault(g => g.Value == vm.SchoolOptionGuid)?.Text;
            }

            vm.InterestName = (from i1 in GetInterests()
                               join i2 in vm.Interests
                                   on i1.Value equals i2
                               select i1.Text).ToArray();
        }

        public CustomOptionItem<int>[] GetGendors()
        {
            return new CustomOptionItem<int>[]
                   {
                       new CustomOptionItem<int> { Text = "不明", Value = (int)Gendor.Unknown },
                       new CustomOptionItem<int> { Text = "男", Value  = (int)Gendor.Male },
                       new CustomOptionItem<int> { Text = "女", Value  = (int)Gendor.Female },
                   };
        }

        public CustomOptionItem<Guid>[] GetSchools()
        {
            return _schools;
        }

        public CustomOptionItem<int>[] GetInterests()
        {
            return _interests;
        }

        public TestViewModel Get(int id)
        {
            return GetVms().GetValue(id);
        }

        public void Delete(int id)
        {
            _vms.Remove(id);
        }
    }
}

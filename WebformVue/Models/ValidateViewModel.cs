using System.Collections.Generic;

namespace WebformVue.Models
{
    public class ValidateViewModel<T>
    {
        /// <summary>
        /// 要進行檢查的 Property Names
        /// </summary>
        public List<string> ValidateProperties { get; set; }

        public T ViewModel { get; set; }
    }
}

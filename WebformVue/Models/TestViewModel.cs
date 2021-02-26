using System;
using WebformVue.Parameters;

namespace WebformVue.Models
{
    public class TestViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 確認密碼
        /// </summary>
        public string RePassword { get; set; }

        /// <summary>
        /// 年齡
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        public Gendor? Gendor { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        public string GendorName { get; set; }

        /// <summary>
        /// 興趣
        /// </summary>
        public int[] Interests { get; set; }

        /// <summary>
        /// 興趣
        /// </summary>
        public string[] InterestName { get; set; }

        /// <summary>
        /// 就讀學校
        /// </summary>
        public SchoolType? SchoolType { get; set; }

        /// <summary>
        /// 手動輸入 學校名稱
        /// </summary>
        public string CustomSchoolName { get; set; }

        /// <summary>
        /// 學校 Guid
        /// </summary>
        public Guid? SchoolOptionGuid { get; set; }

        /// <summary>
        /// 學校名
        /// </summary>
        public string SchoolName { get; set; }
    }
}

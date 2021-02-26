using System.Collections.Generic;

namespace WebformVue.Models
{
    public class ValidateResponse
    {
        public ValidateResponse(int?                             statusCode,
                                Dictionary<string, List<string>> validateResult = null)
        {
            StatusCode     = statusCode;
            ValidateResult = validateResult;
        }

        public int? StatusCode { get; private set; }

        public Dictionary<string, List<string>> ValidateResult { get; private set; }

        public object Model { get; set; }
    }
}

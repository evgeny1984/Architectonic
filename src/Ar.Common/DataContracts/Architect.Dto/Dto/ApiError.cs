using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architect.Dto.Dto
{
    [JsonObject(MemberSerialization.Fields)]
    public class ApiError
    {
        private readonly int statusCode;
        private readonly string message;

        #region Properties

        public int StatusCode => statusCode;

        public string Message => message;

        #endregion

        [JsonConstructor]
        public ApiError() { }

        public ApiError(int statuscode, string message)
            => (statusCode, this.message) = (statuscode, message ?? "Internal Server Error");

        public override string ToString()
            => JsonConvert.SerializeObject(this);
    }
}

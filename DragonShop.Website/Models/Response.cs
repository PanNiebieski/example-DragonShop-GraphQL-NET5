using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonShop.Website.Models
{
    public class Response<T>
    {
        public T Data { get; set; }
        public List<ErrorModel> Errors { get; set; }

        public void ThrowErrors()
        {
            if (Errors != null && Errors.Any())
                throw new GraphQlException(
                    $"Message: {Errors[0].Message} Code: {Errors[0].Code}");
        }
    }

    public class GraphQlException : ApplicationException
    {
        public GraphQlException(string message) : base(message)
        {
        }
    }
}

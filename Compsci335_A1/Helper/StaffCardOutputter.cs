using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Compsci335_A1.Dtos;

namespace Compsci335_A1.Helper
{
    public class StaffCardOutputter : TextOutputFormatter
    {
        public StaffCardOutputter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/vcard"));
            SupportedEncodings.Add(Encoding.UTF8);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            StaffCardOut card = (StaffCardOut)context.Object;
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("BEGIN:VCARD");
            builder.AppendLine("VERSION:4.0");
            builder.Append("N:").AppendLine(card.Name);
            builder.Append("FN:").AppendLine(card.FullName);
            if (card.Uid != -1)
            {
                builder.Append("UID:").AppendLine(card.Uid + "");
            }
            else
            {
                builder.Append("UID:").AppendLine("");
            }
            builder.Append("ORG:").AppendLine(card.Company);
            builder.Append("EMAIL;TYPE=work:").AppendLine(card.Email);
            builder.Append("TEL:").AppendLine(card.Tel);
            builder.Append("URL:").AppendLine(card.Url);
            builder.Append("CATEGORIES:").AppendLine(card.Categories);
            builder.Append("PHOTO;ENCODING=BASE64;TYPE=").Append(card.PhotoType).Append(":").AppendLine(card.Photo);
            builder.Append("LOGO;ENCODING=BASE64;TYPE=").Append(card.LogoType).Append(":").AppendLine(card.Logo);
            builder.AppendLine("END:VCARD");
            string outString = builder.ToString();
            byte[] outBytes = selectedEncoding.GetBytes(outString);
            var response = context.HttpContext.Response.Body;
            return response.WriteAsync(outBytes, 0, outBytes.Length);
        }
    }
}

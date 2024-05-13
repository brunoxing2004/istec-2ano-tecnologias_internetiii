using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DemoObjetos.Models
{
    public class UpperMeResult : ActionResult
    {
        private string _str;
        public UpperMeResult(string str)
        {
            _str = str;
        }

        public override void ExecuteResult(ActionContext context)
        {
            //base.ExecuteResult(context);    
            var bytesUpper = Encoding.UTF8.GetBytes(_str.ToUpper());
            context.HttpContext.Response.Body.WriteAsync(bytesUpper, 0, bytesUpper.Length);
        }


    }
}

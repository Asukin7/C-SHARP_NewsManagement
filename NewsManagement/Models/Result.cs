using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsManagement.Models
{
    public class Result
    {
        public int code { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
        public static Result success()
        {
            Result result = new Result();
            result.code = 0;
            result.msg = "成功";
            return result;
        }
        public static Result success(object obj)
        {
            Result result = new Result();
            result.code = 0;
            result.msg = "成功";
            result.data = obj;
            return result;
        }
        public static Result fail()
        {
            Result result = new Result();
            result.code = 1;
            result.msg = "失败";
            return result;
        }
        public static Result fail(object obj)
        {
            Result result = new Result();
            result.code = 1;
            result.msg = "失败";
            result.data = obj;
            return result;
        }
    }
}
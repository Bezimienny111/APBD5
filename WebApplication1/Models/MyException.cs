using System;
namespace WebApplication1.Models
{
    public class MyException : Exception {
        public int i { get; internal set; }

        public MyException(String s, int intin) : base(s) {
             i = intin;
        }
    }
}

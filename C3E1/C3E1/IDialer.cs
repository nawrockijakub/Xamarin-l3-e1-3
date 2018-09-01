using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace C3E1
{
    public interface IDialer
    {
        Task<bool> DialAsync(string number);
    }
}

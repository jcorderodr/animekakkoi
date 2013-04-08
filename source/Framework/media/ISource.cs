using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.media
{
    public interface ISource : IDisposable
    {

        void DisassembleSource(string html);
    }
}

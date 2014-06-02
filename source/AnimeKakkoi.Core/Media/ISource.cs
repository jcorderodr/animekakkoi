using System;
using System.Collections.Generic;

namespace AnimeKakkoi.Core.Media
{
    public interface ISource : IDisposable
    {

        IEnumerable<Object> ResultedItems { get; }

    }
}

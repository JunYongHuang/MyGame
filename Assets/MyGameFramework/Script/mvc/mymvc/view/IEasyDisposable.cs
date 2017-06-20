using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

interface IEasyDisposable
{
    bool HasDisposed { get; }

    bool Dispose(float t = 0);
}
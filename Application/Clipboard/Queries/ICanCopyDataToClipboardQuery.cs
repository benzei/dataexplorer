﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Clipboard.Queries
{
    public interface ICanCopyDataToClipboardQuery
    {
        bool Execute();
    }
}

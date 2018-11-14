﻿using NTwain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTwain.Triplets
{
    /// <summary>
    /// Represents <see cref="DataGroups.Control"/>.
	/// </summary>
    public partial class DGControl : BaseTriplet
    {
        internal DGControl(TwainSession session) : base(session) { }

        Parent _parent;
        internal Parent Parent => _parent ?? (_parent = new Parent(session));

        EntryPoint _entryPoint;
        internal EntryPoint EntryPoint => _entryPoint ?? (_entryPoint = new EntryPoint(session));
    }
}
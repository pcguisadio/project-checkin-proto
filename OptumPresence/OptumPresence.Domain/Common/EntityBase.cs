﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptumPresence.Domain.Common
{
    /// <summary>
    /// Base Class for all enitity classes.
    /// </summary>
    public class EntityBase
    {
        public DateTime RecordCreateDate { get; set; }
        public DateTime RecordCreateUserId { get; set; }
        public DateTime RecordUpdateDate { get; set; }
        public DateTime RecordUpdateUserId { get; set; }
    }
}

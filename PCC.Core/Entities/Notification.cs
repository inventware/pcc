using System;
using System.Collections.Generic;
using System.Text;

namespace PCC.Core.Entities
{
    public abstract class Notification
    {
        public Notification(string code, string description)
        {
            Code = code ?? "Error";
            Description = description;
        }


        public string Code { get; }

        public string Description { get; }
    }
}

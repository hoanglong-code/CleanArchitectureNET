using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.Enums.ApiEnums;

namespace Infrastructure.Commons
{
    public class SignalRNotify
    {
        public string Title { get; set; }
        public string Contents { get; set; }
        public TypeSignalRNotify Type { get; set; }

        public SignalRNotify(string title, string contents, TypeSignalRNotify type)
        {
            Title = title;
            Contents = contents;
            Type = type;
        }
    }
}

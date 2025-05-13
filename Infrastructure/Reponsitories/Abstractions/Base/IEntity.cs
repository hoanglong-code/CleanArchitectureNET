using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Reponsitories.Abstractions
{
    public interface IEntity<out T>
    {
        T Id { get; }
    }
}

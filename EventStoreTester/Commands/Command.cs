using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStoreTester.Commands {
  public class Command {
    public Guid AggregateId { get; set; }
  }
}

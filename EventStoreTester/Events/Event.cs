using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStoreTester.Events {
  public class Event {
    public Guid AggregateId { get; set; }
  }
}

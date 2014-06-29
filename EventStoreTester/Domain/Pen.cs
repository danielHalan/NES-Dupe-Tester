using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonDomain.Core;
using EventStoreTester.Events;

namespace EventStoreTester.Domain {

  public class Pen : AggregateBase {

    public string Name { get; set; }

    public Pen()
      : base() {
      Id = Guid.Empty;
    }

    public Pen(Guid id)
      : base() {
      Id = id;
    }

    private Pen(Guid penId, string name)
      : base() {

      Id = penId;

      RaiseEvent(new PenCreated() {
        AggregateId = penId,
        Name = name
      });
    }


    public static Pen CreateNew(Guid penId, string name) {
      return new Pen(penId, name);
    }

    protected void Apply(PenCreated @event) {
      Name = @event.Name;
    }

  
  }
}

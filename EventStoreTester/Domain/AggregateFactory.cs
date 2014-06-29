using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Persistence;

namespace EventStoreTester {
  public class AggregateFactory : IConstructAggregates {

    public IAggregate Build(Type type, Guid id, IMemento snapshot) {
      return Activator.CreateInstance(type, id) as IAggregate;
    }

  }
}

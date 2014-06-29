using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEventStore.Dispatcher;

namespace EventStoreTester.ServiceBus {
  
  public class SBCommitDispatcher : IDispatchCommits {
    
    public void Dispatch(NEventStore.ICommit commit) {
    }

    public void Dispose() {
    }
  }
}

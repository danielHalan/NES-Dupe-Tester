using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonDomain.Core;
using CommonDomain.Persistence.EventStore;
using EventStoreTester.Commands;
using EventStoreTester.Domain;
using EventStoreTester.ServiceBus;
using NEventStore;
using NEventStore.Persistence.Sql.SqlDialects;
using NLog;

namespace EventStoreTester {
  
  public class CommandHandler {

    static Logger _log = LogManager.GetCurrentClassLogger();

    EventStoreRepository rep;

    public CommandHandler(string connectionStr) {

      var es = Wireup.Init()
          .UsingSqlPersistence(new SqlTenantEventStoreConnectionFactory(connectionStr)) 
              .WithDialect(new MsSqlDialect())
              .InitializeStorageEngine()
              //.UsingCustomSerialization(new Itq.EventStore.EventSerializer())
              .UsingJsonSerialization()
            .UsingSynchronousDispatchScheduler()
              .DispatchTo(new SBCommitDispatcher())
            .Build();

      rep = new EventStoreRepository(es, new AggregateFactory(), new ConflictDetector());
    }

    public void Handle(CreateNote m) {
      Note note = Note.CreateNew(m.AggregateId, m.Text);

      rep.Save("system", note, Guid.NewGuid(), null);
      
      _log.Info("Successfully Created Note with Id " + m.AggregateId);
    }

    public void Handle(CreatePen m) {
      Pen pen = Pen.CreateNew(m.AggregateId, m.Name);

      rep.Save("system", pen, Guid.NewGuid(), null);

      _log.Info("Successfully Created Pen with Id " + m.AggregateId);
    }


  }
}

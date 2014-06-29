using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventStoreTester.Commands;
using NLog;

namespace EventStoreTester {
  class Program {

    static Logger _log = LogManager.GetCurrentClassLogger();

    static void Main(string[] args) {

      var connectionStr =
      "Server=tcp:xxxxxxx.database.windows.net,1433;Database=test_events;User ID=yyyyyy@xxxxxxx;Password=zzzzzzz;Trusted_Connection=False;Encrypt=True;Connection Timeout=30; Enlist=False;";

      CommandHandler ch = new CommandHandler(connectionStr);

      var cmdNote = new CreateNote() { 
        AggregateId = Guid.NewGuid(), 
        Text = "Test1" 
      };

      _log.Info("Sendig CreateNote command First Time");
      ch.Handle(cmdNote);

      _log.Info("Sendig CreateNote command Second Time");
      ch.Handle(cmdNote);


      var cmdPen = new CreatePen() { 
        AggregateId = Guid.NewGuid(), 
        Name = "Itq" 
      };

      _log.Info("Sendig CreatePen command");
      ch.Handle(cmdPen);


      Console.Write("Finished, press any key to exit...");
      Console.ReadKey();
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStoreTester.Commands {
  public class CreateNote : Command {

    public string Text { get; set; }
  }
}

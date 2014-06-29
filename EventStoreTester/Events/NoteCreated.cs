using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStoreTester.Events {
  public class NoteCreated : Event {

    public string Text { get; set; }
  
  }
}

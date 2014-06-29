using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonDomain.Core;
using EventStoreTester.Events;

namespace EventStoreTester.Domain {

  public class Note : AggregateBase {

    public string Text { get; set; }

    public Note()
      : base() {
      Id = Guid.Empty;
    }

    public Note(Guid id)
      : base() {
      Id = id;
    }

    private Note(Guid noteId, string note)
      : base() {

      Id = noteId;

      RaiseEvent(new NoteCreated() {
        AggregateId = noteId,
        Text = note
      });
    }


    public static Note CreateNew(Guid noteId, string note) {
      return new Note(noteId, note);
    }

    protected void Apply(NoteCreated @event) {
      Text = @event.Text;
    }
  }
}

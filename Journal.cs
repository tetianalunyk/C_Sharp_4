using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Journal
    {
        private List<JournalEntry> Changes = new List<JournalEntry>();

        public void JournalEventHandler(object source, StudentListHandlerEventArgs eventArgs)
        {
            JournalEntry journalEntry = new JournalEntry(eventArgs.CollectionName, eventArgs.TypeOfChanges, eventArgs.Student);
            Changes.Add(journalEntry);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            foreach (var change in Changes)
            {
                stringBuilder.Append($"\n Collection Name: {change.CollectionName} Type of Changes: { change.TypeOfChanges } {change.GetStudent.ToString()}\n");
            }
            return stringBuilder.ToString();
        }
    }
}

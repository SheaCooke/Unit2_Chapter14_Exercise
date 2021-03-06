using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Models
{
    
    public class Event
    {

        public string Name { get; set; }
        public string Description { get; set; }

        public int Id { get; }

        private static int nextId = 1;

        public Event(string name, string description) :this()
        {
            this.Name = name;
            this.Description = description;
            
        }

        public Event()
        {
            this.Id = nextId;
            nextId++;
        }


        public override string ToString()
        {
            return base.ToString();
            {
                return Name;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event && Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}

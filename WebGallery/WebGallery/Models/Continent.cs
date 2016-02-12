using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebGallery.Models
{
    public class Continent : IMapEntity
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string FullName { get; set; }

        public State State { get; set; }

        public void SetState(State state)
        {
            State = state;
        }

        public Continent(string name, string fullName, State state)
        {
            Name = name;
            FullName = fullName;
            State = state;
        }

        public Continent() { }

        public override string ToString()
        {
            return FullName;
        }
    }
}
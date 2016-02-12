using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebGallery.Models
{
    public class Country : IMapEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; }
        public string FullName { get; }
        public State State { get; set; }

        public Continent Continent { get; set; }

        public void SetState(State state)
        {
            State = state;
        }
        public Country() { }

        public Country(string name, string fullName, State state)
        {
            Name = name;
            FullName = fullName;
            State = state;
        }
    }
}
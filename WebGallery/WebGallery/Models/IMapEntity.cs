using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGallery.Models
{
    public enum State
    {
        Undefined = 0,
        Visited = 1,
        Favorite = 2,
        WantToVisit = 3,

    }

    interface IMapEntity
    {
        int Id { get; }

        string Name { get; }

        string FullName { get; }

        State State { get; }

        void SetState(State state);

    }
}
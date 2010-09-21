using System;
using Agendas.Entities;

namespace Agendas.Views
{
    public interface IDagView
    {
        DateTime Date { get; }
        bool HasChanged { get; }
        IDag Dag { set; get; }
    }
}
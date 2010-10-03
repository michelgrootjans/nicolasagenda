using System;
using Agendas.Entities;

namespace Agendas.Views
{
    public interface IDagView
    {
        DateTime Date { get; set; }
        bool HasChanged { get; }
        IDag Dag { set; get; }
        bool HasFocus { get; }
    }
}
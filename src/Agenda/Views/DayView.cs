using System;
using System.Collections.Generic;
using System.Linq;
using Agendas.Entities;

namespace Agendas.Views
{
    public partial class DayView : MdiChild, IDagView
    {
        private readonly IDictionary<int, _vak> vakken = new Dictionary<int, _vak>();
        public DateTime Date { get; set; }
        private IDag dag;
        private IDagViewPresenter presenter;

        public bool HasChanged
        {
            get { return vakken.Any(v => v.Value.HasChanged); }
        }

        public DayView() : this(DateTime.Now)
        {
        }

        public DayView(DateTime dateTime)
        {
            InitializeComponent();

            Date = dateTime.Date;
            vakken.Add(1, _vak1);
            vakken.Add(2, _vak2);
            vakken.Add(3, _vak3);
            vakken.Add(4, _vak4);
            vakken.Add(5, _vak5);
            vakken.Add(6, _vak6);
            vakken.Add(7, _vak7);
        }

        private void DayView_Load(object sender, EventArgs e)
        {
            if(DesignMode) return;
            presenter = new DagPresenter(this);
            presenter.Initialize();
        }

        public IDag Dag
        {
            set
            {
                if (value == null) return;

                dag = value;
                Text = dag.Date.ToLongDateString();
                foreach (var vak in dag.Vakken)
                    vakken[vak.Uur].SetVak(vak);
                _taakView.SetTaken(dag.Taken.Cast<ITaak>());
            }
            get { return dag; }
        }
    }
}
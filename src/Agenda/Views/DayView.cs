using System;
using System.Collections.Generic;
using System.Linq;
using Agendas.Entities;

namespace Agendas.Views
{
    public partial class DayView : MdiChild<DayView>, IDagView
    {
        private readonly IDictionary<int, _vak> vakken = new Dictionary<int, _vak>();
        public DateTime Date { get; private set; }
        private IDag dag;

        public bool HasChanged
        {
            get { return vakken.Any(v => v.Value.HasChanged); }
        }

        public DayView() : this(DateTime.Now)
        {
        }

        public DayView(DateTime date)
        {
            InitializeComponent();

            Date = date.Date;
            vakken.Add(1, _vak1);
            vakken.Add(2, _vak2);
            vakken.Add(3, _vak3);
            vakken.Add(4, _vak4);
            vakken.Add(5, _vak5);
            vakken.Add(6, _vak6);
            vakken.Add(7, _vak7);
        }

        protected override IPresenter<DayView> CreatePresenter()
        {
            return new DagPresenter(this);
        }

        private void DayView_Load(object sender, EventArgs e)
        {
            presenter.Initialize();
        }

        public IDag Dag
        {
            set
            {
                dag = value;
                foreach (var vak in dag.Vakken)
                    vakken[vak.Uur].SetVak(vak);
            }
            get { return dag; }
        }
    }
}
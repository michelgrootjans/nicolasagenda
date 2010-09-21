//using System;
//using System.Collections.Generic;
//using Agendas.Infrastructure;

//namespace Agendas.Requests
//{
//    public class GetDayRequest : IRequest<GetDayResponse>
//    {
//        public GetDayRequest(DateTime dateTime)
//        {
//            Date = dateTime.Date;
//        }

//        public DateTime Date { get; private set; }
//    }

//    public class GetDayResponse
//    {
//        public DateTime Date { get; private set; }
//        public IEnumerable<LesUurInfo> Vakken { get; private set; }
//    }

//    public class LesUurInfo
//    {
//        public int Uur { get; private set; }
//        public string Naam { get; private set; }
//        public string Content { get; private set; }
//    }
//}
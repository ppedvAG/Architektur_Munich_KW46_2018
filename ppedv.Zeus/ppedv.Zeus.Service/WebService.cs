using AutoMapper;
using ppedv.Zeus.Logic;
using ppedv.Zeus.Model;
using ppedv.Zeus.Service.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Zeus.Service
{
    public class WebService : IService
    {

        public WebService()
        {
            Trace.Listeners.Add(new EventLogTraceListener("Application"));
        }

        Core core = new Core();
        public void AddDrucker(DruckerWCF drucker)
        {
            var op = OperationContext.Current;
            Trace.WriteLine($"{op.Channel.RemoteAddress} Add drucker {drucker.Hersteller}");
            core.Repository.Add(Mapper.Map<Drucker>(drucker));
            core.Repository.Save();
        }


        public IEnumerable<Auftrag> GetAllAuftrag()
        {
            return core.Repository.GetAll<Auftrag>();
        }

        public IEnumerable<DruckerWCF> GetAllDrucker()
        {
            //return core.Repository.GetAll<Drucker>();

            foreach (var d in core.Repository.GetAll<Drucker>())
            {
                yield return Mapper.Map<DruckerWCF>(d);
                //yield return new DruckerWCF()
                //{
                //    Hersteller = i.Hersteller,
                //    Id = i.Id,
                //    MaxX = i.MaxX,
                //    MaxY = i.MaxY,
                //    MaxZ = i.MaxZ,
                //    Model = i.Model,
                //    Schnittstelle = i.Schnittstelle,
                //    Speed = i.Speed
                //};
            }
        }

         static WebService()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Drucker, DruckerWCF>()
                            //   .ForMember(x => x.Haus, opt => opt.Ignore())
                            //   .ForSourceMember(x => x.Verbrauch, o => o.Ignore())
                            .ReverseMap());
        }
    }
}

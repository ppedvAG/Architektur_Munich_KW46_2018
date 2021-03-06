﻿using ppedv.Zeus.Data.AnetA8;
using ppedv.Zeus.Model;
using ppedv.Zeus.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.Zeus.Logic
{
    public class Core
    {
        public IRepository Repository { get; private set; }

        public Dictionary<Drucker, I3dDrucker> Drucker { get; private set; }

        public Core(IRepository repository)
        {
            this.Repository = repository;
            InitDrucker();
        }

        private void InitDrucker()
        {
            Drucker = new Dictionary<Drucker, I3dDrucker>();
            foreach (var d in Repository.GetAll<Drucker>())
            {
                //if(d.Hersteller=="Anet")
                Drucker.Add(d, new Data.AnetA8.Anet());
            }
        }

        public Core() : this(new Data.EF.EfRepository())
        { }

        public Drucker GetDruckerWithLargestVolume()
        {
            return Repository.GetAll<Drucker>().OrderByDescending(x => x.MaxX * x.MaxY * x.MaxZ).ThenBy(x => x.Created).FirstOrDefault();
        }

        public void CreateDemodaten()
        {
            var m1 = new Modell() { Name = "Model Eins" };
            var m2 = new Modell() { Name = "Model Zwei" };

            var d1 = new Drucker() { Hersteller = "Anet", Model = "A8", MaxX = 220, MaxY = 220, MaxZ = 240, Speed = 60, Schnittstelle = "USB" };
            var d2 = new Drucker() { Hersteller = "CTC", Model = "DIY i3", MaxX = 220, MaxY = 220, MaxZ = 240, Speed = 60, Schnittstelle = "USB" };
            var d3 = new Drucker() { Hersteller = "Prusa", Model = "MK3", MaxX = 250, MaxY = 210, MaxZ = 210, Speed = 200, Schnittstelle = "USB" };
            var d4 = new Drucker() { Hersteller = "LulzBot", Model = "TAZ 6", MaxX = 280, MaxY = 280, MaxZ = 250, Speed = 300, Schnittstelle = "USB" };

            var a1 = new Auftrag() { Start = DateTime.Now.AddDays(-5), Status = Auftragstatus.Fertig, Modell = m1, Drucker = d1 };
            var a2 = new Auftrag() { Start = DateTime.Now.AddDays(-4), Status = Auftragstatus.Abgebrochen, Modell = m1, Drucker = d2 };
            var a3 = new Auftrag() { Start = DateTime.Now.AddDays(-3), Status = Auftragstatus.Fertig, Modell = m2, Drucker = d3 };
            var a4 = new Auftrag() { Start = DateTime.Now.AddDays(-1), Status = Auftragstatus.Aktiv, Modell = m2, Drucker = d4 };


            Repository.Add(a1);
            Repository.Add(a2);
            Repository.Add(a3);
            Repository.Add(a4);
            Repository.Save();
        }
    }
}

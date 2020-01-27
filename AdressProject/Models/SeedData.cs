using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressProject.Models
{
    public class SeedData
    {


        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var Context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                if (Context.Adresses.Any())
                {
                    return;
                }
                Context.Adresses.AddRange(
                    new Adress { Name = "Ebru", SurName = "Şahin", PhoneNumber = "05452078669", Adres="Emek Mah, Ekrem Sok Darıca/Kocaeli", AdressType = new AdressType() { AdressTipi = "Ev" } },
                   new Adress { Name = "Anıl", SurName = "Demiroğlu", PhoneNumber = "05538240952", Adres = "Hürriyet Mah,Trump Tower Mecidiyeköy/İstanbul", AdressType = new AdressType() { AdressTipi = "İş" } },
                   new Adress { Name = "Buğra", SurName = "Kaplan", PhoneNumber = "05538241238", Adres = "İstiklal Mah, Papatya sok, Şişli/İstanbul", AdressType = new AdressType() { AdressTipi = "Okul" } },
                   new Adress { Name = "Selin", SurName = "Çolak", PhoneNumber = "05534560958", Adres = "Muratpaşa Mah, Fikribey apt, Üsküdar/İstanbul", AdressType = new AdressType() { AdressTipi = "Evv" } }
                    );

                Context.SaveChanges();
            }

        }
    }
}

using WebAPI.DTO;
using WebAPI.Model;

namespace WebAPI.Serwice
{
    public class Service : IService
    {
        private static List<Klawiatura> keyboards = new List<Klawiatura>
        {
            new Klawiatura { ID = 1, Model = "Logitech K120", Type = KeyboardType.Membranowa },
            new Klawiatura { ID = 2, Model = "Dell KB216", Type = KeyboardType.Nożycowa },
        };

        public void DeleteKlawiatury(int id)
        {
            var keyboard = keyboards.FirstOrDefault(k => k.ID == id);
            if (keyboard == null)
            {
                return;
            }
            keyboards.Remove(keyboard);
        }

        public IEnumerable<KlawiaturaResponceDTO> getKlawiatury()
        {
            return keyboards.Select(k => new KlawiaturaResponceDTO
            {
                ID = k.ID,
                Model = k.Model,
                Type = k.Type
            });
        }

        public void PostKlawiatura(KlawiaturyRequestDTO klawiaturyRequestDTO)
        {
            keyboards.Add(new Klawiatura
            {
                ID = keyboards.Max(k => k.ID) + 1,
                Model = klawiaturyRequestDTO.Model,
                Type = klawiaturyRequestDTO.Type
            });
        }
    }
}

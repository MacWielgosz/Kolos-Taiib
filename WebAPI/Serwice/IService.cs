using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;

namespace WebAPI.Serwice
{
    public interface IService
    {
        IEnumerable<KlawiaturaResponceDTO> getKlawiatury();
        void PostKlawiatura(KlawiaturyRequestDTO klawiaturyRequestDTO);
        void DeleteKlawiatury(int id);

    }
}

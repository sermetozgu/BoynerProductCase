using AutoMapper;
using BoynerCase.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Urun, UrunDTO>(); // Urun modelini UrunDTO'ya dönüştürme kuralını belirtin
    }
}
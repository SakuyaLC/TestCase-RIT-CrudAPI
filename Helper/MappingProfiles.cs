using AutoMapper;
using TestCase_RIT_CrudAPI.Data.DTO;
using TestCase_RIT_CrudAPI.Model;

namespace TestCase_RIT_CrudAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<DrillBlock, DrillBlockDTO>();
            CreateMap<DrillBlockDTO, DrillBlock>();

            CreateMap<DrillBlockPoint, DrillBlockPointDTO>();
            CreateMap<DrillBlockPointDTO, DrillBlockPoint>();

            CreateMap<Hole, HoleDTO>();
            CreateMap<HoleDTO, Hole>();

            CreateMap<HolePoint, HolePointDTO>();
            CreateMap<HolePointDTO, HolePoint>();
        }
    }
}

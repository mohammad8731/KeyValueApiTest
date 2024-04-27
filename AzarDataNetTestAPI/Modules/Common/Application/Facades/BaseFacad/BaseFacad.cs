using AutoMapper;
using AzarDataNetTestAPI.Modules.Common.Domain.Interfaces.Repositories;

namespace AzarDataNetTestAPI.Modules.Common.Application.Facades.BaseFacad
{
    public class BaseFacad
    {
        protected readonly IDatabaseContext _context;

        protected IMapper _mapper;

        //protected DomainDto _domain;

        //protected IFacadPic _facadPic;

        protected IServiceProvider _serviceProvider;

        protected BaseFacad()
        {

        }

        protected BaseFacad(IDatabaseContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        protected void SetMapper(IServiceScope serviceScope)
        {
            _mapper ??= (IMapper)serviceScope.ServiceProvider.GetRequiredService(typeof(IMapper));
        }

        //protected void SetPic(IServiceScope serviceScope)
        //{
        //    _facadPic ??= (IFacadPic)serviceScope.ServiceProvider.GetRequiredService(typeof(IFacadPic));
        //}
        //protected void SetDomain(IServiceScope serviceScope)
        //{
        //    _domain ??= (DomainDto)serviceScope.ServiceProvider.GetRequiredService(typeof(DomainDto));
        //}
    }
}
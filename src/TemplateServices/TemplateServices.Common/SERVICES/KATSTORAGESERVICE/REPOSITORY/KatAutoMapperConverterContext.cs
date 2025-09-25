using AutoMapper;
using Microsoft.EntityFrameworkCore;
using $ext_safeprojectname$Services.Db.Context;


namespace $safeprojectname$.Services.$ext_safeprojectname$StorageService.Repository;


public class $ext_safeprojectname$AutoMapperConverterContext : $ext_safeprojectname$DbContext
{
    private readonly IMapper _mapper;


    public $ext_safeprojectname$AutoMapperConverterContext(DbContextOptions<$ext_safeprojectname$AutoMapperConverterContext> options, IMapper mapper)
        : base(options)
    {
        _mapper = mapper;
    }

    
    /// <inheritdoc/>
    public override bool IsAutoLoggingForEntitiesEnabled => true;


    /// <inheritdoc/>
    protected override object ConvertEntityToLog(object entity, Type sourceType, Type destinationType) => _mapper.Map(entity, sourceType, destinationType);
}
using CIFRAS.Application.AppServices;
using CIFRAS.Application.Interfaces;
using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Domain.Interfaces.Security;
using CIFRAS.Domain.Interfaces.Services;
using CIFRAS.Domain.Services;
using CIFRAS.Infra.CrossCutting.Security;
using CIFRAS.Infra.Data.Context;
using CIFRAS.Infra.Data.Repositories;
using SimpleInjector;

namespace CIFRAS.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            //App
            container.Register<ICategoriaArquivoAppService, CategoriaArquivoAppService>(Lifestyle.Scoped);
            container.Register<IArquivoAppService, ArquivoAppService>(Lifestyle.Scoped);
            container.Register<IBancoAppService, BancoAppService>(Lifestyle.Scoped);
            container.Register<IContaAppService, ContaAppService>(Lifestyle.Scoped);
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);
            container.Register<IContatoAppService, ContatoAppService>(Lifestyle.Scoped);
            container.Register<IContratoAppService, ContratoAppService>(Lifestyle.Scoped);
            container.Register<IEnderecoAppService, EnderecoAppService>(Lifestyle.Scoped);
            container.Register<ITipoContratoAppService, TipoContratoAppService>(Lifestyle.Scoped);
            container.Register<ITipoClienteAppService, TipoClienteAppService>(Lifestyle.Scoped);
            container.Register<ICorretorAppService, CorretorAppService>(Lifestyle.Scoped);
            container.Register<IReciboAppService, ReciboAppService>(Lifestyle.Scoped);
            container.Register<IReciboEmprestimoAppService, ReciboEmprestimoAppService>(Lifestyle.Scoped);
            container.Register<IImportacaoAppService, ImportacaoAppService>(Lifestyle.Scoped);
            container.Register<IFuncionarioAppService, FuncionarioAppService>(Lifestyle.Scoped);

            //Domain
            container.Register<ICategoriaArquivoService, CategoriaArquivoService>(Lifestyle.Scoped);
            container.Register<IArquivoService, ArquivoService>(Lifestyle.Scoped);
            container.Register<IContaService, ContaService>(Lifestyle.Scoped);
            container.Register<IBancoService, BancoService>(Lifestyle.Scoped);
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);
            container.Register<IContatoService, ContatoService>(Lifestyle.Scoped);
            container.Register<IContratoService, ContratoService>(Lifestyle.Scoped);
            container.Register<IEnderecoService, EnderecoService>(Lifestyle.Scoped);
            container.Register<ITipoContratoService, TipoContratoService>(Lifestyle.Scoped);
            container.Register<ITipoClienteService, TipoClienteService>(Lifestyle.Scoped);
            container.Register<ICorretorService, CorretorService>(Lifestyle.Scoped);
            container.Register<IReciboService, ReciboService>(Lifestyle.Scoped);
            container.Register<IReciboEmprestimoService, ReciboEmprestimoService>(Lifestyle.Scoped);
            container.Register<IImportacaoService, ImportacaoService>(Lifestyle.Scoped);
            container.Register<IFuncionarioService, FuncionarioService>(Lifestyle.Scoped);

            //Data
            container.Register<ICategoriaArquivoRepository, CategoriaArquivoRepository>(Lifestyle.Scoped);
            container.Register<IArquivoRepository, ArquivoRepository>(Lifestyle.Scoped);
            container.Register<IContaRepository, ContaRepository>(Lifestyle.Scoped);
            container.Register<IBancoRepository, BancoRepository>(Lifestyle.Scoped);
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IContatoRepository, ContatoRepository>(Lifestyle.Scoped);
            container.Register<IContratoRepository, ContratoRepository>(Lifestyle.Scoped);
            container.Register<IEnderecoRepository, EnderecoRepository>(Lifestyle.Scoped);
            container.Register<ITipoContratoRepository, TipoContratoRepository>(Lifestyle.Scoped);
            container.Register<ITipoClienteRepository, TipoClienteRepository>(Lifestyle.Scoped);
            container.Register<IFuncionarioRepository, FuncionarioRepository>(Lifestyle.Scoped);
          
            //Security
            container.Register<ISecurity, Safety>(Lifestyle.Scoped);
            container.Register<ICorretorRepository, CorretorRepository>(Lifestyle.Scoped);
            container.Register<IReciboRepository, ReciboRepository>(Lifestyle.Scoped);
            container.Register<IReciboEmprestimoRepository, ReciboEmprestimoRepository>(Lifestyle.Scoped);

            //Context
            container.Register<CifrasContext>(Lifestyle.Scoped);
        }
    }
}
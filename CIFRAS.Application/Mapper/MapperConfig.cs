using AutoMapper;
using CIFRAS.Application.ViewModel;
using CIFRAS.Domain.Entities;

namespace CIFRAS.Application.Mapper
{
    public class MapperConfig
    {
        public static IMapper Mapper;

        public static void RegisterMappings()
        {
            Mapper = new MapperConfiguration(x =>
            {
                x.CreateMap<CategoriaArquivo, CategoriaArquivoVm>().PreserveReferences().ReverseMap();
                x.CreateMap<Arquivo, ArquivoVm>().PreserveReferences().ReverseMap();
                x.CreateMap<Conta, ContaVm>().PreserveReferences().ReverseMap();
                x.CreateMap<Banco, BancoVm>().PreserveReferences().ReverseMap();
                x.CreateMap<Cliente, ClienteVm>().PreserveReferences().ReverseMap();
                x.CreateMap<Contato, ContatoVm>().PreserveReferences().ReverseMap();
                x.CreateMap<Contrato, ContratoVm>().PreserveReferences().ReverseMap();
                x.CreateMap<Endereco, EnderecoVm>().PreserveReferences().ReverseMap();
                x.CreateMap<TipoContrato, TipoContratoVm>().PreserveReferences().ReverseMap();
                x.CreateMap<TipoCliente, TipoClienteVm>().PreserveReferences().ReverseMap();
                x.CreateMap<Funcionario, FuncionarioVm>().PreserveReferences().ReverseMap();
                x.CreateMap<Funcionario, LoginVm>().PreserveReferences().ReverseMap();
                x.CreateMap<Recibo, ReciboVm>().PreserveReferences().ReverseMap();
                x.CreateMap<ReciboEmprestimo, ReciboEmprestimoVm>().PreserveReferences().ReverseMap();
                x.CreateMap<Corretor, CorretorVm>().PreserveReferences().ReverseMap();
            }).CreateMapper();
        }
    }
}